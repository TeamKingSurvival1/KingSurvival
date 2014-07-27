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

    /// <summary>
    /// Represents the main engine of the game.
    /// </summary>
    public class KingSurvivalEngine
    {
        private const string KingsTurnMessage = "King's Turn: ";
        private const string PawnsTurnMessage = "Pawn's Turn: ";
        private const string InvalidMoveMessage = "Invalid Move!";
        private const string PressAnyKeyToContinue = "** Press a key to continue **";

        private readonly Board board;
        private readonly PieceFactory pieceFactory;
        private readonly King king;
        private readonly Piece[] pawns;
        private readonly IRenderer renderer;

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

            this.PlacePiecesOnBoard();

            // The main game loop
            while (!gameOver)
            {
                hasTurnEnded = false;

                while (!hasTurnEnded)
                {
                    this.renderer.Render(this.board.GameField);
                    this.PrintTurnMessage(isKingsTurn);

                    string playerInput = Console.ReadLine();
                    Command currentCommand;

                    try
                    {
                        currentCommand = Command.Parse(playerInput);
                    }
                    catch (ArgumentNullException)
                    {
                        this.renderer.PrintMessage("Command cannot be empty.");
                        continue;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        if (ex.ParamName == "input")
                        {
                            this.renderer.PrintMessage("Command must be exacly 3 characters long.");
                        }
                        else
                        {
                            this.renderer.PrintMessage("Invalid command.");
                        }

                        Console.ReadKey(true);
                        continue;
                    }

                    if (!Validations.IsCommandValid(this.board, this.king, this.pawns, currentCommand, isKingsTurn))
                    {
                        this.InvalidMoveAction();
                        continue;
                    }

                    this.ProcessCommand(currentCommand);

                    isKingsTurn = !isKingsTurn;
                    hasTurnEnded = true;
                    gameOver = this.IsGameOver();

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
            this.renderer.PrintMessage(InvalidMoveMessage + Environment.NewLine);
            this.renderer.PrintMessage(PressAnyKeyToContinue + Environment.NewLine);
            Console.ReadKey();
        }

        private bool IsGameOver()
        {
            if (Validations.HasKingReachedTop(this.king) || !Validations.PawnsHavePossibleDirection(this.board, this.pawns) || !Validations.HasKingPossibleDirection(this.board, this.king))
            {
                return true;
            }

            return false;
        }

        private void PlacePiecesOnBoard()
        {
            for (int i = 0; i < this.pawns.Length; i++)
            {
                Piece currentPawn = this.pawns[i];
                this.board.PlacePieceOnBoard(currentPawn.X, currentPawn.Y, currentPawn.Symbol);
            }

            this.board.PlacePieceOnBoard(this.king.X, this.king.Y, this.king.Symbol);
        }

        private void PrintTurnMessage(bool isKingsTurn)
        {
            if (isKingsTurn)
            {
                this.renderer.PrintMessage(KingsTurnMessage);
            }
            else
            {
                this.renderer.PrintMessage(PawnsTurnMessage);
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
