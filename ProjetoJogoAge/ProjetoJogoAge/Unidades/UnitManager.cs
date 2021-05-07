using System.Collections;

namespace ProjetoJogoAge
{
    class UnitManager
    {
        Archer archer;
        Artillary artillary;
        Cavalry cavalry;
        Infantary infantary;

        Hashtable units = new Hashtable();

        int n_units = 0;

        public Hashtable Units { get => units; set => units = value; }

        public Archer New_Archer(int round, int x, int y,ref int movesLeft, bool test2)
        {
            string design = "E";

            if (round == 1)
            {
                design = "K";
            }
            else design = "k";

            archer = new Archer(1, x, y, design, ref movesLeft,1);

            units.Add(n_units, archer);
            n_units++;

            return archer;
        }

        public Artillary New_Artillary(int round, int x, int y, ref int movesLeft, bool test2)
        {
            string design = "E";
            if (round == 1)
            {
                design = "T";
            }
            else design = "t";

            artillary = new Artillary(1, x, y, design, ref movesLeft, 1);

            units.Add(n_units, artillary);
            n_units++;
            return artillary;
        }

        public Cavalry New_Cavalry(int round, int x, int y, ref int movesLeft, bool test2)
        {
            string design = "E";

            if (round == 1)
            {
                design = "C";
            }
            else design = "c";



            cavalry = new Cavalry(1, x, y, design, ref movesLeft, 1);
            units.Add(n_units, cavalry);
            n_units++;
            return cavalry;
        }

        public Infantary New_Infantary(int round, int x, int y, ref int pcoins, bool test2)
        {
            string design = "E";

            if (round == 1)
            {
                design = "I";
            }
            else design = "i";
            infantary = new Infantary(1, x, y, design, ref pcoins, 1);

            units.Add(n_units, infantary);
            n_units++;
            return infantary;
        }

        public ICollection GetUnits()
        {
            return units.Values;
        }
    }
}
