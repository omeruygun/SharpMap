using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasarDemoDx.Helpers
{
    public enum DrawingTools
    {
        None = 0,
        Point = 1
    }
    public class ActiveCustomDrawingTool
    {
        public static DrawingTools Tool { get; set; } = DrawingTools.None;
    }
}
