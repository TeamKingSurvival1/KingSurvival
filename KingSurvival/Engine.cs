namespace KingSurvival
{
    using System;

    public class Engine
    {
        // The original game is played on a standard chess-board of size 8 x 8 cells.
        static int gameBoardSize = 8;
        static King theKing = new King(4, 7);


        static Pawn pawnA = new Pawn(1, 0);

        static Pawn pawnB = new Pawn(3, 0);

        static Pawn pawnC = new Pawn(5, 0);

        static Pawn pawnD = new Pawn(7, 0);

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


            gameBoard[pawnA.Y, pawnA.X] = 'A';
            gameBoard[pawnB.Y, pawnB.X] = 'B';
            gameBoard[pawnC.Y, pawnC.X] = 'C';
            gameBoard[pawnD.Y, pawnD.X] = 'D';
            gameBoard[theKing.Y, theKing.X] = 'K';
            ConsoleRenderer.Instance.Render(gameBoard);
            bool pawnsWin = false;

            while (theKing.Y > 0 && theKing.Y < gameBoardSize && !pawnsWin)
            {
                isKingsTurn = true;
                while (isKingsTurn)
                {
                    isKingsTurn = false;

                    ConsoleRenderer.Instance.Render(gameBoard);
                    Console.Write("King`s Turn:");
                    string moveDirection = Console.ReadLine();
                    if (moveDirection == "")
                    {
                        isKingsTurn = true;
                        continue;
                    }

                    moveDirection = moveDirection.ToUpper();

                    switch (moveDirection)
                    {
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
                while (!isKingsTurn)
                {
                    isKingsTurn = true;
                    ConsoleRenderer.Instance.Render(gameBoard);
                    Console.Write("Pawn`s Turn:");
                    string moveDirection = Console.ReadLine();
                    if (moveDirection == "")
                    {
                        isKingsTurn = false;
                        continue;
                    }

                    moveDirection = moveDirection.ToUpper();

                    switch (moveDirection)
                    {
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
                        default:
                            {
                                isKingsTurn = false;
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("**Press a key to continue**");
                                Console.ReadKey();
                                break;
                            }
                    }
                    ConsoleRenderer.Instance.Render(gameBoard);
                }
            }
            if (pawnsWin)
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
