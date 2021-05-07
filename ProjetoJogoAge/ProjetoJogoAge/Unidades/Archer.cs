using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
  class Archer : MovingUnit
    {
        public Archer(int numcoordenates,int x, int y, string design,ref int movesLeft, int test2) : base(numcoordenates,2, x, y, design, 30, 20, 2,ref movesLeft, 2, test2,60)
        {
        }
    }
}
