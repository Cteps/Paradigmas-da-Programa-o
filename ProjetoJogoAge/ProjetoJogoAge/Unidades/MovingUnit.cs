using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class MovingUnit : GameUnit
    {
        protected int atk;
        protected int range;
        protected int unitMoves;
        protected int cost;

        public MovingUnit(int numcoordenates, int rangecoordenates, int x, int y, string design, int hp, int atk, int range, ref int pcoins, int unitMoves, int test2,int cost) : base(numcoordenates, rangecoordenates, x, y, design, hp, test2)
        {
            this.unitMoves = unitMoves;
            this.atk = atk;
            this.range = range;
            this.cost = cost;

            if (pcoins < cost)
            {
                throw new Exception("Não possui coins suficientes");
            }
            else
            {
                pcoins -= cost;
            }
        }

        public int GetAtk()
        {
            return this.atk;
        }

        public int IncreaseAtk(int atk)
        {
            this.atk += atk;

            return this.atk;
        }

        public int GetRange()
        {
            return this.range;
        }

        
    }
}
