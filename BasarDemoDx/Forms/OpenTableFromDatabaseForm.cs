using BasarDemoDx.Helpers;
using BasarDemoDx.Models;
using DevExpress.XtraEditors;
using Oracle.ManagedDataAccess.Client;
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
    public partial class OpenTableFromDatabaseForm : XtraForm
    {
        public OpenTableFromDatabaseForm()
        {
            InitializeComponent();
        }

        private void OpenTableFromDatabaseForm_Load(object sender, EventArgs e)
        {
            var data = AppHelper.GetSavedConnections().OrderBy(a => a.Alias).ToList();
            var lstConnections = new List<ControlItemModel>();
            foreach (var item in data)
            {
                lstConnections.Add(new ControlItemModel()
                {
                    Text = item.Alias + " (" + item.HostOrIp + ")",
                    Value = item.Id
                });
            }
            DxHelper.FillItems(comboBoxEditSavedConnection, lstConnections, "Choose...");
        }

        private void comboBoxEditSavedConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = DxHelper.GetSelectedItem(comboBoxEditSavedConnection);
            treeListTableList.DataSource = null;
            if (selected.Value.ToString() != "-1")
            {
                var list = new List<DbTableModelItem>();
                var connection = AppHelper.GetSavedConnections().FirstOrDefault(a => a.Id == selected.Value.ToString());
                if (connection.DatabaseType == Models.DbType.Oracle)
                {
                    string _connectionString = "User Id=" + connection.Username + ";Password=" + connection.Password + ";Data Source=" + connection.HostOrIp + ";";
                    using (OracleConnection cnn = new OracleConnection(_connectionString))
                    {
                        cnn.Open();
                        OracleDataAdapter da = new OracleDataAdapter("Select table_name from user_tables where table_name like '%_GEO_%' order by table_name", cnn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            list.Add(new DbTableModelItem()
                            {
                                Connection = connection,
                                IsOpen = Program.mainForm.OpenedTables.Any(async => async.TableName == dt.Rows[i][0].ToString() && async.Connection.Id == connection.Id),
                                TableName = dt.Rows[i][0].ToString()
                            });
                        }

                    }
                }
                treeListTableList.DataSource = list;
            }
        }

        private void simpleButtonOpen_Click(object sender, EventArgs e)
        {
            var data = treeListTableList.DataSource as List<DbTableModelItem>;
            if (data != null)
            {
                var selected = data.Where(a => a.IsOpen).ToList();
                foreach (var item in selected)
                {
                    Program.mainForm.OpenTable(item);
                }
            }
            this.Close();
        }
    }
}
