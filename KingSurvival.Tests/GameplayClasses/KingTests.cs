namespace KingSurvival.Tests.GameplayClasses
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival.GameplayClasses;
    using KingSurvival.Interfaces;

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
            Assert.AreEqual('K', exampleKing.Symbol);
        }


        [TestMethod]
        public void TestingKingsUpMovement()
        {
            King testKing = new King(2, 5);
            testKing.Move(new Direction('u', 'l'));
            Assert.AreEqual(4, testKing.Y);
        }

        [TestMethod]
        public void TestingKingsDownMovement()
        {
            King testKing = new King(2, 5);
            testKing.Move(new Direction('d', 'l'));
            Assert.AreEqual(6, testKing.Y);
        }

        [TestMethod]
        public void TestingKingsLeftMovement()
        {
            King testKing = new King(2, 5);
            testKing.Move(new Direction('u', 'l'));
            Assert.AreEqual(1, testKing.X);
        }

        [TestMethod]
        public void TestingKingsRightMovement()
        {
            King testKing = new King(2, 5);
            testKing.Move(new Direction('u', 'r'));
            Assert.AreEqual(3, testKing.X);
        }
    }
}
