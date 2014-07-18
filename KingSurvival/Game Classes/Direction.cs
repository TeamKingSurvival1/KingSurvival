﻿namespace KingSurvival
{
    public class Direction
    {
        private const int MoveDistance = 1;

        private int xUpdateValue;
        private int yUpdateValue;

        internal Direction(char verticalDirectionLetter, char horizontalDirectionLetter)
        {
            this.CalculateUpdateValues(verticalDirectionLetter, horizontalDirectionLetter);
        }

        public override int GetHashCode()
        {
            return this.XUpdateValue.GetHashCode() ^ this.YUpdateValue.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Direction compareDirection = obj as Direction;

            if ((object)compareDirection == null)
            {
                return false;
            }

            return Equals(this.XUpdateValue, compareDirection.XUpdateValue) &&
                   Equals(this.YUpdateValue, compareDirection.YUpdateValue);
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
                this.YUpdateValue = -MoveDistance;
            }
            else if (verticalDirectionLetter == 'D')
            {
                this.YUpdateValue = +MoveDistance;
            }

            if (horizontalDirectionLetter == 'R')
            {
                this.XUpdateValue = MoveDistance;
            }
            else if (horizontalDirectionLetter == 'L')
            {
                this.XUpdateValue = -MoveDistance;
            }
        }
    }
}
