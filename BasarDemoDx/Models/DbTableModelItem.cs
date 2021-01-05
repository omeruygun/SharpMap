using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasarDemoDx.Models
{
    public class DbTableModelItem
    {
        public bool IsOpen { get; set; }
        public string TableName { get; set; }
        public DbConnectionModel Connection { get; set; }
        public string UniqColumnName { get; set; } = "MI_PRINX";
        public bool IsLive { get; set; } = true;
        public string SavePath { get; set; }
        public bool IsLabelOpen { get; internal set; }
    }
}
