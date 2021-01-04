using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasarDemo.Models
{
    public class DbTableModel
    {
        public string TableName { get; set; }
        public DbModel Db { get; set; } = new DbModel();
        public bool IsOpen { get; set; }
    }
    public class DbModel
    {
        public string ConnectionString { get; set; }
        public string Guid { get; set; } = new Guid().ToString();
        public DbModelType DbType { get; set; }
    }
    public enum DbModelType
    {
        None = 0,
        Postgresql = 1,
        Oracle = 2
    }
}
