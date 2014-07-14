namespace KingSurvival
{
    using System;

    public class Engine
    {
        static int size = 8;
        static King car = new King(4, 7);


        static Pawn peshkaA = new Pawn(1, 0);

        static Pawn peshkaB = new Pawn(3, 0);

        static Pawn peshkaC = new Pawn(5, 0);

        static Pawn peshkaD = new Pawn(7, 0);

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


            matrica[peshkaA.Position.Y, peshkaA.Position.X] = 'A';
            matrica[peshkaB.Position.Y, peshkaB.Position.X] = 'B';
            matrica[peshkaC.Position.Y, peshkaC.Position.X] = 'C';
            matrica[peshkaD.Position.Y, peshkaD.Position.X] = 'D';
            matrica[car.Position.Y, car.Position.X] = 'K';
            ConsoleRenderer.Instance.Render(matrica);
            bool pobedaPeshki = false;

            while (car.Position.Y > 0 && car.Position.Y < size && !pobedaPeshki)
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
                        case "KUL": car.Move();
                            break;
                        case "KUR": car.Move();
                            break;
                        case "KDL": car.Move();
                            break;
                        case "KDR": car.Move();
                            break;
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
                        case "ADR": peshkaA.Move();
                            break;
                        case "ADL": peshkaA.Move();
                            break;
                        case "BDL": peshkaB.Move();
                            break;
                        case "BDR": peshkaB.Move();
                            break;
                        case "CDL": peshkaC.Move();
                            break;
                        case "CDR": peshkaC.Move();
                            break;
                        case "DDR": peshkaD.Move();
                            break;
                        case "DDL": peshkaD.Move();
                            break;
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
