//-----------------------------------------------------------------------
// <summary>
//     Class file for initializing the <c>Direction</c> type.
// </summary>
// <copyright file="Direction.cs" company="Telerik Academy - OOP 2014 Course">
//     Copyright (c) Telerik Academy - OOP 2014 Course. All rights reserved.
// </copyright>
// <author>
//     Not avaialbe. Refactored by Team King-Survival-1
// </author>
//-----------------------------------------------------------------------
namespace KingSurvival.GameplayClasses
{
    using Interfaces;

    public class Direction : IDirection
    {
        private const int MoveDistance = 1;

        private int xUpdateValue;
        private int yUpdateValue;

        public Direction(char verticalDirectionLetter, char horizontalDirectionLetter)
        {
            this.CalculateUpdateValues(verticalDirectionLetter, horizontalDirectionLetter);
        }

        public int XUpdateValue
        {
            get
            {
                return this.xUpdateValue;
            }

            private set
            {
                this.xUpdateValue = value;
            }
        }

        public int YUpdateValue
        {
            get
            {
                return this.yUpdateValue;
            }

            private set
            {
                this.yUpdateValue = value;
            }
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

            return object.Equals(this.XUpdateValue, compareDirection.XUpdateValue) &&
                   object.Equals(this.YUpdateValue, compareDirection.YUpdateValue);
        }
        
        private void CalculateUpdateValues(char verticalDirectionLetter, char horizontalDirectionLetter)
        {
            // TODO: Extract constants
            if (verticalDirectionLetter == 'U')
            {
                this.YUpdateValue = -MoveDistance;
            }
            else if (verticalDirectionLetter == 'D')
            {
                this.YUpdateValue = MoveDistance;
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
