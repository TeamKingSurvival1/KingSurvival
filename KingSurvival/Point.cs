namespace KingSurvival
{
    using System;

    internal class Point
    {
        int x;
        int y;

        internal Point(int xCoordinate, int yCoordinate)
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

        private void CoordinateValidationCheck(int coordinate)
        {
            if (coordinate < 1 || coordinate > 8)
            {
                throw new ArgumentOutOfRangeException("coordinate", String.Format("Co-ordinate {0} is out of the gameboard"));
            }
        }
    }
}