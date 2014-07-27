//-----------------------------------------------------------------------
// <summary>
//     Class file for accessing methods of <c>Validations</c> type.
// </summary>
// <copyright file="Validations.cs" company="Telerik Academy - OOP 2014 Course">
//     Copyright (c) Telerik Academy - OOP 2014 Course. All rights reserved.
// </copyright>
// <author>
//     Not avaialbe. Refactored by Team King-Survival-1
// </author>
//-----------------------------------------------------------------------
namespace KingSurvival.GameplayClasses
{
    using System;
    using KingSurvival.Interfaces;

    /// <summary>
    /// Contains big amount of validations used by the engine.
    /// </summary>
    internal static class Validations
    {
        private static readonly IDirection[] ValidKingDirections =
        {
            new Direction('U', 'L'), new Direction('U', 'R'),
            new Direction('D', 'L'), new Direction('D', 'R')
        };

        private static readonly IDirection[] ValidPawnDirections =
        {
            new Direction('D', 'L'), new Direction('D', 'R')
        };

        internal static bool IsCommandPieceSymbolValid(Piece king, Piece[] pawns, char symbol, bool isKingsTurn)
        {
            if (isKingsTurn)
            {
                if (symbol == king.Symbol)
                {
                    return true;
                }
            }
            else
            {
                for (int i = 0; i < pawns.Length; i++)
                {
                    if (symbol == pawns[i].Symbol)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal static bool IsCommandDirectionValid(ICommand command, bool isKingsTurn)
        {
            if (isKingsTurn)
            {
                for (int i = 0; i < ValidKingDirections.Length; i++)
                {
                    if (command.MoveDirection.Equals(ValidKingDirections[i]))
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ValidPawnDirections.Length; i++)
                {
                    if (command.MoveDirection.Equals(ValidPawnDirections[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal static bool HasKingPossibleDirection(Board board, Piece king)
        {
            for (int i = 0; i < ValidKingDirections.Length; i++)
            {
                if (IsMoveValid(board, king, ValidKingDirections[i]))
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool IsMoveValid(Board board, IPiece currentPiece, IDirection currentDirection)
        {
            int newCellX = currentPiece.X + currentDirection.XUpdateValue;
            int newCellY = currentPiece.Y + currentDirection.YUpdateValue;

            if (!IsMoveInValidRange(newCellX, newCellY) || !board.IsCellAvailable(newCellX, newCellY))
            {
                return false;
            }

            return true;
        }

        internal static bool HasKingReachedTop(IPiece king)
        {
            if (king.Y == 0)
            {
                return true;
            }

            return false;
        }

        internal static bool PawnsHavePossibleDirection(Board board, Piece[] pawns)
        {
            for (int i = 0; i < ValidPawnDirections.Length; i++)
            {
                IDirection checkDirection = ValidPawnDirections[i];

                for (int j = 0; j < pawns.Length; j++)
                {
                    Piece checkPawn = pawns[j];

                    if (IsMoveValid(board, checkPawn, checkDirection))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal static bool IsCommandValid(Board board, Piece king, Piece[] pawns, ICommand currentCommand, bool isKingsTurn)
        {
            if (!Validations.IsCommandPieceSymbolValid(king, pawns, currentCommand.TargetSymbol, isKingsTurn))
            {
                return false;
            }

            Piece currentPiece = Engine.KingSurvivalEngine.GetCurrentPiece(king, pawns, currentCommand.TargetSymbol);

            if (!Validations.IsMoveValid(board, currentPiece, currentCommand.MoveDirection))
            {
                return false;
            }

            if (!Validations.IsCommandDirectionValid(currentCommand, isKingsTurn))
            {
                return false;
            }

            return true;
        }

        private static bool IsMoveInValidRange(int newCellX, int newCellY)
        {
            int fieldSize = Board.BoardSize - 1;

            if (newCellX < 0 || newCellX > fieldSize ||
                newCellY < 0 || newCellY > fieldSize)
            {
                return false;
            }

            return true;
        }
    }
}