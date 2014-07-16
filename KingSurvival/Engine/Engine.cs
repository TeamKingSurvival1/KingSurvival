namespace KingSurvival
{
    using System;

    public class Engine
    {
        King king = new King(4, 7);
        private Board gameBoard;

        Pawn pawnA = new Pawn(1, 0);

        Pawn pawnB = new Pawn(3, 0);

        Pawn pawnC = new Pawn(5, 0);

        Pawn pawnD = new Pawn(7, 0);

        bool isKingsTurn = true;

        internal Engine()
        {
            gameBoard = new Board();
        }

        public void Run()
        {
            gameBoard.GameField[pawnA.Position.Y, pawnA.Position.X] = 'A';
            gameBoard.GameField[pawnB.Position.Y, pawnB.Position.X] = 'B';
            gameBoard.GameField[pawnC.Position.Y, pawnC.Position.X] = 'C';
            gameBoard.GameField[pawnD.Position.Y, pawnD.Position.X] = 'D';
            gameBoard.GameField[king.Position.Y, king.Position.X] = 'K';
            ConsoleRenderer.Instance.Render(gameBoard.GameField);
            bool pawnsWin = false;

            //Game Process - switching turns
            while (king.Position.Y > 0 && king.Position.Y < Board.BoardSize && !pawnsWin)
            {
                //King`s Turn
                isKingsTurn = true;
                while (isKingsTurn)
                {
                    isKingsTurn = false;

                    ConsoleRenderer.Instance.Render(gameBoard.GameField);
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
                        case "KUL": king.Move();
                            break;
                        case "KUR": king.Move();
                            break;
                        case "KDL": king.Move();
                            break;
                        case "KDR": king.Move();
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

                //Pawns` Turn  
                while (!isKingsTurn)
                {
                    isKingsTurn = true;
                    ConsoleRenderer.Instance.Render(gameBoard.GameField);
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

                    ConsoleRenderer.Instance.Render(gameBoard.GameField);
                }
            }

            //End of game
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
