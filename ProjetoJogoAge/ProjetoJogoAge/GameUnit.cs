using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class GameUnit
    {
        CoordenatesManager coordenates;

        protected string design;
        protected int hp;


        public GameUnit(int numcoordenates, int rangecoordenates, int x, int y, string design, int hp, int test2)
        {

            coordenates = new CoordenatesManager(numcoordenates, rangecoordenates, x, y, test2);
            this.design = design;
            this.hp = hp;
        }

        public string GetDesign()
        {
            return this.design;
        }

        public int GetHp()
        {
            return this.hp;
        }

        public int DescreaseHp(int atk)
        {
            this.hp = this.hp - atk;

            return this.hp;
        }

        public bool OverLapTest(int j, int i)
        {
            return coordenates.Overlap(j, i);
        }

        public bool OverlapRange(int j, int i)
        {
            return coordenates.OverlapRange(j, i);
        }
        public void MoveUnit(int x, int y)
        {
            coordenates.MoveUnit(x, y);
        }

        public int GetX()
        {
            return coordenates.GetX();
        }
        public int GetY()
        {
            return coordenates.GetY();
        }
    }
}
