//-----------------------------------------------------------------------
// <summary>
//     Class file for initializing the <c>PieceFactory</c> type.
// </summary>
// <copyright file="PieceFactory.cs" company="Telerik Academy - OOP 2014 Course">
//     Copyright (c) Telerik Academy - OOP 2014 Course. All rights reserved.
// </copyright>
// <author>
//     Not avaialbe. Refactored by Team King-Survival-1
// </author>
//-----------------------------------------------------------------------
namespace KingSurvival.Engine
{
    using GameplayClasses;
    using Interfaces;

    public class PieceFactory : IPieceFactory
    {
        private readonly char[] pawnSymbols = { 'A', 'B', 'C', 'D' };

        public Pawn[] CreatePawns()
        {
            Pawn[] pawns = new Pawn[Constants.NumberOfPawns];
            char currentPawnSymbol;
            int currentPawnX;

            for (int i = 0; i < pawns.Length; i++)
            {
                currentPawnSymbol = this.pawnSymbols[i];
                currentPawnX = Constants.InitialPawnX + (i * Constants.PawnsInitialDifferenceInXCoordinates);

                pawns[i] = new Pawn(currentPawnSymbol, currentPawnX, Constants.InitialPawnY);
            }

            return pawns;
        }

        public King CreateKing()
        {
            return new King(Constants.KingInitialX, Constants.KingInitialY);
        }
    }
}
