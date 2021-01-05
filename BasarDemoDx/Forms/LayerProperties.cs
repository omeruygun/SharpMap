using BasarDemoDx.Helpers;
using BasarDemoDx.Models;
using DevExpress.XtraEditors;
using SharpMap.Data;
using SharpMap.Data.Providers;
using SharpMap.Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasarDemoDx.Forms
{
    public partial class LayerProperties : XtraForm
    {
        public DbTableModelItem Table { get; set; }
        public LayerProperties()
        {
            InitializeComponent();
        }

        private void LayerProperties_Load(object sender, EventArgs e)
        {
            if (Table != null)
            {
                for (int i = 0; i < Program.mainForm.mapBoxMainWindow.Map.Layers.Count; i++)
                {
                    if (Program.mainForm.mapBoxMainWindow.Map.Layers[i].LayerName == Table.TableName)
                    {
                        ILayer layer = Program.mainForm.mapBoxMainWindow.Map.Layers[i];

                        this.Text = layer.LayerName + " Properties";

                        if (layer.MaxVisible == double.MaxValue)
                        {
                            spinEditMaxScale.Value = 10000000;
                        }
                        else
                        {
                            spinEditMaxScale.Value = (decimal)layer.MaxVisible;
                        }

                        spinEditMinScale.Value = (decimal)layer.MinVisible;

                        if (layer.GetType().Name == "VectorLayer")
                        {
                            var outlineStyle = (layer as VectorLayer).Style.Outline.Brush as SolidBrush;

                            colorPickEditOutlineColor.Color = outlineStyle.Color;

                            spinEditPenWidth.Value = (decimal)(layer as VectorLayer).Style.Outline.Width;

                            SolidBrush fillStyle = (layer as VectorLayer).Style.Fill as SolidBrush;

                            colorPickEditFillColor.Color = fillStyle.Color;

                        }


                        checkEditIsLayerVisible.Checked = Table.IsOpen;

                    }
                }
                ILayer _labelLayer = null;
                for (int i = 0; i < Program.mainForm.mapBoxMainWindow.Map.Layers.Count; i++)
                {
                    if (Program.mainForm.mapBoxMainWindow.Map.Layers[i].LayerName == Table.TableName + "-Label")
                    {
                        _labelLayer = Program.mainForm.mapBoxMainWindow.Map.Layers[i];
                    }
                }
                if (_labelLayer != null)
                {
                    if ((_labelLayer as LabelLayer).DataSource.GetType().Name == "ShapeFile")
                    {
                        var ds = (_labelLayer as LabelLayer).DataSource as ShapeFile;
                        FeatureDataRow row = ds.GetFeature(0);
                        List<ControlItemModel> lstColumns = new List<ControlItemModel>();
                        for (int i = 0; i < row.Table.Columns.Count; i++)
                        {
                            lstColumns.Add(new ControlItemModel()
                            {
                                Text=row.Table.Columns[i].ColumnName,
                                Value = row.Table.Columns[i].ColumnName
                            });
                        }
                        DxHelper.FillItems(comboBoxEditLabelColumn, lstColumns, "Choose...");
                    }else if ((_labelLayer as LabelLayer).DataSource.GetType().Name == "Oracle")
                    {
                        var ds = (_labelLayer as LabelLayer).DataSource as SharpMap.Data.Providers.Oracle;
                        FeatureDataRow row = ds.GetFeature(1);
                        List<ControlItemModel> lstColumns = new List<ControlItemModel>();
                        for (int i = 0; i < row.Table.Columns.Count; i++)
                        {
                            lstColumns.Add(new ControlItemModel()
                            {
                                Text = row.Table.Columns[i].ColumnName,
                                Value = row.Table.Columns[i].ColumnName
                            });
                        }
                        DxHelper.FillItems(comboBoxEditLabelColumn, lstColumns, "Choose...");
                    }
                }
            }
        }

        private void simpleButtonApply_Click(object sender, EventArgs e)
        {
            Brush outlineBrush = new SolidBrush(colorPickEditOutlineColor.Color);
            Brush fillBrush = new SolidBrush(colorPickEditFillColor.Color);

            if (Table != null)
            {
                for (int i = 0; i < Program.mainForm.mapBoxMainWindow.Map.Layers.Count; i++)
                {
                    if (Program.mainForm.mapBoxMainWindow.Map.Layers[i].LayerName == Table.TableName)
                    {
                        ILayer layer = Program.mainForm.mapBoxMainWindow.Map.Layers[i];

                        if (layer.GetType().Name == "VectorLayer")
                        {
                            (layer as VectorLayer).Style.Fill = fillBrush;
                            (layer as VectorLayer).Style.Outline.Brush = outlineBrush;
                            (layer as VectorLayer).Style.Outline.Width = (float)spinEditPenWidth.Value;
                        }

                        layer.MaxVisible = (double)spinEditMaxScale.Value;
                        layer.MinVisible = (double)spinEditMinScale.Value;
                    }
                }

                ILayer _labelLayer = null;
                for (int i = 0; i < Program.mainForm.mapBoxMainWindow.Map.Layers.Count; i++)
                {
                    if (Program.mainForm.mapBoxMainWindow.Map.Layers[i].LayerName == Table.TableName + "-Label")
                    {
                        _labelLayer = Program.mainForm.mapBoxMainWindow.Map.Layers[i];
                    }
                }
                if (_labelLayer != null)
                {
                    if ((_labelLayer as LabelLayer).DataSource.GetType().Name == "ShapeFile")
                    {
                        ControlItemModel selected = DxHelper.GetSelectedItem(comboBoxEditLabelColumn);
                        (_labelLayer as LabelLayer).LabelColumn = selected.Text;
                    }
                    else if ((_labelLayer as LabelLayer).DataSource.GetType().Name == "Oracle")
                    {
                        ControlItemModel selected = DxHelper.GetSelectedItem(comboBoxEditLabelColumn);
                        (_labelLayer as LabelLayer).LabelColumn = selected.Text;
                    }
                }

                Program.mainForm.mapBoxMainWindow.Refresh();
            }
        }
    }
}
