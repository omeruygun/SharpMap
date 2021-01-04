using BasarDemoDx.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasarDemoDx.Helpers
{
    public class AppHelper
    {
        private static string _connectionDataPath { get; } = Application.StartupPath + "/App_Data/connections.json";
        public static string TnsRegexParsers { get; } = @"(?imsx)
^(?<name>\S+)\s*=
(?=.*?\(HOST\s*=\s*(?<host>\S+?)\))
(?=.*?\(PORT\s*=\s*(?<port>\S+?)\))
(?=.*?\(SERVICE_NAME\s*=\s*(?<service_name>\S+?)\))
";
        private static List<DbConnectionModel> _savedConnections { get; set; }
        public static List<DbConnectionModel> GetSavedConnections(bool forceRefreshFromFile = false)
        {
            List<DbConnectionModel> lst = new List<DbConnectionModel>();

            if (_savedConnections == null || _savedConnections.Count <= 0 || forceRefreshFromFile)
            {
                _savedConnections = new List<DbConnectionModel>();

                if (!Directory.Exists(Application.StartupPath + "/App_Data"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "/App_Data");
                }

                if (File.Exists(_connectionDataPath))
                {
                    using (StreamReader reader = new StreamReader(_connectionDataPath))
                    {
                        var _text = reader.ReadToEnd();
                        _savedConnections = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DbConnectionModel>>(_text);
                    }
                }
            }

            foreach (var item in _savedConnections)
            {
                lst.Add(new DbConnectionModel()
                {
                    Alias = item.Alias,
                    Database = item.Database,
                    HostOrIp = item.HostOrIp,
                    Password = item.Password,
                    Port = item.Port,
                    Username = item.Username,
                    Id = item.Id,
                    DatabaseType = item.DatabaseType
                });
            }

            return lst;
        }
        public static void SaveConnection(DbConnectionModel model)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                model.Id = Guid.NewGuid().ToString();
            }

            if (_savedConnections == null)
            {
                _savedConnections = new List<DbConnectionModel>();
            }
            if (!_savedConnections.Any(a => a.Id == model.Id))
            {
                _savedConnections.Add(model);
            }
            var _text = Newtonsoft.Json.JsonConvert.SerializeObject(_savedConnections);
            using (StreamWriter writer = new StreamWriter(_connectionDataPath, false))
            {
                writer.Write(_text);
            }
        }
        public static void RemoveConnection(string guid)
        {
            if (_savedConnections != null)
            {
                var data = _savedConnections.FirstOrDefault(a => a.Id == guid);
                if (data != null)
                {
                    _savedConnections.Remove(data);
                    var _text = Newtonsoft.Json.JsonConvert.SerializeObject(_savedConnections);
                    using (StreamWriter writer = new StreamWriter(_connectionDataPath, false))
                    {
                        writer.Write(_text);
                    }
                }
            }
        }
    }
}
