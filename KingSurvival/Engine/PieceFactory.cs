namespace KingSurvival.Engine
{
    using Interfaces;
    using GameplayClasses;

    public class PieceFactory : IPieceFactory
    {
        private readonly char[] PawnSymbols = { 'A', 'B', 'C', 'D' };

        public Pawn[] CreatePawns()
        {
            Pawn[] pawns = new Pawn[Constants.NumberOfPawns];
            char currentPawnSymbol;
            int currentPawnX;

            for (int i = 0; i < pawns.Length; i++)
            {
                currentPawnSymbol = PawnSymbols[i];
                currentPawnX = Constants.InitialPawnX + i * Constants.PawnsInitialDifferenceInXCoordinates;

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
