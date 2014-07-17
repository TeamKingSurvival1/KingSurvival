namespace KingSurvival
{
    using System;

    public class Engine
    {
        private Board gameBoard;
        private King king;
        private Piece[] pawns;
        public Engine()
        {
            this.gameBoard = new Board();
            this.king = new King(3, 7);
            this.pawns = new Piece[] { new Pawn('A', 0, 0), new Pawn('B', 2, 0), new Pawn('C', 4, 0), new Pawn('D', 6, 0) };
        }

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

        internal bool IsValidCommandSymol(char commandSymbol)
        {
            for (int i = 0; i < pawns.Length; i++)
            {
                if (pawns[i].Symbol == commandSymbol)
                {
                    return true;
                }
            }
            return false;
        }

        internal Piece GetCurrentPawn(char commandSymbol)
        {
            for (int i = 0; i < pawns.Length; i++)
            {
                if (pawns[i].Symbol == commandSymbol)
                {
                    return pawns[i];
                }

            }
            throw new ArgumentOutOfRangeException("Invalid command!");
        }
        
        public void Run()
        {
            for (int i = 0; i < pawns.Length; i++)
            {
                Piece currentPawn = pawns[i];
                gameBoard[currentPawn.Position.Y, currentPawn.Position.X] = currentPawn.Symbol;
            }
          
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
                                PrintInvalidMoveMessage();
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

                    char commandSymbol = moveDirection[0];
                    string commandDirection = moveDirection[1].ToString() + moveDirection[2].ToString();
                    Piece currentPawn;

                    if(!IsValidCommandSymol(commandSymbol))
                    {
                        isKingsTurn = false;                        
                        PrintInvalidMoveMessage();
                        continue;
                    }
                    else
                    {
                        currentPawn = GetCurrentPawn(commandSymbol);                        
                    }                    

                    switch (commandDirection)
                    {
                        case "DR":
                            UpdatePawnsPosition(currentPawn, 1, 1);
                            break;
                        case "DL":
                            UpdatePawnsPosition(currentPawn, -1, 1);
                            break;                        
                        default:
                            {
                                isKingsTurn = false;
                                PrintInvalidMoveMessage();
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
