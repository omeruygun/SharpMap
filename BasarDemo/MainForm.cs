using BasarDemo.Models;
using GeoAPI.Geometries;
using NetTopologySuite.IO;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using OSGeo.OSR;
using SharpMap.Data.Providers;
using SharpMap.Forms;
using SharpMap.Forms.Tools;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SharpMap.Forms.MapBox;

namespace BasarDemo
{
    public partial class MainForm : Form
    {
        public List<DbTableModel> DbTableModels { get; set; } = new List<DbTableModel>();
        public string ConnectionStringPostgis { get; set; } = "Server = 172.16.11.129; Port = 5432; Database = SUDABIS_MESKI; User Id = sudabis_meski; Password = Basar2020*;";
        public string ConnectionStringOracle { get; set; } = "User Id=ENERYA;Password=ENERYA;Data Source=BASARORA2";
        public void AddDbLayer(DbTableModel table)
        {

            if (!IsLayerOpen(table.TableName))
            {
                string idColumn = "MI_PRINX";
                SharpMap.Layers.VectorLayer lay1 = new SharpMap.Layers.VectorLayer(table.TableName);
                switch (table.Db.DbType)
                {
                    case DbModelType.None:
                        break;
                    case DbModelType.Postgresql:
                        lay1.DataSource = new SharpMap.Data.Providers.PostGIS(Program.mainForm.ConnectionStringPostgis, table.TableName, idColumn);
                        break;
                    case DbModelType.Oracle:
                        lay1.DataSource = new SharpMap.Data.Providers.Oracle(Program.mainForm.ConnectionStringOracle, table.TableName, idColumn);
                        break;
                    case DbModelType.EsriShape:
                        lay1.DataSource = new SharpMap.Data.Providers.ShapeFile(table.Path);
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
                mapBox1.Map.Layers.Add(lay1);
                //mapBox1.Map.ZoomToExtents();
                mapBox1.Refresh();

                table.IsOpen = true;

                LoadLayerList();
            }
            
        }

        private bool IsLayerOpen(string tableName)
        {
            foreach (var item in mapBox1.Map.Layers)
            {
                if (item.LayerName == tableName)
                {
                    return true;
                }
            }
            return false;
        }

        public MainForm()
        {
            InitializeComponent();
            mapBox1.MapQueried += MapBox1_MapQueried;
            mapBox1.Map.LayerRendered += Map_LayerRendered;
            mapBox1.Map.MapRendered += Map_MapRendered;
            mapBox1.ActiveTool = Tools.Pan;
        }

        private void Map_MapRendered(Graphics g)
        {

        }

        private void Map_LayerRendered(object sender, EventArgs e)
        {

        }

        private void MapBox1_MapQueried(SharpMap.Data.FeatureDataTable data)
        {
            if (mapBox1.ActiveTool == Tools.QueryPoint || mapBox1.ActiveTool == Tools.Query)
            {
                InfoWindows form = new InfoWindows();
                form.tabControlMain.TabPages.Clear();
                form.Owner = this;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    TabPage page = new TabPage();
                    DataGridView grid = new DataGridView();
                    grid.Dock = DockStyle.Fill;
                    page.Controls.Add(grid);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("field", typeof(string));
                    dt.Columns.Add("value", typeof(string));

                    for (int x = 0; x < data.Columns.Count; x++)
                    {
                        var dr = dt.NewRow();
                        dr[0] = data.Columns[x].Caption;
                        dr[1] = data.Rows[i][x];

                        dt.Rows.Add(dr);
                    }
                    grid.DataSource = dt;

                    form.tabControlMain.TabPages.Add(page);
                    form.tabControlMain.TabPages[form.tabControlMain.TabPages.Count - 1].Text = data.TableName;
                }

                form.Show();
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            var osm = new SharpMap.Layers.TileLayer(
                      BruTile.Predefined.KnownTileSources.Create(
                          BruTile.Predefined.KnownTileSource.OpenStreetMap), "Osm");

            mapBox1.Map.Center = new Coordinate(3805545.6472164583, 4534423.3788634948);
            mapBox1.Map.Zoom = 778190;

            //mapBox1.Map.BackgroundLayer.Add(osm);
            mapBox1.Refresh();
        }

        private void readFromCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Filter = "Csv File |*.csv";
            file.Multiselect = false;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string FileName = file.SafeFileName.Replace(".csv", "");
                string FilePath = file.FileName;

                string encoding = "UTF-8";
                string seperator = "##";
                int index = 0;

                using (StreamReader reader = new StreamReader(FilePath, Encoding.GetEncoding(encoding)))
                {
                    DataTable dt = new DataTable();

                    var dtFeature = new SharpMap.Data.FeatureDataTable();

                    WKTReader wktreader = new WKTReader();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var data = line.Split(new string[] { seperator }, StringSplitOptions.None);

                        if (index == 0)
                        {
                            for (int i = 0; i < data.Length; i++)
                            {
                                dtFeature.Columns.Add(data[i], typeof(string));
                                dt.Columns.Add(data[i], typeof(string));
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            SharpMap.Data.FeatureDataRow drFeature = dtFeature.NewRow();

                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                dr[i] = data[i];

                                if (dt.Columns[i].Caption == "geom_wkt")
                                {
                                    drFeature[i] = data[i];
                                    if (!string.IsNullOrEmpty(data[i]))
                                    {
                                        IGeometry geom = wktreader.Read(data[i]);

                                        drFeature.Geometry = geom;
                                    }
                                }
                                else
                                {
                                    drFeature[i] = data[i];
                                }
                            }
                            dt.Rows.Add(dr);
                            dtFeature.Rows.Add(drFeature);
                        }

                        index++;
                    }

                    //Collection<IGeometry> geometry = new Collection<IGeometry>();
                    //VectorLayer layer = new VectorLayer(FileName);

                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    if (!string.IsNullOrEmpty(dt.Rows[i]["geom_wkt"].ToString()))
                    //    {
                    //        IGeometry geom = wktreader.Read(dt.Rows[i]["geom_wkt"].ToString());

                    //        geometry.Add(geom);
                    //    }
                    //}

                    var gfp = new GeometryFeatureProvider(dtFeature);

                    var layer = new SharpMap.Layers.VectorLayer(FileName, gfp);
                    layer.DataSource.SRID = 3857;

                    mapBox1.Map.Layers.Add(layer);

                    listBoxLayerList.Items.Add(FileName);

                    var labelLayer = new LabelLayer(FileName + "-Label");
                    labelLayer.DataSource = gfp;
                    labelLayer.LabelColumn = "kapi_kodu";

                    //mapBox1.Map.Layers.Add(labelLayer);

                    //var provider = new GeometryProvider(geometry);
                    //layer.DataSource = provider;
                    //layer.DataSource.SRID = 3857;

                    //mapBox1.Map.Layers.Add(layer);

                    mapBox1.Map.ZoomToExtents();
                    mapBox1.Refresh();
                }
            }
        }

        private void browseDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void shapeshpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            for (int i = 0; i < mapBox1.Map.Layers.Count; i++)
            {
                if (mapBox1.Map.Layers[i].LayerName == SelectedLayer)
                {
                    var layer = mapBox1.Map.Layers[i] as VectorLayer;

                    var dataSource = layer.DataSource as GeometryFeatureProvider;


                    for (int k = 0; k < dataSource.Features.Columns.Count; k++)
                    {
                        dt.Columns.Add(dataSource.Features.Columns[k].Caption);
                    }
                    for (int k = 0; k < dataSource.Features.Count; k++)
                    {
                        var row = dt.NewRow();
                        for (int x = 0; x < dataSource.Features.Columns.Count; x++)
                        {
                            row[x] = dataSource.Features[k][x];
                        }
                        dt.Rows.Add(row);
                    }
                }
            }
            BrowseForm form = new BrowseForm();
            form.dataGridView1.DataSource = dt;
            form.Owner = this;
            form.Show();
        }

        private void toolStripMenuItemZoomToLayer_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mapBox1.Map.Layers.Count; i++)
            {
                if (mapBox1.Map.Layers[i].LayerName == SelectedLayer)
                {
                    var env = mapBox1.Map.Layers[i].Envelope;

                    mapBox1.Map.ZoomToBox(env);
                    mapBox1.Refresh();
                }
            }
        }
        public string SelectedLayer { get; set; }
        private void listBoxLayerList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            var index = listBoxLayerList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                SelectedLayer = listBoxLayerList.Items[index].ToString();
                contextMenuStripLayerControl.Show(Cursor.Position);
                contextMenuStripLayerControl.Visible = true;
            }
            else
            {
                contextMenuStripLayerControl.Visible = false;
            }
        }

        private void mapInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mapBox1.Map.Layers.Count; i++)
            {
                if (mapBox1.Map.Layers[i].LayerName == SelectedLayer)
                {
                    var layer = mapBox1.Map.Layers[i] as VectorLayer;

                    var dataSource = layer.DataSource as GeometryFeatureProvider;

                    OSGeo.OGR.Driver driverSH = OSGeo.OGR.Ogr.GetDriverByName("MapInfo File");

                    var referance = new SpatialReference("PROJCS[\"WGS 84 / Pseudo-Mercator\",GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563,AUTHORITY[\"EPSG\",\"7030\"]],AUTHORITY[\"EPSG\",\"6326\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.0174532925199433,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4326\"]],PROJECTION[\"Mercator_1SP\"],PARAMETER[\"central_meridian\",0],PARAMETER[\"scale_factor\",1],PARAMETER[\"false_easting\",0],PARAMETER[\"false_northing\",0],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],AXIS[\"X\",EAST],AXIS[\"Y\",NORTH],EXTENSION[\"PROJ4\",\"+proj=merc +a=6378137 +b=6378137 +lat_ts=0.0 +lon_0=0.0 +x_0=0.0 +y_0=0 +k=1.0 +units=m +nadgrids=@null +wktext  +no_defs\"],AUTHORITY[\"EPSG\",\"3857\"]]");


                    OSGeo.OGR.DataSource dataSourceSH = driverSH.CreateDataSource(Application.StartupPath + "\\" + SelectedLayer + ".mif", new string[] { "ENCODING=UTF-8", "FORMAT=MIF" });


                    var layerSH = dataSourceSH.CreateLayer("PointLayer", referance, OSGeo.OGR.wkbGeometryType.wkbPoint, new string[] { "ENCODING=UTF-8", "FORMAT=MIF" });


                    layerSH.StartTransaction();

                    for (int k = 0; k < dataSource.Features.Columns.Count; k++)
                    {
                        OSGeo.OGR.FieldDefn field = new OSGeo.OGR.FieldDefn(dataSource.Features.Columns[k].Caption, OSGeo.OGR.FieldType.OFTString);


                        layerSH.CreateField(field, 1);
                    }

                    for (int k = 0; k < dataSource.Features.Rows.Count; k++)
                    {
                        OSGeo.OGR.Feature feature = new OSGeo.OGR.Feature(layerSH.GetLayerDefn());

                        if (!string.IsNullOrEmpty(dataSource.Features.Rows[k]["geom_wkt"].ToString()))
                        {
                            OSGeo.OGR.Geometry geom = OSGeo.OGR.Geometry.CreateFromWkt(dataSource.Features.Rows[k]["geom_wkt"].ToString());
                            feature.SetGeometry(geom);
                        }

                        for (int x = 0; x < dataSource.Features.Columns.Count; x++)
                        {
                            var data = dataSource.Features.Rows[k][x].ToString();

                            feature.SetField(dataSource.Features.Columns[x].Caption, data);
                        }
                        try
                        {
                            layerSH.CreateFeature(feature);
                            feature.Dispose();
                        }
                        catch (Exception)
                        {

                        }

                    }
                    layerSH.CommitTransaction();
                    layerSH.SyncToDisk();
                    layerSH.Dispose();

                    dataSourceSH.FlushCache();
                    dataSourceSH.Dispose();

                    driverSH.Dispose();
                }
            }
        }

        private void panToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = Tools.Pan;
        }

        [Obsolete]
        private void queryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = Tools.Query;
            mapBox1.MapQueryMode = MapQueryType.AllLayers;
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = Tools.ZoomIn;

        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = Tools.ZoomOut;
        }

        private void driverListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Driver Name (Short Name)", typeof(string));
            dt.Columns.Add("Driver Name (Long Name)", typeof(string));

            var driverCount = OSGeo.GDAL.Gdal.GetDriverCount();
            for (int i = 0; i < driverCount; i++)
            {
                var dr = dt.NewRow();
                dr[0] = OSGeo.GDAL.Gdal.GetDriver(i).ShortName;
                dr[1] = OSGeo.GDAL.Gdal.GetDriver(i).LongName;
                dt.Rows.Add(dr);
            }

            BrowseForm form = new BrowseForm();
            form.dataGridView1.DataSource = dt;
            form.Show();
        }

        private void kmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mapBox1.Map.Layers.Count; i++)
            {
                if (mapBox1.Map.Layers[i].LayerName == SelectedLayer)
                {
                    var layer = mapBox1.Map.Layers[i] as VectorLayer;

                    var dataSource = layer.DataSource as GeometryFeatureProvider;

                    OSGeo.OGR.Driver driverSH = OSGeo.OGR.Ogr.GetDriverByName("KML");



                    var referance = new SpatialReference("PROJCS[\"WGS 84 / Pseudo-Mercator\",GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563,AUTHORITY[\"EPSG\",\"7030\"]],AUTHORITY[\"EPSG\",\"6326\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.0174532925199433,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4326\"]],PROJECTION[\"Mercator_1SP\"],PARAMETER[\"central_meridian\",0],PARAMETER[\"scale_factor\",1],PARAMETER[\"false_easting\",0],PARAMETER[\"false_northing\",0],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],AXIS[\"X\",EAST],AXIS[\"Y\",NORTH],EXTENSION[\"PROJ4\",\"+proj=merc +a=6378137 +b=6378137 +lat_ts=0.0 +lon_0=0.0 +x_0=0.0 +y_0=0 +k=1.0 +units=m +nadgrids=@null +wktext  +no_defs\"],AUTHORITY[\"EPSG\",\"3857\"]]");


                    OSGeo.OGR.DataSource dataSourceSH = driverSH.CreateDataSource(Application.StartupPath + "\\" + SelectedLayer + ".kml", new string[] { "ENCODING=UTF-16" });


                    var layerSH = dataSourceSH.CreateLayer("PointLayer", referance, OSGeo.OGR.wkbGeometryType.wkbPoint, new string[] { "ENCODING=UTF-16" });


                    layerSH.StartTransaction();

                    for (int k = 0; k < dataSource.Features.Columns.Count; k++)
                    {
                        OSGeo.OGR.FieldDefn field = new OSGeo.OGR.FieldDefn(dataSource.Features.Columns[k].Caption, OSGeo.OGR.FieldType.OFTString);


                        layerSH.CreateField(field, 1);
                    }

                    for (int k = 0; k < dataSource.Features.Rows.Count; k++)
                    {
                        OSGeo.OGR.Feature feature = new OSGeo.OGR.Feature(layerSH.GetLayerDefn());

                        if (!string.IsNullOrEmpty(dataSource.Features.Rows[k]["geom_wkt"].ToString()))
                        {
                            OSGeo.OGR.Geometry geom = OSGeo.OGR.Geometry.CreateFromWkt(dataSource.Features.Rows[k]["geom_wkt"].ToString());
                            feature.SetGeometry(geom);
                        }

                        for (int x = 0; x < dataSource.Features.Columns.Count; x++)
                        {
                            var data = dataSource.Features.Rows[k][x].ToString();

                            feature.SetField(dataSource.Features.Columns[x].Caption, data);
                        }
                        try
                        {
                            layerSH.CreateFeature(feature);
                            feature.Dispose();
                        }
                        catch (Exception)
                        {

                        }

                    }
                    layerSH.CommitTransaction();
                    layerSH.SyncToDisk();
                    layerSH.Dispose();

                    dataSourceSH.FlushCache();
                    dataSourceSH.Dispose();

                    driverSH.Dispose();
                }
            }
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mapBox1.Map.Layers.Count; i++)
            {
                if (mapBox1.Map.Layers[i].LayerName == SelectedLayer)
                {
                    var layer = mapBox1.Map.Layers[i] as VectorLayer;

                    var dataSource = layer.DataSource as GeometryFeatureProvider;

                    OSGeo.OGR.Driver driverSH = OSGeo.OGR.Ogr.GetDriverByName("PNG");



                    var referance = new SpatialReference("PROJCS[\"WGS 84 / Pseudo-Mercator\",GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563,AUTHORITY[\"EPSG\",\"7030\"]],AUTHORITY[\"EPSG\",\"6326\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.0174532925199433,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4326\"]],PROJECTION[\"Mercator_1SP\"],PARAMETER[\"central_meridian\",0],PARAMETER[\"scale_factor\",1],PARAMETER[\"false_easting\",0],PARAMETER[\"false_northing\",0],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],AXIS[\"X\",EAST],AXIS[\"Y\",NORTH],EXTENSION[\"PROJ4\",\"+proj=merc +a=6378137 +b=6378137 +lat_ts=0.0 +lon_0=0.0 +x_0=0.0 +y_0=0 +k=1.0 +units=m +nadgrids=@null +wktext  +no_defs\"],AUTHORITY[\"EPSG\",\"3857\"]]");


                    OSGeo.OGR.DataSource dataSourceSH = driverSH.CreateDataSource(Application.StartupPath + "\\" + SelectedLayer + ".png", new string[] { "ENCODING=UTF-16" });


                    var layerSH = dataSourceSH.CreateLayer("PointLayer", referance, OSGeo.OGR.wkbGeometryType.wkbPoint, new string[] { "ENCODING=UTF-16" });


                    layerSH.StartTransaction();

                    for (int k = 0; k < dataSource.Features.Columns.Count; k++)
                    {
                        OSGeo.OGR.FieldDefn field = new OSGeo.OGR.FieldDefn(dataSource.Features.Columns[k].Caption, OSGeo.OGR.FieldType.OFTString);


                        layerSH.CreateField(field, 1);
                    }

                    for (int k = 0; k < dataSource.Features.Rows.Count; k++)
                    {
                        OSGeo.OGR.Feature feature = new OSGeo.OGR.Feature(layerSH.GetLayerDefn());

                        if (!string.IsNullOrEmpty(dataSource.Features.Rows[k]["geom_wkt"].ToString()))
                        {
                            OSGeo.OGR.Geometry geom = OSGeo.OGR.Geometry.CreateFromWkt(dataSource.Features.Rows[k]["geom_wkt"].ToString());
                            feature.SetGeometry(geom);
                        }

                        for (int x = 0; x < dataSource.Features.Columns.Count; x++)
                        {
                            var data = dataSource.Features.Rows[k][x].ToString();

                            feature.SetField(dataSource.Features.Columns[x].Caption, data);
                        }
                        try
                        {
                            layerSH.CreateFeature(feature);
                            feature.Dispose();
                        }
                        catch (Exception)
                        {

                        }

                    }
                    layerSH.CommitTransaction();
                    layerSH.SyncToDisk();
                    layerSH.Dispose();

                    dataSourceSH.FlushCache();
                    dataSourceSH.Dispose();

                    driverSH.Dispose();
                }
            }
        }

        private void pdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mapBox1.Map.Layers.Count; i++)
            {
                if (mapBox1.Map.Layers[i].LayerName == SelectedLayer)
                {
                    var layer = mapBox1.Map.Layers[i] as VectorLayer;

                    var dataSource = layer.DataSource as GeometryFeatureProvider;

                    OSGeo.OGR.Driver driverSH = OSGeo.OGR.Ogr.GetDriverByName("PDF");



                    var referance = new SpatialReference("PROJCS[\"WGS 84 / Pseudo-Mercator\",GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563,AUTHORITY[\"EPSG\",\"7030\"]],AUTHORITY[\"EPSG\",\"6326\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.0174532925199433,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4326\"]],PROJECTION[\"Mercator_1SP\"],PARAMETER[\"central_meridian\",0],PARAMETER[\"scale_factor\",1],PARAMETER[\"false_easting\",0],PARAMETER[\"false_northing\",0],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],AXIS[\"X\",EAST],AXIS[\"Y\",NORTH],EXTENSION[\"PROJ4\",\"+proj=merc +a=6378137 +b=6378137 +lat_ts=0.0 +lon_0=0.0 +x_0=0.0 +y_0=0 +k=1.0 +units=m +nadgrids=@null +wktext  +no_defs\"],AUTHORITY[\"EPSG\",\"3857\"]]");


                    OSGeo.OGR.DataSource dataSourceSH = driverSH.CreateDataSource(Application.StartupPath + "\\" + SelectedLayer + ".pdf", new string[] { "ENCODING=UTF-16" });


                    var layerSH = dataSourceSH.CreateLayer("PointLayer", referance, OSGeo.OGR.wkbGeometryType.wkbPoint, new string[] { "ENCODING=UTF-16" });


                    layerSH.StartTransaction();

                    for (int k = 0; k < dataSource.Features.Columns.Count; k++)
                    {
                        OSGeo.OGR.FieldDefn field = new OSGeo.OGR.FieldDefn(dataSource.Features.Columns[k].Caption, OSGeo.OGR.FieldType.OFTString);


                        layerSH.CreateField(field, 1);
                    }

                    for (int k = 0; k < dataSource.Features.Rows.Count; k++)
                    {
                        OSGeo.OGR.Feature feature = new OSGeo.OGR.Feature(layerSH.GetLayerDefn());

                        if (!string.IsNullOrEmpty(dataSource.Features.Rows[k]["geom_wkt"].ToString()))
                        {
                            OSGeo.OGR.Geometry geom = OSGeo.OGR.Geometry.CreateFromWkt(dataSource.Features.Rows[k]["geom_wkt"].ToString());
                            feature.SetGeometry(geom);
                        }

                        for (int x = 0; x < dataSource.Features.Columns.Count; x++)
                        {
                            var data = dataSource.Features.Rows[k][x].ToString();

                            feature.SetField(dataSource.Features.Columns[x].Caption, data);
                        }
                        try
                        {
                            layerSH.CreateFeature(feature);
                            feature.Dispose();
                        }
                        catch (Exception)
                        {

                        }

                    }
                    layerSH.CommitTransaction();
                    layerSH.SyncToDisk();
                    layerSH.Dispose();

                    dataSourceSH.FlushCache();
                    dataSourceSH.Dispose();

                    driverSH.Dispose();
                }
            }
        }

        private void drawPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = Tools.DrawPoint;
        }

        private void bMPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bMPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapBox1.Map.GetMap().Save(Application.StartupPath + "\\Map.bmp", ImageFormat.Bmp);
        }

        private void pointStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mapBox1.Map.Layers.Count; i++)
            {
                if (mapBox1.Map.Layers[i].LayerName == SelectedLayer)
                {
                    var layer = mapBox1.Map.Layers[i] as VectorLayer;

                    PointSymbolForm form = new PointSymbolForm();

                    form.colorDialog1.Color = new Pen(layer.Style.PointColor).Color;

                    form.Owner = this;
                    form.ShowDialog();

                    layer.Style.PointColor = new SolidBrush(form.colorDialog1.Color);
                    mapBox1.Refresh();
                }
            }
        }

        private void ınfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapBox1.ActiveTool = Tools.QueryPoint;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILayer layer = null;
            for (int i = 0; i < mapBox1.Map.Layers.Count; i++)
            {
                if (mapBox1.Map.Layers[i].LayerName == SelectedLayer)
                {
                    layer = mapBox1.Map.Layers[i] as VectorLayer;
                }
            }
            if (layer != null)
            {
                mapBox1.Map.Layers.Remove(layer);
                mapBox1.Refresh();

                LoadLayerList();
            }
        }

        private void LoadLayerList()
        {
            listBoxLayerList.Items.Clear();
            SelectedLayer = null;
            for (int i = 0; i < mapBox1.Map.Layers.Count; i++)
            {
                listBoxLayerList.Items.Add(mapBox1.Map.Layers[i].LayerName);
            }
        }

        private void postgresqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbTableListForm form = new DbTableListForm();

            using (NpgsqlConnection cnn = new NpgsqlConnection(this.ConnectionStringPostgis))
            {
                cnn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT f_table_name FROM geometry_columns where f_table_name like '%_geo_%'", cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<DbTableModel> lst = new List<DbTableModel>();
                foreach (DataRow row in dt.Rows)
                {
                    lst.Add(new DbTableModel()
                    {
                        TableName = row[0].ToString(),
                        Db = new DbModel()
                        {
                            ConnectionString = this.ConnectionStringPostgis,
                            DbType = DbModelType.Postgresql,
                            Guid = Guid.NewGuid().ToString()
                        }
                    });
                }

                foreach (var item in lst)
                {
                    if (!this.DbTableModels.Any(a => a.TableName == item.TableName && a.Db.ConnectionString == item.Db.ConnectionString))
                    {
                        this.DbTableModels.Add(item);
                    }
                }

            }

            form.checkedListBoxTables.Items.Clear();
            foreach (var item in this.DbTableModels.Where(a => a.Db.DbType == DbModelType.Postgresql).ToList())
            {
                form.checkedListBoxTables.Items.Add(item.TableName, item.IsOpen);
            }
            form.TableList = this.DbTableModels.Where(a => a.Db.DbType == DbModelType.Postgresql).ToList();

            form.Owner = this;
            form.Show();
        }

        private void oracleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbTableListForm form = new DbTableListForm();

            using (OracleConnection cnn = new OracleConnection(this.ConnectionStringOracle))
            {
                cnn.Open();
                OracleDataAdapter da = new OracleDataAdapter("Select table_name from user_tables where table_name like '%_GEO_%' order by table_name", cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<DbTableModel> lst = new List<DbTableModel>();
                foreach (DataRow row in dt.Rows)
                {
                    lst.Add(new DbTableModel()
                    {
                        TableName = row[0].ToString(),
                        Db = new DbModel()
                        {
                            ConnectionString = this.ConnectionStringPostgis,
                            DbType = DbModelType.Oracle,
                            Guid = Guid.NewGuid().ToString()
                        }
                    });
                }

                foreach (var item in lst)
                {
                    if (!this.DbTableModels.Any(a => a.TableName == item.TableName && a.Db.ConnectionString == item.Db.ConnectionString))
                    {
                        this.DbTableModels.Add(item);
                    }
                }

            }

            form.checkedListBoxTables.Items.Clear();
            foreach (var item in this.DbTableModels.Where(a => a.Db.DbType == DbModelType.Oracle).ToList())
            {
                form.checkedListBoxTables.Items.Add(item.TableName, item.IsOpen);
            }
            form.TableList = this.DbTableModels.Where(a => a.Db.DbType == DbModelType.Oracle).ToList();

            form.Owner = this;
            form.Show();
        }
    }
}
