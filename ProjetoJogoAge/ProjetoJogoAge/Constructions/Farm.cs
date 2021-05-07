using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
  class Farm : BuildingsWithCost
    {
        public Farm(int numcoordenates, int x, int y, string Design, ref int pcoins, int test2) : base(numcoordenates, x, y, Design, 500, 60, ref pcoins,test2)
        {

        }

    }
}
