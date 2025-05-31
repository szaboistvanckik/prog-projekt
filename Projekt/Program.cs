using System;

namespace Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("mopsz", 40, 45.7, "Ascendant", true);

            //p1.IncreaseLevel(5);

            //Console.WriteLine(p1.HsCategory() + "\n");

            Console.WriteLine(p1);
            Console.WriteLine(p1.IsSmurf());

            PlayerManager pm = new PlayerManager();
            pm.FajlbolOlvas("players.txt");
            pm.WriteData();

            Console.WriteLine();

            Console.WriteLine(pm.GetExtremeValue(false));

            //Console.WriteLine(pm.Sort(true));
        }
    }
}
