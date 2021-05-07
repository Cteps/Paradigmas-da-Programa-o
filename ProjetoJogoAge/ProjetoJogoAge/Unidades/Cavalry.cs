using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class Cavalry : MovingUnit
    {
        public Cavalry(int numcoordenates, int x, int y, string design, ref int movesLeft, int test2) : base(numcoordenates,1,x, y, design, 60, 30, 0, ref movesLeft, 1, test2,100)
        {
        }
    }
}
