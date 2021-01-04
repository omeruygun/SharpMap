
namespace BasarDemo
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFromCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bMPToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ınfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gdalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driverListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postgresqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxLayerList = new System.Windows.Forms.ListBox();
            this.contextMenuStripLayerControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemBrowseData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemZoomToLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mapInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pdfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.styleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapBox1 = new SharpMap.Forms.MapBox();
            this.oracleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripLayerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.gdalToolStripMenuItem,
            this.databaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readFromCSVToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // readFromCSVToolStripMenuItem
            // 
            this.readFromCSVToolStripMenuItem.Name = "readFromCSVToolStripMenuItem";
            this.readFromCSVToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.readFromCSVToolStripMenuItem.Text = "Read From CSV";
            this.readFromCSVToolStripMenuItem.Click += new System.EventHandler(this.readFromCSVToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.panToolStripMenuItem,
            this.queryToolStripMenuItem,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.drawPointToolStripMenuItem,
            this.exportMapToolStripMenuItem,
            this.ınfoToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // panToolStripMenuItem
            // 
            this.panToolStripMenuItem.Name = "panToolStripMenuItem";
            this.panToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.panToolStripMenuItem.Text = "Pan";
            this.panToolStripMenuItem.Click += new System.EventHandler(this.panToolStripMenuItem_Click);
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.queryToolStripMenuItem.Text = "Query";
            this.queryToolStripMenuItem.Click += new System.EventHandler(this.queryToolStripMenuItem_Click);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // drawPointToolStripMenuItem
            // 
            this.drawPointToolStripMenuItem.Name = "drawPointToolStripMenuItem";
            this.drawPointToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.drawPointToolStripMenuItem.Text = "Draw Point";
            this.drawPointToolStripMenuItem.Click += new System.EventHandler(this.drawPointToolStripMenuItem_Click);
            // 
            // exportMapToolStripMenuItem
            // 
            this.exportMapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bMPToolStripMenuItem1});
            this.exportMapToolStripMenuItem.Name = "exportMapToolStripMenuItem";
            this.exportMapToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exportMapToolStripMenuItem.Text = "Export Map";
            // 
            // bMPToolStripMenuItem1
            // 
            this.bMPToolStripMenuItem1.Name = "bMPToolStripMenuItem1";
            this.bMPToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.bMPToolStripMenuItem1.Text = "BMP";
            this.bMPToolStripMenuItem1.Click += new System.EventHandler(this.bMPToolStripMenuItem1_Click);
            // 
            // ınfoToolStripMenuItem
            // 
            this.ınfoToolStripMenuItem.Name = "ınfoToolStripMenuItem";
            this.ınfoToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ınfoToolStripMenuItem.Text = "Info";
            this.ınfoToolStripMenuItem.Click += new System.EventHandler(this.ınfoToolStripMenuItem_Click);
            // 
            // gdalToolStripMenuItem
            // 
            this.gdalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driverListToolStripMenuItem});
            this.gdalToolStripMenuItem.Name = "gdalToolStripMenuItem";
            this.gdalToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.gdalToolStripMenuItem.Text = "Gdal";
            // 
            // driverListToolStripMenuItem
            // 
            this.driverListToolStripMenuItem.Name = "driverListToolStripMenuItem";
            this.driverListToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.driverListToolStripMenuItem.Text = "Driver List";
            this.driverListToolStripMenuItem.Click += new System.EventHandler(this.driverListToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postgresqlToolStripMenuItem,
            this.oracleToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // postgresqlToolStripMenuItem
            // 
            this.postgresqlToolStripMenuItem.Name = "postgresqlToolStripMenuItem";
            this.postgresqlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.postgresqlToolStripMenuItem.Text = "Postgresql";
            this.postgresqlToolStripMenuItem.Click += new System.EventHandler(this.postgresqlToolStripMenuItem_Click);
            // 
            // listBoxLayerList
            // 
            this.listBoxLayerList.ContextMenuStrip = this.contextMenuStripLayerControl;
            this.listBoxLayerList.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxLayerList.FormattingEnabled = true;
            this.listBoxLayerList.Location = new System.Drawing.Point(0, 24);
            this.listBoxLayerList.Name = "listBoxLayerList";
            this.listBoxLayerList.Size = new System.Drawing.Size(226, 426);
            this.listBoxLayerList.TabIndex = 2;
            this.listBoxLayerList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxLayerList_MouseDown);
            // 
            // contextMenuStripLayerControl
            // 
            this.contextMenuStripLayerControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBrowseData,
            this.toolStripMenuItemZoomToLayer,
            this.exportToolStripMenuItemExport,
            this.styleToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStripLayerControl.Name = "contextMenuStripLayerControl";
            this.contextMenuStripLayerControl.Size = new System.Drawing.Size(153, 114);
            // 
            // toolStripMenuItemBrowseData
            // 
            this.toolStripMenuItemBrowseData.Name = "toolStripMenuItemBrowseData";
            this.toolStripMenuItemBrowseData.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemBrowseData.Text = "Browse Data";
            this.toolStripMenuItemBrowseData.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItemZoomToLayer
            // 
            this.toolStripMenuItemZoomToLayer.Name = "toolStripMenuItemZoomToLayer";
            this.toolStripMenuItemZoomToLayer.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemZoomToLayer.Text = "Zoom To Layer";
            this.toolStripMenuItemZoomToLayer.Click += new System.EventHandler(this.toolStripMenuItemZoomToLayer_Click);
            // 
            // exportToolStripMenuItemExport
            // 
            this.exportToolStripMenuItemExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapInfoToolStripMenuItem,
            this.kmlToolStripMenuItem,
            this.pdfToolStripMenuItem});
            this.exportToolStripMenuItemExport.Name = "exportToolStripMenuItemExport";
            this.exportToolStripMenuItemExport.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItemExport.Text = "Export";
            // 
            // mapInfoToolStripMenuItem
            // 
            this.mapInfoToolStripMenuItem.Name = "mapInfoToolStripMenuItem";
            this.mapInfoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.mapInfoToolStripMenuItem.Text = "MapInfo (.mif)";
            this.mapInfoToolStripMenuItem.Click += new System.EventHandler(this.mapInfoToolStripMenuItem_Click);
            // 
            // kmlToolStripMenuItem
            // 
            this.kmlToolStripMenuItem.Name = "kmlToolStripMenuItem";
            this.kmlToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.kmlToolStripMenuItem.Text = "Kml";
            this.kmlToolStripMenuItem.Click += new System.EventHandler(this.kmlToolStripMenuItem_Click);
            // 
            // pdfToolStripMenuItem
            // 
            this.pdfToolStripMenuItem.Name = "pdfToolStripMenuItem";
            this.pdfToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.pdfToolStripMenuItem.Text = "Pdf";
            this.pdfToolStripMenuItem.Click += new System.EventHandler(this.pdfToolStripMenuItem_Click);
            // 
            // styleToolStripMenuItem
            // 
            this.styleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointStyleToolStripMenuItem});
            this.styleToolStripMenuItem.Name = "styleToolStripMenuItem";
            this.styleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.styleToolStripMenuItem.Text = "Style";
            // 
            // pointStyleToolStripMenuItem
            // 
            this.pointStyleToolStripMenuItem.Name = "pointStyleToolStripMenuItem";
            this.pointStyleToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.pointStyleToolStripMenuItem.Text = "Point Style";
            this.pointStyleToolStripMenuItem.Click += new System.EventHandler(this.pointStyleToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // mapBox1
            // 
            this.mapBox1.ActiveTool = SharpMap.Forms.MapBox.Tools.None;
            this.mapBox1.BackColor = System.Drawing.Color.White;
            this.mapBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.mapBox1.CustomTool = null;
            this.mapBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapBox1.FineZoomFactor = 10D;
            this.mapBox1.Location = new System.Drawing.Point(226, 24);
            this.mapBox1.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.LayerByIndex;
            this.mapBox1.Name = "mapBox1";
            this.mapBox1.QueryGrowFactor = 5F;
            this.mapBox1.QueryLayerIndex = 0;
            this.mapBox1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBox1.ShowProgressUpdate = false;
            this.mapBox1.Size = new System.Drawing.Size(574, 426);
            this.mapBox1.TabIndex = 3;
            this.mapBox1.Text = "mapBox1";
            this.mapBox1.WheelZoomMagnitude = -2D;
            // 
            // oracleToolStripMenuItem
            // 
            this.oracleToolStripMenuItem.Name = "oracleToolStripMenuItem";
            this.oracleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.oracleToolStripMenuItem.Text = "Oracle";
            this.oracleToolStripMenuItem.Click += new System.EventHandler(this.oracleToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mapBox1);
            this.Controls.Add(this.listBoxLayerList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripLayerControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readFromCSVToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxLayerList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLayerControl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBrowseData;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemZoomToLayer;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItemExport;
        private System.Windows.Forms.ToolStripMenuItem mapInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gdalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driverListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pdfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bMPToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem styleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointStyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ınfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postgresqlToolStripMenuItem;
        public SharpMap.Forms.MapBox mapBox1;
        private System.Windows.Forms.ToolStripMenuItem oracleToolStripMenuItem;
    }
}