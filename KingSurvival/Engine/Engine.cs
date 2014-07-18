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

            // The main game loop
            while (!gameOver)
            {
                PlacePiecesOnBoard(this.board, this.pawns, this.king);
                this.renderer.Render(board.GameField);
                hasTurnEnded = false;

                while (!hasTurnEnded)
                {
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
            // Check if chosen symbol is valid (consider isKingsTurn too)
            // Get current piece
            // Check if the move for that piece is valid (consider if its 
            // Methods - GetCurrentPiece(symbol, isKingsTurn), IsMoveValid(currentPiece, direction) with method IsCellAvailable

            return true;
        }

        internal void PrintInvalidMoveMessage()
        {
            Console.WriteLine("Invalid Move!");
            Console.WriteLine("**Press a key to continue**");
            Console.ReadKey();
        }

        private void ProcessCommand(Command currentCommand, bool isKingsTurn)
        {
            if (isKingsTurn)
            {
                this.board.ClearBoardCell(this.king.Position.Y, this.king.Position.X);
                this.king.Move(currentCommand.MoveDirection);
            }
            else
            {
                Piece currentPawn = GetCurrentPawn(currentCommand.TargetSymbol);
                this.board.ClearBoardCell(currentPawn.Position.Y, currentPawn.Position.X);
                currentPawn.Move(currentCommand.MoveDirection);
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
