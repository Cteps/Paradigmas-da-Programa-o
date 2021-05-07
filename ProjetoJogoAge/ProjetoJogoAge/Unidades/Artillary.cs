using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
   class Artillary : MovingUnit
    {
        public Artillary(int numcoordenates, int x, int y, string design, ref int movesLeft, int test2) : base(numcoordenates, 3,x, y, design, 40, 60, 3, ref movesLeft, 3, test2,160)
        {
        }
    }
}
