
namespace BasarDemo
{
    partial class DbTableListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBoxTables = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checkedListBoxTables
            // 
            this.checkedListBoxTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxTables.FormattingEnabled = true;
            this.checkedListBoxTables.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxTables.Name = "checkedListBoxTables";
            this.checkedListBoxTables.Size = new System.Drawing.Size(195, 450);
            this.checkedListBoxTables.TabIndex = 0;
            this.checkedListBoxTables.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxTables_SelectedIndexChanged);
            // 
            // DbTableListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 450);
            this.Controls.Add(this.checkedListBoxTables);
            this.Name = "DbTableListForm";
            this.Text = "DbTableListForm";
            this.Load += new System.EventHandler(this.DbTableListForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckedListBox checkedListBoxTables;
    }
}