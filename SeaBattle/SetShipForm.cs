using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class SetShipForm : Form
    {
        public Pole pole = new Pole();
        List<int> Ships = new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
        bool dragging = false;
        private bool GoNext = false;
        private bool IsClosing = false;
        Point startPoint = new Point();
        public SetShipForm()
        {
            InitializeComponent();
            ucMap1.IsVisible = true;
        }

        private void SetShipForm_Load(object sender, EventArgs e)
        {
            Ships.Sort((a, b) => b.CompareTo(a));
            ucMap1.pole.Init();
        }

        private void GetPictureBox()
        {
            switch (Ships[0])
            {
                case 4:
                    pbShipTemplate.Image = Properties.Resources.ship4_h;
                    pbShipTemplate.Tag = "4H";
                    break;
                case 3:
                    pbShipTemplate.Image = Properties.Resources.ship3_h;
                    pbShipTemplate.Tag = "3H";
                    break;
                case 2:
                    pbShipTemplate.Image = Properties.Resources.ship2_h;
                    pbShipTemplate.Tag = "2H";
                    break;
                case 1:
                    pbShipTemplate.Image = Properties.Resources.ship;
                    pbShipTemplate.Tag = "1H";
                    break;
                default:
                    break;
            }
            pbShipTemplate.Location = new Point((pShip.Width - pbShipTemplate.Width) / 2, (pShip.Height - pbShipTemplate.Height) / 2);
            Ships.Remove(Ships[0]);
        }

        private void SetShipForm_Shown(object sender, EventArgs e)
        {
            while (Ships.Count > 0 && !IsClosing)
            {
                GetPictureBox();
                GoNext = false;
                while (!GoNext && !IsClosing)
                {
                    Application.DoEvents();
                    Thread.Sleep(500);
                }
            }
            pole = ucMap1.pole;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void bRotate_Click(object sender, EventArgs e)
        {
            if (pbShipTemplate.Tag == "4H")
            {
                pbShipTemplate.Image = Properties.Resources.ship4_v;
                pbShipTemplate.Tag = "4V";
            }
            else if (pbShipTemplate.Tag == "4V")
            {
                pbShipTemplate.Image = Properties.Resources.ship4_h;
                pbShipTemplate.Tag = "4H";
            }
            else if (pbShipTemplate.Tag == "3H")
            {
                pbShipTemplate.Image = Properties.Resources.ship3_v;
                pbShipTemplate.Tag = "3V";
            }
            else if (pbShipTemplate.Tag == "3V")
            {
                pbShipTemplate.Image = Properties.Resources.ship3_h;
                pbShipTemplate.Tag = "3H";
            }
            else if (pbShipTemplate.Tag == "2H")
            {
                pbShipTemplate.Image = Properties.Resources.ship2_v;
                pbShipTemplate.Tag = "2V";
            }
            else if (pbShipTemplate.Tag == "2V")
            {
                pbShipTemplate.Image = Properties.Resources.ship2_h;
                pbShipTemplate.Tag = "2H";
            }
            pbShipTemplate.Location = new Point((pShip.Width - pbShipTemplate.Width) / 2, (pShip.Height - pbShipTemplate.Height) / 2);
            this.Refresh();
        }

        private void pbShipTemplate_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                pbShipTemplate.Location = new Point(pbShipTemplate.Location.X + e.Location.X, pbShipTemplate.Location.Y + e.Location.Y);
                startPoint = e.Location;
            }
        }

        private void pbShipTemplate_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                pbShipTemplate.Location = new Point(pbShipTemplate.Left + e.Location.X, pbShipTemplate.Top + e.Location.Y);
                this.Refresh();
            }
        }

        private void pbShipTemplate_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
                Control pbImg = FindControlAtPoint(this, pbShipTemplate.Location);
                Point pos = new Point(pbShipTemplate.Location.X + pbShipTemplate.Width - 30, pbShipTemplate.Location.Y + pbShipTemplate.Height - 30);
                Control pbImg2 = FindControlAtPoint(this, pos);
                if (pbImg != null && pbImg2 != null && pbImg.Name.StartsWith("pb_") && pbImg2.Name.StartsWith("pb_"))
                {
                    var coord = pbImg.Name.Remove(0, 3).Split('x');
                    int x1 = int.Parse(coord[0]);
                    int y1 = int.Parse(coord[1]);
                    bool isVertical = pbShipTemplate.Tag.ToString().Substring(1) == "V";
                    int shipLength = int.Parse(pbShipTemplate.Tag.ToString().Substring(0, 1));

                    int xa = x1 > 1 ? x1 - 2 : 0;
                    int ya = y1 > 1 ? y1 - 2 : 0;
                    int xb = isVertical ? x1 : x1 + shipLength - 1;
                    if (xb > 9) xb = 9;
                    int yb = isVertical ? y1 + shipLength - 1 : y1;
                    if (yb > 9) yb = 9;
                    bool isCorrect = true;
                    char[,] tmpMap = ucMap1.pole.getMap();
                    for (int x = xa; x <= xb; x++)
                        for (int y = ya; y <= yb; y++)
                            if (tmpMap[x, y] == 'o')
                            {
                                isCorrect = false;
                                break;
                            }
                    if (isCorrect)
                    {
                        for (int i = 0; i < shipLength; i++)
                        {
                            ucMap1.pole.setMap(x1 + (isVertical ? 0 : i) - 1, y1 + (isVertical ? i : 0) - 1, 'o');
                        }
                        ucMap1.ShowMap();
                        pbShipTemplate.Location = new Point((pShip.Width - pbShipTemplate.Width) / 2, (pShip.Height - pbShipTemplate.Height) / 2);
                        GoNext = true;
                    }
                }
            }
        }

        public static Control FindControlAtPoint(Control container, Point pos)
        {
            Control child;
            foreach (Control c in container.Controls)
            {
                if (!c.Name.Contains("pbShipTemplate"))
                {
                    if (c.Visible && c.Bounds.Contains(pos))
                    {
                        child = FindControlAtPoint(c, new Point(pos.X - c.Left, pos.Y - c.Top));
                        if (child == null) return c;
                        else return child;
                    }
                }
            }
            return null;
        }

        private void SetShipForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void SetShipForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsClosing = true;
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
