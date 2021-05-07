using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class Player
    {
        BuildManager builds;
        UnitManager units;
        string name;
        int pcoins;
        int movesleft;

        public BuildManager GetBM()
        {
            return builds;
        }

        public UnitManager GetUM()
        {
            return units;
        }

        public string GetPlayerName()
        {
            return name;
        }


        public Player(string name)
        {
            this.name = name;
            builds = new BuildManager();
            units = new UnitManager();
            this.pcoins = FirstCoins(pcoins);
            movesleft = FirstMoves();
        }

        public string Names(string names)
        {
            names += name;

            return names;
        }

        public void BaseWar()
        {
            pcoins = 10000000;
        }

        public void CoinsNextRound()
        {
            pcoins = pcoins + (builds.GetNumFarms() * 100);
        }

        public int ShowCoins()
        {
            return pcoins;
        }

        public int ShowMovesLeft()
        {
            return movesleft;
        }

        public void decreasemoves(int num)
        {
            movesleft -= num;
        }

        public void ResetMoves()
        {
            movesleft = FirstMoves();
        }

        private int FirstMoves()
        {
            return 8;
        }
        
        private int FirstCoins(int coins)
        {
            coins = 100;
            return coins;
        }

        public bool BaseMaker(int round, int x, int y, bool test2)
        {
            bool b = false;

            builds.New_Base(round, x, y, test2);

            return b;
        }

        public int NewType_GameUnit(int type, int round, int x, int y, bool test2)
        {
            if (type == 1)
            {
                builds.New_Farm(round, x, y,ref pcoins, test2);           
            }
            else if (type == 2)
            {
                builds.New_Barrack(round, x, y,ref pcoins, test2);
            }
            else if (type == 3)
            {
                builds.New_Stable(round, x, y,ref pcoins, test2);
            }
            else if (type == 4)
            {
                builds.New_Armoury(round, x, y,ref pcoins, test2);
            }
            else if (type == 5)
            {
                builds.New_Archery(round, x, y,ref pcoins, test2);
            }
            return type;
        }

        public int UnitType(int type, int round, int x, int y, bool test2)
        {
            if (type == 1)
            {
                units.New_Archer(round, x, y, ref pcoins, test2);
            }
            else if (type == 2)
            {
                units.New_Artillary(round, x, y, ref pcoins, test2);

            }
            else if (type == 3)
            {
                units.New_Cavalry(round, x, y, ref pcoins, test2);

            }
            else if (type == 4)
            {
                units.New_Infantary(round, x, y, ref pcoins, test2);
            }
            return type;
        }

        public int GetNumBuild(int type)
        {
            return builds.GetNumBuilds(type);
        }
    }
}
