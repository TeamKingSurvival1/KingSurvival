namespace KingSurvival.Engine
{
    using System;
    using Interfaces;
    using GameplayClasses;

    public class KingSurvivalEngine
    {
        private Board board;
        private PieceFactory pieceFactory;
        private King king;
        private Piece[] pawns;
        private IRenderer renderer;
        private const string KingsTurnMessage = "King's Turn: ";
        private const string PawnsTurnMessage = "Pawn's Turn: ";
        private const string InvalidMoveMessage = "Invalid Move!";
        private const string PressAnyKeyToContinue = "** Press a key to continue **";

        public KingSurvivalEngine()
        {
            this.board = new Board();
            this.pieceFactory = new PieceFactory();
            this.king = pieceFactory.CreateKing();
            this.pawns = pieceFactory.CreatePawns();
            this.renderer = ConsoleRenderer.Instance;
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
                    renderer.Render(board.GameField);
                    PrintTurnMessage(isKingsTurn);

                    string playerInput = Console.ReadLine();
                    Command currentCommand = Command.Parse(playerInput);

                    //?? get currentPiece here, instead of getting it twice - inProcessCommand and IsCommandValid methods
                    
                    if (!Validations.IsCommandValid(this.board, this.king, this.pawns, currentCommand, isKingsTurn))
                    {
                        InvalidMoveAction();
                        continue;
                    }

                    ProcessCommand(currentCommand);

                    isKingsTurn = !isKingsTurn;
                    hasTurnEnded = true;
                    gameOver = IsGameOver(this.board, this.pawns, this.king);

                    if (gameOver)
                    {
                        if (Validations.HasKingReachedTop(king) ||
                            !Validations.PawnsHavePossibleDirection(this.board, this.pawns))
                        {
                            kingWins = true;
                        }
                    }

                    renderer.Render(board.GameField);

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
            if (Validations.HasKingReachedTop(this.king) || !Validations.PawnsHavePossibleDirection(this.board, this.pawns) || !Validations.HasKingPossibleDirection(this.board, this.king))
            {
                return true;
            }           

            return false;
        }

        

        private void PlacePiecesOnBoard(Board gameBoard, Piece[] pawns, King king)
        {
            for (int i = 0; i < pawns.Length; i++)
            {
                Piece currentPawn = pawns[i];
                this.board.PlacePieceOnBoard(currentPawn.X, currentPawn.Y, currentPawn.Symbol);
            }

            this.board.PlacePieceOnBoard(king.X, king.Y, king.Symbol);
        }

        private void PrintTurnMessage(bool isKingsTurn)
        {
            if (isKingsTurn)
            {
                ConsoleRenderer.PrintMessage(KingsTurnMessage);
            }
            else
            {
                ConsoleRenderer.PrintMessage(PawnsTurnMessage);
            }
        }

        

        internal void InvalidMoveAction()
        {
            ConsoleRenderer.PrintMessage(InvalidMoveMessage + Environment.NewLine);
            ConsoleRenderer.PrintMessage(PressAnyKeyToContinue + Environment.NewLine);
            Console.ReadKey();
        }

        internal static Piece GetCurrentPiece(Piece king, Piece[] pawns, char pieceSymbol)
        {
            Piece currentPiece = null;

            if (pieceSymbol == king.Symbol)
            {
                currentPiece = king;
            }
            else
            {
                for (int i = 0; i < pawns.Length; i++)
                {
                    if (pieceSymbol == pawns[i].Symbol)
                    {
                        currentPiece = pawns[i];
                    }
                }
            }

            return currentPiece;
        }

        private void ProcessCommand(ICommand currentCommand)
        {
            Piece currentPiece = KingSurvivalEngine.GetCurrentPiece(this.king, this.pawns, currentCommand.TargetSymbol);

            this.board.ClearBoardCell(currentPiece.X, currentPiece.Y);
            currentPiece.Move(currentCommand.MoveDirection);
            this.board.PlacePieceOnBoard(currentPiece.X, currentPiece.Y, currentPiece.Symbol);
        }
    }
}
