using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class Utils
    {
        public static int ReadInteger(string msg)
        {
            int x = 0;

            try
            {
                Console.WriteLine(msg);
                x = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de inteiro errado.");
                x = ReadInteger(msg);
            }
            return x;
        }

        public static string ReadxCoordenate()
        {
            string x;
            int xconvert = 0;

            x = Console.ReadLine().ToLower();
            try
            {
                xconvert = x.ElementAt(0);
            }
            catch (Exception)
            {
                Console.WriteLine("Caracter Errado, introduza apenas uma letra");
                x = ReadxCoordenate();
            }

            if ((xconvert >= 65 && xconvert <= 90) || (xconvert >= 97 && xconvert <= 122))
            {

            }
            else
            {
                Console.WriteLine("Caracter Errado, introduza uma letra");
                x = ReadxCoordenate();
            }

            return x;
        }

        public static int ReadyCoordenate()
        {
            int y = 0;

            try
            {
                y = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Numero Invalido, introduza apenas um número entre 0 e 16");
                y = ReadyCoordenate();
            }

            if (y >= 0 && y <= 16)
            {
            }
            else
            {
                Console.WriteLine("Numero Invalido, introduza um número entre 0 e 16");
                y = ReadyCoordenate();
            }
            return y;
        }
    }
}
