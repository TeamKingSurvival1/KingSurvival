namespace KingSurvival.Engine.Formatters
{
    using System;

    using Interfaces;    

    public class BigSpacesFormatter : IFormatter
    {
        public string Format(char symbol)
        {
            return string.Format("{0,3}", symbol);
        }
    }
}
