using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;

namespace SeaBattle
{

    public class Pole
    {

        private char[,] map = new char[10,10];
        public int ShotCounter = 0;
        public int ShipOnWater = 10;

        Random rnd = new Random(DateTime.Now.Millisecond);

        List<Tuple<int, int>> d = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1), new Tuple<int, int>(1, 0),
                new Tuple<int, int>(0, -1), new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(1, 1), new Tuple<int, int>(-1, 1),
                new Tuple<int, int>(1, -1), new Tuple<int, int>(-1, -1)
            };

        public void Init()
        {
            for (int X = 0; X < 10; X++)
                for (int Y = 0; Y < 10; Y++)
                    map[X, Y] = ' ';
        }

        public void Ships()
        {
            bool b = true;
            Init();
            for (int n = 3; n >= 0; n--)
                for (int m = 0; m <= 3 - n; m++)
                    do
                    {
                        int x = rnd.Next(10);
                        int y = rnd.Next(10);
                        int kx = rnd.Next(2);
                        int ky = 0;
                        if (kx == 0) ky = 1;
                        b = true;
                        for (int i = 0; i <= n; i++)
                            if (!Freedom(x + kx * i, y + ky * i)) b = false;
                        if (b)
                            for (int i = 0; i <= n; i++)
                                map[x + kx * i, y + ky * i] = 'o';
                    }
                    while (!b);
        }

        bool Freedom(int x, int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10 && map[x, y] == ' ')
            {
                foreach (Tuple<int, int> item in d)
                {
                    int dx = x + item.Item1;
                    int dy = y + item.Item2;
                    if (dx >= 0 && dx < 10 && dy >= 0 && dy < 10 && map[dx, dy] != ' ') return false;
                }
                return true;
            }
            else return false;
        }

        public char[,] getMap()
        {
            return map;
        }

        public void setMap(int x, int y, char cell)
        {
            map[x, y] = cell;
        }

        public bool Shot()
        {
            int x = rnd.Next(0, 10);
            int y = rnd.Next(0, 10);
            while (!" o".Contains(map[x, y]))
            {
                x = rnd.Next(0, 10);
                y = rnd.Next(0, 10);
            }
            return Shot(x, y);
        }

        public bool Shot(int x, int y)
        {
            char old = map[x, y];
            if (old != ' ' && old != 'o') return true;
            ShotCounter++;
            if (old == 'o')
            {
                map[x, y] = 'X';
                SoundPlayer player = new SoundPlayer(Properties.Resources.babah);
                if (IsDestroyed(x, y))
                {
                    ShipOnWater--;
                    MarkArea(x, y);
                }
                player.Play();
            }
            else
            {
                map[x, y] = 'V';
                SoundPlayer player = new SoundPlayer(Properties.Resources.plyuh);
                player.Play();
            }
            return old == 'o';
        }

        private void MarkArea(int x, int y, int ix = -1, int iy = -1)
        {
            if (x < 9 && x + 1 != ix && map[x + 1, y] == 'X') MarkArea(x + 1, y, x, y);
            if (x > 0 && x - 1 != ix && map[x - 1, y] == 'X') MarkArea(x - 1, y, x, y);
            if (y < 9 && y + 1 != iy && map[x, y + 1] == 'X') MarkArea(x, y + 1, x, y);
            if (y > 0 && y - 1 != iy && map[x, y - 1] == 'X') MarkArea(x, y - 1, x, y);
            if (x < 9 && map[x + 1, y] == ' ') map[x + 1, y] = '.';
            if (x < 9 && y < 9 && map[x + 1, y + 1] == ' ') map[x + 1, y + 1] = '.';
            if (y < 9 && map[x, y + 1] == ' ') map[x, y + 1] = '.';
            if (x > 0 && y < 9 && map[x - 1, y + 1] == ' ') map[x - 1, y + 1] = '.';
            if (x > 0 && map[x - 1, y] == ' ') map[x - 1, y] = '.';
            if (x > 0 && y > 0 && map[x - 1, y - 1] == ' ') map[x - 1, y - 1] = '.';
            if (y > 0 && map[x, y - 1] == ' ') map[x, y - 1] = '.';
            if (x < 9 && y > 0 && map[x + 1, y - 1] == ' ') map[x + 1, y - 1] = '.';
        }

        public bool IsDestroyed(int x, int y, int ix = -1, int iy = -1)
        {
            bool right = (x == 9) || (x + 1 == ix && y == iy) || " .V".Contains(map[x + 1, y]) || (map[x + 1, y] == 'X' && IsDestroyed(x + 1, y, x, y));
            bool left = (x == 0) || (x - 1 == ix && y == iy) || " .V".Contains(map[x - 1, y]) || (map[x - 1, y] == 'X' && IsDestroyed(x - 1, y, x, y));
            bool top = (y == 0) || (x == ix && y - 1 == iy) || " .V".Contains(map[x, y - 1]) || (map[x, y - 1] == 'X' && IsDestroyed(x, y - 1, x, y));
            bool bottom = (y == 9) || (x == ix && y + 1 == iy) || " .V".Contains(map[x, y + 1]) || (map[x, y + 1] == 'X' && IsDestroyed(x, y + 1, x, y));
            return right && left && top && bottom;
        }
    }
}
