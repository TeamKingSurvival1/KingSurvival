﻿namespace KingSurvival
{
    internal class Direction
    {
        private const int MoveDistance = 1;

        private int xUpdateValue;
        private int yUpdateValue;

        internal Direction(char verticalDirectionLetter, char horizontalDirectionLetter)
        {
            this.CalculateUpdateValues(verticalDirectionLetter, horizontalDirectionLetter);
        }

        internal int XUpdateValue
        {
            get
            {
                return this.xUpdateValue;
            }
            set
            {
                this.xUpdateValue = value;
            }
        }

        internal int YUpdateValue
        {
            get
            {
                return this.yUpdateValue;
            }
            set
            {
                this.yUpdateValue = value;
            }
        }

        internal void CalculateUpdateValues(char verticalDirectionLetter, char horizontalDirectionLetter)
        {
            // TODO: Extract constants
            if (verticalDirectionLetter == 'U')
            {
                this.XUpdateValue = MoveDistance;
            }
            else if (verticalDirectionLetter == 'D')
            {
                this.XUpdateValue = -MoveDistance;
            }

            if (horizontalDirectionLetter == 'R')
            {
                this.YUpdateValue = MoveDistance;
            }
            else if (horizontalDirectionLetter == 'L')
            {
                this.YUpdateValue = -MoveDistance;
            }
        }
    }
}