using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("MenuPrincipal");

            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;

            menu.MenuStart(46);
        }
    }
}
