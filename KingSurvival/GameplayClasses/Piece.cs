//-----------------------------------------------------------------------
// <summary>
//     Class file for initializing functionality of a <c>Piece</c> type.
// </summary>
// <copyright file="Piece.cs" company="Telerik Academy - OOP 2014 Course">
//     Copyright (c) Telerik Academy - OOP 2014 Course. All rights reserved.
// </copyright>
// <author>
//     Not avaialbe. Refactored by Team King-Survival-1
// </author>
//-----------------------------------------------------------------------
namespace KingSurvival.GameplayClasses
{
    using System;
    using Interfaces;

    /// <summary>
    ///     The abstract <c>Piece</c> type provides functionality for pieces in the game.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Has symbol for initialization on the game board.
    ///     </para>
    ///     <para>
    ///         Has functionality for moving on the game board.
    ///     </para>
    ///     <para>
    ///         Holds information for the position of the piece on the game board through "x" and y" co-ordinates.
    ///     </para>
    /// </remarks>
    public abstract class Piece : IPiece
    {
        /// <summary>
        ///     Hold a <see cref="Int32"/> value for its position at the "x" co-ordinate.
        /// </summary>
        private int x;

        /// <summary>
        ///     Hold a <see cref="Int32"/> value for its position at the "y" co-ordinate.
        /// </summary>
        private int y;

        /// <summary>
        ///     Holds a <see cref="Char" /> value for its initialization on the game board.
        /// </summary>
        private char symbol;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Piece" /> class.
        /// </summary>
        /// <param name="symbol">
        ///     Initializes the instance with symbol as <see cref="Char" /> type.
        /// </param>
        /// <param name="initialX">
        ///     Initializes the instance at co-ordinate "x" as <see cref="Int32" /> type.
        /// </param>
        /// <param name="initialY">
        ///     Initializes the instance at co-ordinate "y" as <see cref="Int32" /> type.
        /// </param>
        protected Piece(char symbol, int initialX, int initialY)
        {
            this.Symbol = symbol;
            this.X = initialX;
            this.Y = initialY;
        }

        /// <summary>
        ///     Gets or sets the position of the instance at the "x" co-ordinate.
        /// </summary>
        /// <value>The value is held as <see cref="Int32" /> type.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     Thrown when a negative value is set.
        /// </exception>
        /// <remarks>
        ///     Iterates with the <c>x</c> field.
        /// </remarks>
        public int X
        {
            get
            {
                return this.x;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Piece coordinates cannot be negative");
                }

                this.x = value;
            }
        }

        /// <summary>
        ///     Gets or sets the position of the instance at the "y" co-ordinate.
        /// </summary>
        /// <value>The value is held as <see cref="Int32" /> type.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     Thrown when a negative value is set.
        /// </exception>
        /// <remarks>
        ///     Iterates with the <c>y</c> field.
        /// </remarks>
        public int Y
        {
            get
            {
                return this.y;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Piece coordinates cannot be negative");
                }

                this.y = value;
            }
        }

        /// <summary>
        ///     Gets or sets the symbol of the instance with which will be displayed on the game board.
        /// </summary>
        /// <value>The value is held as <see cref="Char" /> type.</value>
        /// <exception cref="System.ArgumentException">
        ///     Thrown when a white space value is set.
        /// </exception>
        /// <remarks>
        ///     Iterates with the <c>symbol</c> field.
        /// </remarks>
        public char Symbol
        {
            get
            {
                return this.symbol;
            }

            protected set
            {
                if (char.IsWhiteSpace(value))
                {
                    throw new ArgumentException("Piece symbol cannot be white space");
                }

                this.symbol = value;
            }
        }

        /// <summary>
        ///     The methods provides functionality for moving the <c>Piece</c> on the game field.
        /// </summary>
        /// <param name="moveDirection">
        ///     Takes <see cref="IDirection" /> parameter for direction to move on.
        /// </param>
        /// <remarks>
        ///     Iterates with the properties for holding the position on the game board.
        /// </remarks>
        public virtual void Move(IDirection moveDirection)
        {
            this.X += moveDirection.XUpdateValue;
            this.Y += moveDirection.YUpdateValue;
        }
    }
}