//-----------------------------------------------------------------------
// <summary>
//     Class file for initializing the <c>Board</c> type.
// </summary>
// <copyright file="Board.cs" company="Telerik Academy - OOP 2014 Course">
//     Copyright (c) Telerik Academy - OOP 2014 Course. All rights reserved.
// </copyright>
// <author>
//     Not avaialbe. Refactored by Team King-Survival-1
// </author>
//-----------------------------------------------------------------------
namespace KingSurvival.GameplayClasses
{
    using System;

    /// <summary>
    ///     The <c>Board</c> type provides functionality for a standard chess-board of size 8 x 8 cells (half of them - white, the other half - black).
    /// </summary>
    public class Board
    {
        /// <summary>
        ///     Declares and initializes the default size of the game board.
        /// </summary>
        public const int BoardSize = 8;

        /// <summary>
        ///     Declares and initializes the character of the white cells on the game board.
        /// </summary>
        private const char EmptyWhiteCell = '+';

        /// <summary>
        ///     Declares and initializes the character of the black cells on the game board.
        /// </summary>
        private const char EmptyBlackCell = '-';

        /// <summary>
        ///     Declares the game board as two-dimensional array of characters.
        /// </summary>
        private char[,] gameField;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Board" /> class.
        /// </summary>
        public Board()
        {
            this.gameField = new char[BoardSize, BoardSize];

            this.InitializeEmptyBoardCells();
        }

        /// <summary>
        ///     Gets a copy of the game field.
        /// </summary>
        /// <value>
        ///     The value is held as <see cref="Array"/> of <see cref="Char" /> type.
        /// </value>
        public char[,] GameField
        {
            get
            {
                char[,] copyOfGameField = new char[BoardSize, BoardSize];
                Array.Copy(this.gameField, copyOfGameField, this.gameField.Length);

                return copyOfGameField;
            }
        }

        /// <summary>
        ///     Indexer to access the two-dimensional game field.
        /// </summary>
        /// <param name="row">
        ///     Takes <see cref="Int32"/> type value for accessing the first dimension of the game field.
        /// </param>
        /// <param name="col">
        ///     Takes <see cref="Int32"/> type value for accessing the second dimension of the game field.
        /// </param>
        /// <returns>
        ///     Returns a cell at given two-dimensional indexer.
        /// </returns>
        public char this[int row, int col]
        {
            get
            {
                return this.gameField[row, col];
            }

            private set
            {
                this.gameField[row, col] = value;
            }
        }

        /// <summary>
        ///     Places a piece on the game board.
        /// </summary>
        /// <param name="x">
        ///     Sets the co-ordinate "x" for setting the piece.
        /// </param>
        /// <param name="y">
        ///     Sets the co-ordinate "y" for setting the piece.
        /// </param>
        /// <param name="pieceSymbol">
        ///     Initializes the symbol of the piece as <see cref="Char"/>.
        /// </param>
        public void PlacePieceOnBoard(int x, int y, char pieceSymbol)
        {
            this[x, y] = pieceSymbol;
        }

        /// <summary>
        ///     Clears a cell from the game board.
        /// </summary>
        /// <param name="x">
        ///     Sets the co-ordinate "x" of the cell for clearing.
        /// </param>
        /// <param name="y">
        ///     Sets the co-ordinate "y" of the cell for clearing.
        /// </param>
        public void ClearBoardCell(int x, int y)
        {
            this[x, y] = EmptyWhiteCell;
        }

        /// <summary>
        ///     Checks a cell on the game board is empty.
        /// </summary>
        /// <param name="x">
        ///     Sets the co-ordinate "x" for checking.
        /// </param>
        /// <param name="y">
        ///     Sets the co-ordinate "y" for checking.
        /// </param>
        /// <returns>
        ///     Returns a <see cref="Boolean"/> value is a cell empty.
        /// </returns>
        public bool IsCellAvailable(int x, int y)
        {
            if (this[x, y] == EmptyWhiteCell)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Initializes all empty cells with the default for the cell board color as <see cref="Char"/>.
        /// </summary>
        private void InitializeEmptyBoardCells()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    // Check if both row and col numbers are even/odd at the same time.
                    if ((row % 2) == (col % 2))
                    {
                        this[row, col] = EmptyWhiteCell;
                    }
                    else
                    {
                        this[row, col] = EmptyBlackCell;
                    }
                }
            }
        }
    }
}
