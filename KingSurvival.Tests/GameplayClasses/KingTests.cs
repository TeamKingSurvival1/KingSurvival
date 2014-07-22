namespace KingSurvival.Tests.GameplayClasses
{
    using System;
    using KingSurvival.GameplayClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KingTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingInitializationOfKingWithNegativeValueOfX()
        {
            King exampleKing = new King(-2, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingInitializationOfKingWithNegativeValueOfY()
        {
            King exampleKing = new King(2, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestingInitializationOfKingWithNegativeValuesOfXAndY()
        {
            King exampleKing = new King(-2, -5);
        }

        [TestMethod]
        public void TestingKingsSymbol()
        {
            King exampleKing = new King(2, 5);
            Assert.AreEqual('K', exampleKing.Symbol, "King's symbol initialization didn't match the expected character.");
        }

        [TestMethod]
        public void TestingKingsUpMovement()
        {
            King testKing = new King(2, 5);
            testKing.Move(new Direction('U', 'L'));
            Assert.AreEqual(4, testKing.Y, "King's move direction didn't match the expected position");
        }

        [TestMethod]
        public void TestingKingsDownMovement()
        {
            King testKing = new King(2, 5);
            testKing.Move(new Direction('D', 'L'));
            Assert.AreEqual(6, testKing.Y, "King's move direction didn't match the expected position");
        }

        [TestMethod]
        public void TestingKingsLeftMovement()
        {
            King testKing = new King(2, 5);
            testKing.Move(new Direction('U', 'L'));
            Assert.AreEqual(1, testKing.X, "King's move direction didn't match the expected position");
        }

        [TestMethod]
        public void TestingKingsRightMovement()
        {
            King testKing = new King(2, 5);
            testKing.Move(new Direction('U', 'R'));
            Assert.AreEqual(3, testKing.X, "King's move direction didn't match the expected position");
        }

        [TestMethod]
        public void TestingKingsMoveCount()
        {
            King testKing = new King(2, 5);

            testKing.Move(new Direction('U', 'R'));
            testKing.Move(new Direction('D', 'L'));

            Assert.AreEqual(2, testKing.MovesCount, "King's move count didn't match the expected count.");
        }
    }
}