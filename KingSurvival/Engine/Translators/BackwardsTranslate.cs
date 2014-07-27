namespace KingSurvival.Engine.Translators
{
    using System;

    using Interfaces;

    /// <summary>
    /// Represents backwards translation of user's command.
    /// </summary>
    public class BackwardsTranslate : ITranslateStrategy
    {
        public string Translate(string input)
        {
            char[] inputUppercaseArray = input.ToUpper().ToCharArray();
            Array.Reverse(inputUppercaseArray);
            string backwards = string.Join(string.Empty, inputUppercaseArray);
            
            return backwards;
        }
    }
}
