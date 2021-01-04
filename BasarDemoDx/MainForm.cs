﻿using BasarDemoDx.Forms;
using BasarDemoDx.Models;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Menu;
using DevExpress.XtraTreeList.Nodes;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasarDemoDx
{
    public partial class MainForm : XtraForm
    {
        public List<DbTableModelItem> OpenedTables { get; set; } = new List<DbTableModelItem>();
        public MainForm()
        {
            InitializeComponent();
            mapBoxMainWindow.Map.LayerRendering += Map_LayerRendering;
            mapBoxMainWindow.Map.LayerRenderedEx += Map_LayerRendered;
        }



        private void barButtonItemConnectToDb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ConnectToDb form = new ConnectToDb();
            form.Owner = this;
            form.ShowDialog();
        }

        private void barButtonItemOpenTableFromDatabase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenTableFromDatabaseForm form = new OpenTableFromDatabaseForm();
            form.Owner = this;
            form.Show();
        }

        public void OpenTable(DbTableModelItem item)
        {
            if (!IsLayerOpen(item.TableName))
            {
                SharpMap.Layers.VectorLayer lay1 = new SharpMap.Layers.VectorLayer(item.TableName);
                switch (item.Connection.DatabaseType)
                {
                    case Models.DbType.None:
                        break;
                    case Models.DbType.PostgreSQL:
                        lay1.DataSource = new SharpMap.Data.Providers.PostGIS("Server = " + item.Connection.HostOrIp + "; Port = " + item.Connection.Port + "; Database = " + item.Connection.Database + "; User Id = " + item.Connection.Username + "; Password = " + item.Connection.Password + "", item.TableName, item.UniqColumnName);
                        break;
                    case Models.DbType.Oracle:
                        lay1.DataSource = new SharpMap.Data.Providers.Oracle("User Id=" + item.Connection.Username + ";Password=" + item.Connection.Password + ";Data Source=" + item.Connection.HostOrIp + "", item.TableName, item.UniqColumnName);
                        break;
                }

                Random rnd = new Random();
                int R = rnd.Next(0, 255);
                int G = rnd.Next(0, 255);
                int B = rnd.Next(0, 255);
                Color col = Color.FromArgb(R, G, B);
                Brush brushColor = new SolidBrush(col);
                lay1.Style.Outline.Brush = brushColor;
                Color col2 = Color.FromArgb(255 - R, 255 - G, 255 - B);
                Brush brushColor2 = new SolidBrush(col2);
                lay1.Style.Fill = brushColor2;
                lay1.Style.EnableOutline = true;

                lay1.LayerRendered += Lay1_LayerRendered;

                mapBoxMainWindow.Map.Layers.Add(lay1);
                //mapBox1.Map.ZoomToExtents();
                mapBoxMainWindow.Refresh();

                item.IsOpen = true;

                this.OpenedTables.Add(item);

                LoadLayerList();
            }
        }

        private void Lay1_LayerRendered(Layer layer, Graphics g)
        {

        }

        private void LoadLayerList()
        {
            List<LayerItemModel> lst = new List<LayerItemModel>();
            for (int i = 0; i < mapBoxMainWindow.Map.Layers.Count; i++)
            {
                lst.Add(new LayerItemModel()
                {
                    IsVisible = mapBoxMainWindow.Map.Layers[i].Enabled,
                    LayerName = mapBoxMainWindow.Map.Layers[i].LayerName
                });
            }
            treeListLayerList.DataSource = lst;
        }

        private bool IsLayerOpen(string tableName)
        {
            foreach (var item in mapBoxMainWindow.Map.Layers)
            {
                if (item.LayerName == tableName)
                {
                    return true;
                }
            }
            return false;
        }

        private void treeListLayerList_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                TreeListHitInfo hitInfo = treeListLayerList.CalcHitInfo(e.Location);

                var data = treeListLayerList.GetRow(hitInfo.Node.Id) as LayerItemModel;

                TreeListMenu menu = new TreeListMenu(sender as TreeList);

                DXMenuItem menuItemZoomToExtends = new DXMenuItem("Zoom To Extends");
                menuItemZoomToExtends.Tag = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                menuItemZoomToExtends.Click += MenuItemZoomToExtends_Click;

                menu.Items.Add(menuItemZoomToExtends);

                DXMenuItem menuItemClose = new DXMenuItem("Close");
                menuItemClose.Tag = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                menuItemClose.Click += MenuItemClose_Click; ;

                menu.Items.Add(menuItemClose);

                DXMenuItem menuItemProperties = new DXMenuItem("Properties");
                menuItemProperties.Tag = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                menuItemProperties.Click += MenuItemProperties_Click;

                menu.Items.Add(menuItemProperties);

                menu.Show(e.Location);

            }
            else
            {
                return;
            }
        }

        private void MenuItemProperties_Click(object sender, EventArgs e)
        {
            var item = sender as DXMenuItem;

            var layer = Newtonsoft.Json.JsonConvert.DeserializeObject<LayerItemModel>(item.Tag.ToString());

            var table = this.OpenedTables.FirstOrDefault(async => async.TableName == layer.LayerName);

            LayerProperties form = new LayerProperties();
            form.Table = table;
            form.Owner = this;
            form.ShowDialog();
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            var item = sender as DXMenuItem;

            var layer = Newtonsoft.Json.JsonConvert.DeserializeObject<LayerItemModel>(item.Tag.ToString());

            ILayer _removeLayer = null;

            for (int i = 0; i < mapBoxMainWindow.Map.Layers.Count; i++)
            {
                if (mapBoxMainWindow.Map.Layers[i].LayerName == layer.LayerName)
                {
                    _removeLayer = mapBoxMainWindow.Map.Layers[i];
                }
            }
            if (_removeLayer != null)
            {
                mapBoxMainWindow.Map.Layers.Remove(_removeLayer);

                var rec = this.OpenedTables.FirstOrDefault(async => async.TableName == layer.LayerName);
                if (rec != null)
                {
                    this.OpenedTables.Remove(rec);
                }

                LoadLayerList();
            }
        }

        private void MenuItemZoomToExtends_Click(object sender, EventArgs e)
        {
            var item = sender as DXMenuItem;

            var layer = Newtonsoft.Json.JsonConvert.DeserializeObject<LayerItemModel>(item.Tag.ToString());

            for (int i = 0; i < mapBoxMainWindow.Map.Layers.Count; i++)
            {
                if (mapBoxMainWindow.Map.Layers[i].LayerName == layer.LayerName)
                {
                    var env = mapBoxMainWindow.Map.Layers[i].Envelope;

                    mapBoxMainWindow.Map.ZoomToBox(env);
                    mapBoxMainWindow.Refresh();
                }
            }
        }

        private void mapBoxMainWindow_MapChanging(object sender, CancelEventArgs e)
        {

        }

        private void mapBoxMainWindow_MapChanged(object sender, EventArgs e)
        {

        }

        private void mapBoxMainWindow_MapQueryDone(object sender, EventArgs e)
        {

        }

        private void mapBoxMainWindow_MapZooming(double zoom)
        {

        }

        private void mapBoxMainWindow_MapQueried(SharpMap.Data.FeatureDataTable data)
        {

        }

        private void mapBoxMainWindow_MapQueryStarted(object sender, EventArgs e)
        {

        }

        private void mapBoxMainWindow_MapRefreshed(object sender, EventArgs e)
        {

        }

        private void mapBoxMainWindow_MapZoomChanged(double zoom)
        {
            barStaticItemMapZoom.Caption = zoom.ToString();
        }

        private void mapBoxMainWindow_LocationChanged(object sender, EventArgs e)
        {

        }

        private void Map_LayerRendered(object sender, EventArgs e)
        {

        }

        private void Map_LayerRendering(object sender, SharpMap.LayerRenderingEventArgs e)
        {

        }

        private void repositoryItemCheckEditIsOpen_CheckedChanged(object sender, EventArgs e)
        {
            var checkEdit = sender as CheckEdit;

            TreeListHitInfo hitInfo = treeListLayerList.CalcHitInfo(checkEdit.Location);

            var data = treeListLayerList.GetRow(hitInfo.Node.Id) as LayerItemModel;

            foreach (var item in mapBoxMainWindow.Map.Layers)
            {
                if (item.LayerName == data.LayerName)
                {
                    item.Enabled = !data.IsVisible;
                }
            }

            var rec = this.OpenedTables.FirstOrDefault(async => async.TableName == data.LayerName);
            if (rec != null)
            {
                rec.IsOpen = !data.IsVisible;
            }

            mapBoxMainWindow.Refresh();
        }

        private void barButtonItemSaveWorkspace_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<WorkspaceLayerItem> lst = new List<WorkspaceLayerItem>();
            for (int i = 0; i < mapBoxMainWindow.Map.Layers.Count; i++)
            {
                var item = new WorkspaceLayerItem();

                item.DbLayerModel = this.OpenedTables.FirstOrDefault(async => async.TableName == mapBoxMainWindow.Map.Layers[i].LayerName);

                ILayer layer = Program.mainForm.mapBoxMainWindow.Map.Layers[i];

                item.MinVisible = layer.MinVisible;
                item.MaxVisible = layer.MaxVisible;

                if (layer.GetType().Name == "VectorLayer")
                {
                    var outlineStyle = (layer as VectorLayer).Style.Outline.Brush as SolidBrush;

                    item.OutlineColor = outlineStyle.Color;

                    item.PenWidth = (int)(layer as VectorLayer).Style.Outline.Width;

                    SolidBrush fillStyle = (layer as VectorLayer).Style.Fill as SolidBrush;

                    item.FillColor = fillStyle.Color;

                }

                lst.Add(item);
            }

            WorkspaceModel workspace = new WorkspaceModel();
            workspace.CenterX = mapBoxMainWindow.Map.Center.X;
            workspace.CenterY = mapBoxMainWindow.Map.Center.Y;
            workspace.Scale = mapBoxMainWindow.Map.MapScale;
            workspace.Layers = lst;

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Map Workspace File|*.ygn";
            save.OverwritePrompt = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(save.FileName))
                {
                    writer.Write(Newtonsoft.Json.JsonConvert.SerializeObject(workspace));
                }
            }
        }

        private void barButtonItemOpenWorkspace_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Map Workspace File|*.ygn";

            if (file.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(file.FileName))
                {
                    var data = reader.ReadToEnd();

                    var workspace = Newtonsoft.Json.JsonConvert.DeserializeObject<WorkspaceModel>(data);

                    LoadWorkspace(workspace);
                }
            }
        }

        private void LoadWorkspace(WorkspaceModel workspace)
        {
            mapBoxMainWindow.Map.Center = new GeoAPI.Geometries.Coordinate(workspace.CenterX, workspace.CenterY);
            mapBoxMainWindow.Map.MapScale = workspace.Scale;

            mapBoxMainWindow.Map.Layers.Clear();

            foreach (var item in workspace.Layers)
            {
                SharpMap.Layers.VectorLayer lay1 = new SharpMap.Layers.VectorLayer(item.DbLayerModel.TableName);
                switch (item.DbLayerModel.Connection.DatabaseType)
                {
                    case Models.DbType.None:
                        break;
                    case Models.DbType.PostgreSQL:
                        lay1.DataSource = new SharpMap.Data.Providers.PostGIS("Server = " + item.DbLayerModel.Connection.HostOrIp + "; Port = " + item.DbLayerModel.Connection.Port + "; Database = " + item.DbLayerModel.Connection.Database + "; User Id = " + item.DbLayerModel.Connection.Username + "; Password = " + item.DbLayerModel.Connection.Password + "", item.DbLayerModel.TableName, item.DbLayerModel.UniqColumnName);
                        break;
                    case Models.DbType.Oracle:
                        lay1.DataSource = new SharpMap.Data.Providers.Oracle("User Id=" + item.DbLayerModel.Connection.Username + ";Password=" + item.DbLayerModel.Connection.Password + ";Data Source=" + item.DbLayerModel.Connection.HostOrIp + "", item.DbLayerModel.TableName, item.DbLayerModel.UniqColumnName);
                        break;
                }

                Brush brushColor = new SolidBrush(item.OutlineColor);
                lay1.Style.Outline.Brush = brushColor;
                lay1.Style.Outline.Width = item.PenWidth;

                Brush brushColor2 = new SolidBrush(item.FillColor);
                lay1.Style.Fill = brushColor2;
                lay1.Style.EnableOutline = true;

                lay1.MinVisible = item.MinVisible;
                lay1.MaxVisible = item.MaxVisible;
                lay1.Enabled = item.DbLayerModel.IsOpen;

                mapBoxMainWindow.Map.Layers.Add(lay1);
                //mapBox1.Map.ZoomToExtents();
                mapBoxMainWindow.Refresh();

                var addItem = new DbTableModelItem()
                {
                    Connection = item.DbLayerModel.Connection,
                    IsOpen = item.DbLayerModel.IsOpen,
                    TableName = item.DbLayerModel.TableName,
                    UniqColumnName = item.DbLayerModel.UniqColumnName
                };

                this.OpenedTables.Add(addItem);

                LoadLayerList();
            }
        }
    }
}
