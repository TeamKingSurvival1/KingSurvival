namespace KingSurvival
{
    using System;

    public class Engine
    {
        // The game is played on a standard chess-board of size 8 x 8 cells.
        int gameBoardSize = 8;
        King theKing = new King(4, 7);


        Pawn pawnA = new Pawn(1, 0);

        Pawn pawnB = new Pawn(3, 0);

        Pawn pawnC = new Pawn(5, 0);

        Pawn pawnD = new Pawn(7, 0);

        bool isKingsTurn = true;

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


            gameBoard[pawnA.Position.Y, pawnA.Position.X] = 'A';
            gameBoard[pawnB.Position.Y, pawnB.Position.X] = 'B';
            gameBoard[pawnC.Position.Y, pawnC.Position.X] = 'C';
            gameBoard[pawnD.Position.Y, pawnD.Position.X] = 'D';
            gameBoard[theKing.Position.Y, theKing.Position.X] = 'K';
            ConsoleRenderer.Instance.Render(gameBoard);
            bool pawnsWin = false;

            while (theKing.Position.Y > 0 && theKing.Position.Y < gameBoardSize && !pawnsWin)
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
                        case "KUL": theKing.Move();
                            break;
                        case "KUR": theKing.Move();
                            break;
                        case "KDL": theKing.Move();
                            break;
                        case "KDR": theKing.Move();
                            break;
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
                        case "ADR": pawnA.Move();
                            break;
                        case "ADL": pawnA.Move();
                            break;
                        case "BDL": pawnB.Move();
                            break;
                        case "BDR": pawnB.Move();
                            break;
                        case "CDL": pawnC.Move();
                            break;
                        case "CDR": pawnC.Move();
                            break;
                        case "DDR": pawnD.Move();
                            break;
                        case "DDL": pawnD.Move();
                            break;
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
