namespace TotalCommander
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbleft = new System.Windows.Forms.ComboBox();
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SizeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LeftContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showHiddenFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ChooseList = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LargeIconButton = new System.Windows.Forms.ToolStripButton();
            this.DetailIconButton = new System.Windows.Forms.ToolStripButton();
            this.SmallIconButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.cbright = new System.Windows.Forms.ComboBox();
            this.listViewRight = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RightContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tbleft = new System.Windows.Forms.TextBox();
            this.tbright = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Large_Icon = new System.Windows.Forms.ImageList(this.components);
            this.Detail_Icon = new System.Windows.Forms.ImageList(this.components);
            this.LeftContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.RightContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbleft
            // 
            this.cbleft.FormattingEnabled = true;
            this.cbleft.Location = new System.Drawing.Point(12, 52);
            this.cbleft.Name = "cbleft";
            this.cbleft.Size = new System.Drawing.Size(53, 21);
            this.cbleft.TabIndex = 0;
            this.cbleft.SelectedIndexChanged += new System.EventHandler(this.cbleft_SelectedIndexChanged);
            // 
            // listViewLeft
            // 
            this.listViewLeft.AllowDrop = true;
            this.listViewLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewLeft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.TypeColumn,
            this.DateColumn,
            this.SizeColumn});
            this.listViewLeft.ContextMenuStrip = this.LeftContextMenuStrip;
            this.listViewLeft.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewLeft.FullRowSelect = true;
            this.listViewLeft.LabelEdit = true;
            this.listViewLeft.Location = new System.Drawing.Point(12, 79);
            this.listViewLeft.Name = "listViewLeft";
            this.listViewLeft.Size = new System.Drawing.Size(547, 291);
            this.listViewLeft.TabIndex = 1;
            this.listViewLeft.UseCompatibleStateImageBehavior = false;
            this.listViewLeft.View = System.Windows.Forms.View.Details;
            this.listViewLeft.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewLeft_AfterLabelEdit);
            this.listViewLeft.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewLeft_KeyUp);
            this.listViewLeft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewLeft_MouseDoubleClick);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 200;
            // 
            // TypeColumn
            // 
            this.TypeColumn.Text = "Type";
            this.TypeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TypeColumn.Width = 80;
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Date";
            this.DateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DateColumn.Width = 200;
            // 
            // SizeColumn
            // 
            this.SizeColumn.Text = "Size";
            this.SizeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LeftContextMenuStrip
            // 
            this.LeftContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.cutToolStripMenuItem,
            this.newFolderToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.renameToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.LeftContextMenuStrip.Name = "contextMenuStrip1";
            this.LeftContextMenuStrip.Size = new System.Drawing.Size(135, 180);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.viewToolStripMenuItem1.Text = "View";
            this.viewToolStripMenuItem1.Click += new System.EventHandler(this.viewToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.editToolStripMenuItem1.Text = "Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // newFolderToolStripMenuItem1
            // 
            this.newFolderToolStripMenuItem1.Name = "newFolderToolStripMenuItem1";
            this.newFolderToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.newFolderToolStripMenuItem1.Text = "New Folder";
            this.newFolderToolStripMenuItem1.Click += new System.EventHandler(this.newFolderToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1314, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.newFolderToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultEditorToolStripMenuItem,
            this.showHiddenFilesToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // defaultEditorToolStripMenuItem
            // 
            this.defaultEditorToolStripMenuItem.Name = "defaultEditorToolStripMenuItem";
            this.defaultEditorToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.defaultEditorToolStripMenuItem.Text = "Default Editor";
            this.defaultEditorToolStripMenuItem.Click += new System.EventHandler(this.defaultEditorToolStripMenuItem_Click);
            // 
            // showHiddenFilesToolStripMenuItem
            // 
            this.showHiddenFilesToolStripMenuItem.Name = "showHiddenFilesToolStripMenuItem";
            this.showHiddenFilesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.showHiddenFilesToolStripMenuItem.Text = "Show Hidden Files";
            this.showHiddenFilesToolStripMenuItem.Click += new System.EventHandler(this.showHiddenFilesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChooseList,
            this.toolStripSeparator1,
            this.LargeIconButton,
            this.DetailIconButton,
            this.SmallIconButton,
            this.RefreshButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1314, 26);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ChooseList
            // 
            this.ChooseList.Items.AddRange(new object[] {
            "Left",
            "Right"});
            this.ChooseList.Name = "ChooseList";
            this.ChooseList.Size = new System.Drawing.Size(121, 26);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // LargeIconButton
            // 
            this.LargeIconButton.AutoSize = false;
            this.LargeIconButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LargeIconButton.Image = ((System.Drawing.Image)(resources.GetObject("LargeIconButton.Image")));
            this.LargeIconButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LargeIconButton.Name = "LargeIconButton";
            this.LargeIconButton.Size = new System.Drawing.Size(23, 23);
            this.LargeIconButton.ToolTipText = "Large Icons";
            this.LargeIconButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // DetailIconButton
            // 
            this.DetailIconButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DetailIconButton.Image = ((System.Drawing.Image)(resources.GetObject("DetailIconButton.Image")));
            this.DetailIconButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetailIconButton.Name = "DetailIconButton";
            this.DetailIconButton.Size = new System.Drawing.Size(23, 23);
            this.DetailIconButton.Text = "toolStripButton2";
            this.DetailIconButton.ToolTipText = "Detail Icons";
            this.DetailIconButton.Click += new System.EventHandler(this.DetailIconButton_Click);
            // 
            // SmallIconButton
            // 
            this.SmallIconButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SmallIconButton.Image = ((System.Drawing.Image)(resources.GetObject("SmallIconButton.Image")));
            this.SmallIconButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SmallIconButton.Name = "SmallIconButton";
            this.SmallIconButton.Size = new System.Drawing.Size(23, 23);
            this.SmallIconButton.Text = "toolStripButton3";
            this.SmallIconButton.ToolTipText = "Small Icons";
            this.SmallIconButton.Click += new System.EventHandler(this.SmallIconButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(23, 23);
            this.RefreshButton.ToolTipText = "Refresh";
            this.RefreshButton.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // cbright
            // 
            this.cbright.FormattingEnabled = true;
            this.cbright.Location = new System.Drawing.Point(574, 51);
            this.cbright.Name = "cbright";
            this.cbright.Size = new System.Drawing.Size(63, 21);
            this.cbright.TabIndex = 4;
            this.cbright.SelectedIndexChanged += new System.EventHandler(this.cbright_SelectedIndexChanged);
            // 
            // listViewRight
            // 
            this.listViewRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewRight.ContextMenuStrip = this.RightContextMenuStrip;
            this.listViewRight.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewRight.FullRowSelect = true;
            this.listViewRight.Location = new System.Drawing.Point(574, 78);
            this.listViewRight.Name = "listViewRight";
            this.listViewRight.Size = new System.Drawing.Size(547, 292);
            this.listViewRight.TabIndex = 5;
            this.listViewRight.UseCompatibleStateImageBehavior = false;
            this.listViewRight.View = System.Windows.Forms.View.Details;
            this.listViewRight.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewRight_AfterLabelEdit);
            this.listViewRight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewRight_KeyUp);
            this.listViewRight.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewRight_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RightContextMenuStrip
            // 
            this.RightContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.pasteToolStripMenuItem1});
            this.RightContextMenuStrip.Name = "contextMenuStrip1";
            this.RightContextMenuStrip.Size = new System.Drawing.Size(135, 180);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem1.Text = "View";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem2.Text = "Edit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem3.Text = "Copy";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem4.Text = "Cut";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem5.Text = "New Folder";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem6.Text = "Delete";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem7.Text = "Rename";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // tbleft
            // 
            this.tbleft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbleft.Location = new System.Drawing.Point(13, 386);
            this.tbleft.Name = "tbleft";
            this.tbleft.Size = new System.Drawing.Size(546, 20);
            this.tbleft.TabIndex = 6;
            this.tbleft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbleft_KeyPress);
            // 
            // tbright
            // 
            this.tbright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbright.Location = new System.Drawing.Point(574, 386);
            this.tbright.Name = "tbright";
            this.tbright.Size = new System.Drawing.Size(547, 20);
            this.tbright.TabIndex = 7;
            this.tbright.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbright_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // Large_Icon
            // 
            this.Large_Icon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Large_Icon.ImageStream")));
            this.Large_Icon.TransparentColor = System.Drawing.Color.Transparent;
            this.Large_Icon.Images.SetKeyName(0, "Folder-icon.png");
            this.Large_Icon.Images.SetKeyName(1, "exe-icon.png");
            this.Large_Icon.Images.SetKeyName(2, "Document-Blank-icon.png");
            this.Large_Icon.Images.SetKeyName(3, "Adobe-PDF-Document-icon.png");
            this.Large_Icon.Images.SetKeyName(4, "File-Video-icon.png");
            this.Large_Icon.Images.SetKeyName(5, "docx-win-icon.png");
            this.Large_Icon.Images.SetKeyName(6, "XLS-File-icon.png");
            this.Large_Icon.Images.SetKeyName(7, "mp3-icon.png");
            this.Large_Icon.Images.SetKeyName(8, "Images-icon.png");
            this.Large_Icon.Images.SetKeyName(9, "text-icon.png");
            this.Large_Icon.Images.SetKeyName(10, "RAR-icon.png");
            this.Large_Icon.Images.SetKeyName(11, "Mimetypes-iso-icon.png");
            // 
            // Detail_Icon
            // 
            this.Detail_Icon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Detail_Icon.ImageStream")));
            this.Detail_Icon.TransparentColor = System.Drawing.Color.Transparent;
            this.Detail_Icon.Images.SetKeyName(0, "Folder-icon.png");
            this.Detail_Icon.Images.SetKeyName(1, "exe-icon.png");
            this.Detail_Icon.Images.SetKeyName(2, "Document-Blank-icon.png");
            this.Detail_Icon.Images.SetKeyName(3, "Adobe-PDF-Document-icon.png");
            this.Detail_Icon.Images.SetKeyName(4, "File-Video-icon.png");
            this.Detail_Icon.Images.SetKeyName(5, "docx-win-icon.png");
            this.Detail_Icon.Images.SetKeyName(6, "XLS-File-icon.png");
            this.Detail_Icon.Images.SetKeyName(7, "mp3-icon.png");
            this.Detail_Icon.Images.SetKeyName(8, "Images-icon.png");
            this.Detail_Icon.Images.SetKeyName(9, "text-icon.png");
            this.Detail_Icon.Images.SetKeyName(10, "RAR-icon.png");
            this.Detail_Icon.Images.SetKeyName(11, "Mimetypes-iso-icon.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1314, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbright);
            this.Controls.Add(this.tbleft);
            this.Controls.Add(this.listViewRight);
            this.Controls.Add(this.cbright);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listViewLeft);
            this.Controls.Add(this.cbleft);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TotalCommander";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LeftContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.RightContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbleft;
        private System.Windows.Forms.ListView listViewLeft;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader TypeColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.ColumnHeader SizeColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip LeftContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox ChooseList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton LargeIconButton;
        private System.Windows.Forms.ToolStripButton DetailIconButton;
        private System.Windows.Forms.ToolStripButton SmallIconButton;
        private System.Windows.Forms.ComboBox cbright;
        private System.Windows.Forms.ListView listViewRight;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.TextBox tbleft;
        private System.Windows.Forms.TextBox tbright;
        private System.Windows.Forms.ToolStripMenuItem defaultEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showHiddenFilesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip RightContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList Large_Icon;
        private System.Windows.Forms.ImageList Detail_Icon;
    }
}

