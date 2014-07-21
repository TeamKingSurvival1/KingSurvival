//-----------------------------------------------------------------------
// <summary>
//     Class file for initializing the <c>KingSurvivalEngine</c> type.
// </summary>
// <copyright file="KingSurvivalEngine.cs" company="Telerik Academy - OOP 2014 Course">
//     Copyright (c) Telerik Academy - OOP 2014 Course. All rights reserved.
// </copyright>
// <author>
//     Not avaialbe. Refactored by Team King-Survival-1
// </author>
//-----------------------------------------------------------------------
namespace KingSurvival.Engine
{
    using System;
    using GameplayClasses;
    using Interfaces;

    public class KingSurvivalEngine
    {
        private const string KingsTurnMessage = "King's Turn: ";
        private const string PawnsTurnMessage = "Pawn's Turn: ";
        private const string InvalidMoveMessage = "Invalid Move!";
        private const string PressAnyKeyToContinue = "** Press a key to continue **";

        private Board board;
        private PieceFactory pieceFactory;
        private King king;
        private Piece[] pawns;
        private IRenderer renderer;

        public KingSurvivalEngine()
        {
            this.board = new Board();
            this.pieceFactory = new PieceFactory();
            this.king = this.pieceFactory.CreateKing();
            this.pawns = this.pieceFactory.CreatePawns();
            this.renderer = ConsoleRenderer.Instance;
        }

        public void Run()
        {
            bool isKingsTurn = true;
            bool gameOver = false;
            bool hasTurnEnded;
            bool kingWins = false;

            this.PlacePiecesOnBoard(this.board, this.pawns, this.king);

            // The main game loop
            while (!gameOver)
            {
                hasTurnEnded = false;

                while (!hasTurnEnded)
                {
                    this.renderer.Render(this.board.GameField);
                    this.PrintTurnMessage(isKingsTurn);

                    string playerInput = Console.ReadLine();
                    Command currentCommand = Command.Parse(playerInput);
                    
                    // TODO:
                    /* 
                    * ?? get currentPiece here, instead of getting it twice - inProcessCommand and IsCommandValid methods
                    */
 
                    if (!Validations.IsCommandValid(this.board, this.king, this.pawns, currentCommand, isKingsTurn))
                    {
                        this.InvalidMoveAction();
                        continue;
                    }

                    this.ProcessCommand(currentCommand);

                    isKingsTurn = !isKingsTurn;
                    hasTurnEnded = true;
                    gameOver = this.IsGameOver(this.board, this.pawns, this.king);

                    if (gameOver)
                    {
                        if (Validations.HasKingReachedTop(this.king) ||
                            !Validations.PawnsHavePossibleDirection(this.board, this.pawns))
                        {
                            kingWins = true;
                        }
                    }

                    this.renderer.Render(this.board.GameField);

                    if (gameOver)
                    {
                        if (kingWins)
                        {
                            Console.WriteLine("King wins in {0} turns.", this.king.MovesCount);
                        }
                        else 
                        { 
                            Console.WriteLine("King loses.");
                        }
                    }
                }
            }

            // TODO: PrintWinMessage();
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
        
        internal void InvalidMoveAction()
        {
            ConsoleRenderer.PrintMessage(InvalidMoveMessage + Environment.NewLine);
            ConsoleRenderer.PrintMessage(PressAnyKeyToContinue + Environment.NewLine);
            Console.ReadKey();
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

        private void ProcessCommand(ICommand currentCommand)
        {
            Piece currentPiece = KingSurvivalEngine.GetCurrentPiece(this.king, this.pawns, currentCommand.TargetSymbol);

            this.board.ClearBoardCell(currentPiece.X, currentPiece.Y);
            currentPiece.Move(currentCommand.MoveDirection);
            this.board.PlacePieceOnBoard(currentPiece.X, currentPiece.Y, currentPiece.Symbol);
        }
    }
}
