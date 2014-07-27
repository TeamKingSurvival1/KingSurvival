namespace KingSurvival.Tests.Engine
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Engine;
    using KingSurvival.Interfaces;
    using KingSurvival.GameplayClasses;

    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseTestThatMustThrowAnArgumentNullException()
        {
            Command.Parse("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ParseTestThatMustThrowAnArgumentOutOfRangeException()
        {
            Command.Parse("a");
        }

        [TestMethod]
        public void ParseTestThatMustNotThrowAnException()
        {
            Assert.IsInstanceOfType(Command.Parse("KUR"), typeof(Command));
        }

        [TestMethod]
        public void MoveDirectionTest()
        {
            Command command = Command.Parse("KUR");
            IDirection expected = new Direction('U', 'R');
            IDirection actual = command.MoveDirection;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TargetSymbolTest()
        {
            Command command = Command.Parse("KUR");
            char expected = 'K';
            char actual = command.TargetSymbol;

            Assert.AreEqual(expected, actual);
        }
    }
}
