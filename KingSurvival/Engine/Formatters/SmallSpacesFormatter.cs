namespace KingSurvival.Engine.Formatters
{
    using System;

    using Interfaces;

    /// <summary>
    /// Represents formatter with small spaces between symbols.
    /// </summary>
    public class SmallSpacesFormatter : IFormatter
    {
        public string Format(char symbol)
        {
            return symbol.ToString();
        }
    }
}
