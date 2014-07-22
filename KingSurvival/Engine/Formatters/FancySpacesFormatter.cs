namespace KingSurvival.Engine.Formatters
{
    using System;

    using Interfaces;

    public class FancySpacesFormatter : IFormatter
    {
        public string Format(char symbol)
        {
            return "_" + symbol;
        }
    }
}
