using System;
using System.ComponentModel;
using System.Windows.Forms;
using EasyMirror.Properties;

namespace EasyMirror {
	public partial class MainWindow : Form {
		private BackgroundWorker comparer;
		private BackgroundWorker mirrorer;
		private bool workerCancelled;
		private string workerCancelReason;

		public MainWindow() {
			InitializeComponent();
			masterDirLabel.Text = Resources.MASTER_DIRECTORY;
			mirrorDirLabel.Text = Resources.MIRROR_DIRECTORY;
			progressLabel.Text = Resources.TOTAL_PROGRESS;
			masterDirBrowseButton.Text = Resources.BROWSE;
			mirrorDirBrowseButton.Text = Resources.BROWSE;
			compareButton.Text = Resources.COMPARE;
			mirrorButton.Text = Resources.MIRROR;
			statusBarLabel.Text = Resources.STATUS_READY;
			Text = Resources.APP_NAME + " v" + Resources.VERSION;
		}

		private void MasterDirBrowseButtonClick(object sender, EventArgs e) {
			var folderBrowser = new FolderBrowserDialog();
			folderBrowser.Dispose();
			if(folderBrowser.ShowDialog() == DialogResult.OK)
				masterDirTextbox.Text = folderBrowser.SelectedPath;

			operationsTreeView.Nodes.Clear();
			comparer = null;
			ToggleButtons();
		}

		private void MirrorDirBrowseButtonClick(object sender, EventArgs e) {
			var folderBrowser = new FolderBrowserDialog();
			folderBrowser.Dispose();
			if(folderBrowser.ShowDialog() == DialogResult.OK)
				mirrorDirTextbox.Text = folderBrowser.SelectedPath;

			operationsTreeView.Nodes.Clear();
			comparer = null;
			ToggleButtons();
		}

		private void CompareButtonClick(object sender, EventArgs e) {
			operationsTreeView.Nodes.Clear();

			if(comparer != null && comparer.IsBusy) {
				CancelBackgroundWorker(comparer, Resources.USER_CANCELLED_COMPARE);
				compareButton.Enabled = false;
				return;
			}

			comparer = new BackgroundWorker();
			comparer.DoWork += CompareStart;
			comparer.RunWorkerCompleted += CompareCompleted;
			comparer.RunWorkerAsync();
			progressBar.Style = ProgressBarStyle.Marquee;
			compareButton.Text = Resources.CANCEL;
			compareButton.Image = Resources.ICON_CANCEL;
			mirrorButton.Enabled = false;
			masterDirBrowseButton.Enabled = false;
			mirrorDirBrowseButton.Enabled = false;
            statusBarLabel.Text = Resources.STATUS_COMPARING;
		}

		private void MirrorButtonClick(object sender, EventArgs e) {
			if(mirrorer != null && mirrorer.IsBusy) {
				workerCancelled = true;
				workerCancelReason = Resources.USER_CANCELLED_MIRROR;
				mirrorer.CancelAsync();
				return;
			}

			mirrorer = new BackgroundWorker();
			mirrorer.DoWork += MirrorStart;
			mirrorer.ProgressChanged += MirrorProgress;
			mirrorer.RunWorkerCompleted += MirrorCompleted;
			mirrorer.WorkerReportsProgress = true;
			mirrorer.WorkerSupportsCancellation = true;
			mirrorer.RunWorkerAsync();
			progressBar.Minimum = 0;
			progressBar.Maximum = 100;
			mirrorButton.Text = Resources.CANCEL;
			mirrorButton.Image = Resources.ICON_CANCEL;
			compareButton.Enabled = false;
			masterDirBrowseButton.Enabled = false;
			mirrorDirBrowseButton.Enabled = false;
		}

		private void CancelBackgroundWorker(BackgroundWorker worker, string reason) {
			workerCancelled = true;
			workerCancelReason = reason;
			if(worker.WorkerSupportsCancellation)
				worker.CancelAsync();
		}

		private void ToggleButtons() {
			compareButton.Enabled = masterDirTextbox.Text.Length > 0 && mirrorDirTextbox.Text.Length > 0;
			if(comparer != null && !workerCancelled)
				mirrorButton.Enabled = operations.Count > 0;
			else
				mirrorButton.Enabled = false;
		}

		private void PictureBox1Click(object sender, EventArgs e) {
			var about = new AboutDialog();
			about.ShowDialog();
			about.Dispose();
		}
	}

	class TreeCategories {
		public static readonly string CopyOperations = "CopyOperations";
		public static readonly string NewDirectoryOperations = "NewDirectoryOperations";
		public static readonly string OverwriteOperations = "OverwriteOperations";
		public static readonly string DeleteOperations = "DeleteOperations";
		public static readonly string DeleteDirectoryOperations = "DeleteDirectoryOperations";
	}
}
