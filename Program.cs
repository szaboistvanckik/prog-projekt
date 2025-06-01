using System;

namespace Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Objektum példányosítás paraméterezett konstruktorral
            Player p1 = new Player("mopsz", 40, 50.7, "Ascendant", true);
            Console.WriteLine("1. Konstruktorral létrehozott játékos:");
            Console.WriteLine(p1);

            // 2. Objektum példányosítás szöveges sorból (fájlformátumból)
            Player p2 = new Player("lilpapi;15;33.3;Gold;false");
            Console.WriteLine("\n2. Sor alapú konstruktor:");
            Console.WriteLine(p2);

            // 3. Nem triviális getter (mikrofon állapot szövegesen)
            Console.WriteLine("\n3. Nem triviális getter:");
            Console.WriteLine($"{p2.Name} játékosnak van mikrofonja? {p2.Has_mic}");

            // 4. Nem triviális setter (rang változtatás)
            Console.WriteLine("\n4. Nem triviális setter:");
            p2.Rank = "Platinum"; // csak akkor változik, ha érvényes a megadott rang
            Console.WriteLine(p2);

            // 5. Szint növelés
            Console.WriteLine("\n5. Szint növelése 3-mal:");
            p2.IncreaseLevel(3); // csak 1 és 5 közötti értéket lehet megadni
            Console.WriteLine(p2);

            // 6. HS kategória lekérdezése
            Console.WriteLine("\n6. HS kategória:");
            Console.WriteLine($"{p1.Name} HS% kategória: {p1.HsCategory()}");
            Console.WriteLine($"{p2.Name} HS% kategória: {p2.HsCategory()}");

            // 7. Smurf ellenőrzés (smurf --> magas rangú játkos, aki alacsonyabb rangú lobbykban játszik)
            Console.WriteLine("\n7. Smurf ellenőrzés:");
            Console.WriteLine($"{p1.Name} smurf játékos? {p1.IsSmurf()}");
            Console.WriteLine($"{p2.Name} smurf játékos? {p2.IsSmurf()}");

            // 8. Fájlbeolvasás
            PlayerManager pm = new PlayerManager();
            pm.FajlbolOlvas("../../players.txt"); //players.txt --> double-ok (","-vel való elválasztása)

            // 9. Legmagasabb HS%-os játékos (HS% --> Headshot% --> Fejlövések aránya százalékban)
            Console.WriteLine("\n9. Legmagasabb HS%-os játékos:");
            Console.WriteLine(pm.GetExtremeValue(true));

            // 10. Rendezés szint szerint (növekvő)
            Console.WriteLine("\n10. Rendezés szint szerint (növekvő):");
            pm.SortByLevel(true);
            pm.WriteData();

            // 11. INSERT INTO generálás
            pm.General("adatok.sql");
        }
    }
}