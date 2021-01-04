using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasarDemoDx.Models
{
    public class WorkspaceModel
    {
        public List<WorkspaceLayerItem> Layers { get; set; } = new List<WorkspaceLayerItem>();
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double Scale { get; set; }
    }
}
