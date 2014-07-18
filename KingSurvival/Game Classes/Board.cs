namespace KingSurvival
{
using System;
    public class Board
    {
        // The game is played on a standard chess-board of size 8 x 8 cells (half of them - white, the other half - black).
        public const int BoardSize = 8;
        private const char EmptyWhiteCell = '+';
        private const char EmptyBlackCell = '-';
        
        private char[,] gameField;

        public Board()
        {
            this.gameField = new char[BoardSize, BoardSize];

            InitializeEmptyBoardCells();
        }

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
        /// Indexer to access game field cells
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
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

        public void PlacePieceOnBoard(int row, int col, char pieceSymbol)
        {
            this[row, col] = pieceSymbol;
        }

        public void ClearBoardCell(int row, int col)
        {
            this.gameField[row, col] = EmptyWhiteCell;
        }

        public bool IsCellAvailable(int row, int col)
        {
            if(this.gameField[row, col] == EmptyWhiteCell)
            {
                return true;
            }
            return false;
        }

        private void InitializeEmptyBoardCells()
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
    }
}
