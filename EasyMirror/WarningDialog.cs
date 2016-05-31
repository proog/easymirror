using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using EasyMirror.Properties;

namespace EasyMirror {
	public partial class WarningDialog : Form {
		public WarningDialog() {
			InitializeComponent();
		}

		public WarningDialog(IEnumerable<DirectoryInfo> paths) {
			InitializeComponent();

			Text = Resources.WARNING;
			explanationLabel.Text = Resources.BAD_PATHS;

			UpdateListBox(paths.Select(x => x.FullName));
		}

		public WarningDialog(IEnumerable<IOperation> paths) {
			InitializeComponent();

			Text = Resources.WARNING;
			explanationLabel.Text = Resources.BAD_OPERATIONS;

			UpdateListBox(paths.Select(x => x.ToString()));
		}

		private void UpdateListBox(IEnumerable<string> paths) {
			badPathsListBox.BeginUpdate();
			
			foreach(var path in paths)
				badPathsListBox.Items.Add(path);

			badPathsListBox.EndUpdate();
		}
	}
}
