using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using EasyMirror.Properties;

namespace EasyMirror {
	public partial class MainWindow {
		private void MirrorStart(object sender, DoWorkEventArgs e) {
			// http://stackoverflow.com/questions/5668921/getting-localized-strings-from-language-resource-files-in-a-backgroundworker-thr
			Thread.CurrentThread.CurrentCulture = Application.CurrentCulture;
			Thread.CurrentThread.CurrentUICulture = Application.CurrentCulture;

			statusBarLabel.Text = Resources.STATUS_MIRRORING;
			int executedOperations = 0;

			foreach(var operation in operations) {
				if(mirrorer.CancellationPending)
					return;

				mirrorer.ReportProgress((int)((double)executedOperations / operations.Count * 100), operation);

				try {
					operation.Execute();
				}
				catch(Exception) {
					operations.BadOperations.Add(operation);
				}

				executedOperations++;
			}
		}

		private void MirrorProgress(object sender, ProgressChangedEventArgs e) {
			progressBar.Value = e.ProgressPercentage;
			var currentOperation = (IOperation) e.UserState;

			if(currentOperation is CopyOperation)
				statusBarLabel.Text = Resources.STATUS_COPYING + ((CopyOperation)currentOperation).MasterFile.FullName;
			else if(currentOperation is DeleteOperation)
				statusBarLabel.Text = Resources.STATUS_DELETING + ((DeleteOperation)currentOperation).MirrorFile.FullName;
			else if(currentOperation is DeleteDirectoryOperation)
				statusBarLabel.Text = Resources.STATUS_DELETING + ((DeleteDirectoryOperation)currentOperation).MirrorDir.FullName;
			else if(currentOperation is OverwriteOperation)
				statusBarLabel.Text = Resources.STATUS_UPDATING + ((OverwriteOperation)currentOperation).MirrorFile.FullName;
			else if(currentOperation is NewDirectoryOperation)
				statusBarLabel.Text = Resources.STATUS_CREATING + ((NewDirectoryOperation)currentOperation).MirrorDir.FullName;
		}

		private void MirrorCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if(operations.BadOperations.Count > 0) {
				var badOpsDialog = new WarningDialog(operations.BadOperations);
				badOpsDialog.ShowDialog(this);
				badOpsDialog.Dispose();
			}

			if(workerCancelled)
				MessageBox.Show(this, workerCancelReason, Resources.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			else
				MessageBox.Show(this, Resources.MIRROR_COMPLETED, Resources.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);

			ToggleButtons();
			workerCancelled = false;
			mirrorButton.Text = Resources.MIRROR;
			mirrorButton.Image = Resources.ICON_MIRROR;
			mirrorButton.Enabled = false;
			progressBar.Value = 0; //reset progress bar
			masterDirBrowseButton.Enabled = true;
			mirrorDirBrowseButton.Enabled = true;
			operationsTreeView.Nodes.Clear();
			statusBarLabel.Text = Resources.STATUS_READY;
		}
	}
}
