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

                    if (!IsCommandValid(currentCommand, isKingsTurn))
                    {
                        PrintInvalidMoveMessage();
                        continue;
                    }

                    ProcessCommand(currentCommand, isKingsTurn);

                    isKingsTurn = !isKingsTurn;
                    hasTurnEnded = true;
                    //gameOver = IsGameOver();
                }
            }

            //PrintWinMessage();
        }

        private void PlacePiecesOnBoard(Board gameBoard, Piece[] pawns, King king)
        {
            for (int i = 0; i < pawns.Length; i++)
            {
                Piece currentPawn = pawns[i];
                this.board.PlacePieceOnBoard(currentPawn.Position.Y, currentPawn.Position.X, currentPawn.Symbol);
            }

            this.board.PlacePieceOnBoard(king.Position.Y, king.Position.X, king.Symbol);
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
            // Check if chosen symbol is valid (consider isKingsTurn too)
            // Get current piece
            // Check if the move for that piece is valid (consider if its 
            // Methods - GetCurrentPiece(symbol, isKingsTurn), IsMoveValid(currentPiece, direction) with method IsCellAvailable

            return true;
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

        private bool IsInRangeMove(int newCellX, int newCellY)
        {
            int fieldSize = Board.BoardSize - 1;

            if (newCellX < 0 || newCellX > fieldSize ||
                newCellY < 0 || newCellY > fieldSize)
            {
                return false;
            }
            return true;
        }

        private bool IsMoveValid(Piece currentPiece, Direction currentDirection)
        {
            int newCellX = currentPiece.Position.X + currentDirection.XUpdateValue;
            int newCellY = currentPiece.Position.Y + currentDirection.YUpdateValue;

            if (!IsInRangeMove(newCellX, newCellY) || !this.board.IsCellAvailable(newCellY, newCellX))
            {
                return false;
            }
            return true;
        }

        private void ProcessCommand(Command currentCommand, bool isKingsTurn)
        {
            if (isKingsTurn)
            {
                this.board.ClearBoardCell(this.king.Position.Y, this.king.Position.X);
                this.king.Move(currentCommand.MoveDirection);
                this.board.PlacePieceOnBoard(this.king.Position.Y, this.king.Position.X, this.king.Symbol);
            }
            else
            {
                Piece currentPawn = GetCurrentPawn(currentCommand.TargetSymbol);
                this.board.ClearBoardCell(currentPawn.Position.Y, currentPawn.Position.X);
                currentPawn.Move(currentCommand.MoveDirection);
                this.board.PlacePieceOnBoard(currentPawn.Position.Y, currentPawn.Position.X, currentPawn.Symbol);
            }
        }

        internal Piece GetCurrentPawn(char commandSymbol)
        {
            for (int i = 0; i < this.pawns.Length; i++)
            {
                if (this.pawns[i].Symbol == commandSymbol)
                {
                    return this.pawns[i];
                }

            }

            throw new ArgumentOutOfRangeException("Invalid command!");
        }
    }
}
