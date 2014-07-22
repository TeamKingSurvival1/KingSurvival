namespace KingSurvival.Engine.Formatters
{
    using System;

    using Interfaces;

    public class SmallSpacesFormatter : IFormatter
    {
        public string Format(char symbol)
        {
            return symbol.ToString();
        }
    }
}
