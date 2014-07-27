namespace KingSurvival.Tests.GameplayClasses
{
    using System;
    using KingSurvival.GameplayClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PawnTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingInitializationOfPawngWithNegativeValueOfX()
        {
            Pawn examplePawn = new Pawn('B', -2, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingInitializationOfPawnWithNegativeValueOfY()
        {
            Pawn examplePawn = new Pawn('B', 2, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingInitializationOfPawnWithNegativeValuesOfXAndY()
        {
            Pawn examplePawn = new Pawn('B', -2, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingInitializationOfPawnWithInvalidSymbolK()
        {
            Pawn examplePawn = new Pawn('K', 2, 5);
        }

        [TestMethod]
        public void TestingInitializationOfPawnWithValidData()
        {
            Pawn examplePawn = new Pawn('B', 2, 5);
        }
    }
}