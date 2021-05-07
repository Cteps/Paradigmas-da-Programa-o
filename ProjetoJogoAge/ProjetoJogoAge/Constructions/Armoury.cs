using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class Armoury : BuildingsWithCost
    {
        public Armoury(int numcoordenates, int x, int y, string Design, ref int pcoins, int test2) : base(numcoordenates, x, y, Design, 700, 200, ref pcoins, test2)
        {
        }
    }
}
