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

        public Player GetExtremeValue(bool highest)
        {
            int ind = 0;

            for (int i = 0; i < players.Count; i++)
            {
                if (!highest && (players[i].Hs_percent < players[ind].Hs_percent) 
                    || highest && (players[i].Hs_percent > players[ind].Hs_percent)) ind = i; //ChangeCurrent
            }

            return players[ind];
        }

        //public void Sort()
        //{
        //    List<Player> lst = new List<Player>(players);

        //    for (int i = 0; i < lst.Count; i++)
        //    {
        //        int ind = i;
        //        for (int j = i + 1; j < lst.Count; j++)
        //        {
        //            if (lst[j] < lst[ind])
        //            {
        //                ind = j;
        //            }
        //        }
        //        (lst[i], lst[ind]) = (lst[ind], lst[i])
        //    }
        //}
    }
}
