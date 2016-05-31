namespace EasyMirror {
	partial class MainWindow {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.masterDirLabel = new System.Windows.Forms.Label();
			this.mirrorDirLabel = new System.Windows.Forms.Label();
			this.masterDirTextbox = new System.Windows.Forms.TextBox();
			this.mirrorDirTextbox = new System.Windows.Forms.TextBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.progressLabel = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.mirrorDirBrowseButton = new System.Windows.Forms.Button();
			this.masterDirBrowseButton = new System.Windows.Forms.Button();
			this.mirrorButton = new System.Windows.Forms.Button();
			this.compareButton = new System.Windows.Forms.Button();
			this.operationsTreeView = new System.Windows.Forms.TreeView();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.statusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.statusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// masterDirLabel
			// 
			this.masterDirLabel.AutoSize = true;
			this.masterDirLabel.Location = new System.Drawing.Point(13, 13);
			this.masterDirLabel.Name = "masterDirLabel";
			this.masterDirLabel.Size = new System.Drawing.Size(85, 13);
			this.masterDirLabel.TabIndex = 7;
			this.masterDirLabel.Text = "Master directory:";
			// 
			// mirrorDirLabel
			// 
			this.mirrorDirLabel.AutoSize = true;
			this.mirrorDirLabel.Location = new System.Drawing.Point(13, 78);
			this.mirrorDirLabel.Name = "mirrorDirLabel";
			this.mirrorDirLabel.Size = new System.Drawing.Size(106, 13);
			this.mirrorDirLabel.TabIndex = 3;
			this.mirrorDirLabel.Text = "Destination directory:";
			// 
			// masterDirTextbox
			// 
			this.masterDirTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.masterDirTextbox.Enabled = false;
			this.masterDirTextbox.Location = new System.Drawing.Point(125, 10);
			this.masterDirTextbox.Name = "masterDirTextbox";
			this.masterDirTextbox.Size = new System.Drawing.Size(343, 20);
			this.masterDirTextbox.TabIndex = 0;
			// 
			// mirrorDirTextbox
			// 
			this.mirrorDirTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mirrorDirTextbox.Enabled = false;
			this.mirrorDirTextbox.Location = new System.Drawing.Point(125, 75);
			this.mirrorDirTextbox.Name = "mirrorDirTextbox";
			this.mirrorDirTextbox.Size = new System.Drawing.Size(343, 20);
			this.mirrorDirTextbox.TabIndex = 1;
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(70, 393);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(502, 23);
			this.progressBar.TabIndex = 5;
			// 
			// progressLabel
			// 
			this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.progressLabel.AutoSize = true;
			this.progressLabel.Location = new System.Drawing.Point(13, 398);
			this.progressLabel.Name = "progressLabel";
			this.progressLabel.Size = new System.Drawing.Size(51, 13);
			this.progressLabel.TabIndex = 12;
			this.progressLabel.Text = "Progress:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pictureBox1.Image = global::EasyMirror.Properties.Resources.easymirrorlogo;
			this.pictureBox1.Location = new System.Drawing.Point(272, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(42, 40);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.PictureBox1Click);
			// 
			// mirrorDirBrowseButton
			// 
			this.mirrorDirBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.mirrorDirBrowseButton.Image = global::EasyMirror.Properties.Resources.ICON_BROWSE;
			this.mirrorDirBrowseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mirrorDirBrowseButton.Location = new System.Drawing.Point(474, 67);
			this.mirrorDirBrowseButton.Name = "mirrorDirBrowseButton";
			this.mirrorDirBrowseButton.Size = new System.Drawing.Size(97, 34);
			this.mirrorDirBrowseButton.TabIndex = 3;
			this.mirrorDirBrowseButton.Text = "Browse";
			this.mirrorDirBrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.mirrorDirBrowseButton.UseVisualStyleBackColor = true;
			this.mirrorDirBrowseButton.Click += new System.EventHandler(this.MirrorDirBrowseButtonClick);
			// 
			// masterDirBrowseButton
			// 
			this.masterDirBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.masterDirBrowseButton.Image = global::EasyMirror.Properties.Resources.ICON_BROWSE;
			this.masterDirBrowseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.masterDirBrowseButton.Location = new System.Drawing.Point(474, 2);
			this.masterDirBrowseButton.Name = "masterDirBrowseButton";
			this.masterDirBrowseButton.Size = new System.Drawing.Size(97, 34);
			this.masterDirBrowseButton.TabIndex = 2;
			this.masterDirBrowseButton.Text = "Browse";
			this.masterDirBrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.masterDirBrowseButton.UseVisualStyleBackColor = true;
			this.masterDirBrowseButton.Click += new System.EventHandler(this.MasterDirBrowseButtonClick);
			// 
			// mirrorButton
			// 
			this.mirrorButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.mirrorButton.Enabled = false;
			this.mirrorButton.Image = global::EasyMirror.Properties.Resources.ICON_MIRROR;
			this.mirrorButton.Location = new System.Drawing.Point(308, 422);
			this.mirrorButton.Name = "mirrorButton";
			this.mirrorButton.Size = new System.Drawing.Size(118, 45);
			this.mirrorButton.TabIndex = 6;
			this.mirrorButton.Text = "Mirror";
			this.mirrorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.mirrorButton.UseVisualStyleBackColor = true;
			this.mirrorButton.Click += new System.EventHandler(this.MirrorButtonClick);
			// 
			// compareButton
			// 
			this.compareButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.compareButton.Enabled = false;
			this.compareButton.Image = global::EasyMirror.Properties.Resources.ICON_COMPARE;
			this.compareButton.Location = new System.Drawing.Point(162, 422);
			this.compareButton.Name = "compareButton";
			this.compareButton.Size = new System.Drawing.Size(118, 45);
			this.compareButton.TabIndex = 5;
			this.compareButton.Text = "Compare";
			this.compareButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.compareButton.UseVisualStyleBackColor = true;
			this.compareButton.Click += new System.EventHandler(this.CompareButtonClick);
			// 
			// operationsTreeView
			// 
			this.operationsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.operationsTreeView.Location = new System.Drawing.Point(13, 104);
			this.operationsTreeView.Name = "operationsTreeView";
			this.operationsTreeView.Size = new System.Drawing.Size(559, 279);
			this.operationsTreeView.TabIndex = 4;
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarLabel});
			this.statusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.statusBar.Location = new System.Drawing.Point(0, 478);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(584, 20);
			this.statusBar.TabIndex = 13;
			this.statusBar.Text = "statusStrip1";
			// 
			// statusBarLabel
			// 
			this.statusBarLabel.Name = "statusBarLabel";
			this.statusBarLabel.Size = new System.Drawing.Size(42, 15);
			this.statusBarLabel.Text = "Ready.";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 498);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.operationsTreeView);
			this.Controls.Add(this.progressLabel);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.mirrorDirBrowseButton);
			this.Controls.Add(this.masterDirBrowseButton);
			this.Controls.Add(this.mirrorDirTextbox);
			this.Controls.Add(this.masterDirTextbox);
			this.Controls.Add(this.mirrorDirLabel);
			this.Controls.Add(this.masterDirLabel);
			this.Controls.Add(this.mirrorButton);
			this.Controls.Add(this.compareButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(500, 400);
			this.Name = "MainWindow";
			this.Text = "EasyMirror v0.1.1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button compareButton;
		private System.Windows.Forms.Button mirrorButton;
		private System.Windows.Forms.Label masterDirLabel;
		private System.Windows.Forms.Label mirrorDirLabel;
		private System.Windows.Forms.TextBox masterDirTextbox;
		private System.Windows.Forms.TextBox mirrorDirTextbox;
		private System.Windows.Forms.Button masterDirBrowseButton;
		private System.Windows.Forms.Button mirrorDirBrowseButton;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.TreeView operationsTreeView;
        private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripStatusLabel statusBarLabel;

	}
}