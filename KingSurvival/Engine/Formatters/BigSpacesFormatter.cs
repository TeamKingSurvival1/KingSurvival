namespace KingSurvival.Engine.Formatters
{
    using System;

    using Interfaces;    

    /// <summary>
    /// Represents formatter with big spaces between symbols.
    /// </summary>
    public class BigSpacesFormatter : IFormatter
    {
        public string Format(char symbol)
        {
            return string.Format("{0,3}", symbol);
        }
    }
}
