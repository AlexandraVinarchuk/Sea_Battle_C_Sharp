using System;
using System.Threading;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class frmSeaBattle : Form
    {
        bool IsGameOver = false;

        public frmSeaBattle()
        {
            InitializeComponent();
            ucMapEnemy.ShowMap();
            ucMapMy.IsVisible = true;
            ucMapMy.ShowMap();

        }

        private void ucMap1_Click(object sender, EventArgs e)
        {
            if (!IsGameOver && ucMapEnemy.x > 0 && ucMapEnemy.y > 0) // Проверка что игра не окончена и клик произведен именно по ячейке
            {
                ucMapEnemy.Enabled = false;
                Process(ucMapEnemy.x, ucMapEnemy.y);
                ucMapEnemy.Enabled = true;
            }
        }

        private void Process(int x, int y)
        {
            if (ucMapEnemy.Shot(ucMapEnemy.x - 1, ucMapEnemy.y - 1))
            {
                ucMapEnemy.ShowMap();
                ucMapEnemy.x = -1;
                ucMapEnemy.y = -1;
                Application.DoEvents();
                Thread.Sleep(500);
                if (ucMapEnemy.pole.ShipOnWater == 0)
                {
                    IsGameOver = true;
                    MessageBox.Show("Ура! Вы выиграли!");
                    AddNameToStat ants = new AddNameToStat(ucMapEnemy.pole.ShotCounter);
                    DialogResult dr = ants.ShowDialog();
                    StatForm statForm = new StatForm();
                    statForm.ShowDialog();
                }
                return;
            }
            ucMapEnemy.ShowMap();
            Application.DoEvents();
            Thread.Sleep(500);
            bool b = true;
            while (b)
            {
                b = ucMapMy.pole.Shot();
                ucMapMy.ShowMap();
                Application.DoEvents();
                Thread.Sleep(500);
                if (ucMapMy.pole.ShipOnWater == 0)
                {
                    IsGameOver = true;
                    MessageBox.Show("Вы проиграли");
                    StatForm statForm = new StatForm();
                    statForm.ShowDialog();
                    return;
                }
            }
        }

        private void Init()
        {
            IsGameOver = false;

            if (MessageBox.Show("Расставить корабли автоматически?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ucMapMy.pole.Ships();
            else
            {
                SetShipForm ssf = new SetShipForm();
                DialogResult dr = ssf.ShowDialog();
                if (dr == DialogResult.OK && ssf.pole != null)
                    ucMapMy.pole = ssf.pole;
                else return;
            }
            ucMapMy.IsVisible = true;
            ucMapMy.pole.ShipOnWater = 10;
            ucMapMy.pole.ShotCounter = 0;
            ucMapMy.ShowMap();

            ucMapEnemy.Enabled = true;
            ucMapEnemy.pole.Ships();
            ucMapEnemy.pole.ShipOnWater = 10;
            ucMapEnemy.pole.ShotCounter = 0;
            ucMapEnemy.ShowMap();
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Уверены?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void tsmiStatistics_Click(object sender, EventArgs e)
        {
            StatForm statForm = new StatForm();
            statForm.ShowDialog();
        }
    }
}
