using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace Projekt
{
    internal class PlayerManager
    {
        #region Fields
        private List<Player> players = new List<Player>();
        #endregion

        #region Methods
        public void FajlbolOlvas(string fajlnev)
        {
            StreamReader sr = new StreamReader(fajlnev);

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();

                Player p = new Player(s);

                players.Add(p);
            }

            sr.Close();
        }

        public void WriteData()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine(players[i]);
            }
        }

        public Player GetExtremeValue(bool highest)
        {
            int ind = 0;

            for (int i = 0; i < players.Count; i++)
            {
                if (ChangeCurrent(i, ind, highest)) ind = i;
            }

            return players[ind];
        }

        private bool ChangeCurrent(int i, int best_index, bool highest)
        {
            if (!highest) return (players[i].Hs_percent < players[best_index].Hs_percent);
            else return (players[i].Hs_percent > players[best_index].Hs_percent);
        }

        public void SortByLevel(bool isAscending)
        {
            for (int i = 0; i < players.Count; i++)
            {
                int target = i;
                for (int j = i + 1; j < players.Count; j++)
                {
                    bool condition = isAscending
                    ? players[j].Level < players[target].Level
                    : players[j].Level > players[target].Level;

                    if (condition)
                    {
                        target = j;
                    }
                }

                (players[i], players[target]) = (players[target], players[i]);
            }
        }

        public void General(string fajlnev)
        {
            StreamReader sr = new StreamReader("../../names.txt");
            string[] names = sr.ReadLine().Split(';');
            sr.Close();

            Random r = new Random();
            StreamWriter sw = new StreamWriter($"../../{fajlnev}");
            sw.WriteLine("USE PlayerManager;");
            sw.WriteLine("DELETE FROM Players;\n");
            sw.WriteLine("INSERT INTO Players(name, level, hs_percent, rank, has_mic) VALUES");

            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                int level = r.Next(20, 201);
                double hs_percent = Math.Round(5 + r.NextDouble() * (60 - 5), 2);
                string rank = Player.ranks[r.Next(1, 7)];
                bool mic = r.Next(2) == 1;
                string end = (i == names.Length - 1) ? ";" : ",";

                sw.WriteLine($"('{name}', {level}, {hs_percent}, '{rank}', {mic.ToString().ToLower()}){end}");
            }

            sw.Close();
        }
        #endregion
    }
}