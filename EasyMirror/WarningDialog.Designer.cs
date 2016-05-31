namespace EasyMirror {
	partial class WarningDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.badPathsListBox = new System.Windows.Forms.ListBox();
			this.explanationLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// badPathsListBox
			// 
			this.badPathsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.badPathsListBox.FormattingEnabled = true;
			this.badPathsListBox.HorizontalScrollbar = true;
			this.badPathsListBox.IntegralHeight = false;
			this.badPathsListBox.Location = new System.Drawing.Point(12, 44);
			this.badPathsListBox.Name = "badPathsListBox";
			this.badPathsListBox.Size = new System.Drawing.Size(412, 284);
			this.badPathsListBox.TabIndex = 0;
			// 
			// explanationLabel
			// 
			this.explanationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.explanationLabel.Location = new System.Drawing.Point(12, 9);
			this.explanationLabel.Name = "explanationLabel";
			this.explanationLabel.Size = new System.Drawing.Size(412, 32);
			this.explanationLabel.TabIndex = 1;
			this.explanationLabel.Text = "Bad paths:";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(340, 334);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(84, 34);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// BadPathDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(436, 380);
			this.ControlBox = false;
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.explanationLabel);
			this.Controls.Add(this.badPathsListBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BadPathDialog";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Warning";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox badPathsListBox;
		private System.Windows.Forms.Label explanationLabel;
		private System.Windows.Forms.Button okButton;
	}
}