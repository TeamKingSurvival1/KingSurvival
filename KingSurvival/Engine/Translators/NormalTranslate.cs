namespace KingSurvival.Engine.Translators
{
    using System;

    using Interfaces;

    /// <summary>
    /// Represents normal translation of user's command.
    /// </summary>
    public class NormalTranslate : ITranslateStrategy
    {
        public string Translate(string input)
        {
            string inputUppercase = input.ToUpper();

            return inputUppercase;
        }
    }
}
