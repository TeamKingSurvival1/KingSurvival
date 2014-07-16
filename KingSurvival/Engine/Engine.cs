namespace KingSurvival
{
    using System;

    public class Engine
    {
        King king = new King(3, 7);
        private Board gameBoard;

        Pawn pawnA = new Pawn('A', 0, 0);

        Pawn pawnB = new Pawn('B', 2, 0);

        Pawn pawnC = new Pawn('C', 4, 0);

        Pawn pawnD = new Pawn('D', 6, 0);

        bool isKingsTurn = true;

        internal bool IsInRangeMove(Piece piece, int dirX, int dirY)
        {
            int fieldSize = Board.BoardSize - 1;

            if (piece.Position.X + dirX < 0 || piece.Position.X + dirX > fieldSize ||
                piece.Position.Y + dirY < 0 || piece.Position.Y + dirY > fieldSize)
            {
                return false;
            }
            return true;
        }

        internal bool IsAvailableCell(Piece piece, int dirX, int dirY)
        {
            if (gameBoard[piece.Position.Y + dirY, piece.Position.X + dirX] == '+' ||
                gameBoard[piece.Position.Y + dirY, piece.Position.X + dirX] == '-')
            {
                return true;
            }
            return false;
        }

        internal bool IsValidMove(Piece piece, int dirX, int dirY)
        {
            if (!IsInRangeMove(piece, dirX, dirY) || !IsAvailableCell(piece, dirX, dirY))
            {
                return false;
            }
            return true;
        }

        internal void PrintInvalidMoveMessage()
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
        }

        internal void UpdateKingsPosition(int dirX, int dirY)
        {
            if (!IsValidMove(king, dirX, dirY))
            {
                PrintInvalidMoveMessage();
                isKingsTurn = true;
            }
            else
            {
                UpdateBoard(king, dirX, dirY, king.Symbol);
                king.Move(dirX, dirY);
            }
        }

        internal void UpdatePawnsPosition(Piece piece, int dirX, int dirY)
        {
            if (!IsValidMove(piece, dirX, dirY))
            {
                PrintInvalidMoveMessage();
                isKingsTurn = false;
            }
            else
            {
                UpdateBoard(piece, dirX, dirY, piece.Symbol);
                piece.Move(dirX, dirY);
            }
        }

        internal void UpdateBoard(Piece piece, int dirX, int dirY, char pieceSymbol)
        {
            gameBoard[piece.Position.Y, piece.Position.X] = '+';
            gameBoard[piece.Position.Y + dirY, piece.Position.X + dirX] = pieceSymbol;
        }
        
        internal Engine()
        {
            gameBoard = new Board();
        }

        public void Run()
        {
            gameBoard[pawnA.Position.Y, pawnA.Position.X] = pawnA.Symbol;
            gameBoard[pawnB.Position.Y, pawnB.Position.X] = pawnB.Symbol;
            gameBoard[pawnC.Position.Y, pawnC.Position.X] = pawnC.Symbol;
            gameBoard[pawnD.Position.Y, pawnD.Position.X] = pawnD.Symbol;
            gameBoard[king.Position.Y, king.Position.X] = king.Symbol;

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
                        case "KUL":
                            UpdateKingsPosition(-1, -1);                            
                            break;
                        case "KUR":
                            UpdateKingsPosition(1, -1);
                            break;
                        case "KDL":
                            UpdateKingsPosition(-1, 1);
                            break;
                        case "KDR":
                            UpdateKingsPosition(1, 1);
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
                        case "ADR":
                            UpdatePawnsPosition(pawnA, 1, 1);
                            break;
                        case "ADL":
                            UpdatePawnsPosition(pawnA, -1, 1);
                            break;
                        case "BDL":
                            UpdatePawnsPosition(pawnB, -1, 1);
                            break;
                        case "BDR":
                            UpdatePawnsPosition(pawnB, 1, 1);
                            break;
                        case "CDL":
                            UpdatePawnsPosition(pawnC, -1, 1);
                            break;
                        case "CDR":
                            UpdatePawnsPosition(pawnC, 1, 1);
                            break;
                        case "DDR":
                            UpdatePawnsPosition(pawnD, 1, 1);
                            break;
                        case "DDL":
                            UpdatePawnsPosition(pawnD, -1, 1);
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
