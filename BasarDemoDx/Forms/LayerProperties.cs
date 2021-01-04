using BasarDemoDx.Models;
using DevExpress.XtraEditors;
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
                Program.mainForm.mapBoxMainWindow.Refresh();
            }
        }
    }
}
