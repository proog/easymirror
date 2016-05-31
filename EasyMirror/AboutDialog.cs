using System;
using System.Windows.Forms;
using EasyMirror.Properties;

namespace EasyMirror {
	public partial class AboutDialog : Form {
		public AboutDialog() {
			InitializeComponent();
			linkLabel1.Links.Add(0, 17, "http://permortensen.com");
			linkLabel2.Links.Add(0, 5, "http://kde-look.org/content/show.php?content=38467");
			Text = Resources.ABOUT_TITLE;
			label1.Text = Resources.ABOUT_TITLE;
			label2.Text = Resources.VERSION_TITLE + Resources.VERSION;
			label3.Text = Resources.BY;
			label4.Text = Resources.ICONS_FROM;
			closeButton.Text = Resources.CLOSE;
		}

		private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
		}

		private void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
		}

		private void CloseButtonClick(object sender, EventArgs e) {
			Visible = false;
			Dispose();
		}
	}
}
