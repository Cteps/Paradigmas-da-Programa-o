using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
 class Base : GameUnit
    {
        public Base(int numcoordenates, int x, int y, string Design, int test2) : base(numcoordenates,0, x, y, Design, 2400, test2)
        {
        }
    }
}
