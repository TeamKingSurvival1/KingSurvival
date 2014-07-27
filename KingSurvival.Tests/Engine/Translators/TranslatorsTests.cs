namespace KingSurvival.Tests.Engine.Translators
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.Engine.Translators;
    using KingSurvival.Interfaces;

    [TestClass]
    public class TranslatorsTests
    {
        [TestMethod]
        public void NormalTranslateTest()
        {
            ITranslateStrategy translator = new NormalTranslate();
            string input = "abc";
            string expected = "ABC";
            string actual = translator.Translate(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BackwardsTranslateTest()
        {
            ITranslateStrategy translator = new BackwardsTranslate();
            string input = "abc";
            string expected = "CBA";
            string actual = translator.Translate(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
