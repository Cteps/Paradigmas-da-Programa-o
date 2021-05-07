using System;
using System.Linq;

namespace ProjetoJogoAge
{
    class InterfaceJogo
    {
        Field field = new Field();
        string player1, player2;

        int roundnum = 1;
        int atkdone = 0;
        int nump = 5;


        // Método para gerar as bases de cada player
        public void BaseGenerator()
        {
            Random rnd = new Random();
            int x;
            int y;

            char[] letters = new char[] { 'A', 'B' };

            for (int count = 0; count < 2; count++)
            {

                if (roundnum == 1)
                {
                    y = rnd.Next(1, 4);
                }
                else
                {
                    y = rnd.Next(12, 15);
                }

                x = rnd.Next('A', 'Z');

                field.BaseMaker(roundnum, x, y, true);
                Round();
            }
        }

        private bool Range(int range)
        {
            bool rangebool = false;

            return rangebool;
        }

        // Mostrar o campo de jogo
        public void ShowField()
        {
            field.ShowField();
        }

        //Metodos para converter as coordenadas de x e y
        public int CoordenatesConversor_x(int type, string xconvertstring, int x)
        {
            if (type == 1)
            {
                x = xconvertstring.ElementAt(0);
                x = Convert.ToInt32(x);
            }

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

        public int CoordenatesConversor_y(int y)
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

        // Método para mostrar qual é o player que deve jogar
        public string Playerround()
        {
            string name;

            if (roundnum == 1)
            {
                name = "Player 1: " + player1;
            }
            else
            {
                name = ("Player 2: " + player2);
            }
            return name;
        }

        // Método que gera o turno de cada player
        public void Round()
        {
            roundnum++;

            if (roundnum >= 3)
            {
                roundnum = 1;
            }
            nump = 5;
            //return roundnum;
        }

        // Bool Para criar 2 players e Testar o jogo 
        public bool Players2(int gm)
        {
            int n_t1, n_t2;
            int xfirst, yfirst;
            bool endgame = false;

            Console.Clear();
            Console.WriteLine("Player 1: ");
            player1 = Console.ReadLine();
            field.PlayerName(0, player1);
            Console.WriteLine("Player 2: ");
            player2 = Console.ReadLine();
            field.PlayerName(1, player2);
            Console.WriteLine("\n");
            Console.Clear();
            if (gm == 2)
            {
                BaseGenerator();
            }
            else
            {
                field.BaseMaker(1, 65, 0, true);
                field.BaseMaker(2, 89, 15, true);
                field.BaseWar();

                for (int p = 0; p < 2; p++)
                {
                    Console.Clear();

                    Console.WriteLine("-----------------------------------Tropas de Jogo-----------------------------------");
                    if (p == 0)
                    {
                        Console.WriteLine("Player 1: " + player1);
                    }
                    else
                    {
                        Console.WriteLine("Player 2:" + player2);
                    }
                    Console.WriteLine("Escolha dois tipos de tropas para o jogo:");
                    Console.WriteLine("Archer: (1) ");
                    Console.WriteLine("Artillary: (2) ");
                    Console.WriteLine("Cavalry: (3) ");
                    Console.WriteLine("Infantary: (4) ");
                    Console.WriteLine("Retornar ao menu: (0) ");
                    n_t1 = Convert.ToInt32(Utils.ReadInteger("------------------------------------------------------------------------"));
                    n_t2 = Convert.ToInt32(Utils.ReadInteger("------------------------------------------------------------------------"));
                    Console.WriteLine();

                    if (p == 0)
                    {
                        xfirst = 67;
                        yfirst = 0;
                    }
                    else
                    {
                        xfirst = 65;
                        yfirst = 16;
                    }

                    for (int i = 0; i < 25; i++)
                    {
                        if (i > 13)
                        {
                            if (OverlapTest(roundnum, " ", CoordenatesConversor_x(0, " ", xfirst), CoordenatesConversor_y(yfirst), 0, true, ref atkdone, false))
                            {
                                Console.Clear();
                                CreateUnit(roundnum, n_t1, xfirst, yfirst, true);
                                xfirst++;
                            }
                        }
                        else
                        {
                            if (OverlapTest(roundnum, " ", CoordenatesConversor_x(0, " ", xfirst), CoordenatesConversor_y(yfirst), 0, true, ref atkdone, false))
                            {
                                Console.Clear();
                                CreateUnit(roundnum, n_t2, xfirst, yfirst, true);
                                xfirst++;
                            }
                        }
                    }
                    Round();
                }
                ShowField();
            }

            do
            {
                Console.Clear();
                field.ShowField();
                endgame = MOptions(gm);
            } while (endgame != true);

            if (endgame == true)
            {
                field.EndGame();
                roundnum = 1;
            }
            return endgame;
        }

        // In-game menu
        public bool MOptions(int gm)
        {
            int moptions, msuboptions;
            string design = " ";
            int x;
            string xtest;
            int y, xc, yc, atk;
            int xt, yt;
            bool test = false;

            bool endGame = false;

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Playerround());
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (gm == 2)
            {
                Console.WriteLine("Coins: " + field.ShowCoins(roundnum));

                Console.WriteLine("Nº de jogadas restantes: " + nump);
            }
            Console.WriteLine("Nº de moves restantes: " + field.ShowMovesLeft(roundnum));
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("------------------Opções----------------");
            Console.WriteLine("Selecione: ");
            Console.WriteLine("Tropas: (1) ");
            if (gm == 2)
            {
                Console.WriteLine("Construções: (2) ");
                Console.WriteLine("Construir: (3) ");
            }
            Console.WriteLine("Acabar Turno: (4) ");
            Console.WriteLine("Desistir: (5) ");
            Console.WriteLine("----------------------------------------");

            moptions = Utils.ReadInteger("");

            if (gm == 1)
            {
                if (moptions == 1 || moptions == 5 || moptions == 4)
                {

                }
            }
            else if (gm == 1)
            {
                if (moptions != 1 || moptions != 5 || moptions != 4)
                {
                    MOptions(gm);
                }
            }
            else { }

            if (moptions == 1)
            {
                if (field.ShowMovesLeft(roundnum) > 0)
                {
                    Console.WriteLine("------------------Opções Tropas----------------");
                    Console.WriteLine("Mover: (1) ");
                    Console.WriteLine("Atacar: (2) ");
                    Console.WriteLine("Voltar atrás: (0) ");
                    Console.WriteLine("-----------------------------------------------");

                    msuboptions = Utils.ReadInteger("");

                    if (msuboptions == 1)
                    {
                        Console.Clear();
                        ShowField();

                        Console.WriteLine("\nIntroduza as coordenadas da tropa");
                        xt = Convert.ToInt32(Utils.ReadxCoordenate().ElementAt(0));
                        yt = Convert.ToInt32(Utils.ReadyCoordenate());

                        xc = CoordenatesConversor_x(0, "", xt);
                        yc = CoordenatesConversor_y(yt);

                        design = GetDesign(xc, yc);
                        atk = field.Atk(roundnum, xc, yc);

                        if ((roundnum == 1 && (design == "I" || design == "K")) || (roundnum == 2 && (design == "k" || design == "i")))
                        {
                            Console.WriteLine("Pode mover uma area de 2x2");
                            Console.WriteLine("Introduza as coordenadas para a qual deseja movê-la");
                            xtest = Utils.ReadxCoordenate();
                            y = Utils.ReadyCoordenate();
                            if (((y - yt) <= 2 || (y - yt) <= -2) && ((xt - Convert.ToInt32(xtest.ElementAt(0))) <= 2 || (xt - Convert.ToInt32(xtest.ElementAt(0))) <= -2))
                            {
                                test = field.OverlapTest(roundnum, design, CoordenatesConversor_x(1, xtest, 0), CoordenatesConversor_y(y), atk, false, ref atk, false);
                            }
                            else
                            {
                                Console.WriteLine("Limite de moves");
                                Console.ReadLine();
                            }
                        }
                        else if ((roundnum == 2 && design == "t") || (roundnum == 1 && design == "T"))
                        {
                            Console.WriteLine("Pode mover uma area de 1x1");
                            Console.WriteLine("Introduza as coordenadas para a qual deseja movê-la");
                            xtest = Utils.ReadxCoordenate();
                            y = Utils.ReadyCoordenate();
                            if (((y - yt) <= 1 || (y - yt) <= -1) && ((xt - Convert.ToInt32(xtest.ElementAt(0))) <= 1 || (xt - Convert.ToInt32(xtest.ElementAt(0))) <= -1))
                            {
                                test = field.OverlapTest(roundnum, design, CoordenatesConversor_x(1, xtest, 0), CoordenatesConversor_y(y), atk, false, ref atk, false);
                            }
                            else
                            {
                                Console.WriteLine("Limite de moves");
                                Console.ReadLine();
                            }
                        }
                        else if ((roundnum == 1 && design == "C") ||(roundnum == 2 && design == "c"))
                        {
                            Console.WriteLine("Pode mover uma area de 4x4");
                            Console.WriteLine("Introduza as coordenadas para a qual deseja movê-la");
                            xtest = Utils.ReadxCoordenate();
                            y = Utils.ReadyCoordenate();
                            if (((y - yt) <= 4 || (y - yt) <= -4) && ((xt - Convert.ToInt32(xtest.ElementAt(0))) <= 4 || (xt - Convert.ToInt32(xtest.ElementAt(0))) <= -4))
                            {
                                test = field.OverlapTest(roundnum, design, CoordenatesConversor_x(1, xtest, 0), CoordenatesConversor_y(y), atk, false, ref atk, false);
                            }
                            else
                            {
                                Console.WriteLine("Limite de moves");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tropa inexistente");
                            Console.ReadLine();
                            Console.Clear();
                            ShowField();
                            MOptions(gm);
                            test = false;
                            xtest = null;
                            y = 0;
                        }


                        if (test == true)
                        {
                            x = xtest.ElementAt(0);
                            field.MoveUnit(roundnum, xc, yc, x, y);

                            Console.Clear();
                            ShowField();
                            OverlapTest(roundnum, design, CoordenatesConversor_x(2, "", x), CoordenatesConversor_y(y), atk, false, ref atkdone, true);

                            if (design == "I" || design == "i" || design == "k" || design == "K")
                            {

                                field.DecreaseMoves(roundnum, 2);
                            }
                            else if (design == "a" || design == "A")
                            {
                                field.DecreaseMoves(roundnum, 3);
                            }
                            else if (design == "C" || design == "c")
                            {
                                field.DecreaseMoves(roundnum, 1);
                            }
                        }
                        nump--;
                    }
                    else if (msuboptions == 2)
                    {
                        atkdone = 1;

                        Console.Clear();
                        ShowField();

                        Console.WriteLine("\nIntroduza as coordenadas da tropa");

                        xc = CoordenatesConversor_x(1, Utils.ReadxCoordenate(), 0);
                        yc = CoordenatesConversor_y(Utils.ReadyCoordenate());

                        design = GetDesign(xc, yc);
                        atk = field.Atk(roundnum, xc, yc);

                        OverlapTest(roundnum, design, xc, yc, atk, false, ref atkdone, true);
                        if (atkdone == 0)
                        {
                            nump--;
                        }
                        else
                        {
                            Console.WriteLine("Não existem tropas inimigas dentro do range");
                        }
                    }
                    else if (msuboptions == 0)
                        MOptions(gm);
                }
                else Console.WriteLine("Número de moves ultrapassado");
            }

            else if (moptions == 2)
            {
                int buildType;

                Console.WriteLine("------------------Opções Construções----------------");
                Console.WriteLine("Selecionar construção: (1)");
                Console.WriteLine("Voltar: (0)");
                Console.WriteLine("----------------------------------------------------");

                msuboptions = Utils.ReadInteger("");

                if (msuboptions == 1)
                {
                    Console.WriteLine("------------------Construções----------------             Tropa produzida/Custo");
                    Console.WriteLine("Barraca: (1)                                                   (1) i ou I/60 ");
                    Console.WriteLine("Estábulo: (2)                                                  (2) c ou C/100");
                    Console.WriteLine("Armeiro: (3)                                                   (3) t ou T/160");
                    Console.WriteLine("Arcos: (4)                                                     (4) k ou K/60 ");
                    Console.WriteLine("Voltar atrás: (0)");
                    Console.WriteLine("----------------------------------------------------");

                    buildType = Utils.ReadInteger("");

                    if (buildType == 4)
                    {
                        if (field.GetNumBuilds(roundnum, 4) > 0)
                        {
                            Console.Clear();
                            ShowField();

                            Console.WriteLine("\nIntroduza as coordenadas da construção");

                            xtest = Utils.ReadxCoordenate();
                            y = Utils.ReadyCoordenate();

                            design = field.Design(CoordenatesConversor_x(1, xtest, 0), CoordenatesConversor_y(y));

                            if (design == "R" || design == "r")
                            {
                                Console.WriteLine("-------------------------------------------");
                                Console.WriteLine("Produzir Archer: (1)");
                                Console.WriteLine("Voltar: (0)");
                                Console.WriteLine("-------------------------------------------");

                                moptions = Utils.ReadInteger("");

                                if (moptions != 1 && moptions != 0)
                                {
                                    MensageError(buildType, gm);
                                }
                                else if (moptions == 1)
                                {
                                    if (field.ShowCoins(roundnum) >= 60)
                                    {
                                        SelBuild(moptions, xtest, y);
                                        nump--;
                                    }
                                    else Console.WriteLine("Coins insuficientes");
                                }
                                else
                                {
                                    Console.Clear();
                                    ShowField();
                                    MOptions(gm);
                                }
                            }
                            else Console.WriteLine("Construção mal selecionada");
                        }
                        else
                        {
                            MensageErrorNumBuilds(gm);
                        }
                    }
                    else if (buildType == 1)
                    {
                        if (field.GetNumBuilds(roundnum, 1) > 0)
                        {
                            Console.WriteLine("Introduza as coordenadas da construção");

                            xtest = Utils.ReadxCoordenate();
                            y = Utils.ReadyCoordenate();
                            design = field.Design(CoordenatesConversor_x(1, xtest, 0), CoordenatesConversor_y(y));

                            if (design == "B" || design == "b")
                            {

                                Console.WriteLine("-------------------------------------------");
                                Console.WriteLine("Produzir Infantary: (4)");
                                Console.WriteLine("Voltar: (0)");
                                Console.WriteLine("-------------------------------------------");
                                moptions = Utils.ReadInteger("");

                                if (moptions != 4 && moptions != 0)
                                {
                                    MensageError(buildType, gm);
                                }
                                else if (moptions == 4)
                                {
                                    if (field.ShowCoins(roundnum) >= 60)
                                    {
                                        SelBuild(moptions, xtest, y);
                                        nump--;
                                    }
                                    else Console.WriteLine("Coins insuficientes");
                                }
                                else
                                {
                                    Console.Clear();
                                    ShowField();
                                    MOptions(gm);
                                }
                            }
                            Console.WriteLine("Construção mal selecionada");
                        }
                        else
                        {
                            MensageErrorNumBuilds(gm);
                        }
                    }
                    else if (buildType == 2)
                    {
                        if (field.GetNumBuilds(roundnum, 2) > 0)
                        {
                            Console.WriteLine("Introduza as coordenadas da construção");

                            xtest = Utils.ReadxCoordenate();
                            y = Utils.ReadyCoordenate();
                            design = field.Design(CoordenatesConversor_x(1, xtest, 0), CoordenatesConversor_y(y));

                            if (design == "s" || design == "S")
                            {
                                Console.WriteLine("-------------------------------------------");
                                Console.WriteLine("Produzir Cavalry: (3)");
                                Console.WriteLine("Voltar:(0)");
                                Console.WriteLine("-------------------------------------------");

                                moptions = Utils.ReadInteger("");
                                if (moptions != 3 && moptions != 0)
                                {
                                    MensageError(buildType, gm);
                                }
                                else if (moptions == 3)
                                {
                                    if (field.ShowCoins(roundnum) >= 100)
                                    {
                                        SelBuild(moptions, xtest, y);
                                        nump--;
                                    }
                                    else Console.WriteLine("Coins insuficientes");
                                }
                                else
                                {
                                    Console.Clear();
                                    ShowField();
                                    MOptions(gm);
                                }
                            }
                            Console.WriteLine("Construção mal selecionada");
                        }
                        else
                        {
                            MensageErrorNumBuilds(gm);
                        }
                    }
                    else if (buildType == 3)
                    {
                        if (field.GetNumBuilds(roundnum, 3) > 0)
                        {
                            Console.WriteLine("Introduza as coordenadas da construção");

                            xtest = Utils.ReadxCoordenate();
                            y = Utils.ReadyCoordenate();
                            design = field.Design(CoordenatesConversor_x(1, xtest, 0), CoordenatesConversor_y(y));

                            if (design == "a" || design == "A")
                            {
                                Console.WriteLine("-------------------------------------------");
                                Console.WriteLine("Produzir Artillary: (2)");
                                Console.WriteLine("Voltar: (0)");
                                Console.WriteLine("-------------------------------------------");

                                moptions = Utils.ReadInteger("");

                                if (moptions != 2 && moptions != 0)
                                {
                                    MensageError(buildType, gm);
                                }
                                else if (moptions == 2)
                                {
                                    if (field.ShowCoins(roundnum) >= 160)
                                    {
                                        SelBuild(moptions, xtest, y);
                                        nump--;
                                    }
                                    else Console.WriteLine("Coins insuficientes");
                                }
                                else
                                {
                                    Console.Clear();
                                    ShowField();
                                    MOptions(gm);
                                }
                            }
                            Console.WriteLine("Construção mal selecionada");
                        }
                        else
                        {
                            MensageErrorNumBuilds(gm);
                        }
                    }
                }
                else if (msuboptions == 0)
                    MOptions(gm);
            }

            else if (moptions == 3)
            {
                int type;

                Console.WriteLine("---Que Tipo de construção deseja fazer-----");
                Console.WriteLine("                                                 Cost (Build/Unit): ");
                Console.WriteLine("Farm: (1)                                         (1) - 100/0 coins");
                Console.WriteLine("Barraca: (2)                                      (2) - 175/160 coins");
                Console.WriteLine("Estábulo: (3)                                     (3) - 175/100 coins ");
                Console.WriteLine("Armeiro: (4)                                      (4) - 200/70 coins ");
                Console.WriteLine("Arcos: (5)                                        (5) - 150/60 coins ");
                Console.WriteLine("Voltar atrás: (0)");

                type = Utils.ReadInteger("");

                if (type <= 5 && type > 0)
                {
                    Console.Clear();
                    ShowField();

                    Console.WriteLine("\nO player 1 só pode construir até à linha 7 e o player 2 só a partir da linha 11");
                    Console.WriteLine("Escreva no formato seguinte:\nx \ny");

                    xtest = Utils.ReadxCoordenate();
                    x = Convert.ToInt32(xtest.ElementAt(0));
                    y = Utils.ReadyCoordenate();

                    test = false;

                    if (roundnum == 1 && y < 8)
                    {
                        test = true;
                    }
                    else if (roundnum == 2 && y > 10)
                    {
                        test = true;
                    }
                    else
                    {
                        test = false;
                        Console.WriteLine("Não pode construir nesta zona");
                    }

                    if (test == true)
                    {
                        try
                        {
                            if (field.OverlapTest(roundnum, " ", CoordenatesConversor_x(1, xtest, 0), CoordenatesConversor_y(y), 0, true, ref atkdone, false)) //Fazer teste de Overlap
                            {
                                test = field.OverlapTest(roundnum, " ", CoordenatesConversor_x(2, "", x + 1), CoordenatesConversor_y(y), 0, true, ref atkdone, false);

                                if (x + 1 > 'z' || (x + 1 > 'Z' && x + 1 < 'a'))
                                {
                                    test = false;
                                }

                                if (test == false)
                                {
                                    if (((field.OverlapTest(roundnum, " ", CoordenatesConversor_x(2, "", x - 1), CoordenatesConversor_y(y), 0, true, ref atkdone, false)) == false) || ((x - 1 < 65) || (x - 1 < 97)))
                                    {
                                        Console.WriteLine("Espaço insuficiente");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        field.BuildType(roundnum, type, x, y, test);
                                        nump--;
                                    }
                                }
                                else
                                {
                                    field.BuildType(roundnum, type, x, y, test);
                                    nump--;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Não possui coins suficientes!!");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.ReadLine();
                        Console.Clear();
                        ShowField();
                        MOptions(gm);
                    }
                }
                else
                {
                    Console.Clear();
                    ShowField();
                    MOptions(gm);
                }
            }

            else if (moptions == 4)
            {
                nump = 0;
            }

            else if (moptions == 5)
            {
                int giveUp;

                Console.Clear();
                Console.WriteLine("Pretende realmente desistir? ");
                Console.WriteLine("Sim: (1) ");
                Console.WriteLine("Não: (2) ");

                giveUp = Utils.ReadInteger("");

                if (giveUp == 1)
                {
                    Console.Clear();
                    field.GiveUp(roundnum);
                    endGame = true;
                    Console.Clear();
                    Console.WriteLine("O jogo vai recomeçar mas para isso introduza os nomes dos players que vão agora jogar \n");
                }

                else if (giveUp == 2)
                {
                    Console.Clear();
                    ShowField();
                    MOptions(gm);
                }
            }

            if (field.BaseHP(roundnum) <= 0)
            {
                Console.Clear();
                Console.WriteLine("-----------------------");
                Console.WriteLine(Playerround() + "Ganhou o Jogo");
                Console.WriteLine("-----------------------");
                Console.ReadLine();
                Console.Clear();
                endGame = true;
            }

            if (nump <= 0)
            {
                field.ResetMoves(roundnum);
                field.CoinsNextRound(roundnum);
                Round();
            }

            return endGame;
        }

        private string GetDesign(int x, int y)
        {
            return field.Design(x, y);
        }

        private bool OverlapTest(int round, string design, int x, int y, int atk, bool firstime, ref int atkdone, bool toatk)
        {
            return field.OverlapTest(round, design, x, y, atk, firstime, ref atkdone, toatk);
        }

        private int CreateUnit(int round, int buildType, int x, int y, bool test2)
        {
            field.UnitType(roundnum, buildType, x, y, test2);

            return 46;
        }

        // Mensagem de erro que aparece quando o player introduz mal as coordenadas de builds/units
        private int MensageError(int buildType, int gm)
        {
            buildType = 66;
            Console.WriteLine("!!Carater Errado!!");
            Console.ReadLine();
            Console.Clear();
            ShowField();
            MOptions(gm);

            return buildType;
        }

        //Mensagem de erro quando não há construções
        private void MensageErrorNumBuilds(int gm)
        {
            Console.WriteLine("Tem de construir primeiro");
            Console.ReadLine();
            Console.Clear();
            ShowField();
            MOptions(gm);
        }

        private void SelBuild(int unitype, string x, int y)
        {
            bool test = false;
            char xun;
            int stop = 0;

            xun = Convert.ToChar(x);

            for (int countx = 2; countx >= -1; countx--)
            {
                for (int county = 1; county >= -1; county--)
                {
                    test = true;

                    if (xun + countx < 'A' || (xun + countx > 'Z' && xun + countx < 'a') || xun + countx > 'z')
                    {
                        test = false;
                    }

                    if (y + county < 0 || y + county > 16)
                    {
                        test = false;
                    }

                    if (test)
                    {
                        if (OverlapTest(roundnum, " ", CoordenatesConversor_x(2, "", xun + countx), CoordenatesConversor_y(y + county), 0, true, ref atkdone, false))
                        {
                            stop = 4;
                            CreateUnit(roundnum, unitype, xun + countx, y + county, true);
                            break;
                        }
                    }
                }
                if (stop == 4)
                {
                    break;
                }
            }
        }

    }
}
