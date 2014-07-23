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

    /// <summary>
    ///     The <c>Direction</c> type provides functionality for iterating with a piece's movement on the game board.
    /// </summary>
    public class Direction : IDirection
    {
        /// <summary>
        ///     Holds a <see cref="Int32"/> type value for setting the movement's speed as cells count per move.
        /// </summary>
        private const int MoveDistance = 1;

        /// <summary>
        ///     Holds a <see cref="Int32"/> type value for initializing the forthcoming change on the "x" co-ordinate.
        /// </summary>
        private int xUpdateValue;

        /// <summary>
        ///     Holds a <see cref="Int32"/> type value for initializing the forthcoming change on the "y" co-ordinate.
        /// </summary>
        private int yUpdateValue;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Direction" /> class.
        /// </summary>
        /// <param name="verticalDirectionLetter">
        ///     Initializes the direction at co-ordinate "y" as <see cref="Char" /> type.
        /// </param>
        /// <param name="horizontalDirectionLetter">
        ///     Initializes the direction at co-ordinate "x" as <see cref="Char" /> type.
        /// </param>
        public Direction(char verticalDirectionLetter, char horizontalDirectionLetter)
        {
            this.CalculateUpdateValues(verticalDirectionLetter, horizontalDirectionLetter);
        }

        /// <summary>
        ///     Gets the forthcoming movement change of the co-ordinate "x".
        /// </summary>
        /// <value>
        ///     The value is held as <see cref="Int32" /> type.
        /// </value>
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

        /// <summary>
        ///     Gets the forthcoming movement change of the co-ordinate "y".
        /// </summary>
        /// /// <value>
        ///     The value is held as <see cref="Int32" /> type.
        /// </value>
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

        /// <summary>
        ///     Produces a hash code with the operator XOR between <c>XUpdateValue</c> and <c>YUpdateValue</c>.
        /// </summary>
        /// <returns>
        ///     Returns the compiled has code as <see cref="Int32"/>.
        /// </returns>
        public override int GetHashCode()
        {
            var result = this.XUpdateValue.GetHashCode() ^ this.YUpdateValue.GetHashCode();
            
            return result;
        }

        /// <summary>
        ///     Compares an <see cref="object"/> type with the current instance.
        /// </summary>
        /// <param name="obj">
        ///     Takes an <see cref="object"/> type parameter to compare with.
        /// </param>
        /// <returns>
        ///     Returns an <see cref="Boolean"/> type value as result of comparing the objects.
        /// </returns>
        public override bool Equals(object obj)
        {
            var areEqual = false;

            Direction compareDirection = obj as Direction;

            if ((object)compareDirection == null)
            {
                return areEqual;
            }

            areEqual =
                object.Equals(this.XUpdateValue, compareDirection.XUpdateValue) &&
                object.Equals(this.YUpdateValue, compareDirection.YUpdateValue);

            return areEqual;
        }
        
        /// <summary>
        ///     Calculates the values with which the co-ordinates of a piece should be changed.
        /// </summary>
        /// <param name="verticalDirectionLetter">
        ///     Takes a <see cref="Char"/> type parameter to expose the forthcoming change of the "y" co-ordinate.
        /// </param>
        /// <param name="horizontalDirectionLetter">
        ///     Takes a <see cref="Char"/> type parameter to expose the forthcoming change of the "x" co-ordinate.
        /// </param>
        private void CalculateUpdateValues(char verticalDirectionLetter, char horizontalDirectionLetter)
        {
            // TODO: Extract constants
            if (verticalDirectionLetter == 'U')
            {
                this.YUpdateValue = -MoveDistance; // TODO: not easy readable -MoveDistance, I guess
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