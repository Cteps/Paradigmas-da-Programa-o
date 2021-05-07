using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
  
  class Infantary : MovingUnit
    {
        public Infantary(int numcoordenates, int x, int y, string design, ref int movesLeft, int test2) : base(numcoordenates,1, x, y, design, 70, 20, 0, ref movesLeft, 2, test2,60)
        {
        }
    }
}
