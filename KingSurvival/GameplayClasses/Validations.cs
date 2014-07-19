﻿namespace KingSurvival.GameplayClasses
{
    using System;
    using KingSurvival.Interfaces;

    internal static class Validations
    {
        private static readonly IDirection[] validKingDirections = { new Direction('U', 'L'), new Direction('U', 'R'),
                                                             new Direction('D', 'L'), new Direction('D', 'R')};
        private static readonly IDirection[] validPawnDirections = { new Direction('D', 'L'), new Direction('D', 'R') };

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

        internal static bool HasKingPossibleDirection(Board board, Piece king)
        {
            for (int i = 0; i < validKingDirections.Length; i++)
            {
                if (IsMoveValid(board, king, validKingDirections[i]))
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
            for (int i = 0; i < validPawnDirections.Length; i++)
            {
                IDirection checkDirection = validPawnDirections[i];

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
    }
}