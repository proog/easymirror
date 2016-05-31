using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EasyMirror.Properties;
using System.IO;
using System.Linq;

namespace EasyMirror {
	public partial class MainWindow {
		private Operations operations;

		private void CompareStart(object sender, DoWorkEventArgs e) {
			// http://stackoverflow.com/questions/5668921/getting-localized-strings-from-language-resource-files-in-a-backgroundworker-thr
			Thread.CurrentThread.CurrentCulture = Application.CurrentCulture;
			Thread.CurrentThread.CurrentUICulture = Application.CurrentCulture;

			string masterDir = masterDirTextbox.Text;
			string mirrorDir = mirrorDirTextbox.Text;

			if(IsSubdirectory(masterDir, mirrorDir) || IsSubdirectory(mirrorDir, masterDir)) {
				CancelBackgroundWorker(comparer, Resources.MASTER_MIRROR_CONFLICT);
				return;
			}

			operations = new Operations();
			Compare(masterDir, mirrorDir);
		}

		private void CompareCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if(workerCancelled)
				MessageBox.Show(this, workerCancelReason, Resources.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else {
				operationsTreeView.BeginUpdate();
				operationsTreeView.Nodes.Clear();
				operationsTreeView.Nodes.Add(TreeCategories.CopyOperations,
											 Resources.THERE_ARE + operations.CopyOperations + Resources.FILES_TO_COPY);
				operationsTreeView.Nodes.Add(TreeCategories.NewDirectoryOperations,
											 Resources.THERE_ARE + operations.NewDirOperations + Resources.DIRECTORIES_TO_CREATE);
				operationsTreeView.Nodes.Add(TreeCategories.OverwriteOperations,
											 Resources.THERE_ARE + operations.OverwriteOperations + Resources.FILES_TO_OVERWRITE);
				operationsTreeView.Nodes.Add(TreeCategories.DeleteOperations,
											 Resources.THERE_ARE + operations.DeleteOperations + Resources.FILES_TO_DELETE);
				operationsTreeView.Nodes.Add(TreeCategories.DeleteDirectoryOperations,
											 Resources.THERE_ARE + operations.DeleteDirOperations + Resources.DIRECTORIES_TO_DELETE);

				foreach(var operation in operations) {
					if(operation is CopyOperation)
						operationsTreeView.Nodes[TreeCategories.CopyOperations].Nodes.Add(operation.ToString());
					else if(operation is NewDirectoryOperation)
						operationsTreeView.Nodes[TreeCategories.NewDirectoryOperations].Nodes.Add(operation.ToString());
					else if(operation is OverwriteOperation)
						operationsTreeView.Nodes[TreeCategories.OverwriteOperations].Nodes.Add(operation.ToString());
					else if(operation is DeleteOperation)
						operationsTreeView.Nodes[TreeCategories.DeleteOperations].Nodes.Add(operation.ToString());
					else if(operation is DeleteDirectoryOperation)
						operationsTreeView.Nodes[TreeCategories.DeleteDirectoryOperations].Nodes.Add(operation.ToString());
				}

				operationsTreeView.EndUpdate();

				if(operations.BadPaths.Count > 0) {
					var badPathDialog = new WarningDialog(operations.BadPaths);
					badPathDialog.ShowDialog(this);
					badPathDialog.Dispose();
				}

				if(operations.Count == 0)
					MessageBox.Show(this, Resources.COMPLETE_MATCH, Resources.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			ToggleButtons();
			workerCancelled = false;
			progressBar.Style = ProgressBarStyle.Continuous;
			compareButton.Text = Resources.COMPARE;
			compareButton.Image = Resources.ICON_COMPARE;
			masterDirBrowseButton.Enabled = true;
			mirrorDirBrowseButton.Enabled = true;
			statusBarLabel.Text = Resources.STATUS_READY;
		}

		private void Compare(string masterDir, string mirrorDir) {
			if(comparer.CancellationPending)
				return;

			var masterFiles   = GetFilesSafe(new DirectoryInfo(masterDir));
			var mirrorFiles   = GetFilesSafe(new DirectoryInfo(mirrorDir));
			var masterSubDirs = GetDirectoriesSafe(new DirectoryInfo(masterDir));
			var mirrorSubDirs = GetDirectoriesSafe(new DirectoryInfo(mirrorDir));

			//find non-needed files in mirror dir
			foreach(var mirrorFile in mirrorFiles) {
				bool masterFileFound = masterFiles.Any(masterFile => mirrorFile.Name.Equals(masterFile.Name));

				if(!masterFileFound)
					AddOperation(new DeleteOperation(mirrorFile));
			}

			//compare files
			foreach(var masterFile in masterFiles) {
				bool mirrorFileFound = false;
				foreach(var mirrorFile in mirrorFiles) {
					if(masterFile.Name.Equals(mirrorFile.Name)) {
						//filenames match, but only overwrite if master is different from mirror
						if(masterFile.LastWriteTime > mirrorFile.LastWriteTime)
							AddOperation(new OverwriteOperation(masterFile, mirrorFile));
						else if(masterFile.LastWriteTime == mirrorFile.LastWriteTime && masterFile.Length > mirrorFile.Length)
							AddOperation(new OverwriteOperation(masterFile, mirrorFile));

						mirrorFileFound = true;
						break;
					}
				}

				//if matching mirror file was not found, copy file
				if(!mirrorFileFound)
					AddOperation(new CopyOperation(masterFile, new FileInfo(mirrorDir + Resources.DIRECTORY_SEPARATOR + masterFile.Name)));
			}

			//find non-needed dirs in mirror dir
			foreach(var mirrorSubDir in mirrorSubDirs) {
				bool masterSubDirFound = masterSubDirs.Any(masterSubDir => mirrorSubDir.Name.Equals(masterSubDir.Name));

				if(!masterSubDirFound)
					MarkForDeletion(mirrorSubDir.FullName);
			}

			//compare dirs
			foreach(var masterSubDir in masterSubDirs) {
				bool mirrorSubDirFound = false;
				foreach(var mirrorSubDir in mirrorSubDirs) {
					if(masterSubDir.Name.Equals(mirrorSubDir.Name)) {
						//dirnames match
						Compare(masterSubDir.FullName, mirrorSubDir.FullName);
						mirrorSubDirFound = true;
						break;
					}
				}

				if(!mirrorSubDirFound)
					MarkForCopying(masterSubDir.FullName, mirrorDir + Resources.DIRECTORY_SEPARATOR + masterSubDir.Name);
			}
		}

		private void MarkForCopying(string masterDir, string mirrorDir) {
			var copyDir = new DirectoryInfo(masterDir);
			var destDir = new DirectoryInfo(mirrorDir);

			AddOperation(new NewDirectoryOperation(copyDir, destDir));

			foreach(var subDir in GetDirectoriesSafe(copyDir))
				MarkForCopying(subDir.FullName, mirrorDir + Resources.DIRECTORY_SEPARATOR + subDir.Name);
			foreach(var file in GetFilesSafe(copyDir))
				AddOperation(new CopyOperation(file, new FileInfo(mirrorDir + Resources.DIRECTORY_SEPARATOR + file.Name)));
		}

		private void MarkForDeletion(string dir) {
			var deleteDir = new DirectoryInfo(dir);
			foreach(var subDir in GetDirectoriesSafe(deleteDir))
				MarkForDeletion(subDir.FullName);
			foreach(var file in GetFilesSafe(deleteDir))
				AddOperation(new DeleteOperation(file));

			AddOperation(new DeleteDirectoryOperation(deleteDir));
		}

		private void AddOperation(IOperation operation) {
			operations.Add(operation);
			if(operation is CopyOperation)
				operations.CopyOperations++;
			else if(operation is NewDirectoryOperation)
				operations.NewDirOperations++;
			else if(operation is OverwriteOperation)
				operations.OverwriteOperations++;
			else if(operation is DeleteOperation)
				operations.DeleteOperations++;
			else if(operation is DeleteDirectoryOperation)
				operations.DeleteDirOperations++;
		}

		private FileInfo[] GetFilesSafe(DirectoryInfo path) {
			try {
				return path.GetFiles();
			}
			catch(Exception) {
				operations.BadPaths.Add(path);
				return new FileInfo[0];
			}
		}

		private DirectoryInfo[] GetDirectoriesSafe(DirectoryInfo path) {
			try {
				return path.GetDirectories();
			}
			catch(Exception) {
				operations.BadPaths.Add(path);
				return new DirectoryInfo[0];
			}
		}

		// Is dir1 a subdirectory of dir2?
		private static bool IsSubdirectory(string dir1, string dir2) {
			var child = new DirectoryInfo(dir1);
			var parent = new DirectoryInfo(dir2);

			while(child != null) {
				if(child.FullName.ToLowerInvariant() == parent.FullName.ToLowerInvariant())
					return true;

				child = child.Parent;
			}

			return false;
		}
	}
}
