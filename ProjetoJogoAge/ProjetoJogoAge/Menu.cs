using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoJogoAge
{
    class Menu
    {
        InterfaceJogo IJ = new InterfaceJogo();

        string MenuPrincipal;
        int exitmenup;

        public Menu(string name)
        {
            this.MenuPrincipal = name;
        }

        public int MenuStart(int option)
        {
            {
                int op;
                do
                {
                    Console.Clear();

                    Console.WriteLine("-----------------------------------MENU-----------------------------------");
                    Console.WriteLine("Para selecionar o que deseja fazer, introduza o valor correspondente...");
                    Console.WriteLine("Jogar: 1");
                    Console.WriteLine("Sair: 0");
                    op = Utils.ReadInteger("--------------------------------------------------------------------------");

                    if (op == 1)
                    {
                        MenunPlayers();
                    }

                } while (op != 0);
            }
            return option;
        }

        public void MenunPlayers()
        {
            bool endGame = false;
            Console.Clear();
            Console.WriteLine("-----------------------------------MODOS DE JOGO-----------------------------------");
            Console.WriteLine("Para selecionar o que deseja fazer , introduza o valor correspondente...");
            Console.WriteLine("Multi-Player: 1");
            Console.WriteLine("Retornar ao menu: 0");
            exitmenup = Utils.ReadInteger("------------------------------------------------------------------------");

            Console.Clear();
            if (exitmenup == 1)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("-----------------------------------MULTI_PLAYER MODOS DE JOGO-----------------------------------");
                    Console.WriteLine("Para selecionar o que deseja fazer , introduza o valor correspondente...");
                    Console.WriteLine("Base Wars: 1");
                    Console.WriteLine("Multi-Player: 2");
                    Console.WriteLine("Retornar ao menu: 0");
                    exitmenup = Utils.ReadInteger("------------------------------------------------------------------------");
                    Console.WriteLine();
                    if (exitmenup == 1 || exitmenup == 2)
                    {
                        MenunumPlayers(exitmenup);
                    }
                    else if (exitmenup == 0) { break; }

                } while (endGame != true);
            }
        }

        public bool MenunumPlayers(int gm)
        {
            bool endGame = false;
            do
            {
                endGame = IJ.Players2(gm);

            } while (endGame != true);

            return endGame;
        }
    }
}
