namespace KingSurvival
{
    using System;

    public class Engine
    {
        // The original game is played on a standard chess-board of size 8 x 8 cells.
        static int gameBoardSize = 8;
        static King theKing = new King(4, 7);


<<<<<<< HEAD
        static Pawn pawnA = new Pawn(1, 0);

        static Pawn pawnB = new Pawn(3, 0);

        static Pawn pawnC = new Pawn(5, 0);

        static Pawn pawnD = new Pawn(7, 0);
=======
        static Pawn peshkaA = new Pawn(1, 0);

        static Pawn peshkaB = new Pawn(3, 0);

        static Pawn peshkaC = new Pawn(5, 0);

        static Pawn peshkaD = new Pawn(7, 0);
>>>>>>> 3f4ffc5009ed25a8071dc94815964ca91689ded7

        static bool isKingsTurn = true;

        public void Run()
        {
            char[,] gameBoard = new char[,]   {{'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'},
                                            {'+','-','+','-','+','-','+','-'},
                                            {'-','+','-','+','-','+','-','+'}};


<<<<<<< HEAD
            gameBoard[pawnA.Y, pawnA.X] = 'A';
            gameBoard[pawnB.Y, pawnB.X] = 'B';
            gameBoard[pawnC.Y, pawnC.X] = 'C';
            gameBoard[pawnD.Y, pawnD.X] = 'D';
            gameBoard[theKing.Y, theKing.X] = 'K';
            ConsoleRenderer.Instance.Render(gameBoard);
            bool pawnsWin = false;

            while (theKing.Y > 0 && theKing.Y < gameBoardSize && !pawnsWin)
=======
            matrica[peshkaA.Position.Y, peshkaA.Position.X] = 'A';
            matrica[peshkaB.Position.Y, peshkaB.Position.X] = 'B';
            matrica[peshkaC.Position.Y, peshkaC.Position.X] = 'C';
            matrica[peshkaD.Position.Y, peshkaD.Position.X] = 'D';
            matrica[car.Position.Y, car.Position.X] = 'K';
            ConsoleRenderer.Instance.Render(matrica);
            bool pobedaPeshki = false;

            while (car.Position.Y > 0 && car.Position.Y < size && !pobedaPeshki)
>>>>>>> 3f4ffc5009ed25a8071dc94815964ca91689ded7
            {
                isKingsTurn = true;
                while (isKingsTurn)
                {
                    isKingsTurn = false;

                    ConsoleRenderer.Instance.Render(gameBoard);
                    Console.Write("King`s Turn:");
<<<<<<< HEAD
                    string moveDirection = Console.ReadLine();
                    if (moveDirection == "")
=======
                    string direction = Console.ReadLine();

                    if (direction == "")
>>>>>>> 3f4ffc5009ed25a8071dc94815964ca91689ded7
                    {
                        isKingsTurn = true;
                        continue;
                    }

                    moveDirection = moveDirection.ToUpper();

                    switch (moveDirection)
                    {
<<<<<<< HEAD
                        case "KUL":
                            {
                                King.MoveTheKing(theKing, pawnA, pawnB, pawnC, pawnD, -1, -1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "KUR":
                            {
                                King.MoveTheKing(theKing, pawnA, pawnB, pawnC, pawnD, 1, -1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "KDL":
                            {
                                King.MoveTheKing(theKing, pawnA, pawnB, pawnC, pawnD, -1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "KDR":
                            {
                                King.MoveTheKing(theKing, pawnA, pawnB, pawnC, pawnD, 1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
=======
                        case "KUL": car.Move();
                            break;
                        case "KUR": car.Move();
                            break;
                        case "KDL": car.Move();
                            break;
                        case "KDR": car.Move();
                            break;
>>>>>>> 3f4ffc5009ed25a8071dc94815964ca91689ded7
                        default:
                            {
                                isKingsTurn = true;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }

                    }
                }
<<<<<<< HEAD
                while (!isKingsTurn)
=======

                while (!isKingTurn)
>>>>>>> 3f4ffc5009ed25a8071dc94815964ca91689ded7
                {
                    isKingsTurn = true;
                    ConsoleRenderer.Instance.Render(gameBoard);
                    Console.Write("Pawn`s Turn:");
<<<<<<< HEAD
                    string moveDirection = Console.ReadLine();
                    if (moveDirection == "")
=======
                    string direction = Console.ReadLine();

                    if (direction == "")
>>>>>>> 3f4ffc5009ed25a8071dc94815964ca91689ded7
                    {
                        isKingsTurn = false;
                        continue;
                    }

                    moveDirection = moveDirection.ToUpper();

                    switch (moveDirection)
                    {
<<<<<<< HEAD
                        case "ADR":
                            {
                                pawnsWin = Pawn.PawnAMove(pawnA, 1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "ADL":
                            {
                                pawnsWin = Pawn.PawnAMove(pawnA, -1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "BDL":
                            {
                                pawnsWin = Pawn.PawnBMove(pawnB, -1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "BDR":
                            {
                                pawnsWin = Pawn.PawnBMove(pawnB, 1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "CDL":
                            {
                                pawnsWin = Pawn.PawnCMove(pawnC, -1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "CDR":
                            {
                                pawnsWin = Pawn.PawnCMove(pawnC, 1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "DDR":
                            {
                                pawnsWin = Pawn.PawnDMove(pawnD, 1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
                        case "DDL":
                            {
                                pawnsWin = Pawn.PawnDMove(pawnD, -1, 1, gameBoard, ref isKingsTurn);
                                break;
                            }
=======
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
>>>>>>> 3f4ffc5009ed25a8071dc94815964ca91689ded7
                        default:
                            {
                                isKingsTurn = false;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }
<<<<<<< HEAD
                    ConsoleRenderer.Instance.Render(gameBoard);
                }
            }
            if (pawnsWin)
=======

                    ConsoleRenderer.Instance.Render(matrica);
                }
            }

            if (pobedaPeshki)
>>>>>>> 3f4ffc5009ed25a8071dc94815964ca91689ded7
            {
                Console.WriteLine("Pawns win!");
            }
            else
            {
                Console.WriteLine("King wins!");
            }
        }
    }
}
