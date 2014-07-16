﻿using System;
namespace KingSurvival
{
    public class Board
    {
        // The game is played on a standard chess-board of size 8 x 8 cells (half of them - white, the other half - black).
        public const int BoardSize = 8;

        private const char EmptyWhiteCell = '+';
        private const char EmptyBlackCell = '-';

        private char[,] gameField;

        internal Board()
        {
            this.gameField = new char[BoardSize, BoardSize];

            FillBoard();
        }

        internal char[,] GameField
        {
            get
            {
                char[,] copyOfGameField = new char[BoardSize, BoardSize];
                Array.Copy(this.gameField, copyOfGameField, this.gameField.Length);

                return copyOfGameField;
            }

            //set
            //{
            //    this.gameField = value;
            //}
        }

        /// <summary>
        /// Indexer to access game field cells
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        internal char this[int row, int col]
        {
            get
            {
                return this.gameField[row, col];
            }

            set
            {
                this.gameField[row, col] = value;
            }
        }

        private void FillBoard()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    // Check if both row and col numbers are even/odd at the same time.
                    if ((row % 2) == (col % 2))
                    {
                        gameField[row, col] = EmptyWhiteCell;
                    }
                    else
                    {
                        gameField[row, col] = EmptyBlackCell;
                    }
                }
            }
        }


        // Drawing method just for testing
        //public static void drawBoard()
        //{
        //    for (int i = 0; i < BoardSize; i++)
        //    {
        //        for (int j = 0; j < BoardSize; j++)
        //        {
        //            System.Console.Write(gameField[i, j]);
        //        }
        //        System.Console.WriteLine();
        //    }
        //}
    }
}