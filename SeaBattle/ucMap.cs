using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class ucMap : UserControl
    {
        public Pole pole = new Pole();
        public int x = -1;
        public int y = -1;
        public bool IsVisible = false;

        public ucMap()
        {
            InitializeComponent();
            int i = 0;
            for (int ix = 1; ix <= 10; ix++)
            {
                Label lb = new Label();
                lb.Text = ix.ToString();
                lb.Size = new Size(30, 20);
                lb.BorderStyle = BorderStyle.None;
                lb.Location = new Point(i * 30 + 40, 10);
                this.Controls.Add(lb);
                i++;
            }
            i = 0;
            for (char ch = 'A'; ch <= 'J'; ch++)
            {
                Label lb = new Label();
                lb.Text = ch.ToString();
                lb.Size = new Size(20, 20);
                lb.BorderStyle = BorderStyle.None;
                lb.Location = new Point(10, i * 30 + 40);
                this.Controls.Add(lb);
                i++;
            }

            Panel p = new Panel();
            p.Name = "pImages";
            p.Location = new Point(30, 30);
            p.Size = new Size(300, 300);
            this.Controls.Add(p);

            for (int iy = 1; iy <= 10; iy++)
                for (int ix = 1; ix <= 10; ix++)
                {
                    PictureBox pb = new PictureBox();
                    pb.Name = "pb_" + ix + "x" + iy; 
                    pb.Image = Properties.Resources.empty;
                    pb.Size = new Size(30, 30);
                    pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.Location = new Point((ix - 1) * 30, (iy - 1) * 30);
                    p.Controls.Add(pb);
                }
            Panel p2 = new Panel();
            p2.Name = "pInfo";
            p2.Location = new Point(10, 340);
            p2.Size = new Size(330, 50);
            this.Controls.Add(p2);

            Label shotcounter = new Label();
            shotcounter.Name = "lbShotCounter";
            shotcounter.Text = "Произведено выстрелов: ";
            shotcounter.Location = new Point(0, 0);
            shotcounter.Size = new Size(330, 20);
            p2.Controls.Add(shotcounter);

            Label shiponwater = new Label();
            shiponwater.Name = "lbShipOnWater";
            shiponwater.Text = "Осталось кораблей: ";
            shiponwater.Location = new Point(0, 30);
            shiponwater.Size = new Size(330, 20);
            p2.Controls.Add(shiponwater);

            this.Size = new Size(330, 330);
            if (!IsVisible) WireAllControls(this);
        }

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ucMap_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }

        private void ucMap_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(PictureBox))
            {
                PictureBox pb = sender as PictureBox;
                var coord = pb.Name.Remove(0, 3).Split('x'); 
                x = int.Parse(coord[0]);
                y = int.Parse(coord[1]);
                this.OnClick(e);
            }
            else
            {
                x = -1;
                y = -1;
            }
            
        }

        public bool Shot(int x, int y)
        {
            return pole.Shot(x, y);
        }

        public void SetShotCounter(int cnt)
        {
            var p = this.Controls.Find("pInfo", false);
            if (p.Length <= 0) return;
            var l = p[0].Controls.Find("lbShotCounter", false);
            if (l.Length <= 0) return;
            l[0].Text = "Произведено выстрелов: " + cnt;
        }

        public void SetShipOnWater(int cnt)
        {
            var p = this.Controls.Find("pInfo", false);
            if (p.Length <= 0) return;
            var l = p[0].Controls.Find("lbShipOnWater", false);
            if (l.Length <= 0) return;
            l[0].Text = "Осталось кораблей: " + cnt;
        }

        public void ShowMap()
        {
            var p = this.Controls.Find("pImages", false);
            if (p.Length <= 0) return;
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    var pbs = p[0].Controls.Find("pb_" + i + "x" + j, false);
                    if (pbs.Length > 0)
                    {
                        var cell = pole.getMap()[i -1, j - 1];
                        switch (cell)
                        {
                            case 'o': // В ячейке находится корабль
                                if (IsVisible) ((PictureBox)pbs[0]).Image = Properties.Resources.ship; // для своей карты отрисовка корабля
                                else ((PictureBox)pbs[0]).Image = Properties.Resources.empty; // для карты противника пустая ячейка 
                                break;
                            case ' ': // В ячейке ничего нет
                                ((PictureBox)pbs[0]).Image = Properties.Resources.empty;
                                break;
                            case 'V': // По этой ячейке уже был произведен выстрел
                                ((PictureBox)pbs[0]).Image = Properties.Resources.bulk;
                                break;
                            case 'X': // В ячейке находится подбитый корабль
                                ((PictureBox)pbs[0]).Image = Properties.Resources.drop;
                                break;
                            case '.': // Заведомо пустая ячейка
                                ((PictureBox)pbs[0]).Image = Properties.Resources.around;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            SetShotCounter(pole.ShotCounter);
            SetShipOnWater(pole.ShipOnWater);
        }
    }
}
