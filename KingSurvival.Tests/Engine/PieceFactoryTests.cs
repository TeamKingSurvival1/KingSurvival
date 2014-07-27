namespace KingSurvival.Tests.Engine
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Interfaces;
    using KingSurvival.Engine;
    using KingSurvival.GameplayClasses;

    [TestClass]
    public class PieceFactoryTests
    {
        [TestMethod]
        public void CreateKingTest()
        {
            IPieceFactory factory = new PieceFactory();
            King actual = factory.CreateKing();

            Assert.IsInstanceOfType(actual, typeof(King));
        }

        [TestMethod]
        public void CreatePawnsTest()
        {
            IPieceFactory factory = new PieceFactory();
            IPiece[] pawns = factory.CreatePawns();
            bool areAllPawns = true;

            for (int i = 0; i < pawns.Length; i++)
            {
                if (pawns[i].GetType() != typeof(Pawn))
                {
                    areAllPawns = false;

                    break;
                }
            }

            Assert.IsTrue(areAllPawns);
        }
    }
}
