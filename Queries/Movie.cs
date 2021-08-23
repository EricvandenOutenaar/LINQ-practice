namespace Queries
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }
        int _year;
        public int Year
        {
            get
            {   // to demonstrate deferred execution
                Console.WriteLine($"Returning {_year} for {Title}");
                return _year;
            }
            set
            {
                _year = value;
            }
        }
    }
}
