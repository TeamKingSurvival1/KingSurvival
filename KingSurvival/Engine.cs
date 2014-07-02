namespace KingSurvival
{
    using System;

    public class Engine
    {
        static int size = 8;
        static Car car = new Car(4, 7);


        static Peshka peshkaA = new Peshka(1, 0);

        static Peshka peshkaB = new Peshka(3, 0);

        static Peshka peshkaC = new Peshka(5, 0);

        static Peshka peshkaD = new Peshka(7, 0);

        static bool isKingTurn = true;

        public void Run()
        {
            char[,] matrica = new char[,]   {{'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'}};


            matrica[peshkaA.Y, peshkaA.X] = 'A';
            matrica[peshkaB.Y, peshkaB.X] = 'B';
            matrica[peshkaC.Y, peshkaC.X] = 'C';
            matrica[peshkaD.Y, peshkaD.X] = 'D';
            matrica[car.Y, car.X] = 'K';
            ConsoleRenderer.Instance.Render(matrica);
            bool pobedaPeshki = false;

            while (car.Y > 0 && car.Y < size && !pobedaPeshki)
            {
                isKingTurn = true;
                while (isKingTurn)
                {
                    isKingTurn = false;

                    ConsoleRenderer.Instance.Render(matrica);
                    Console.Write("King`s Turn:");
                    string direction = Console.ReadLine();
                    if (direction == "")
                    {
                        isKingTurn = true;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "KUL":
                            {
                                Car.KingMove(car, peshkaA, peshkaB, peshkaC, peshkaD, -1, -1, matrica, ref isKingTurn);
                                break;
                            }
                        case "KUR":
                            {
                                Car.KingMove(car, peshkaA, peshkaB, peshkaC, peshkaD, 1, -1, matrica, ref isKingTurn);
                                break;
                            }
                        case "KDL":
                            {
                                Car.KingMove(car, peshkaA, peshkaB, peshkaC, peshkaD, -1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        case "KDR":
                            {
                                Car.KingMove(car, peshkaA, peshkaB, peshkaC, peshkaD, 1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        default:
                            {
                                isKingTurn = true;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }

                    }
                }
                while (!isKingTurn)
                {
                    isKingTurn = true;
                    ConsoleRenderer.Instance.Render(matrica);
                    Console.Write("Pawn`s Turn:");
                    string direction = Console.ReadLine();
                    if (direction == "")
                    {
                        isKingTurn = false;
                        continue;
                    }

                    direction = direction.ToUpper();

                    switch (direction)
                    {
                        case "ADR":
                            {
                                pobedaPeshki = Peshka.PawnAMove(peshkaA, 1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        case "ADL":
                            {
                                pobedaPeshki = Peshka.PawnAMove(peshkaA, -1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        case "BDL":
                            {
                                pobedaPeshki = Peshka.PawnBMove(peshkaB, -1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        case "BDR":
                            {
                                pobedaPeshki = Peshka.PawnBMove(peshkaB, 1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        case "CDL":
                            {
                                pobedaPeshki = Peshka.PawnCMove(peshkaC, -1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        case "CDR":
                            {
                                pobedaPeshki = Peshka.PawnCMove(peshkaC, 1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        case "DDR":
                            {
                                pobedaPeshki = Peshka.PawnDMove(peshkaD, 1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        case "DDL":
                            {
                                pobedaPeshki = Peshka.PawnDMove(peshkaD, -1, 1, matrica, ref isKingTurn);
                                break;
                            }
                        default:
                            {
                                isKingTurn = false;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }
                    ConsoleRenderer.Instance.Render(matrica);
                }
            }
            if (pobedaPeshki)
            {
                Console.WriteLine("Pawn`s win!");
            }
            else
            {
                Console.WriteLine("King`s win!");
            }
        }
    }
}
