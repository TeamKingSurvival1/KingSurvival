namespace KingSurvival.Tests.Engine.Formatters
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Engine.Formatters;
    using KingSurvival.Interfaces;

    [TestClass]
    public class FormattersTests
    {
        [TestMethod]
        public void SmallSpacesFormatterTest()
        {
            IFormatter formatter = new SmallSpacesFormatter();
            char symbol = 'a';
            string actual = formatter.Format(symbol);
            string expected = "a";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MediumSpacesFormatterTest()
        {
            IFormatter formatter = new MediumSpacesFormatter();
            char symbol = 'a';
            string actual = formatter.Format(symbol);
            string expected = " a";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BigSpacesFormatterTest()
        {
            IFormatter formatter = new BigSpacesFormatter();
            char symbol = 'a';
            string actual = formatter.Format(symbol);
            string expected = "  a";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FancySpacesFormatterTest()
        {
            IFormatter formatter = new FancySpacesFormatter();
            char symbol = 'a';
            string actual = formatter.Format(symbol);
            string expected = "_a";

            Assert.AreEqual(expected, actual);
        }
    }
}
