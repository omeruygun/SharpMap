using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasarDemoDx.Models
{
    public class DbConnectionModel
    {
        public string Alias { get; set; }
        public string HostOrIp { get; set; }
        public int Port { get; set; } = 5432;
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }
        [JsonProperty("DatabaseType")]
        public DbType DatabaseType { get; set; }
    }
    public enum DbType
    {
        None = 0,
        PostgreSQL = 1,
        Oracle = 2,
        EsriShape = 3,
        MapInfo = 4
    }
}
