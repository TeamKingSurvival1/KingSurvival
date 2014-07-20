namespace KingSurvival.Tests.GameplayClasses
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival.GameplayClasses;

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
        [ExpectedException(typeof(ArgumentException))]
        public void TestingInitializationOfPawnWithInvalidSymbolZ()
        {
            Pawn examplePawn = new Pawn('Z', 2, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingInitializationOfPawnWithDefaultCharValue()
        {
            Pawn examplePawn = new Pawn('\0', 2, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingInitializationOfPawnWithInvalidLowerCaseSymbolZ()
        {
            Pawn examplePawn = new Pawn('z', 2, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestingInitializationOfPawnWithValidLetterAsSymbolButInLowerCase()
        {
            Pawn examplePawn = new Pawn('b', 2, 5);
        }
    }
}
