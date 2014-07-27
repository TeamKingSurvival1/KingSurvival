namespace KingSurvival.Engine
{
    using System;
    using System.Collections;

    using Interfaces;

    public class BackwardsTranslate : ITranslateStrategy
    {
        public string Translate(string input)
        {
            char[] inputUppercaseArray = input.ToUpper().ToCharArray();
            Array.Reverse(inputUppercaseArray);
            string backwards = string.Join("", inputUppercaseArray);
            
            return backwards;
        }
    }
}
