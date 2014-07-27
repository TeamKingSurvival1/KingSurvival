namespace KingSurvival.Tests.GameplayClasses
{
    using System;
    using KingSurvival.GameplayClasses;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DirectionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDirectionVerticalValueInitialization()
        {
            var direction = new Direction('V', 'L');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDirectionHorizontalValueInitialization()
        {
            var direction = new Direction('U', 'V');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDirectionWithExchangedVerticalAndHorizontalValues()
        {
            var direction = new Direction('L', 'D');
        }
    }
}