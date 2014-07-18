namespace KingSurvival
{
    using System;

    public class Engine
    {
        private Board board;
        private King king;
        private Piece[] pawns;
        private IRenderer renderer;
        private const string KingsTurnMessage = "King's Turn: ";
        private const string PawnsTurnMessage = "Pawn's Turn: ";
        private readonly Direction[] validKingDirections = { new Direction('U', 'L'), new Direction('U', 'R'),
                                                             new Direction('D', 'L'), new Direction('D', 'R')};
        private readonly Direction[] validPawnDirections = { new Direction('D', 'L'), new Direction('D', 'R')};

        public Engine()
        {
            this.board = new Board();
            this.king = new King(3, 7);
            this.pawns = new Piece[] { new Pawn('A', 0, 0), new Pawn('B', 2, 0), new Pawn('C', 4, 0), new Pawn('D', 6, 0) };
            this.renderer = new ConsoleRenderer();
        }

        public void Run()
        {
            bool isKingsTurn = true;
            bool gameOver = false;
            bool hasTurnEnded;
            bool kingWins = false;

            PlacePiecesOnBoard(this.board, this.pawns, this.king);

            // The main game loop
            while (!gameOver)
            {
                hasTurnEnded = false;

                while (!hasTurnEnded)
                {
                    this.renderer.Render(board.GameField);
                    PrintTurnMessage(isKingsTurn);

                    string playerInput = Console.ReadLine();
                    Command currentCommand = Command.Parse(playerInput);

                    //?? get currentPiece here, instead of getting it twice - inProcessCommand and IsCommandValid methods
                    
                    if (!IsCommandValid(currentCommand, isKingsTurn))
                    {
                        PrintInvalidMoveMessage();
                        continue;
                    }

                    ProcessCommand(currentCommand, isKingsTurn);

                    isKingsTurn = !isKingsTurn;
                    hasTurnEnded = true;
                    gameOver = IsGameOver(this.board, this.pawns, this.king);
                    if (gameOver)
                    {
                        if (HasKingReachedTop() || !PawnsHavePossibleDirection())
                        {
                            kingWins = true;
                        }
                    }

                    this.renderer.Render(board.GameField);

                    if (gameOver)
                    {
                        if (kingWins)
                        {
                            Console.WriteLine("King wins in {0} turns.", king.MovesMade);
                        }
                        else 
                        { 
                            Console.WriteLine("King loses.");
                        }
                    }
                }
            }

            //PrintWinMessage();
        }

        private bool IsGameOver(Board gameBoard, Piece[] pawns, King king)
        {            
            if (HasKingReachedTop() || !PawnsHavePossibleDirection() || !KingHasPossibleDirection())
            {
                return true;
            }           

            return false;
        }

        private bool HasKingReachedTop()
        {
            if (king.Position.Y == 0)
            {
                return true;
            }
            return false;
        }

        private bool PawnsHavePossibleDirection()
        {
            for (int i = 0; i < validPawnDirections.Length; i++)
            {
                Direction checkDirection = validPawnDirections[i];

                for (int j = 0; j < this.pawns.Length; j++)
                {
                    Piece checkPawn = pawns[j];

                    if (IsMoveValid(checkPawn,checkDirection))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool KingHasPossibleDirection()
        {
            for (int i = 0; i < validKingDirections.Length; i++)
            {
                if (IsMoveValid(king, validKingDirections[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private void PlacePiecesOnBoard(Board gameBoard, Piece[] pawns, King king)
        {
            for (int i = 0; i < pawns.Length; i++)
            {
                Piece currentPawn = pawns[i];
                this.board.PlacePieceOnBoard(currentPawn.Position.X, currentPawn.Position.Y, currentPawn.Symbol);
            }

            this.board.PlacePieceOnBoard(king.Position.X, king.Position.Y, king.Symbol);
        }

        private void PrintTurnMessage(bool isKingsTurn)
        {
            if (isKingsTurn)
            {
                Console.Write(KingsTurnMessage);
            }
            else
            {
                Console.Write(PawnsTurnMessage);
            }
        }

        private bool IsCommandValid(Command currentCommand, bool isKingsTurn)
        {
            if (!IsCommandPieceSymbolValid(currentCommand.TargetSymbol, isKingsTurn))
            {
                return false;
            }

            Piece currentPiece = GetCurrentPiece(currentCommand.TargetSymbol);

            if (!IsMoveValid(currentPiece, currentCommand.MoveDirection))
            {
                return false;
            }

            if (!IsCommandDirectionValid(currentCommand, isKingsTurn))
            {
                return false;
            }

            return true;
        }

        private bool IsCommandDirectionValid(Command command, bool isKingsTurn)
        {
            if(isKingsTurn)
            {
                for (int i = 0; i < validKingDirections.Length; i++)
                {
                    if (command.MoveDirection.Equals(validKingDirections[i]))
                    {
                        return true;
                    }
                }
            }
            else 
            {
                for (int i = 0; i < validPawnDirections.Length; i++)
                {
                    if (command.MoveDirection.Equals(validPawnDirections[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool IsCommandPieceSymbolValid(char symbol, bool isKingsTurn)
        {
            if (isKingsTurn)
            {
                if (symbol == this.king.Symbol)
                {
                    return true;
                }
            }
            else
            {
                for (int i = 0; i < this.pawns.Length; i++)
                {
                    if (symbol == this.pawns[i].Symbol)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal void PrintInvalidMoveMessage()
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
        }

        private Piece GetCurrentPiece(char pieceSymbol)
        {
            Piece currentPiece = null;

            if (pieceSymbol == this.king.Symbol)
            {
                currentPiece = this.king;
            }
            else
            {
                for (int i = 0; i < this.pawns.Length; i++)
                {
                    if (pieceSymbol == this.pawns[i].Symbol)
                    {
                        currentPiece = this.pawns[i];
                    }
                }
            }

            return currentPiece;
        }

        private bool IsMoveValid(Piece currentPiece, Direction currentDirection)
        {
            int newCellX = currentPiece.Position.X + currentDirection.XUpdateValue;
            int newCellY = currentPiece.Position.Y + currentDirection.YUpdateValue;

            if (!IsMoveInValidRange(newCellX, newCellY) || !this.board.IsCellAvailable(newCellX, newCellY))
            {
                return false;
            }

            return true;
        }

        private bool IsMoveInValidRange(int newCellX, int newCellY)
        {
            int fieldSize = Board.BoardSize - 1;

            if (newCellX < 0 || newCellX > fieldSize ||
                newCellY < 0 || newCellY > fieldSize)
            {
                return false;
            }

            return true;
        }

        private void ProcessCommand(Command currentCommand, bool isKingsTurn)
        {
            Piece currentPiece = GetCurrentPiece(currentCommand.TargetSymbol);

            this.board.ClearBoardCell(currentPiece.Position.X, currentPiece.Position.Y);
            currentPiece.Move(currentCommand.MoveDirection);
            this.board.PlacePieceOnBoard(currentPiece.Position.X, currentPiece.Position.Y, currentPiece.Symbol);
        }
    }
}
