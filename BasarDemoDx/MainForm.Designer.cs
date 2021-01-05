
namespace BasarDemoDx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.ribbonControlMain = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemGeocodeWkt = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInfo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemConnectToDb = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOpenTableFromDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemZoomToExtends = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCloseLayer = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemMapZoom = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemSaveWorkspace = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOpenWorkspace = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemMousePosition = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemBingRoad = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDrawPoint = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemOpen = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemOpenShape = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOpenMapInfo = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGeneral = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupTools = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupBackgroundLayers = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupDrawing = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBarMain = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.treeListLayerList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnIsVisible = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEditIsOpen = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.mapBoxMainWindow = new SharpMap.Forms.MapBox();
            this.repositoryItemCheckEditLayerLabel = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.treeListColumnLabelColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsOpen)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditLayerLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document1});
            // 
            // document1
            // 
            this.document1.Caption = "Maps";
            this.document1.ControlName = "dockPanel2";
            this.document1.FloatLocation = new System.Drawing.Point(-1165, 419);
            this.document1.FloatSize = new System.Drawing.Size(200, 200);
            this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // ribbonControlMain
            // 
            this.ribbonControlMain.ExpandCollapseItem.Id = 0;
            this.ribbonControlMain.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControlMain.ExpandCollapseItem,
            this.ribbonControlMain.SearchEditItem,
            this.barButtonItemGeocodeWkt,
            this.barButtonItemPan,
            this.barButtonItemQuery,
            this.barButtonItemZoomIn,
            this.barButtonItemZoomOut,
            this.barButtonItemInfo,
            this.barButtonItemConnectToDb,
            this.barButtonItemOpenTableFromDatabase,
            this.barButtonItemZoomToExtends,
            this.barButtonItemCloseLayer,
            this.barStaticItemMapZoom,
            this.barButtonItemSaveWorkspace,
            this.barButtonItemOpenWorkspace,
            this.barStaticItemMousePosition,
            this.barButtonItemBingRoad,
            this.barButtonItemDrawPoint,
            this.barSubItemOpen,
            this.barButtonItemOpenShape,
            this.barButtonItemOpenMapInfo});
            this.ribbonControlMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonControlMain.MaxItemId = 21;
            this.ribbonControlMain.Name = "ribbonControlMain";
            this.ribbonControlMain.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageGeneral});
            this.ribbonControlMain.Size = new System.Drawing.Size(1138, 150);
            this.ribbonControlMain.StatusBar = this.ribbonStatusBarMain;
            // 
            // barButtonItemGeocodeWkt
            // 
            this.barButtonItemGeocodeWkt.Caption = "Geocode From WKT";
            this.barButtonItemGeocodeWkt.Id = 1;
            this.barButtonItemGeocodeWkt.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemGeocodeWkt.ImageOptions.SvgImage")));
            this.barButtonItemGeocodeWkt.Name = "barButtonItemGeocodeWkt";
            // 
            // barButtonItemPan
            // 
            this.barButtonItemPan.Caption = "Pan";
            this.barButtonItemPan.Id = 2;
            this.barButtonItemPan.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemPan.ImageOptions.SvgImage")));
            this.barButtonItemPan.Name = "barButtonItemPan";
            // 
            // barButtonItemQuery
            // 
            this.barButtonItemQuery.Caption = "Query";
            this.barButtonItemQuery.Id = 3;
            this.barButtonItemQuery.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemQuery.ImageOptions.SvgImage")));
            this.barButtonItemQuery.Name = "barButtonItemQuery";
            // 
            // barButtonItemZoomIn
            // 
            this.barButtonItemZoomIn.Caption = "Zoom In";
            this.barButtonItemZoomIn.Id = 4;
            this.barButtonItemZoomIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemZoomIn.ImageOptions.SvgImage")));
            this.barButtonItemZoomIn.Name = "barButtonItemZoomIn";
            // 
            // barButtonItemZoomOut
            // 
            this.barButtonItemZoomOut.Caption = "Zoom Out";
            this.barButtonItemZoomOut.Id = 5;
            this.barButtonItemZoomOut.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemZoomOut.ImageOptions.SvgImage")));
            this.barButtonItemZoomOut.Name = "barButtonItemZoomOut";
            // 
            // barButtonItemInfo
            // 
            this.barButtonItemInfo.Caption = "Info";
            this.barButtonItemInfo.Id = 6;
            this.barButtonItemInfo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemInfo.ImageOptions.SvgImage")));
            this.barButtonItemInfo.Name = "barButtonItemInfo";
            // 
            // barButtonItemConnectToDb
            // 
            this.barButtonItemConnectToDb.Caption = "Connect To Database";
            this.barButtonItemConnectToDb.Id = 7;
            this.barButtonItemConnectToDb.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemConnectToDb.ImageOptions.SvgImage")));
            this.barButtonItemConnectToDb.Name = "barButtonItemConnectToDb";
            this.barButtonItemConnectToDb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemConnectToDb_ItemClick);
            // 
            // barButtonItemOpenTableFromDatabase
            // 
            this.barButtonItemOpenTableFromDatabase.Caption = "Open Table";
            this.barButtonItemOpenTableFromDatabase.Id = 8;
            this.barButtonItemOpenTableFromDatabase.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemOpenTableFromDatabase.ImageOptions.SvgImage")));
            this.barButtonItemOpenTableFromDatabase.Name = "barButtonItemOpenTableFromDatabase";
            this.barButtonItemOpenTableFromDatabase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOpenTableFromDatabase_ItemClick);
            // 
            // barButtonItemZoomToExtends
            // 
            this.barButtonItemZoomToExtends.Caption = "Zoom To Extends";
            this.barButtonItemZoomToExtends.Id = 9;
            this.barButtonItemZoomToExtends.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemZoomToExtends.ImageOptions.SvgImage")));
            this.barButtonItemZoomToExtends.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.barButtonItemZoomToExtends.Name = "barButtonItemZoomToExtends";
            // 
            // barButtonItemCloseLayer
            // 
            this.barButtonItemCloseLayer.Caption = "Close";
            this.barButtonItemCloseLayer.Id = 10;
            this.barButtonItemCloseLayer.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemCloseLayer.ImageOptions.SvgImage")));
            this.barButtonItemCloseLayer.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.barButtonItemCloseLayer.Name = "barButtonItemCloseLayer";
            // 
            // barStaticItemMapZoom
            // 
            this.barStaticItemMapZoom.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItemMapZoom.Id = 11;
            this.barStaticItemMapZoom.Name = "barStaticItemMapZoom";
            // 
            // barButtonItemSaveWorkspace
            // 
            this.barButtonItemSaveWorkspace.Caption = "Save Workspace";
            this.barButtonItemSaveWorkspace.Id = 12;
            this.barButtonItemSaveWorkspace.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemSaveWorkspace.ImageOptions.SvgImage")));
            this.barButtonItemSaveWorkspace.Name = "barButtonItemSaveWorkspace";
            this.barButtonItemSaveWorkspace.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSaveWorkspace_ItemClick);
            // 
            // barButtonItemOpenWorkspace
            // 
            this.barButtonItemOpenWorkspace.Caption = "Open Workspace";
            this.barButtonItemOpenWorkspace.Id = 13;
            this.barButtonItemOpenWorkspace.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemOpenWorkspace.ImageOptions.SvgImage")));
            this.barButtonItemOpenWorkspace.Name = "barButtonItemOpenWorkspace";
            this.barButtonItemOpenWorkspace.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOpenWorkspace_ItemClick);
            // 
            // barStaticItemMousePosition
            // 
            this.barStaticItemMousePosition.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItemMousePosition.Caption = "-";
            this.barStaticItemMousePosition.Id = 14;
            this.barStaticItemMousePosition.Name = "barStaticItemMousePosition";
            // 
            // barButtonItemBingRoad
            // 
            this.barButtonItemBingRoad.Caption = "Bing Road";
            this.barButtonItemBingRoad.Id = 15;
            this.barButtonItemBingRoad.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemBingRoad.ImageOptions.SvgImage")));
            this.barButtonItemBingRoad.Name = "barButtonItemBingRoad";
            this.barButtonItemBingRoad.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemBingRoad_ItemClick);
            // 
            // barButtonItemDrawPoint
            // 
            this.barButtonItemDrawPoint.Caption = "Point";
            this.barButtonItemDrawPoint.Id = 16;
            this.barButtonItemDrawPoint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemDrawPoint.ImageOptions.SvgImage")));
            this.barButtonItemDrawPoint.Name = "barButtonItemDrawPoint";
            this.barButtonItemDrawPoint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDrawPoint_ItemClick);
            // 
            // barSubItemOpen
            // 
            this.barSubItemOpen.Caption = "Open";
            this.barSubItemOpen.Id = 18;
            this.barSubItemOpen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barSubItemOpen.ImageOptions.SvgImage")));
            this.barSubItemOpen.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemOpenShape),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemOpenMapInfo)});
            this.barSubItemOpen.Name = "barSubItemOpen";
            // 
            // barButtonItemOpenShape
            // 
            this.barButtonItemOpenShape.Caption = "Shape";
            this.barButtonItemOpenShape.Id = 19;
            this.barButtonItemOpenShape.ImageOptions.SvgImage = global::BasarDemoDx.Properties.Resources.shapeFile;
            this.barButtonItemOpenShape.Name = "barButtonItemOpenShape";
            this.barButtonItemOpenShape.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOpenShape_ItemClick);
            // 
            // barButtonItemOpenMapInfo
            // 
            this.barButtonItemOpenMapInfo.Caption = "MapInfo";
            this.barButtonItemOpenMapInfo.Id = 20;
            this.barButtonItemOpenMapInfo.ImageOptions.SvgImage = global::BasarDemoDx.Properties.Resources.mapinfoFile;
            this.barButtonItemOpenMapInfo.Name = "barButtonItemOpenMapInfo";
            this.barButtonItemOpenMapInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOpenMapInfo_ItemClick);
            // 
            // ribbonPageGeneral
            // 
            this.ribbonPageGeneral.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroupTools,
            this.ribbonPageGroupDatabase,
            this.ribbonPageGroupBackgroundLayers,
            this.ribbonPageGroupDrawing});
            this.ribbonPageGeneral.Name = "ribbonPageGeneral";
            this.ribbonPageGeneral.Text = "General";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemGeocodeWkt);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemSaveWorkspace);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemOpenWorkspace);
            this.ribbonPageGroup1.ItemLinks.Add(this.barSubItemOpen);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "General";
            // 
            // ribbonPageGroupTools
            // 
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemPan);
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemQuery);
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemZoomIn);
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemZoomOut);
            this.ribbonPageGroupTools.ItemLinks.Add(this.barButtonItemInfo);
            this.ribbonPageGroupTools.Name = "ribbonPageGroupTools";
            this.ribbonPageGroupTools.Text = "Tools";
            // 
            // ribbonPageGroupDatabase
            // 
            this.ribbonPageGroupDatabase.ItemLinks.Add(this.barButtonItemConnectToDb);
            this.ribbonPageGroupDatabase.ItemLinks.Add(this.barButtonItemOpenTableFromDatabase);
            this.ribbonPageGroupDatabase.Name = "ribbonPageGroupDatabase";
            this.ribbonPageGroupDatabase.Text = "Dabase";
            // 
            // ribbonPageGroupBackgroundLayers
            // 
            this.ribbonPageGroupBackgroundLayers.ItemLinks.Add(this.barButtonItemBingRoad);
            this.ribbonPageGroupBackgroundLayers.Name = "ribbonPageGroupBackgroundLayers";
            this.ribbonPageGroupBackgroundLayers.Text = "Background Layers";
            // 
            // ribbonPageGroupDrawing
            // 
            this.ribbonPageGroupDrawing.ItemLinks.Add(this.barButtonItemDrawPoint);
            this.ribbonPageGroupDrawing.Name = "ribbonPageGroupDrawing";
            this.ribbonPageGroupDrawing.Text = "Drawing";
            // 
            // ribbonStatusBarMain
            // 
            this.ribbonStatusBarMain.ItemLinks.Add(this.barStaticItemMapZoom);
            this.ribbonStatusBarMain.ItemLinks.Add(this.barStaticItemMousePosition);
            this.ribbonStatusBarMain.Location = new System.Drawing.Point(0, 441);
            this.ribbonStatusBarMain.Name = "ribbonStatusBarMain";
            this.ribbonStatusBarMain.Ribbon = this.ribbonControlMain;
            this.ribbonStatusBarMain.Size = new System.Drawing.Size(856, 27);
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.MenuManager = this.ribbonControlMain;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
            this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1});
            dockingContainer2.Element = this.documentGroup1;
            this.tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer2});
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("04e32109-e51a-4770-9ef5-e8b13a3102f9");
            this.dockPanel1.Location = new System.Drawing.Point(0, 150);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(276, 200);
            this.dockPanel1.Size = new System.Drawing.Size(276, 497);
            this.dockPanel1.Text = "Layers";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.treeListLayerList);
            this.dockPanel1_Container.Location = new System.Drawing.Point(3, 26);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(269, 468);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // treeListLayerList
            // 
            this.treeListLayerList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnIsVisible,
            this.treeListColumn1,
            this.treeListColumnLabelColumn});
            this.treeListLayerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListLayerList.Location = new System.Drawing.Point(0, 0);
            this.treeListLayerList.MenuManager = this.ribbonControlMain;
            this.treeListLayerList.Name = "treeListLayerList";
            this.treeListLayerList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEditIsOpen,
            this.repositoryItemCheckEditLayerLabel});
            this.treeListLayerList.Size = new System.Drawing.Size(269, 468);
            this.treeListLayerList.TabIndex = 3;
            this.treeListLayerList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeListLayerList_MouseDown);
            // 
            // treeListColumnIsVisible
            // 
            this.treeListColumnIsVisible.ColumnEdit = this.repositoryItemCheckEditIsOpen;
            this.treeListColumnIsVisible.FieldName = "IsVisible";
            this.treeListColumnIsVisible.Name = "treeListColumnIsVisible";
            this.treeListColumnIsVisible.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.treeListColumnIsVisible.Visible = true;
            this.treeListColumnIsVisible.VisibleIndex = 0;
            this.treeListColumnIsVisible.Width = 27;
            // 
            // repositoryItemCheckEditIsOpen
            // 
            this.repositoryItemCheckEditIsOpen.AutoHeight = false;
            this.repositoryItemCheckEditIsOpen.Name = "repositoryItemCheckEditIsOpen";
            this.repositoryItemCheckEditIsOpen.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEditIsOpen_CheckedChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Layer";
            this.treeListColumn1.FieldName = "LayerName";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 1;
            this.treeListColumn1.Width = 187;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.DockedAsTabbedDocument = true;
            this.dockPanel2.FloatLocation = new System.Drawing.Point(-1165, 419);
            this.dockPanel2.ID = new System.Guid("c5ad1570-5b1b-4a4f-a552-508e57b2f1df");
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.Text = "Maps";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.ribbonStatusBarMain);
            this.dockPanel2_Container.Controls.Add(this.mapBoxMainWindow);
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(856, 468);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // mapBoxMainWindow
            // 
            this.mapBoxMainWindow.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
            this.mapBoxMainWindow.BackColor = System.Drawing.Color.White;
            this.mapBoxMainWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mapBoxMainWindow.CustomTool = null;
            this.mapBoxMainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapBoxMainWindow.FineZoomFactor = 10D;
            this.mapBoxMainWindow.Location = new System.Drawing.Point(0, 0);
            this.mapBoxMainWindow.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.LayerByIndex;
            this.mapBoxMainWindow.Name = "mapBoxMainWindow";
            this.mapBoxMainWindow.QueryGrowFactor = 5F;
            this.mapBoxMainWindow.QueryLayerIndex = 0;
            this.mapBoxMainWindow.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBoxMainWindow.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.mapBoxMainWindow.ShowProgressUpdate = false;
            this.mapBoxMainWindow.Size = new System.Drawing.Size(856, 468);
            this.mapBoxMainWindow.TabIndex = 0;
            this.mapBoxMainWindow.Text = "mapBox1";
            this.mapBoxMainWindow.WheelZoomMagnitude = -2D;
            this.mapBoxMainWindow.MapRefreshed += new System.EventHandler(this.mapBoxMainWindow_MapRefreshed);
            this.mapBoxMainWindow.MapChanging += new System.ComponentModel.CancelEventHandler(this.mapBoxMainWindow_MapChanging);
            this.mapBoxMainWindow.MapChanged += new System.EventHandler(this.mapBoxMainWindow_MapChanged);
            this.mapBoxMainWindow.MapZoomChanged += new SharpMap.Forms.MapBox.MapZoomHandler(this.mapBoxMainWindow_MapZoomChanged);
            this.mapBoxMainWindow.MapZooming += new SharpMap.Forms.MapBox.MapZoomHandler(this.mapBoxMainWindow_MapZooming);
            this.mapBoxMainWindow.MapQueried += new SharpMap.Forms.MapBox.MapQueryHandler(this.mapBoxMainWindow_MapQueried);
            this.mapBoxMainWindow.MapQueryStarted += new System.EventHandler(this.mapBoxMainWindow_MapQueryStarted);
            this.mapBoxMainWindow.MapQueryDone += new System.EventHandler(this.mapBoxMainWindow_MapQueryDone);
            this.mapBoxMainWindow.LocationChanged += new System.EventHandler(this.mapBoxMainWindow_LocationChanged);
            // 
            // repositoryItemCheckEditLayerLabel
            // 
            this.repositoryItemCheckEditLayerLabel.AutoHeight = false;
            this.repositoryItemCheckEditLayerLabel.Name = "repositoryItemCheckEditLayerLabel";
            this.repositoryItemCheckEditLayerLabel.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEditLayerLabel_CheckedChanged);
            // 
            // treeListColumnLabelColumn
            // 
            this.treeListColumnLabelColumn.Caption = "Label";
            this.treeListColumnLabelColumn.ColumnEdit = this.repositoryItemCheckEditLayerLabel;
            this.treeListColumnLabelColumn.FieldName = "IsLabelOpen";
            this.treeListColumnLabelColumn.Name = "treeListColumnLabelColumn";
            this.treeListColumnLabelColumn.Visible = true;
            this.treeListColumnLabelColumn.VisibleIndex = 2;
            this.treeListColumnLabelColumn.Width = 30;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 647);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.ribbonControlMain);
            this.Name = "MainForm";
            this.Text = "Basar Demo Map";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLayerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditIsOpen)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEditLayerLabel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControlMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageGeneral;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.BarButtonItem barButtonItemGeocodeWkt;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPan;
        private DevExpress.XtraBars.BarButtonItem barButtonItemQuery;
        private DevExpress.XtraBars.BarButtonItem barButtonItemZoomIn;
        private DevExpress.XtraBars.BarButtonItem barButtonItemZoomOut;
        private DevExpress.XtraBars.BarButtonItem barButtonItemInfo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupTools;
        private DevExpress.XtraTreeList.TreeList treeListLayerList;
        private DevExpress.XtraBars.BarButtonItem barButtonItemConnectToDb;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupDatabase;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpenTableFromDatabase;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnIsVisible;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditIsOpen;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemZoomToExtends;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCloseLayer;
        private DevExpress.XtraBars.BarStaticItem barStaticItemMapZoom;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBarMain;
        public SharpMap.Forms.MapBox mapBoxMainWindow;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSaveWorkspace;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpenWorkspace;
        private DevExpress.XtraBars.BarStaticItem barStaticItemMousePosition;
        private DevExpress.XtraBars.BarButtonItem barButtonItemBingRoad;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupBackgroundLayers;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDrawPoint;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupDrawing;
        private DevExpress.XtraBars.BarSubItem barSubItemOpen;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpenShape;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOpenMapInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnLabelColumn;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEditLayerLabel;
    }
}
