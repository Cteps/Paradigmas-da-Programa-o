using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class Coordenates
    {
        int x;
        int y;

        public Coordenates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //Obter as coordenadas de Y
        public int GetCoordenatesY(int y)
        {
            if (y % 2 == 0 || y == 0)
            {
                y = 2 + (y / 2) * 6;
            }
            else
            {
                y = 4 + ((y - 1) / 2) * 6;
            }
            return y;
        }

        //Obter as coordernadas de X
        public int GetCoordenatesX(int x)
        {
            if (x >= 97 && x <= 122)
            {
                x = x - 97;

                if (x % 2 == 0 || x == 0)
                {
                    x = 2 + (x / 2) * 6;
                }
                else
                {
                    x = 4 + ((x - 1) / 2) * 6;
                }

            }
            else if (x >= 65 && x <= 90)
            {
                x = (x - 65);

                if (x % 2 == 0 || x == 0)
                {
                    x = 2 + (x / 2) * 6;
                }
                else
                {
                    x = 4 + ((x - 1) / 2) * 6;
                }
            }
            return x;
        }    

        public int X { get => this.x; set => this.x = value; }

        public int Y { get => this.y; set => this.y = value; }
    }
}
