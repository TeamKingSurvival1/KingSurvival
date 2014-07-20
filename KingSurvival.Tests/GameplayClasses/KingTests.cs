namespace KingSurvival.Tests.GameplayClasses
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using KingSurvival.GameplayClasses;

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
    }
}
