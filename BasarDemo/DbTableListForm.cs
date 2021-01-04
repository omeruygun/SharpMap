using BasarDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasarDemo
{
    public partial class DbTableListForm : Form
    {
        public DbTableListForm()
        {
            InitializeComponent();
        }

        public List<DbTableModel> TableList { get; set; }

        private void DbTableListForm_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in checkedListBoxTables.CheckedItems)
            {

                var table = this.TableList.FirstOrDefault(async => async.TableName == item.ToString());

                Program.mainForm.AddDbLayer(table);

            }
        }
    }
}
