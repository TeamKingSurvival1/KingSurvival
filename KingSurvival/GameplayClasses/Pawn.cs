//-----------------------------------------------------------------------
// <summary>
//     Class file for initializing the <c>Pawn</c> type.
// </summary>
// <copyright file="Pawn.cs" company="Telerik Academy - OOP 2014 Course">
//     Copyright (c) Telerik Academy - OOP 2014 Course. All rights reserved.
// </copyright>
// <author>
//     Not avaialbe. Refactored by Team King-Survival-1
// </author>
//-----------------------------------------------------------------------
namespace KingSurvival.GameplayClasses
{
    using System;

    /// <summary>
    ///     The <c>Pawn</c> type provides specific functionality for the piece "Pawn".
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Has symbol for initialization on the game board.
    ///     </para>
    ///     <para>
    ///         Has functionality for moving on the game board.
    ///     </para>
    /// </remarks>
    public class Pawn : Piece
    {
        /// <summary>
        ///     Holds a <see cref="Char" /> for its initialization on the game board.
        /// </summary>
        private const char InvalidPawnSymbol = 'K';

        /// <summary>
        ///     Initializes a new instance of the <see cref="Pawn" /> class.
        /// </summary>
        /// <param name="symbol">
        ///     Initializes the instance with symbol as <see cref="Char"/> type.
        /// </param>
        /// <param name="initialX">
        ///     Initializes the instance at co-ordinate "x" as <see cref="Int32" /> type.
        /// </param>
        /// <param name="initialY">
        ///     Initializes the instance at co-ordinate "y" as <see cref="Int32" /> type.
        /// </param>
        /// <remarks>
        ///     Inherits the base class constructor of the <see cref="Piece" /> type.
        /// </remarks>
        /// <exception cref="System.ArgumentException">
        ///     Thrown when an incorrect symbol for a <c>Pawn</c> is passed for initialization.
        /// </exception>
        public Pawn(char symbol, int initialX, int initialY)
            : base(symbol, initialX, initialY)
        {
            if (symbol == InvalidPawnSymbol)
            {
                throw new ArgumentException("Invalid pawn symbol!");
            }
        }
    }
}