using System.Collections.Generic;
using System.Globalization;

namespace Projekt
{
    internal class Player
    {
        #region Datatypes
        private string name;
        private int level;
        private double hs_percent;
        private string rank; // "Bronze", "Silver", "Gold", "Platinum", "Diamond", "Ascendant" 
        private bool has_mic;
        private Dictionary<int, string> ranks = new Dictionary<int, string>
        {
            { 1, "Bronze" },
            { 2, "Silver" },
            { 3, "Gold" },
            { 4, "Platinum" },
            { 5, "Diamond" },
            { 6, "Ascendant" }
        };
        #endregion

        #region Constructors
        public Player(string name, int level, double hs_percent, string rank, bool has_mic)
        {
            this.name = name;
            this.level = level;
            this.hs_percent = hs_percent;
            this.rank = rank;
            this.has_mic = has_mic;
        }

        public Player(string v)
        {
            string[] data = v.Split(';');

            this.name = data[0];
            this.level = int.Parse(data[1]);
            this.hs_percent = double.Parse(data[2]);
            this.rank = data[3];
            this.has_mic = bool.Parse(data[4]);
        }
        #endregion

        #region Properties
        public string Has_mic { 
            get
            {
                return this.has_mic ? "Van" : "Nincs";
            }
        }

        public string Rank
        {
            set
            {
                if (!ranks.ContainsValue(value)) return;
                this.rank = value;
            }
        }

        public double Hs_percent { get => hs_percent; }
        public int Level { get => level; }
        public string Name { get => name; }
        #endregion

        #region Methods
        public void IncreaseLevel(int amount)
        {
            if (amount > 0 && amount <= 5)
            {
                this.level += amount;
            }
        }

        public bool IsSmurf()
        {
            if (this.level >= 20 && this.level <= 40) return IsAbove("Diamond");
            return false;
        }

        public bool IsAbove(string rank)
        {
            int key = GetKey(rank);

            if (key == -1) return false;
            return GetKey(this.rank) >= key;
        }

        private int GetKey(string rank)
        {
            foreach (KeyValuePair<int, string> kvp in ranks)
            {
                if (kvp.Value == rank) return kvp.Key;
            }

            return -1;
        }

        public string HsCategory()
        {
            if (this.hs_percent >= 50) return "Mesterlövész";
            else if (this.hs_percent >= 35) return "Kiváló";
            else if (this.hs_percent >= 20) return "Jó";
            else return "Gyakorlás szükséges";
        }
        
        public override string ToString()
        {
            return $"{name} - Level {level} | Rank: {rank} | HS: {hs_percent}% - {HsCategory()} | VC: {Has_mic}";
        }
        #endregion
    }
}
