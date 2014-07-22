namespace KingSurvival.Engine.Formatters
{
    using System;

    using Interfaces;

    public class MediumSpacesFormatter : IFormatter
    {
        public string Format(char symbol)
        {
            return string.Format("{0,2}", symbol);
        }
    }
}
