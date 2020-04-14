

namespace EventParser.GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browseCSV = new System.Windows.Forms.OpenFileDialog();
            this.mnuAboutHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.labelOpenLogFile = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnOpenLogFile = new System.Windows.Forms.Button();
            this.groupBoxFilepaths = new System.Windows.Forms.GroupBox();
            this.txtOpenLogFile = new System.Windows.Forms.TextBox();
            this.btnSetConnectionString = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.groupBoxConnString = new System.Windows.Forms.GroupBox();
            this.txtSaveLogFile = new System.Windows.Forms.TextBox();
            this.labelSaveLogFile = new System.Windows.Forms.Label();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.processedRecords = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveLogFile = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBoxFilepaths.SuspendLayout();
            this.groupBoxConnString.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseCSV
            // 
            this.browseCSV.FileName = "browseCSV";
            this.browseCSV.Title = "Browse";
            // 
            // mnuAboutHelp
            // 
            this.mnuAboutHelp.Name = "mnuAboutHelp";
            this.mnuAboutHelp.Size = new System.Drawing.Size(118, 29);
            this.mnuAboutHelp.Text = "&About/Help";
            this.mnuAboutHelp.Click += new System.EventHandler(this.mnuFile_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAboutHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(861, 35);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // labelOpenLogFile
            // 
            this.labelOpenLogFile.AutoSize = true;
            this.labelOpenLogFile.Location = new System.Drawing.Point(9, 25);
            this.labelOpenLogFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOpenLogFile.Name = "labelOpenLogFile";
            this.labelOpenLogFile.Size = new System.Drawing.Size(64, 20);
            this.labelOpenLogFile.TabIndex = 14;
            this.labelOpenLogFile.Text = "Log file:";
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(696, 612);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(122, 35);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnOpenLogFile
            // 
            this.btnOpenLogFile.Location = new System.Drawing.Point(670, 45);
            this.btnOpenLogFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenLogFile.Name = "btnOpenLogFile";
            this.btnOpenLogFile.Size = new System.Drawing.Size(112, 35);
            this.btnOpenLogFile.TabIndex = 1;
            this.btnOpenLogFile.Text = "Browse...";
            this.btnOpenLogFile.UseVisualStyleBackColor = true;
            this.btnOpenLogFile.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBoxFilepaths
            // 
            this.groupBoxFilepaths.Controls.Add(this.btnOpenLogFile);
            this.groupBoxFilepaths.Controls.Add(this.txtOpenLogFile);
            this.groupBoxFilepaths.Controls.Add(this.labelOpenLogFile);
            this.groupBoxFilepaths.Location = new System.Drawing.Point(36, 149);
            this.groupBoxFilepaths.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxFilepaths.Name = "groupBoxFilepaths";
            this.groupBoxFilepaths.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxFilepaths.Size = new System.Drawing.Size(792, 220);
            this.groupBoxFilepaths.TabIndex = 1;
            this.groupBoxFilepaths.TabStop = false;
            // 
            // txtOpenLogFile
            // 
            this.txtOpenLogFile.Location = new System.Drawing.Point(9, 49);
            this.txtOpenLogFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOpenLogFile.Name = "txtOpenLogFile";
            this.txtOpenLogFile.ReadOnly = true;
            this.txtOpenLogFile.Size = new System.Drawing.Size(650, 26);
            this.txtOpenLogFile.TabIndex = 2;
            this.txtOpenLogFile.TabStop = false;
            // 
            // btnSetConnectionString
            // 
            this.btnSetConnectionString.Location = new System.Drawing.Point(670, 25);
            this.btnSetConnectionString.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSetConnectionString.Name = "btnSetConnectionString";
            this.btnSetConnectionString.Size = new System.Drawing.Size(112, 35);
            this.btnSetConnectionString.TabIndex = 2;
            this.btnSetConnectionString.Text = "Options";
            this.btnSetConnectionString.UseVisualStyleBackColor = true;
            this.btnSetConnectionString.Click += new System.EventHandler(this.btnSetConnectionString_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.AcceptsTab = true;
            this.txtConnectionString.Location = new System.Drawing.Point(9, 29);
            this.txtConnectionString.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(650, 26);
            this.txtConnectionString.TabIndex = 1;
            this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
            // 
            // groupBoxConnString
            // 
            this.groupBoxConnString.Controls.Add(this.btnSetConnectionString);
            this.groupBoxConnString.Controls.Add(this.txtConnectionString);
            this.groupBoxConnString.Location = new System.Drawing.Point(36, 57);
            this.groupBoxConnString.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxConnString.Name = "groupBoxConnString";
            this.groupBoxConnString.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxConnString.Size = new System.Drawing.Size(792, 83);
            this.groupBoxConnString.TabIndex = 0;
            this.groupBoxConnString.TabStop = false;
            this.groupBoxConnString.Text = "SQL Server connection string:";
            // 
            // txtSaveLogFile
            // 
            this.txtSaveLogFile.Location = new System.Drawing.Point(45, 300);
            this.txtSaveLogFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSaveLogFile.Name = "txtSaveLogFile";
            this.txtSaveLogFile.ReadOnly = true;
            this.txtSaveLogFile.Size = new System.Drawing.Size(650, 26);
            this.txtSaveLogFile.TabIndex = 4;
            this.txtSaveLogFile.TabStop = false;
            // 
            // labelSaveLogFile
            // 
            this.labelSaveLogFile.AutoSize = true;
            this.labelSaveLogFile.Location = new System.Drawing.Point(45, 277);
            this.labelSaveLogFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSaveLogFile.Name = "labelSaveLogFile";
            this.labelSaveLogFile.Size = new System.Drawing.Size(172, 20);
            this.labelSaveLogFile.TabIndex = 17;
            this.labelSaveLogFile.Text = "Parsed log file (output):";
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.label3);
            this.groupBoxOutput.Controls.Add(this.txtOutput);
            this.groupBoxOutput.Location = new System.Drawing.Point(36, 380);
            this.groupBoxOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxOutput.Size = new System.Drawing.Size(792, 223);
            this.groupBoxOutput.TabIndex = 21;
            this.groupBoxOutput.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "Output:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(9, 35);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(774, 169);
            this.txtOutput.TabIndex = 31;
            this.txtOutput.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.processedRecords,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel5,
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(861, 30);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 25);
            // 
            // processedRecords
            // 
            this.processedRecords.Name = "processedRecords";
            this.processedRecords.Size = new System.Drawing.Size(0, 25);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.RightToLeftAutoMirrorImage = true;
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(281, 25);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = "       ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 25);
            this.toolStripStatusLabel2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.RightToLeftAutoMirrorImage = true;
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(281, 25);
            this.toolStripStatusLabel5.Spring = true;
            this.toolStripStatusLabel5.Text = "       ";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.RightToLeftAutoMirrorImage = true;
            this.status.Size = new System.Drawing.Size(281, 25);
            this.status.Spring = true;
            this.status.Text = "       ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(566, 614);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 35);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveLogFile
            // 
            this.btnSaveLogFile.Location = new System.Drawing.Point(705, 297);
            this.btnSaveLogFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveLogFile.Name = "btnSaveLogFile";
            this.btnSaveLogFile.Size = new System.Drawing.Size(112, 35);
            this.btnSaveLogFile.TabIndex = 2;
            this.btnSaveLogFile.Text = "Browse...";
            this.btnSaveLogFile.UseVisualStyleBackColor = true;
            this.btnSaveLogFile.Click += new System.EventHandler(this.btnLogOutput_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(36, 612);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(122, 35);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 688);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.btnSaveLogFile);
            this.Controls.Add(this.txtSaveLogFile);
            this.Controls.Add(this.labelSaveLogFile);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBoxFilepaths);
            this.Controls.Add(this.groupBoxConnString);
            this.Name = "frmMain";
            this.Text = "EventParser";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxFilepaths.ResumeLayout(false);
            this.groupBoxFilepaths.PerformLayout();
            this.groupBoxConnString.ResumeLayout(false);
            this.groupBoxConnString.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxOutput.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog browseCSV;
        private System.Windows.Forms.ToolStripMenuItem mnuAboutHelp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label labelOpenLogFile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnOpenLogFile;
        private System.Windows.Forms.GroupBox groupBoxFilepaths;
        private System.Windows.Forms.TextBox txtOpenLogFile;
        private System.Windows.Forms.Button btnSetConnectionString;
        public System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.GroupBox groupBoxConnString;
        private System.Windows.Forms.TextBox txtSaveLogFile;
        private System.Windows.Forms.Label labelSaveLogFile;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel processedRecords;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveLogFile;
        private System.Windows.Forms.Button btnReset;
    }
}

