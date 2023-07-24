namespace SwitchGiftDataManager.WinForm;

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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
        BtnLGPE = new Button();
        BtnSWSH = new Button();
        BtnBDSP = new Button();
        BtnSCVI = new Button();
        BtnPLA = new Button();
        ListBoxWC = new ListBox();
        BtnOpen = new Button();
        BtnSave = new Button();
        GrpBCAT = new GroupBox();
        ChkRepeatable = new CheckBox();
        BtnApply = new Button();
        GrpContent = new GroupBox();
        LblInfo7 = new Label();
        LblInfo6 = new Label();
        LblInfo5 = new Label();
        LblInfo4 = new Label();
        LblInfo3 = new Label();
        LblInfo2 = new Label();
        LblInfo1 = new Label();
        TxtWCID = new TextBox();
        LblWCID = new Label();
        ContextMenuStripWC = new ContextMenuStrip(components);
        BtnRemove = new ToolStripMenuItem();
        BtnRemoveAll = new ToolStripMenuItem();
        OpenFileDialogWC = new OpenFileDialog();
        ToolTipWcid = new ToolTip(components);
        MenuStrip = new MenuStrip();
        ToolsToolStripMenu = new ToolStripMenuItem();
        MenuItemMGDB = new ToolStripMenuItem();
        GrpBCAT.SuspendLayout();
        GrpContent.SuspendLayout();
        ContextMenuStripWC.SuspendLayout();
        MenuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // BtnLGPE
        // 
        BtnLGPE.AccessibleDescription = "";
        BtnLGPE.AccessibleName = "";
        BtnLGPE.Cursor = Cursors.Hand;
        BtnLGPE.FlatStyle = FlatStyle.Flat;
        BtnLGPE.Location = new Point(5, 37);
        BtnLGPE.Name = "BtnLGPE";
        BtnLGPE.Size = new Size(136, 60);
        BtnLGPE.TabIndex = 0;
        BtnLGPE.TabStop = false;
        BtnLGPE.Text = "LGPE";
        BtnLGPE.UseVisualStyleBackColor = true;
        BtnLGPE.Click += BtnLGPE_Click;
        // 
        // BtnSWSH
        // 
        BtnSWSH.AccessibleDescription = "";
        BtnSWSH.AccessibleName = "";
        BtnSWSH.Cursor = Cursors.Hand;
        BtnSWSH.FlatStyle = FlatStyle.Flat;
        BtnSWSH.Location = new Point(147, 37);
        BtnSWSH.Name = "BtnSWSH";
        BtnSWSH.Size = new Size(136, 60);
        BtnSWSH.TabIndex = 1;
        BtnSWSH.TabStop = false;
        BtnSWSH.Text = "SWSH";
        BtnSWSH.UseVisualStyleBackColor = true;
        BtnSWSH.Click += BtnSWSH_Click;
        // 
        // BtnBDSP
        // 
        BtnBDSP.AccessibleDescription = "";
        BtnBDSP.AccessibleName = "";
        BtnBDSP.Cursor = Cursors.Hand;
        BtnBDSP.FlatStyle = FlatStyle.Flat;
        BtnBDSP.Location = new Point(289, 37);
        BtnBDSP.Name = "BtnBDSP";
        BtnBDSP.Size = new Size(136, 60);
        BtnBDSP.TabIndex = 2;
        BtnBDSP.TabStop = false;
        BtnBDSP.Text = "BDSP";
        BtnBDSP.UseVisualStyleBackColor = true;
        BtnBDSP.Click += BtnBDSP_Click;
        // 
        // BtnSCVI
        // 
        BtnSCVI.AccessibleDescription = "";
        BtnSCVI.AccessibleName = "";
        BtnSCVI.Cursor = Cursors.Hand;
        BtnSCVI.FlatStyle = FlatStyle.Flat;
        BtnSCVI.Location = new Point(573, 37);
        BtnSCVI.Name = "BtnSCVI";
        BtnSCVI.Size = new Size(136, 60);
        BtnSCVI.TabIndex = 3;
        BtnSCVI.TabStop = false;
        BtnSCVI.Text = "SCVI";
        BtnSCVI.UseVisualStyleBackColor = true;
        BtnSCVI.Click += BtnSCVI_Click;
        // 
        // BtnPLA
        // 
        BtnPLA.AccessibleDescription = "";
        BtnPLA.AccessibleName = "";
        BtnPLA.Cursor = Cursors.Hand;
        BtnPLA.FlatStyle = FlatStyle.Flat;
        BtnPLA.Location = new Point(431, 37);
        BtnPLA.Name = "BtnPLA";
        BtnPLA.Size = new Size(136, 60);
        BtnPLA.TabIndex = 4;
        BtnPLA.TabStop = false;
        BtnPLA.Text = "PLA";
        BtnPLA.UseVisualStyleBackColor = true;
        BtnPLA.Click += BtnPLA_Click;
        // 
        // ListBoxWC
        // 
        ListBoxWC.AllowDrop = true;
        ListBoxWC.DrawMode = DrawMode.OwnerDrawFixed;
        ListBoxWC.FormattingEnabled = true;
        ListBoxWC.ItemHeight = 20;
        ListBoxWC.Location = new Point(7, 96);
        ListBoxWC.Name = "ListBoxWC";
        ListBoxWC.Size = new Size(214, 304);
        ListBoxWC.TabIndex = 5;
        ToolTipWcid.SetToolTip(ListBoxWC, "                        Wondercards with duplicated WC ID will not be seen by the game.                        ");
        ListBoxWC.DrawItem += ListBoxWC_DrawItem;
        ListBoxWC.SelectedIndexChanged += ListBoxWC_SelectedIndexChanged;
        ListBoxWC.DragDrop += FileDragDrop;
        ListBoxWC.DragEnter += FileDragEnter;
        ListBoxWC.MouseUp += ListBoxWC_MouseUp;
        // 
        // BtnOpen
        // 
        BtnOpen.Location = new Point(7, 26);
        BtnOpen.Name = "BtnOpen";
        BtnOpen.Size = new Size(214, 29);
        BtnOpen.TabIndex = 6;
        BtnOpen.Text = "Open Wondercard Files...";
        BtnOpen.UseVisualStyleBackColor = true;
        BtnOpen.Click += BtnOpen_Click;
        // 
        // BtnSave
        // 
        BtnSave.Enabled = false;
        BtnSave.Location = new Point(6, 61);
        BtnSave.Name = "BtnSave";
        BtnSave.Size = new Size(214, 29);
        BtnSave.TabIndex = 7;
        BtnSave.Text = "Save as BCAT Package...";
        BtnSave.UseVisualStyleBackColor = true;
        BtnSave.Click += BtnSave_Click;
        // 
        // GrpBCAT
        // 
        GrpBCAT.Controls.Add(ChkRepeatable);
        GrpBCAT.Controls.Add(BtnApply);
        GrpBCAT.Controls.Add(GrpContent);
        GrpBCAT.Controls.Add(TxtWCID);
        GrpBCAT.Controls.Add(LblWCID);
        GrpBCAT.Controls.Add(ListBoxWC);
        GrpBCAT.Controls.Add(BtnSave);
        GrpBCAT.Controls.Add(BtnOpen);
        GrpBCAT.Enabled = false;
        GrpBCAT.Location = new Point(5, 103);
        GrpBCAT.Name = "GrpBCAT";
        GrpBCAT.Size = new Size(704, 409);
        GrpBCAT.TabIndex = 8;
        GrpBCAT.TabStop = false;
        GrpBCAT.Text = "BCAT Manager";
        // 
        // ChkRepeatable
        // 
        ChkRepeatable.AutoSize = true;
        ChkRepeatable.Location = new Point(510, 69);
        ChkRepeatable.Name = "ChkRepeatable";
        ChkRepeatable.Size = new Size(121, 24);
        ChkRepeatable.TabIndex = 12;
        ChkRepeatable.Text = "Is Repeatable";
        ChkRepeatable.UseVisualStyleBackColor = true;
        ChkRepeatable.CheckedChanged += ChkRepeatable_CheckedChanged;
        // 
        // BtnApply
        // 
        BtnApply.Enabled = false;
        BtnApply.Location = new Point(426, 368);
        BtnApply.Name = "BtnApply";
        BtnApply.Size = new Size(97, 32);
        BtnApply.TabIndex = 11;
        BtnApply.Text = "Apply";
        BtnApply.UseVisualStyleBackColor = true;
        BtnApply.Click += BtnApply_Click;
        // 
        // GrpContent
        // 
        GrpContent.Controls.Add(LblInfo7);
        GrpContent.Controls.Add(LblInfo6);
        GrpContent.Controls.Add(LblInfo5);
        GrpContent.Controls.Add(LblInfo4);
        GrpContent.Controls.Add(LblInfo3);
        GrpContent.Controls.Add(LblInfo2);
        GrpContent.Controls.Add(LblInfo1);
        GrpContent.Enabled = false;
        GrpContent.Location = new Point(294, 99);
        GrpContent.Name = "GrpContent";
        GrpContent.Size = new Size(358, 263);
        GrpContent.TabIndex = 10;
        GrpContent.TabStop = false;
        GrpContent.Text = "Gift Content";
        // 
        // LblInfo7
        // 
        LblInfo7.AutoSize = true;
        LblInfo7.Location = new Point(158, 230);
        LblInfo7.Name = "LblInfo7";
        LblInfo7.Size = new Size(49, 20);
        LblInfo7.TabIndex = 6;
        LblInfo7.Text = "Info_7";
        LblInfo7.Visible = false;
        LblInfo7.SizeChanged += LblInfo_SizeChanged;
        // 
        // LblInfo6
        // 
        LblInfo6.AutoSize = true;
        LblInfo6.Location = new Point(158, 198);
        LblInfo6.Name = "LblInfo6";
        LblInfo6.Size = new Size(49, 20);
        LblInfo6.TabIndex = 5;
        LblInfo6.Text = "Info_6";
        LblInfo6.Visible = false;
        LblInfo6.SizeChanged += LblInfo_SizeChanged;
        // 
        // LblInfo5
        // 
        LblInfo5.AutoSize = true;
        LblInfo5.Location = new Point(158, 165);
        LblInfo5.Name = "LblInfo5";
        LblInfo5.Size = new Size(49, 20);
        LblInfo5.TabIndex = 4;
        LblInfo5.Text = "Info_5";
        LblInfo5.Visible = false;
        LblInfo5.SizeChanged += LblInfo_SizeChanged;
        // 
        // LblInfo4
        // 
        LblInfo4.AutoSize = true;
        LblInfo4.Location = new Point(158, 132);
        LblInfo4.Name = "LblInfo4";
        LblInfo4.Size = new Size(49, 20);
        LblInfo4.TabIndex = 3;
        LblInfo4.Text = "Info_4";
        LblInfo4.Visible = false;
        LblInfo4.SizeChanged += LblInfo_SizeChanged;
        // 
        // LblInfo3
        // 
        LblInfo3.AutoSize = true;
        LblInfo3.Location = new Point(158, 99);
        LblInfo3.Name = "LblInfo3";
        LblInfo3.Size = new Size(49, 20);
        LblInfo3.TabIndex = 2;
        LblInfo3.Text = "Info_3";
        LblInfo3.Visible = false;
        LblInfo3.SizeChanged += LblInfo_SizeChanged;
        // 
        // LblInfo2
        // 
        LblInfo2.AutoSize = true;
        LblInfo2.Location = new Point(158, 66);
        LblInfo2.Name = "LblInfo2";
        LblInfo2.Size = new Size(49, 20);
        LblInfo2.TabIndex = 1;
        LblInfo2.Text = "Info_2";
        LblInfo2.Visible = false;
        LblInfo2.SizeChanged += LblInfo_SizeChanged;
        // 
        // LblInfo1
        // 
        LblInfo1.AutoSize = true;
        LblInfo1.Location = new Point(158, 33);
        LblInfo1.Name = "LblInfo1";
        LblInfo1.Size = new Size(49, 20);
        LblInfo1.TabIndex = 0;
        LblInfo1.Text = "Info_1";
        LblInfo1.Visible = false;
        LblInfo1.SizeChanged += LblInfo_SizeChanged;
        // 
        // TxtWCID
        // 
        TxtWCID.Enabled = false;
        TxtWCID.Location = new Point(379, 66);
        TxtWCID.MaxLength = 4;
        TxtWCID.Name = "TxtWCID";
        TxtWCID.Size = new Size(115, 27);
        TxtWCID.TabIndex = 9;
        TxtWCID.TextChanged += TxtWCID_TextChanged;
        TxtWCID.KeyPress += TxtWCID_KeyPress;
        // 
        // LblWCID
        // 
        LblWCID.AutoSize = true;
        LblWCID.Enabled = false;
        LblWCID.Location = new Point(319, 69);
        LblWCID.Name = "LblWCID";
        LblWCID.Size = new Size(54, 20);
        LblWCID.TabIndex = 8;
        LblWCID.Text = "WC ID:";
        // 
        // ContextMenuStripWC
        // 
        ContextMenuStripWC.ImageScalingSize = new Size(20, 20);
        ContextMenuStripWC.Items.AddRange(new ToolStripItem[] { BtnRemove, BtnRemoveAll });
        ContextMenuStripWC.Name = "ConextMenuStripWC";
        ContextMenuStripWC.Size = new Size(155, 52);
        ContextMenuStripWC.Text = "Remove";
        // 
        // BtnRemove
        // 
        BtnRemove.Name = "BtnRemove";
        BtnRemove.Size = new Size(154, 24);
        BtnRemove.Text = "Remove";
        BtnRemove.Click += BtnRemove_Click;
        // 
        // BtnRemoveAll
        // 
        BtnRemoveAll.Name = "BtnRemoveAll";
        BtnRemoveAll.Size = new Size(154, 24);
        BtnRemoveAll.Text = "Remove All";
        BtnRemoveAll.Click += BtnRemoveAll_Click;
        // 
        // OpenFileDialogWC
        // 
        OpenFileDialogWC.Multiselect = true;
        // 
        // ToolTipWcid
        // 
        ToolTipWcid.AutoPopDelay = 100000;
        ToolTipWcid.InitialDelay = 500;
        ToolTipWcid.OwnerDraw = true;
        ToolTipWcid.ReshowDelay = 100;
        ToolTipWcid.UseAnimation = false;
        ToolTipWcid.UseFading = false;
        ToolTipWcid.Draw += ToolTipWcid_Draw;
        // 
        // MenuStrip
        // 
        MenuStrip.BackColor = SystemColors.ButtonFace;
        MenuStrip.ImageScalingSize = new Size(20, 20);
        MenuStrip.Items.AddRange(new ToolStripItem[] { ToolsToolStripMenu });
        MenuStrip.Location = new Point(0, 0);
        MenuStrip.Name = "MenuStrip";
        MenuStrip.Size = new Size(715, 28);
        MenuStrip.TabIndex = 9;
        MenuStrip.Text = "menuStrip1";
        // 
        // ToolsToolStripMenu
        // 
        ToolsToolStripMenu.DropDownItems.AddRange(new ToolStripItem[] { MenuItemMGDB });
        ToolsToolStripMenu.Name = "ToolsToolStripMenu";
        ToolsToolStripMenu.Size = new Size(58, 24);
        ToolsToolStripMenu.Text = "Tools";
        // 
        // MenuItemMGDB
        // 
        MenuItemMGDB.Name = "MenuItemMGDB";
        MenuItemMGDB.Size = new Size(351, 26);
        MenuItemMGDB.Text = "Download latest Mystery Gift Database";
        MenuItemMGDB.Click += MenuItemMGDB_Click;
        // 
        // MainWindow
        // 
        AllowDrop = true;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(715, 518);
        Controls.Add(MenuStrip);
        Controls.Add(GrpBCAT);
        Controls.Add(BtnPLA);
        Controls.Add(BtnSCVI);
        Controls.Add(BtnBDSP);
        Controls.Add(BtnSWSH);
        Controls.Add(BtnLGPE);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MainMenuStrip = MenuStrip;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "MainWindow";
        Text = "Switch Gift Data Manager v";
        DragDrop += FileDragDrop;
        DragEnter += FileDragEnter;
        GrpBCAT.ResumeLayout(false);
        GrpBCAT.PerformLayout();
        GrpContent.ResumeLayout(false);
        GrpContent.PerformLayout();
        ContextMenuStripWC.ResumeLayout(false);
        MenuStrip.ResumeLayout(false);
        MenuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
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
    private CheckBox ChkRepeatable;
    private MenuStrip MenuStrip;
    private ToolStripMenuItem ToolsToolStripMenu;
    private ToolStripMenuItem MenuItemMGDB;
}