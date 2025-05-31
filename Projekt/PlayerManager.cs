using System;
using System.Collections.Generic;
using System.IO;

namespace Projekt
{
    internal class PlayerManager
    {
        private List<Player> players = new List<Player>();

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

        public bool ChangeCurrent(int i, int ind)
        {
            return players[i].Hs_percent < players[ind].Hs_percent;
        }

        public Player Max()
        {
            int maxi = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Level > players[maxi].Level)
                {
                    maxi = i;
                }
            }
            return players[maxi];
        }

        public Player GetExtremeValue(bool highest, int j, ref int ind)
        {
            for (int i = j; i < players.Count; i++)
            {
                if ((!highest && ChangeCurrent(ind, i)) || (highest && ChangeCurrent(i, ind)))
                {
                    ind = i;
                }
            }
            return players[ind];
        }

        public void Sort(string m)
        {
            List<Player> lst = new List<Player>(players);

            for (int i = 0; i < lst.Count; i++)
            {
                int ind = i;
                GetExtremeValue(m == "max", i, ref ind);

                (lst[i], lst[ind]) = (lst[ind], lst[i]);
            }
        }

    }
}
