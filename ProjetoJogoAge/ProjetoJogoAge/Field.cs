using System;
using System.Collections;
using System.Linq;

namespace ProjetoJogoAge
{
    class Field
    {
        Player Player;
        Hashtable players;

        public Hashtable Players { get => players; set => players = value; }

        public Field()
        {
            players = new Hashtable();
        }

        //Método para obter o nome do player
        public int PlayerName(int Pp, string name)
        {
            Player = new Player(name);

            players.Add(Pp, Player);

            return Pp;
        }

        public string Name()
        {
            string s = "";

            foreach (DictionaryEntry de in players)
            {
                s += de.Value.ToString() + "\n";
            }
            return s;
        }

        //construção do campo de jogo
        public string ShowField()
        {

            string sc = " ";
            int i, j;  //i-linha j-coluna
            int v, h;
            string letra = "A";
            char cletra;


            v = 0;

            cletra = letra.ElementAt(0);
            h = Convert.ToInt32(cletra);

            for (j = 0; j <= 51; j++)
            {

                for (i = 1; i <= 79; i++)
                {
                    if (j == 0)
                    {
                        while (h < 91)
                        {
                            if (h == 65)
                            {
                                Console.Write("   " + (char)h++);
                            }
                            Console.Write(" " + (char)h);
                            h++;
                        }
                    }
                    else if (j == 1)
                    {
                        if (i <= 76)
                        {
                            if (i == 1)
                            {
                                Console.Write("\n  " + char.ConvertFromUtf32(9484) + char.ConvertFromUtf32(9472));
                            }
                            else if (i == 76)
                            {
                                Console.Write(Char.ConvertFromUtf32(9488));
                            }
                            else if (i % 3 == 0)
                            {
                                Console.Write(char.ConvertFromUtf32(9472));
                            }
                            else if (i % 2 == 0)
                            {
                                Console.Write(char.ConvertFromUtf32(9516));
                            }
                        }
                    }
                    else if (j == 51)
                    {
                        if (i == 1 || i == 0)
                        { }
                        else if (i == 2)
                        {
                            Console.Write("\n  " + char.ConvertFromUtf32(9492));
                        }
                        else if (i == 79)
                        {
                            Console.Write(char.ConvertFromUtf32(9496));
                        }
                        else if (i % 3 == 0)
                        {
                            Console.Write(char.ConvertFromUtf32(9472));
                        }
                        else if (i % 2 == 0)
                        {
                            Console.Write(char.ConvertFromUtf32(9524));
                        }
                    }
                    else if (j % 3 == 0)
                    {

                        if (i == 0 || i == 1)
                        {
                        }
                        else if (i == 2)
                        {
                            Console.Write("\n  " + char.ConvertFromUtf32(9500));
                        }
                        else if (i == 79)
                        {
                            Console.Write(char.ConvertFromUtf32(9508));
                        }
                        else if (i % 3 == 0)
                        {
                            Console.Write(char.ConvertFromUtf32(9472));
                        }
                        else if (i % 2 == 0)
                        {
                            Console.Write(char.ConvertFromUtf32(9532));
                        }
                    }
                    else if (j % 2 == 0)
                    {
                        if (v < 10)
                        {
                            if (i == 1)
                            {
                                Console.Write("\n " + v++ + char.ConvertFromUtf32(9474));
                            }
                            else if (i % 3 == 0)
                            {
                                Console.Write(char.ConvertFromUtf32(9474));
                            }
                            else if (i % 2 == 0)
                            {
                                Console.Write(Test(i, j));
                            }
                        }
                        else
                        {
                            if (i == 1)
                            {
                                Console.Write("\n" + v++ + char.ConvertFromUtf32(9474));
                            }
                            else if (i % 3 == 0)
                            {
                                Console.Write(char.ConvertFromUtf32(9474));
                            }
                            else if (i % 2 == 0)
                            {
                                Console.Write(Test(i, j));
                            }
                        }
                    }

                }

            }
            return sc;
        }

        //Método que vai buscar toda a informação necessária para construir um tipo de construção diferente
        public int BuildType(int round, int type, int x, int y, bool test2)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                p1.NewType_GameUnit(type, round, x, y, test2);
            }
            else if (round == 2)
            {
                p2.NewType_GameUnit(type, round, x, y, test2);
            }
            return 46;
        }

        //Método que vai buscar a informação para cada unidade para depois ser utlilizada mais à frente quando houver uma construção
        public int UnitType(int round, int type, int x, int y, bool test2)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                p1.UnitType(type, round, x, y, test2);
            }
            else if (round == 2)
            {
                p2.UnitType(type, round, x, y, test2);
            }

            return 46;
        }

        public string Test(int j, int i)
        {
            string design = " ";

            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            foreach (GameUnit o in p1.GetBM().GetBuildings())
            {
                if (o.OverLapTest(j, i) == true)
                {
                    design = o.GetDesign();
                }
            }

            foreach (GameUnit o in p2.GetBM().GetBuildings())
            {
                if (o.OverLapTest(j, i) == true)
                {
                    design = o.GetDesign();
                }
            }

            foreach (GameUnit o in p1.GetUM().GetUnits())
            {
                if (o.OverLapTest(j, i) == true)
                {
                    design = o.GetDesign();
                }
            }

            foreach (GameUnit o in p2.GetUM().GetUnits())
            {
                if (o.OverLapTest(j, i) == true)
                {
                    design = o.GetDesign();
                }
            }

            return design;
        } //Para o campo 

        //Método para buscar o design de cada tropa
        public string Design(int x, int y)
        {
            string design = "0";

            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;
            foreach (GameUnit o in p1.GetBM().GetBuildings())
            {
                if (o.OverLapTest(x, y) == true)
                {
                    design = o.GetDesign();
                }
            }
            foreach (GameUnit o in p2.GetBM().GetBuildings())
            {
                if (o.OverLapTest(x, y) == true)
                {
                    design = o.GetDesign();
                }
            }

            foreach (MovingUnit o in p1.GetUM().GetUnits())
            {
                if (o.OverLapTest(x, y) == true)
                {
                    design = o.GetDesign();
                }
            }
            foreach (MovingUnit o in p2.GetUM().GetUnits())
            {
                if (o.OverLapTest(x, y) == true)
                {
                    design = o.GetDesign();
                }
            }

            return design;
        }

        //Método para obter o ataque de cada tropa
        public int Atk(int round, int x, int y)
        {
            int atk = 0;
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;
            if (round == 1)
            {
                foreach (MovingUnit o in p1.GetUM().GetUnits())
                {
                    if (o.OverLapTest(x, y))
                    {
                        atk = o.GetAtk();
                    }
                    else atk = 0;
                }
            }
            else if (round == 2)
            {
                foreach (MovingUnit o in p2.GetUM().GetUnits())
                {
                    if (o.OverLapTest(x, y))
                    {
                        atk = o.GetAtk();
                    }
                    else atk = 0;
                }
            }
            return atk;
        }

        public void BaseWar()
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            p1.BaseWar();
            p2.BaseWar();
        }

        //Método que verifica o overlap e que junta as unidades, soma o ataque das unidades, diminui a vida das unidades
        public bool OverlapTest(int round, string design, int x, int y, int atk, bool firstime, ref int atkdone, bool toatk)
        {
            bool testb = false;
            int test3 = 0;
            bool testS = false;
            string designtest;
            int hp;
            int opcao = 0;
            int numatks = 1;

            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            object muToRemove = null;

            foreach (MovingUnit o in p1.GetUM().GetUnits())
            {
                designtest = o.GetDesign();
                hp = o.GetHp();

                if (round == 1)
                {
                    if (toatk == false)
                    {
                        if (firstime == false)
                        {
                            if (o.OverLapTest(x, y))
                            {
                                if (design == designtest)
                                {
                                    o.IncreaseAtk(atk);
                                    test3 = 1;
                                    testS = true;
                                }
                                else test3 = 2;
                            }
                        }
                        else if ((firstime == true) && o.OverLapTest(x, y))
                        {
                            test3 = 6;
                        }
                    }
                }
                else
                {
                    if (toatk)
                    {
                        if (firstime == false)
                        {
                            if (numatks == 1)
                            {
                                if (RangeTest(round, x, y, o.GetX(), o.GetY()))
                                {
                                    Console.WriteLine("Deseja atacar a tropa " + o.GetDesign());
                                    Console.WriteLine("1: SIM");
                                    Console.WriteLine("2: NÃO");
                                    opcao = Utils.ReadInteger("");
                                    if (opcao == 1)
                                    {
                                        o.DescreaseHp(atk);
                                        Console.WriteLine("Hp =" + o.GetHp());
                                        numatks--;
                                        test3 = 3;
                                        if (o.GetHp() == 0)
                                        {
                                            testb = true;
                                            testS = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if ((firstime == true) && o.OverLapTest(x, y))
                    {
                        test3 = 6;
                    }
                }
            }

            foreach (MovingUnit o in p2.GetUM().GetUnits())
            {
                designtest = o.GetDesign();
                hp = o.GetHp();

                if (round == 2)
                {
                    if (toatk == false)
                    {
                        if (firstime == false)
                        {
                            if (o.OverLapTest(x, y))
                            {
                                if (design == designtest)
                                {
                                    o.IncreaseAtk(atk);
                                    test3 = 1;
                                    testS = true;
                                }
                                else test3 = 2;
                            }
                        }
                        else if ((firstime == true) && o.OverLapTest(x, y))
                        {
                            test3 = 6;
                        }
                    }
                }
                else
                {
                    if (toatk)
                    {
                        if (firstime == false)
                        {
                            if (numatks == 1)
                            {
                                if (RangeTest(round, x, y, o.GetX(), o.GetY()))
                                {
                                    Console.WriteLine("Deseja atacar a tropa " + o.GetDesign());
                                    Console.WriteLine("1: SIM");
                                    Console.WriteLine("2: NÃO");
                                    opcao = Utils.ReadInteger("");
                                    if (opcao == 1)
                                    {
                                        o.DescreaseHp(atk);
                                        Console.WriteLine("Hp =" + o.GetHp());
                                        numatks--;
                                        test3 = 3;
                                        if (o.GetHp() == 0)
                                        {
                                            testb = true;
                                            testS = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (GameUnit o in p1.GetBM().GetBuildings())
            {
                designtest = o.GetDesign();
                hp = o.GetHp();

                if (round == 1)
                {
                    if (o.OverLapTest(x, y))
                    {
                        test3 = 5;
                    }
                }
                else
                {
                    if (toatk)
                    {
                        if (firstime == false)
                        {
                            if (numatks == 1)
                            {
                                if (RangeTest(round, x, y, o.GetX(), o.GetY()))
                                {
                                    Console.WriteLine("Deseja atacar a Construção " + o.GetDesign());
                                    Console.WriteLine("1: SIM");
                                    Console.WriteLine("2: NÃO");
                                    opcao = Utils.ReadInteger("");
                                    if (opcao == 1)
                                    {
                                        if (design == "a")
                                        {
                                            atk = atk * (20 / 3);
                                        }
                                        else if (design == "k" || design == "i")
                                        {
                                            atk = atk * 3;
                                        }
                                        else if (design == "c")
                                        {
                                            atk = atk * 10;
                                        }

                                        o.DescreaseHp(atk);
                                        Console.WriteLine("Hp =" + o.GetHp());
                                        numatks--;
                                        test3 = 3;
                                        if (o.GetHp() == 0)
                                        {
                                            testb = true;
                                            testS = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (GameUnit o in p2.GetBM().GetBuildings())
            {
                designtest = o.GetDesign();
                hp = o.GetHp();

                if (round == 2)
                {
                    if (o.OverLapTest(x, y))
                    {
                        test3 = 5;
                    }
                }
                else
                {
                    if (toatk)
                    {
                        if (firstime == false)
                        {
                            if (numatks == 1)
                            {
                                if (RangeTest(round, x, y, o.GetX(), o.GetY()))
                                {
                                    Console.WriteLine("Deseja atacar a Construção " + o.GetDesign());
                                    Console.WriteLine("1: SIM");
                                    Console.WriteLine("2: NÃO");
                                    opcao = Utils.ReadInteger("");
                                    if (opcao == 1)
                                    {
                                        if (design == "A")
                                        {
                                            atk = 400;
                                        }
                                        else if (design == "K" || design == "I")
                                        {
                                            atk = atk * 3;
                                        }
                                        else if (design == "C")
                                        {
                                            atk = atk * 10;
                                        }

                                        o.DescreaseHp(atk);
                                        Console.WriteLine("Hp =" + o.GetHp());
                                        numatks--;
                                        test3 = 3;
                                        if (o.GetHp() == 0)
                                        {
                                            testb = true;
                                            testS = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (DictionaryEntry de in p1.GetUM().Units)
            {
                if (((MovingUnit)de.Value).GetHp() <= 0 || testS == true)
                {
                    muToRemove = de.Key;
                }
            }

            foreach (DictionaryEntry de in p2.GetUM().Units)
            {
                if (((MovingUnit)de.Value).GetHp() <= 0 || testS == true)
                {
                    muToRemove = de.Key;
                }
            }

            foreach (DictionaryEntry de in p1.GetBM().Builds)
            {
                if (((GameUnit)de.Value).GetHp() <= 0 || testS == true)
                {
                    muToRemove = de.Key;
                }
            }

            foreach (DictionaryEntry de in p2.GetBM().Builds)
            {
                if (((GameUnit)de.Value).GetHp() <= 0 || testS == true)
                {
                    muToRemove = de.Key;
                }
            }

            if (muToRemove != null)
            {
                if (round == 1)
                {
                    p2.GetUM().Units.Remove(muToRemove);
                    p2.GetBM().Builds.Remove(muToRemove);
                }
                else
                {
                    p1.GetUM().Units.Remove(muToRemove);
                    p1.GetBM().Builds.Remove(muToRemove);
                }
            }

            muToRemove = null;

            if (test3 == 1)
            {
                Console.WriteLine("Juntou duas unidades");
                Console.ReadLine();
            }
            else if (test3 == 2)
            {
                Console.WriteLine("Não pode juntar tropas de tipos diferentes");
                Console.ReadLine();
            }
            else if (test3 == 3)
            {
                Console.WriteLine("Ataque feito com sucesso");
                Console.ReadLine();
            }
            else if (test3 == 4)
            {
                Console.WriteLine("Moveu com sucesso");
                testb = true;
                Console.ReadLine();
            }
            else if (test3 == 5)
            {
                Console.WriteLine("Não permitido overlap");
                Console.ReadLine();
            }
            else if (test3 == 6)
            {

            }
            else if (test3 == 0)
            {
                testb = true;
            }
            atkdone = numatks;

            return testb;
        }

        public bool RangeTest(int round, int x, int y, int xrange, int yrange)
        {
            bool range = false;

            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                foreach (MovingUnit mu in p1.GetUM().GetUnits())
                {
                    if (mu.GetX() == x && mu.GetY() == y)
                    {
                        range = mu.OverlapRange(xrange, yrange);
                        break;
                    }

                }
            }
            else if (round == 2)
            {
                foreach (MovingUnit mu in p2.GetUM().GetUnits())
                {
                    if (mu.GetX() == x && mu.GetY() == y)
                    {
                        range = mu.OverlapRange(xrange, yrange);
                        break;
                    }

                }
            }


            return range;
        }

        public void MoveUnit(int round, int x, int y, int xunit, int yunit)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                foreach (MovingUnit o in p1.GetUM().GetUnits())
                {
                    if (o.OverLapTest(x, y))
                    {
                        o.MoveUnit(xunit, yunit);
                    }
                }
            }
            else if (round == 2)
            {
                foreach (MovingUnit o in p2.GetUM().GetUnits())
                {
                    if (o.OverLapTest(x, y))
                    {
                        o.MoveUnit(xunit, yunit);
                    }
                }
            }
        }

        //Método que vai construir a base de cada player
        public void BaseMaker(int round, int x, int y, bool test2)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                p1.BaseMaker(round, x, y, test2);
            }
            else if (round == 2)
            {
                p2.BaseMaker(round, x, y, test2);
            }
        }

        //Método para gerar as coins em cada round
        public void CoinsNextRound(int round)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                p1.CoinsNextRound();
            }
            else
            {
                p2.CoinsNextRound();
            }
        }

        //Método para mostrar as coins que cada player tem
        public int ShowCoins(int round)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            int coins;

            if (round == 1)
            {
                coins = p1.ShowCoins();
            }
            else
            {
                coins = p2.ShowCoins();
            }

            return coins;
        }

        //Método para mostrar os moves que restam para cada player
        public int ShowMovesLeft(int round)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            int movesLeft;

            if (round == 1)
            {
                movesLeft = p1.ShowMovesLeft();
            }
            else
            {
                movesLeft = p2.ShowMovesLeft();
            }

            return movesLeft;
        }

        public void DecreaseMoves(int round, int num)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                p1.decreasemoves(num);
            }
            else
            {
                p2.decreasemoves(num);
            }

        }

        public void ResetMoves(int round)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                p1.ResetMoves();
            }
            else
            {
                p2.ResetMoves();
            }

        }

        //Método para mostrar quem perde ao desistir do jogo
        public void GiveUp(int round)
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                Console.WriteLine("O player " + p2.GetPlayerName() + " ganhou");
                Console.ReadLine();
            }
            else if (round == 2)
            {
                Console.WriteLine("O player " + p1.GetPlayerName() + " ganhou");
                Console.ReadLine();
            }
        }

        public int GetNumBuilds(int round, int type)
        {
            int n_builds = 0;

            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            if (round == 1)
            {
                n_builds = p1.GetNumBuild(type);
            }
            else if (round == 2)
            {
                n_builds = p2.GetNumBuild(type);
            }

            return n_builds;
        }

        public bool UnitsOnBuilds(int round, int type, int x, int y)
        {
            bool test = false;

            string design = null;

            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            //Teste para saber qual é o design
            if (type == 1)
            {
                if (round == 1)
                {
                    design = "B";
                }
                else if (round == 2)
                {
                    design = "b";
                }
            }
            else if (type == 2)
            {
                if (round == 1)
                {
                    design = "S";
                }
                else if (round == 2)
                {
                    design = "s";
                }
            }
            else if (type == 3)
            {
                if (round == 1)
                {
                    design = "A";
                }
                else if (round == 2)
                {
                    design = "a";
                }
            }
            else if (type == 4)
            {
                if (round == 1)
                {
                    design = "R";
                }
                else if (round == 2)
                {
                    design = "r";
                }
            }

            if (round == 1)
            {
                foreach (GameUnit o in p1.GetBM().GetBuildings())
                {

                    if (o.OverLapTest(x, y) == true && design == o.GetDesign())
                    {
                        test = true;
                    }
                }
            }
            else if (round == 2)
            {
                foreach (GameUnit o in p2.GetBM().GetBuildings())
                {
                    if (o.OverLapTest(x, y) == true && design == o.GetDesign())
                    {
                        test = true;
                    }
                }
            }
            return test;
        }

        public int BaseHP(int round)
        {
            int hp = 0;

            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;
            if (round == 2)
            {
                foreach (GameUnit gm in p1.GetBM().GetBuildings())
                {
                    if (gm.GetDesign() == "O")
                    {
                        hp = gm.GetHp();
                    }
                }
            }
            else if (round == 1)
            {
                foreach (GameUnit gm in p2.GetBM().GetBuildings())
                {
                    if (gm.GetDesign() == "o")
                    {
                        hp = gm.GetHp();
                    }
                }
            }
            return hp;
        }

        //Método para dar restart ao jogo, para que possa ser jogável outra vez do início
        public void EndGame()
        {
            Player p1 = players[0] as Player;
            Player p2 = players[1] as Player;

            Players.Remove(0);
            Players.Remove(1);
        }
    }
}

