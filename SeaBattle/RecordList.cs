using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SeaBattle
{
    public class DuplicateKeyComparer<TKey>
                :
             IComparer<TKey> where TKey : IComparable
    {
        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                return 1; 
            else          
                return result;
        }
    }

    public static class RecordList
    {
        public static SortedList<int, string> Records = new SortedList<int, string>(new DuplicateKeyComparer<int>());

        public static void SaveToFile()
        {
            try
            {
                using (TextWriter tw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\records.txt"))
                {
                    foreach (KeyValuePair<int, string> s in Records)
                        tw.WriteLine(s);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка сохранения результатов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public static void ReadFromFile()
        {
            try
            {
                Records.Clear();
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\records.txt"))
                {
                    string s;
                    using (TextReader tr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\records.txt"))
                    {
                        while ((s = tr.ReadLine()) != null)
                        {
                            string[] rec = s.Replace("[", "").Replace("]", "").Split(',');
                            Records.Add(int.Parse(rec[0]), rec[1].Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения результатов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public static void Add(int ShotCount, string Name)
        {
            Records.Add(ShotCount, Name);
            for (int i = 5; i < Records.Count; i++)
            {
                Records.RemoveAt(i);
            }
        }
    }
}
