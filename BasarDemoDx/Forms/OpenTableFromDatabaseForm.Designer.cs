
namespace BasarDemoDx.Forms
{
    partial class OpenTableFromDatabaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenTableFromDatabaseForm));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditSavedConnection = new DevExpress.XtraEditors.ComboBoxEdit();
            this.treeListTableList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEditTableOpen = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.simpleButtonOpen = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSavedConnection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListTableList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditTableOpen)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxEditSavedConnection, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.treeListTableList, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.simpleButtonOpen, 1, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(447, 393);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(217, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Saved Connection";
            // 
            // comboBoxEditSavedConnection
            // 
            this.comboBoxEditSavedConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEditSavedConnection.Location = new System.Drawing.Point(226, 3);
            this.comboBoxEditSavedConnection.Name = "comboBoxEditSavedConnection";
            this.comboBoxEditSavedConnection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSavedConnection.Size = new System.Drawing.Size(218, 20);
            this.comboBoxEditSavedConnection.TabIndex = 1;
            this.comboBoxEditSavedConnection.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditSavedConnection_SelectedIndexChanged);
            // 
            // treeListTableList
            // 
            this.treeListTableList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.tableLayoutPanelMain.SetColumnSpan(this.treeListTableList, 2);
            this.treeListTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListTableList.Location = new System.Drawing.Point(3, 33);
            this.treeListTableList.Name = "treeListTableList";
            this.treeListTableList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditTableOpen});
            this.treeListTableList.Size = new System.Drawing.Size(441, 322);
            this.treeListTableList.TabIndex = 2;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.ColumnEdit = this.repositoryItemCheckEditTableOpen;
            this.treeListColumn1.FieldName = "IsOpen";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 30;
            // 
            // repositoryItemCheckEditTableOpen
            // 
            this.repositoryItemCheckEditTableOpen.AutoHeight = false;
            this.repositoryItemCheckEditTableOpen.Name = "repositoryItemCheckEditTableOpen";
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Table Name";
            this.treeListColumn2.FieldName = "TableName";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 386;
            // 
            // simpleButtonOpen
            // 
            this.simpleButtonOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonOpen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonOpen.ImageOptions.SvgImage")));
            this.simpleButtonOpen.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.simpleButtonOpen.Location = new System.Drawing.Point(322, 361);
            this.simpleButtonOpen.Name = "simpleButtonOpen";
            this.simpleButtonOpen.Size = new System.Drawing.Size(122, 29);
            this.simpleButtonOpen.TabIndex = 3;
            this.simpleButtonOpen.Text = "Apply";
            this.simpleButtonOpen.Click += new System.EventHandler(this.simpleButtonOpen_Click);
            // 
            // OpenTableFromDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 393);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "OpenTableFromDatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Table From Database";
            this.Load += new System.EventHandler(this.OpenTableFromDatabaseForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSavedConnection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListTableList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditTableOpen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSavedConnection;
        private DevExpress.XtraTreeList.TreeList treeListTableList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditTableOpen;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOpen;
    }
}