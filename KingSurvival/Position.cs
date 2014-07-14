namespace KingSurvival
{
    using System;

    /// <summary>
    ///     The <c>Position</c> type provides functionality for interacting with co-ordinates.
    /// </summary>
    internal class Position
    {
        private int x;
        private int y;

        internal Position(int xCoordinate, int yCoordinate)
        {
            this.X = xCoordinate;
            this.Y = yCoordinate;
        }

        internal int X
        {
            get
            {
                return this.x;
            }

            set
            {
                CoordinateValidationCheck(value);

                this.x = value;
            }
        }

        internal int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                CoordinateValidationCheck(value);

                this.y = value;
            }
        }

        /// <summary>
        ///     Checks if a co-ordinate value is valid.
        /// </summary>
        /// <param name="coordinate">
        ///     A <see cref="Int32" /> type for input.
        /// </param>
        /// <returns>
        ///     No value is returned, but in case of invalid co-ordinate value throws an exception.
        /// </returns>
        private void CoordinateValidationCheck(int coordinate)
        {
            if (coordinate < 1 || coordinate > 8)
            {
                throw new ArgumentOutOfRangeException("coordinate", String.Format("Co-ordinate {0} is out of the gameboard", coordinate));
            }
        }
    }
}