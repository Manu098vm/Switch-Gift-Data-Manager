namespace SwitchGiftDataManager.WinForm;

partial class SaveWindow
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveWindow));
        this.GrpBuild = new System.Windows.Forms.GroupBox();
        this.RadioUnique = new System.Windows.Forms.RadioButton();
        this.RadioMultiple = new System.Windows.Forms.RadioButton();
        this.TxtDestPath = new System.Windows.Forms.TextBox();
        this.BtnPath = new System.Windows.Forms.Button();
        this.GrpDest = new System.Windows.Forms.GroupBox();
        this.BtnCancel = new System.Windows.Forms.Button();
        this.BtnSave = new System.Windows.Forms.Button();
        this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.BtnSrcBrowse = new System.Windows.Forms.Button();
        this.TxtSourcePath = new System.Windows.Forms.TextBox();
        this.GrpBuild.SuspendLayout();
        this.GrpDest.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.SuspendLayout();
        // 
        // GrpBuild
        // 
        this.GrpBuild.Controls.Add(this.RadioUnique);
        this.GrpBuild.Controls.Add(this.RadioMultiple);
        this.GrpBuild.Location = new System.Drawing.Point(12, 12);
        this.GrpBuild.Name = "GrpBuild";
        this.GrpBuild.Size = new System.Drawing.Size(458, 58);
        this.GrpBuild.TabIndex = 0;
        this.GrpBuild.TabStop = false;
        this.GrpBuild.Text = "Build Method";
        // 
        // RadioUnique
        // 
        this.RadioUnique.AutoSize = true;
        this.RadioUnique.Location = new System.Drawing.Point(238, 26);
        this.RadioUnique.Name = "RadioUnique";
        this.RadioUnique.Size = new System.Drawing.Size(156, 24);
        this.RadioUnique.TabIndex = 1;
        this.RadioUnique.Text = "Keep separate files";
        this.RadioUnique.UseVisualStyleBackColor = true;
        // 
        // RadioMultiple
        // 
        this.RadioMultiple.AutoSize = true;
        this.RadioMultiple.Checked = true;
        this.RadioMultiple.Location = new System.Drawing.Point(76, 26);
        this.RadioMultiple.Name = "RadioMultiple";
        this.RadioMultiple.Size = new System.Drawing.Size(145, 24);
        this.RadioMultiple.TabIndex = 0;
        this.RadioMultiple.TabStop = true;
        this.RadioMultiple.Text = "Merge as one file";
        this.RadioMultiple.UseVisualStyleBackColor = true;
        // 
        // TxtDestPath
        // 
        this.TxtDestPath.Location = new System.Drawing.Point(6, 26);
        this.TxtDestPath.Name = "TxtDestPath";
        this.TxtDestPath.Size = new System.Drawing.Size(358, 27);
        this.TxtDestPath.TabIndex = 1;
        // 
        // BtnPath
        // 
        this.BtnPath.Location = new System.Drawing.Point(370, 26);
        this.BtnPath.Name = "BtnPath";
        this.BtnPath.Size = new System.Drawing.Size(82, 29);
        this.BtnPath.TabIndex = 2;
        this.BtnPath.Text = "Browse";
        this.BtnPath.UseVisualStyleBackColor = true;
        this.BtnPath.Click += new System.EventHandler(this.BtnPath_Click);
        // 
        // GrpDest
        // 
        this.GrpDest.Controls.Add(this.TxtDestPath);
        this.GrpDest.Controls.Add(this.BtnPath);
        this.GrpDest.Location = new System.Drawing.Point(12, 153);
        this.GrpDest.Name = "GrpDest";
        this.GrpDest.Size = new System.Drawing.Size(458, 66);
        this.GrpDest.TabIndex = 3;
        this.GrpDest.TabStop = false;
        this.GrpDest.Text = "Destination BCAT Path";
        // 
        // BtnCancel
        // 
        this.BtnCancel.Location = new System.Drawing.Point(99, 225);
        this.BtnCancel.Name = "BtnCancel";
        this.BtnCancel.Size = new System.Drawing.Size(125, 29);
        this.BtnCancel.TabIndex = 4;
        this.BtnCancel.Text = "Cancel";
        this.BtnCancel.UseVisualStyleBackColor = true;
        this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
        // 
        // BtnSave
        // 
        this.BtnSave.Location = new System.Drawing.Point(250, 225);
        this.BtnSave.Name = "BtnSave";
        this.BtnSave.Size = new System.Drawing.Size(125, 29);
        this.BtnSave.TabIndex = 5;
        this.BtnSave.Text = "Save";
        this.BtnSave.UseVisualStyleBackColor = true;
        this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.BtnSrcBrowse);
        this.groupBox2.Controls.Add(this.TxtSourcePath);
        this.groupBox2.Location = new System.Drawing.Point(12, 76);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(458, 66);
        this.groupBox2.TabIndex = 6;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "Source BCAT Path";
        // 
        // BtnSrcBrowse
        // 
        this.BtnSrcBrowse.Location = new System.Drawing.Point(370, 26);
        this.BtnSrcBrowse.Name = "BtnSrcBrowse";
        this.BtnSrcBrowse.Size = new System.Drawing.Size(82, 27);
        this.BtnSrcBrowse.TabIndex = 1;
        this.BtnSrcBrowse.Text = "Browse";
        this.BtnSrcBrowse.UseVisualStyleBackColor = true;
        this.BtnSrcBrowse.Click += new System.EventHandler(this.BtnSrcBrowse_Click);
        // 
        // TxtSourcePath
        // 
        this.TxtSourcePath.Location = new System.Drawing.Point(6, 26);
        this.TxtSourcePath.Name = "TxtSourcePath";
        this.TxtSourcePath.Size = new System.Drawing.Size(358, 27);
        this.TxtSourcePath.TabIndex = 0;
        // 
        // SaveWindow
        // 
        this.AcceptButton = this.BtnSave;
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.BtnCancel;
        this.ClientSize = new System.Drawing.Size(483, 261);
        this.Controls.Add(this.groupBox2);
        this.Controls.Add(this.BtnSave);
        this.Controls.Add(this.BtnCancel);
        this.Controls.Add(this.GrpDest);
        this.Controls.Add(this.GrpBuild);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "SaveWindow";
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Text = "Save BCAT Package";
        this.GrpBuild.ResumeLayout(false);
        this.GrpBuild.PerformLayout();
        this.GrpDest.ResumeLayout(false);
        this.GrpDest.PerformLayout();
        this.groupBox2.ResumeLayout(false);
        this.groupBox2.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private GroupBox GrpBuild;
    private RadioButton RadioUnique;
    private RadioButton RadioMultiple;
    private TextBox TxtDestPath;
    private Button BtnPath;
    private GroupBox GrpDest;
    private Button BtnCancel;
    private Button BtnSave;
    private FolderBrowserDialog FolderBrowser;
    private GroupBox groupBox2;
    private Button BtnSrcBrowse;
    private TextBox TxtSourcePath;
}