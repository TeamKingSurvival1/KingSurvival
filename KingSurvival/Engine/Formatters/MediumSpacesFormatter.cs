namespace KingSurvival.Engine.Formatters
{
    using System;

    using Interfaces;

    /// <summary>
    /// Represents formatter with medium spaces between symbols.
    /// </summary>
    public class MediumSpacesFormatter : IFormatter
    {
        public string Format(char symbol)
        {
            return string.Format("{0,2}", symbol);
        }
    }
}
