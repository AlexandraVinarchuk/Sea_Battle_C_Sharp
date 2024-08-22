using System;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class StatForm : Form
    {
        public StatForm()
        {
            InitializeComponent();
        }

        private void StatForm_Load(object sender, EventArgs e)
        {
            RecordList.ReadFromFile();
            foreach (var item in RecordList.Records)
            {
                dataGridView1.Rows.Add(item.Value, item.Key);
            }
        }
    }
}
