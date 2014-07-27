namespace KingSurvival.Interfaces
{
    using System;

    using Interfaces;

    public class NormalTranslate : ITranslateStrategy
    {
        public string Translate(string input)
        {
            string inputUppercase = input.ToUpper();

            return inputUppercase;
        }
    }
}
