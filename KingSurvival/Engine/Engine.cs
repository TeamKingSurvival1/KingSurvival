namespace KingSurvival
{
    using System;

    public class Engine
    {
        // The game is played on a standard chess-board of size 8 x 8 cells.
        King king = new King(4, 7);
        private Board gameBoard;


        Pawn pawnA = new Pawn(1, 0);

        Pawn pawnB = new Pawn(3, 0);

        Pawn pawnC = new Pawn(5, 0);

        Pawn pawnD = new Pawn(7, 0);

        bool isKingsTurn = true;

        internal bool IsValidMove(Piece piece, int dirX, int dirY)
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

        internal bool IsValidPieceMove(Piece piece, int dirX, int dirY)
        {
            if (!IsValidMove(piece, dirX, dirY) || !IsAvailableCell(piece, dirX, dirY))
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
            if (!IsValidPieceMove(king, dirX, dirY))
            {
                PrintInvalidMoveMessage();
                isKingsTurn = true;
            }
            else
            {
                UpdateBoard(king, dirX, dirY, 'K');
                king.Move(dirX, dirY);
            }
        }

        internal void UpdateBoard(Piece piece, int dirX, int dirY, char pieceSymbol)
        {
            gameBoard[piece.Position.Y, piece.Position.X] = '-';
            gameBoard[piece.Position.Y + dirY, piece.Position.X + dirX] = pieceSymbol;
        }


        internal Engine()
        {
            gameBoard = new Board();
        }

        public void Run()
        {
            gameBoard[pawnA.Position.Y, pawnA.Position.X] = 'A';
            gameBoard[pawnB.Position.Y, pawnB.Position.X] = 'B';
            gameBoard[pawnC.Position.Y, pawnC.Position.X] = 'C';
            gameBoard[pawnD.Position.Y, pawnD.Position.X] = 'D';
            gameBoard[king.Position.Y, king.Position.X] = 'K';
            ConsoleRenderer.Instance.Render(gameBoard.GameField);
            bool pawnsWin = false;





            while (king.Position.Y > 0 && king.Position.Y < Board.BoardSize && !pawnsWin)
            {
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
                        case "ADR": pawnA.Move(1, 1);
                            break;
                        case "ADL": pawnA.Move(-1, 1);
                            break;
                        case "BDL": pawnB.Move(-1, 1);
                            break;
                        case "BDR": pawnB.Move(1, 1);
                            break;
                        case "CDL": pawnC.Move(-1, 1);
                            break;
                        case "CDR": pawnC.Move(1, 1);
                            break;
                        case "DDR": pawnD.Move(1, 1);
                            break;
                        case "DDL": pawnD.Move(-1, 1);
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
