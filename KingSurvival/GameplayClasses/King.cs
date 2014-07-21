//-----------------------------------------------------------------------
// <summary>
//     Class file for initializing the <c>King</c> type.
// </summary>
// <copyright file="King.cs" company="Telerik Academy - OOP 2014 Course">
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
    ///     The <c>King</c> type provides specific functionality for the piece "King".
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Has symbol for initialization on the game board.
    ///     </para>
    ///     <para>
    ///         Has functionality for moving on the game board.
    ///     </para>
    ///     <para>
    ///         Has functionality for counting the moves it has made.
    ///     </para>
    /// </remarks>
    public class King : Piece
    {
        /// <summary>
        ///     Holds a <see cref="Char" /> value for its initialization on the game board.
        /// </summary>
        private const char KingsSymbol = 'K';

        /// <summary>
        ///     Holds a value as <see cref="Int32" /> for counting the made moves of the instance.
        /// </summary>
        private int movesCount;

        /// <summary>
        ///     Initializes a new instance of the <see cref="King" /> class.
        /// </summary>
        /// <param name="initialX">
        ///     Initializes the instance at co-ordinate "x" as <see cref="Int32" /> type.
        /// </param>
        /// <param name="initialY">
        ///     Initializes the instance at co-ordinate "y" as <see cref="Int32" /> type.
        /// </param>
        /// <remarks>
        ///     Inherits the base class constructor of the <see cref="Piece" /> type.
        /// </remarks>
        public King(int initialX, int initialY)
            : base(KingsSymbol, initialX, initialY)
        {
            this.MovesCount = 0;
        }

        /// <summary>
        ///     Gets the count of the executed moves.
        /// </summary>
        /// <value>The value is held as <see cref="Int32" /> type.</value>
        /// <remarks>
        ///     Iterates with the <c>movesCount</c> field.
        /// </remarks>
        public int MovesCount
        {
            get
            {
                return this.movesCount;
            }

            private set
            {
                this.movesCount = value;
            }
        }

        /// <summary>
        ///     The methods provides functionality for moving the <c>King</c> on the game field and counting its moves.
        /// </summary>
        /// <param name="moveDirection">
        ///     Takes <see cref="IDirection" /> parameter for direction to move on.
        /// </param>
        public override void Move(IDirection moveDirection)
        {
            base.Move(moveDirection);
            this.MovesCount++;
        }
    }
}