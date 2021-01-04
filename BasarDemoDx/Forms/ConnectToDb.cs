using BasarDemoDx.Helpers;
using BasarDemoDx.Models;
using DevExpress.XtraEditors;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasarDemoDx.Forms
{
    public partial class ConnectToDb : XtraForm
    {
        private string _selectedConnectionId { get; set; }
        public ConnectToDb()
        {
            InitializeComponent();
        }

        private void simpleButtonConnect_Click(object sender, EventArgs e)
        {

            if (xtraTabControlMain.SelectedTabPageIndex == 0) // Postgresql
            {
                var model = new DbConnectionModel();
                model.Alias = textEditAliasPostgres.Text.Trim();
                model.Database = textEditDatabasePostgres.Text.Trim();
                model.HostOrIp = textEditHostOrIPPostgres.Text.Trim();
                model.Password = textEditPasswordPostgres.Text.Trim();
                model.Port = int.Parse(textEditPortPostgres.Text.Trim());
                model.Username = textEditUsernamePostgres.Text.Trim();

                string _connectionString = "Server = " + model.HostOrIp + "; Port = " + model.Port + "; Database = " + model.Database + "; User Id = " + model.Username + "; Password = " + model.Password + ";";
                try
                {
                    using (NpgsqlConnection cnn = new NpgsqlConnection(_connectionString))
                    {
                        cnn.Open();
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter("Select 1", cnn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            if (toggleSwitchSaveConnectionPostgres.IsOn)
                            {
                                if (!string.IsNullOrEmpty(_selectedConnectionId))
                                {
                                    AppHelper.RemoveConnection(_selectedConnectionId);
                                }
                                model.DatabaseType = Models.DbType.PostgreSQL;
                                AppHelper.SaveConnection(model);
                                this.Close();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Cannot connect to database. Please check");
                            this.DialogResult = DialogResult.None;
                        }
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Cannot connect to database. Please check");
                    this.DialogResult = DialogResult.None;
                }

            }
            else if (xtraTabControlMain.SelectedTabPageIndex == 1) // Oracle
            {
                var tns = DxHelper.GetSelectedItem(comboBoxEditTnsNamesOracle);
                if (tns.Value.ToString() != "-1")
                {
                    var model = new DbConnectionModel();
                    model.Alias = textEditAliasOracle.Text.Trim();
                    model.HostOrIp = tns.Text.Trim();
                    model.Password = textEditPasswordOracle.Text.Trim();
                    model.Username = textEditUsernameOracle.Text.Trim();

                    string _connectionString = "User Id=" + model.Username + ";Password=" + model.Password + ";Data Source=" + model.HostOrIp + ";";
                    try
                    {
                        using (OracleConnection cnn = new OracleConnection(_connectionString))
                        {
                            cnn.Open();
                            OracleDataAdapter da = new OracleDataAdapter("Select 1 from dual", cnn);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                if (toggleSwitchIsSaveConnectionOracle.IsOn)
                                {
                                    if (!string.IsNullOrEmpty(_selectedConnectionId))
                                    {
                                        AppHelper.RemoveConnection(_selectedConnectionId);
                                    }
                                    model.DatabaseType = Models.DbType.Oracle;
                                    AppHelper.SaveConnection(model);
                                    this.Close();
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("Cannot connect to database. Please check");
                                this.DialogResult = DialogResult.None;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Cannot connect to database. Please check");
                        this.DialogResult = DialogResult.None;
                    }
                }

            }
        }

        private void simpleButtonIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConnectToDb_Load(object sender, EventArgs e)
        {
            var data = AppHelper.GetSavedConnections().OrderBy(a => a.Alias).ToList();

            var lstPostgres = new List<ControlItemModel>();
            foreach (var item in data.Where(a => a.DatabaseType == Models.DbType.PostgreSQL))
            {
                lstPostgres.Add(new ControlItemModel()
                {
                    Text = item.Alias + " (" + item.HostOrIp + ")",
                    Value = item.Id
                });
            }
            DxHelper.FillItems(comboBoxEditSavedConnectionPostgres, lstPostgres, "Choose...");

            var lstOracle = new List<ControlItemModel>();
            foreach (var item in data.Where(a => a.DatabaseType == Models.DbType.Oracle))
            {
                lstOracle.Add(new ControlItemModel()
                {
                    Text = item.Alias + " (" + item.HostOrIp + ")",
                    Value = item.Id
                });
            }
            DxHelper.FillItems(comboBoxEditSavedConnectionOracle, lstOracle, "Choose...");

            var tnsAdmin = Environment.GetEnvironmentVariable("TNS_ADMIN");

            if (!string.IsNullOrEmpty(tnsAdmin))
            {
                using (StreamReader reader = new StreamReader(tnsAdmin + "\\tnsnames.ora"))
                {
                    var connections = reader.ReadToEnd();
                    var tnsNames = new List<ControlItemModel>();
                    foreach (Match m in Regex.Matches(connections, AppHelper.TnsRegexParsers))
                    {
                        string name = m.Groups["name"].Value;
                        tnsNames.Add(new ControlItemModel()
                        {
                            Text = name,
                            Value = name
                        });
                    }
                    DxHelper.FillItems(comboBoxEditTnsNamesOracle, tnsNames.OrderBy(a => a.Text).ToList(), "Choose...");
                }
            }
        }

        private void comboBoxEditSavedConnectionPostgres_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedConnectionId = string.Empty;

            textEditAliasPostgres.Text = string.Empty;
            textEditDatabasePostgres.Text = string.Empty;
            textEditHostOrIPPostgres.Text = string.Empty;
            textEditPasswordPostgres.Text = string.Empty;
            textEditPortPostgres.Text = "5432";
            textEditUsernamePostgres.Text = string.Empty;


            var secili = DxHelper.GetSelectedItem(comboBoxEditSavedConnectionPostgres);

            if (secili.Value.ToString() != "-1")
            {
                var data = AppHelper.GetSavedConnections(true).FirstOrDefault(a => a.Id == secili.Value.ToString());
                if (data != null)
                {
                    textEditAliasPostgres.Text = data.Alias;
                    textEditDatabasePostgres.Text = data.Database;
                    textEditHostOrIPPostgres.Text = data.HostOrIp;
                    textEditPasswordPostgres.Text = data.Password;
                    textEditPortPostgres.Text = data.Port.ToString();
                    textEditUsernamePostgres.Text = data.Username;
                    _selectedConnectionId = data.Id;
                }
            }
        }

        private void comboBoxEditSavedConnectionOracle_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedConnectionId = string.Empty;

            textEditAliasPostgres.Text = string.Empty;
            textEditHostOrIPPostgres.Text = string.Empty;
            textEditPasswordOracle.Text = string.Empty;
            textEditUsernameOracle.Text = string.Empty;


            var secili = DxHelper.GetSelectedItem(comboBoxEditSavedConnectionOracle);

            if (secili.Value.ToString() != "-1")
            {
                var data = AppHelper.GetSavedConnections(true).FirstOrDefault(a => a.Id == secili.Value.ToString());
                if (data != null)
                {
                    textEditAliasOracle.Text = data.Alias;
                    DxHelper.SetSelectedValue(comboBoxEditTnsNamesOracle, data.HostOrIp);
                    textEditUsernameOracle.Text = data.Username;
                    textEditPasswordOracle.Text = data.Password;
                    _selectedConnectionId = data.Id;
                }
            }
        }
    }
}
