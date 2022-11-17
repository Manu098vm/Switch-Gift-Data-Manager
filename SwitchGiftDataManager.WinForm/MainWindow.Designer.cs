namespace SwitchGiftDataManager.WinForm
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.BtnLGPE = new System.Windows.Forms.Button();
            this.BtnSWSH = new System.Windows.Forms.Button();
            this.BtnBDSP = new System.Windows.Forms.Button();
            this.BtnSCVI = new System.Windows.Forms.Button();
            this.BtnPLA = new System.Windows.Forms.Button();
            this.ListBoxWC = new System.Windows.Forms.ListBox();
            this.BtnOpen = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.GrpBCAT = new System.Windows.Forms.GroupBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.GrpContent = new System.Windows.Forms.GroupBox();
            this.LblInfo7 = new System.Windows.Forms.Label();
            this.LblInfo6 = new System.Windows.Forms.Label();
            this.LblInfo5 = new System.Windows.Forms.Label();
            this.LblInfo4 = new System.Windows.Forms.Label();
            this.LblInfo3 = new System.Windows.Forms.Label();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.TxtWCID = new System.Windows.Forms.TextBox();
            this.LblWCID = new System.Windows.Forms.Label();
            this.ContextMenuStripWC = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BtnRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialogWC = new System.Windows.Forms.OpenFileDialog();
            this.ToolTipWcid = new System.Windows.Forms.ToolTip(this.components);
            this.GrpBCAT.SuspendLayout();
            this.GrpContent.SuspendLayout();
            this.ContextMenuStripWC.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnLGPE
            // 
            this.BtnLGPE.AccessibleDescription = "";
            this.BtnLGPE.AccessibleName = "";
            this.BtnLGPE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLGPE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLGPE.Location = new System.Drawing.Point(5, 12);
            this.BtnLGPE.Name = "BtnLGPE";
            this.BtnLGPE.Size = new System.Drawing.Size(136, 60);
            this.BtnLGPE.TabIndex = 0;
            this.BtnLGPE.TabStop = false;
            this.BtnLGPE.Text = "LGPE";
            this.BtnLGPE.UseVisualStyleBackColor = true;
            this.BtnLGPE.Click += new System.EventHandler(this.BtnLGPE_Click);
            // 
            // BtnSWSH
            // 
            this.BtnSWSH.AccessibleDescription = "";
            this.BtnSWSH.AccessibleName = "";
            this.BtnSWSH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSWSH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSWSH.Location = new System.Drawing.Point(147, 12);
            this.BtnSWSH.Name = "BtnSWSH";
            this.BtnSWSH.Size = new System.Drawing.Size(136, 60);
            this.BtnSWSH.TabIndex = 1;
            this.BtnSWSH.TabStop = false;
            this.BtnSWSH.Text = "SWSH";
            this.BtnSWSH.UseVisualStyleBackColor = true;
            this.BtnSWSH.Click += new System.EventHandler(this.BtnSWSH_Click);
            // 
            // BtnBDSP
            // 
            this.BtnBDSP.AccessibleDescription = "";
            this.BtnBDSP.AccessibleName = "";
            this.BtnBDSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBDSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBDSP.Location = new System.Drawing.Point(289, 12);
            this.BtnBDSP.Name = "BtnBDSP";
            this.BtnBDSP.Size = new System.Drawing.Size(136, 60);
            this.BtnBDSP.TabIndex = 2;
            this.BtnBDSP.TabStop = false;
            this.BtnBDSP.Text = "BDSP";
            this.BtnBDSP.UseVisualStyleBackColor = true;
            this.BtnBDSP.Click += new System.EventHandler(this.BtnBDSP_Click);
            // 
            // BtnSCVI
            // 
            this.BtnSCVI.AccessibleDescription = "";
            this.BtnSCVI.AccessibleName = "";
            this.BtnSCVI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSCVI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSCVI.Location = new System.Drawing.Point(573, 12);
            this.BtnSCVI.Name = "BtnSCVI";
            this.BtnSCVI.Size = new System.Drawing.Size(136, 60);
            this.BtnSCVI.TabIndex = 3;
            this.BtnSCVI.TabStop = false;
            this.BtnSCVI.Text = "SCVI";
            this.BtnSCVI.UseVisualStyleBackColor = true;
            this.BtnSCVI.Click += new System.EventHandler(this.BtnSCVI_Click);
            // 
            // BtnPLA
            // 
            this.BtnPLA.AccessibleDescription = "";
            this.BtnPLA.AccessibleName = "";
            this.BtnPLA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPLA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPLA.Location = new System.Drawing.Point(431, 12);
            this.BtnPLA.Name = "BtnPLA";
            this.BtnPLA.Size = new System.Drawing.Size(136, 60);
            this.BtnPLA.TabIndex = 4;
            this.BtnPLA.TabStop = false;
            this.BtnPLA.Text = "PLA";
            this.BtnPLA.UseVisualStyleBackColor = true;
            this.BtnPLA.Click += new System.EventHandler(this.BtnPLA_Click);
            // 
            // ListBoxWC
            // 
            this.ListBoxWC.AllowDrop = true;
            this.ListBoxWC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListBoxWC.FormattingEnabled = true;
            this.ListBoxWC.ItemHeight = 20;
            this.ListBoxWC.Location = new System.Drawing.Point(7, 96);
            this.ListBoxWC.Name = "ListBoxWC";
            this.ListBoxWC.Size = new System.Drawing.Size(214, 304);
            this.ListBoxWC.TabIndex = 5;
            this.ToolTipWcid.SetToolTip(this.ListBoxWC, "                        Wondercards with duplicated WC ID will not be seen by the" +
        " game.                        ");
            this.ListBoxWC.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxWC_DrawItem);
            this.ListBoxWC.SelectedIndexChanged += new System.EventHandler(this.ListBoxWC_SelectedIndexChanged);
            this.ListBoxWC.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDragDrop);
            this.ListBoxWC.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDragEnter);
            this.ListBoxWC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListBoxWC_MouseUp);
            // 
            // BtnOpen
            // 
            this.BtnOpen.Location = new System.Drawing.Point(7, 26);
            this.BtnOpen.Name = "BtnOpen";
            this.BtnOpen.Size = new System.Drawing.Size(214, 29);
            this.BtnOpen.TabIndex = 6;
            this.BtnOpen.Text = "Open Wondercard Files...";
            this.BtnOpen.UseVisualStyleBackColor = true;
            this.BtnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Enabled = false;
            this.BtnSave.Location = new System.Drawing.Point(6, 61);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(214, 29);
            this.BtnSave.TabIndex = 7;
            this.BtnSave.Text = "Save as BCAT Package...";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // GrpBCAT
            // 
            this.GrpBCAT.Controls.Add(this.BtnApply);
            this.GrpBCAT.Controls.Add(this.GrpContent);
            this.GrpBCAT.Controls.Add(this.TxtWCID);
            this.GrpBCAT.Controls.Add(this.LblWCID);
            this.GrpBCAT.Controls.Add(this.ListBoxWC);
            this.GrpBCAT.Controls.Add(this.BtnSave);
            this.GrpBCAT.Controls.Add(this.BtnOpen);
            this.GrpBCAT.Enabled = false;
            this.GrpBCAT.Location = new System.Drawing.Point(5, 78);
            this.GrpBCAT.Name = "GrpBCAT";
            this.GrpBCAT.Size = new System.Drawing.Size(704, 409);
            this.GrpBCAT.TabIndex = 8;
            this.GrpBCAT.TabStop = false;
            this.GrpBCAT.Text = "BCAT Manager";
            // 
            // BtnApply
            // 
            this.BtnApply.Enabled = false;
            this.BtnApply.Location = new System.Drawing.Point(426, 368);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(97, 32);
            this.BtnApply.TabIndex = 11;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // GrpContent
            // 
            this.GrpContent.Controls.Add(this.LblInfo7);
            this.GrpContent.Controls.Add(this.LblInfo6);
            this.GrpContent.Controls.Add(this.LblInfo5);
            this.GrpContent.Controls.Add(this.LblInfo4);
            this.GrpContent.Controls.Add(this.LblInfo3);
            this.GrpContent.Controls.Add(this.LblInfo2);
            this.GrpContent.Controls.Add(this.LblInfo1);
            this.GrpContent.Enabled = false;
            this.GrpContent.Location = new System.Drawing.Point(294, 99);
            this.GrpContent.Name = "GrpContent";
            this.GrpContent.Size = new System.Drawing.Size(358, 263);
            this.GrpContent.TabIndex = 10;
            this.GrpContent.TabStop = false;
            this.GrpContent.Text = "Gift Content";
            // 
            // LblInfo7
            // 
            this.LblInfo7.AutoSize = true;
            this.LblInfo7.Location = new System.Drawing.Point(158, 230);
            this.LblInfo7.Name = "LblInfo7";
            this.LblInfo7.Size = new System.Drawing.Size(49, 20);
            this.LblInfo7.TabIndex = 6;
            this.LblInfo7.Text = "Info_7";
            this.LblInfo7.Visible = false;
            this.LblInfo7.SizeChanged += new System.EventHandler(this.LblInfo_SizeChanged);
            // 
            // LblInfo6
            // 
            this.LblInfo6.AutoSize = true;
            this.LblInfo6.Location = new System.Drawing.Point(158, 198);
            this.LblInfo6.Name = "LblInfo6";
            this.LblInfo6.Size = new System.Drawing.Size(49, 20);
            this.LblInfo6.TabIndex = 5;
            this.LblInfo6.Text = "Info_6";
            this.LblInfo6.Visible = false;
            this.LblInfo6.SizeChanged += new System.EventHandler(this.LblInfo_SizeChanged);
            // 
            // LblInfo5
            // 
            this.LblInfo5.AutoSize = true;
            this.LblInfo5.Location = new System.Drawing.Point(158, 165);
            this.LblInfo5.Name = "LblInfo5";
            this.LblInfo5.Size = new System.Drawing.Size(49, 20);
            this.LblInfo5.TabIndex = 4;
            this.LblInfo5.Text = "Info_5";
            this.LblInfo5.Visible = false;
            this.LblInfo5.SizeChanged += new System.EventHandler(this.LblInfo_SizeChanged);
            // 
            // LblInfo4
            // 
            this.LblInfo4.AutoSize = true;
            this.LblInfo4.Location = new System.Drawing.Point(158, 132);
            this.LblInfo4.Name = "LblInfo4";
            this.LblInfo4.Size = new System.Drawing.Size(49, 20);
            this.LblInfo4.TabIndex = 3;
            this.LblInfo4.Text = "Info_4";
            this.LblInfo4.Visible = false;
            this.LblInfo4.SizeChanged += new System.EventHandler(this.LblInfo_SizeChanged);
            // 
            // LblInfo3
            // 
            this.LblInfo3.AutoSize = true;
            this.LblInfo3.Location = new System.Drawing.Point(158, 99);
            this.LblInfo3.Name = "LblInfo3";
            this.LblInfo3.Size = new System.Drawing.Size(49, 20);
            this.LblInfo3.TabIndex = 2;
            this.LblInfo3.Text = "Info_3";
            this.LblInfo3.Visible = false;
            this.LblInfo3.SizeChanged += new System.EventHandler(this.LblInfo_SizeChanged);
            // 
            // LblInfo2
            // 
            this.LblInfo2.AutoSize = true;
            this.LblInfo2.Location = new System.Drawing.Point(158, 66);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(49, 20);
            this.LblInfo2.TabIndex = 1;
            this.LblInfo2.Text = "Info_2";
            this.LblInfo2.Visible = false;
            this.LblInfo2.SizeChanged += new System.EventHandler(this.LblInfo_SizeChanged);
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Location = new System.Drawing.Point(158, 33);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(49, 20);
            this.LblInfo1.TabIndex = 0;
            this.LblInfo1.Text = "Info_1";
            this.LblInfo1.Visible = false;
            this.LblInfo1.SizeChanged += new System.EventHandler(this.LblInfo_SizeChanged);
            // 
            // TxtWCID
            // 
            this.TxtWCID.Enabled = false;
            this.TxtWCID.Location = new System.Drawing.Point(435, 63);
            this.TxtWCID.MaxLength = 4;
            this.TxtWCID.Name = "TxtWCID";
            this.TxtWCID.Size = new System.Drawing.Size(115, 27);
            this.TxtWCID.TabIndex = 9;
            this.TxtWCID.TextChanged += new System.EventHandler(this.TxtWCID_TextChanged);
            this.TxtWCID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtWCID_KeyPress);
            // 
            // LblWCID
            // 
            this.LblWCID.AutoSize = true;
            this.LblWCID.Enabled = false;
            this.LblWCID.Location = new System.Drawing.Point(375, 66);
            this.LblWCID.Name = "LblWCID";
            this.LblWCID.Size = new System.Drawing.Size(54, 20);
            this.LblWCID.TabIndex = 8;
            this.LblWCID.Text = "WC ID:";
            // 
            // ContextMenuStripWC
            // 
            this.ContextMenuStripWC.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStripWC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnRemove,
            this.BtnRemoveAll});
            this.ContextMenuStripWC.Name = "ConextMenuStripWC";
            this.ContextMenuStripWC.Size = new System.Drawing.Size(155, 52);
            this.ContextMenuStripWC.Text = "Remove";
            // 
            // BtnRemove
            // 
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(154, 24);
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnRemoveAll
            // 
            this.BtnRemoveAll.Name = "BtnRemoveAll";
            this.BtnRemoveAll.Size = new System.Drawing.Size(154, 24);
            this.BtnRemoveAll.Text = "Remove All";
            this.BtnRemoveAll.Click += new System.EventHandler(this.BtnRemoveAll_Click);
            // 
            // OpenFileDialogWC
            // 
            this.OpenFileDialogWC.Multiselect = true;
            // 
            // ToolTipWcid
            // 
            this.ToolTipWcid.AutoPopDelay = 100000;
            this.ToolTipWcid.InitialDelay = 500;
            this.ToolTipWcid.OwnerDraw = true;
            this.ToolTipWcid.ReshowDelay = 100;
            this.ToolTipWcid.UseAnimation = false;
            this.ToolTipWcid.UseFading = false;
            this.ToolTipWcid.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTipWcid_Draw);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 495);
            this.Controls.Add(this.GrpBCAT);
            this.Controls.Add(this.BtnPLA);
            this.Controls.Add(this.BtnSCVI);
            this.Controls.Add(this.BtnBDSP);
            this.Controls.Add(this.BtnSWSH);
            this.Controls.Add(this.BtnLGPE);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Switch Gift Data Manager v1.0.0";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileDragEnter);
            this.GrpBCAT.ResumeLayout(false);
            this.GrpBCAT.PerformLayout();
            this.GrpContent.ResumeLayout(false);
            this.GrpContent.PerformLayout();
            this.ContextMenuStripWC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnLGPE;
        private Button BtnSWSH;
        private Button BtnBDSP;
        private Button BtnSCVI;
        private Button BtnPLA;
        private ListBox ListBoxWC;
        private Button BtnOpen;
        private Button BtnSave;
        private GroupBox GrpBCAT;
        private Button BtnApply;
        private GroupBox GrpContent;
        private TextBox TxtWCID;
        private Label LblWCID;
        private ContextMenuStrip ContextMenuStripWC;
        private ToolStripMenuItem BtnRemove;
        private Label LblInfo5;
        private Label LblInfo4;
        private Label LblInfo3;
        private Label LblInfo2;
        private Label LblInfo1;
        private OpenFileDialog OpenFileDialogWC;
        private ToolStripMenuItem BtnRemoveAll;
        private ToolTip ToolTipWcid;
        private Label LblInfo7;
        private Label LblInfo6;
    }
}