namespace KingSurvival.Engine.Formatters
{
    using System;

    using Interfaces;

    /// <summary>
    /// Represents formatter with fancy spaces between symbols.
    /// </summary>
    public class FancySpacesFormatter : IFormatter
    {
        public string Format(char symbol)
        {
            return "_" + symbol;
        }
    }
}
