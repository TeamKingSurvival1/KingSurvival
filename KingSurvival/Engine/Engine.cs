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
