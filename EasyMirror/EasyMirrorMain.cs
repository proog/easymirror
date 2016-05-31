using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace EasyMirror {
	static class EasyMirrorMain {
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("da-DK");
			Application.Run(new MainWindow());
		}
	}
}
