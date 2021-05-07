using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class CoordenatesManager
    {
        protected int numCoordenates;
        protected int rangeCoordenates;
        protected int test2;
        int range;

        Coordenates[] nrange;
        Coordenates[] ncoo;

        public CoordenatesManager(int numcoordenates, int rangecoordenates, int x, int y, int test2)
        {
            this.test2 = test2;
            this.rangeCoordenates = rangecoordenates;
            this.numCoordenates = numcoordenates;

            ncoo = new Coordenates[numcoordenates];

            if (rangecoordenates == 3)
            {
                range = 49;
            }
            else if (rangecoordenates == 2)
            {
                range = 25;

            }
            else if (rangecoordenates == 1)
            {
                range = 9;
            }

            nrange = new Coordenates[range];
            CoordenatesM(y, x, test2);
            RangeCoordenates(x, y, rangecoordenates);
        }

        private void CoordenatesM(int y, int x, int test2)
        {
            if (numCoordenates == 1)
            {
                ncoo[0] = new Coordenates(x, y);
            }
            else if (numCoordenates == 2)
            {
                if (test2 == 1)
                {
                    ncoo[0] = new Coordenates(x, y);
                
                
                        ncoo[1] = new Coordenates(x + 1, y);

                }

                else if (test2 == 0)
                {

                    ncoo[0] = new Coordenates(x, y);

                    ncoo[1] = new Coordenates(x - 1, y);

                }
            }
            else if (numCoordenates == 4)
            {
                ncoo[0] = new Coordenates(x, y);
                ncoo[1] = new Coordenates(x + 1, y);
                ncoo[2] = new Coordenates(x, y + 1);
                ncoo[3] = new Coordenates(x + 1, y + 1);
            }
        }

        public void RangeCoordenates(int x, int y, int range)
        {
            int r = 0;

            if (range != 0)
            {
                for (int l = -range; l <= range; l++)
                {
                    for (int i = -range; i <= range; i++)
                    {
                        if ((i == 0) && (l == 0))
                        {
                            nrange[r] = new Coordenates(x, y);

                        }
                        else
                        {
                            nrange[r] = new Coordenates(x + i, y + l);

                        }

                        r++;
                    }
                }
            }
        }

        public bool OverlapRange(int j, int i)
        {
            bool test = false;

            for (int count = 0; count < range; count++)
            {
                if (nrange[count].GetCoordenatesX(nrange[count].X) == j && nrange[count].GetCoordenatesY(nrange[count].Y) == i)
                {
                    test = true;
                }
            }
            return test;
        }

        public bool Overlap(int j, int i)
        {
            bool test = false;

            for (int count = 0; count < numCoordenates; count++)
            {
                if (ncoo[count].GetCoordenatesX(ncoo[count].X) == j && ncoo[count].GetCoordenatesY(ncoo[count].Y) == i)
                {
                    test = true;
                }
            }
            return test;
        }

        public void MoveUnit(int x, int y)
        {
            ncoo[0].X = x;
            ncoo[0].Y = y;

            RangeCoordenates(x, y, rangeCoordenates);
        }

        public int GetX()
        {
            return ncoo[0].GetCoordenatesX(ncoo[0].X);
        }

        public int GetY()
        {
            return ncoo[0].GetCoordenatesY(ncoo[0].Y);
        }
    }
}
