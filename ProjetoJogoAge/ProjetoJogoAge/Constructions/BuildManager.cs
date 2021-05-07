using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class BuildManager
    {
        Farm farm;
        Barrack barrack;
        Armoury armoury;
        Archery archery;
        Stable stable;
        Base BASE;

        Hashtable builds = new Hashtable();

        int n_farm = 0;
        int n_barrack = 0;
        int n_builds = 0;
        int n_armoury = 0;
        int n_archery = 0;
        int n_stable = 0;
        int n_base = 0;

        public Hashtable Builds { get => builds; set => builds = value; }

        public int GetNumFarms()
        {
            return n_farm;
        }

        public int GetNumBuilds(int type)
        {
            int n_build = 0;

            if (type == 1)
            {
                n_build = n_barrack;
            }
            else if (type == 2)
            {
                n_build = n_stable;

            }
            else if (type == 3)
            {

                n_build = n_armoury;
            }
            else if (type == 4)
            {

                n_build = n_archery;
            }

            return n_build;
        }

        public void OneMoreBuild()
        {
            n_builds++;
        }

        public Farm New_Farm(int round, int x, int y, ref int pcoins, bool test2)
        {
            int i;
            string design;
            if (round == 1)
            {
                design = "F";
            }
            else design = "f";

            if (test2 == true)
            {
                i = 1;
            }
            else i = 0;

            farm = new Farm(2, x, y, design, ref pcoins, i);

            builds.Add(n_builds, farm);
            n_farm++;
            OneMoreBuild();

            return farm;
        }

        public Barrack New_Barrack(int round, int x, int y, ref int pcoins, bool test2)
        {
            int i;

            string design;
            if (round == 1)
            {
                design = "B";
            }
            else design = "b";


            if (test2 == true)
            {
                i = 1;
            }
            else i = 0;

            barrack = new Barrack(2, x, y, design, ref pcoins, i);

            builds.Add(n_builds, barrack);
            n_barrack++;
            OneMoreBuild();

            return barrack;
        }

        public Armoury New_Armoury(int round, int x, int y, ref int pcoins, bool test2)
        {
            int i;

            string design;

            if (round == 1)
            {
                design = "A";
            }
            else design = "a";

            if (test2 == true)
            {
                i = 1;
            }
            else i = 0;

            armoury = new Armoury(2, x, y, design, ref pcoins, i);

            builds.Add(n_builds, armoury);
            n_armoury++;
            OneMoreBuild();

            return armoury;
        }

        public Archery New_Archery(int round, int x, int y, ref int pcoins, bool test2)
        {
            int i;

            string design;

            if (round == 1)
            {
                design = "R";
            }
            else design = "r";


            if (test2 == true)
            {
                i = 1;
            }
            else i = 0;

            archery = new Archery(2, x, y, design, ref pcoins, i);

            builds.Add(n_builds, archery);
            n_archery++;
            OneMoreBuild();

            return archery;
        }

        public Stable New_Stable(int round, int x, int y, ref int pcoins, bool test2)
        {
            int i;

            string design;

            if (round == 1)
            {
                design = "S";
            }
            else design = "s";


            if (test2 == true)
            {
                i = 1;
            }
            else i = 0;

            stable = new Stable(2, x, y, design, ref pcoins, i);

            builds.Add(n_builds, stable);
            n_stable++;
            OneMoreBuild();

            return stable;
        }

        public Base New_Base(int round, int x, int y, bool test2)
        {
            string design = "E";

            if (round == 1)
            {
                design = "O";
            }
            else if (round == 2)
            {

                design = "o";
            }

            BASE = new Base(4, x, y, design, 1);

            builds.Add(n_builds, BASE);
            n_base++;
            OneMoreBuild();

            return BASE;
        }

        public ICollection GetBuildings()
        {
            return builds.Values;
        }
    }
}
