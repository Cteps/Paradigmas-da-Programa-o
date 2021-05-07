using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
  class BuildingsWithCost : GameUnit
    {
        protected int cost;
 
        public BuildingsWithCost(int numcoordenates,int x, int y, string Design, int hp,int cost, ref int pcoins,int test2) : base(numcoordenates,0,x, y, Design, hp, test2)
        {
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

    
    }
}
