using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    /// <summary>
    /// Добавить имя игрока и количество выстрелов в таблицу рекордов
    /// </summary>
    public partial class AddNameToStat : Form
    {
        private int _shotCount = 0;
        /// <summary>
        /// Конструктор
        /// </summary>
        public AddNameToStat()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Переопределенный конструктор с возможностью указания количества выстрелов
        /// </summary>
        /// <param name="ShotCount">Количество выстрелов</param>
        public AddNameToStat(int ShotCount)
        {
            InitializeComponent();
            _shotCount = ShotCount;
        }

        /// <summary>
        /// Сохранение достижения игрока в таблице рекордов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                RecordList.ReadFromFile();
                RecordList.Add(_shotCount, tbName.Text);
                RecordList.SaveToFile();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
