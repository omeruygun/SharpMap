using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasarDemoDx.Models
{
    public class WorkspaceLayerItem
    {
        public int Index { get; set; }
        public DbTableModelItem DbLayerModel { get; set; }
        public Color FillColor { get; set; }
        public Color OutlineColor { get; set; }
        public int PenWidth { get; set; }
        public double MaxVisible { get; set; }
        public double MinVisible { get; set; }
    }
}
