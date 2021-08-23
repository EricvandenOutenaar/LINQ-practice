using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var movies = new List<Movie>
                { new Movie { Title = "The Dark Knight", Rating = 8.9f, Year = 2008 },
                  new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010 },
                  new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1942},
                  new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 },
                 };
            // Linq implements deferred execution  - it is as lazy as possible
            // Look at the .Where or .Filter as defining a query - or building a datastructure that
            // knows what to do sometime in the future , but the filtering execution untill we try to see the results of the query

            var query = movies.Filter(m => m.Year > 2000);
            
            // The qurery does no no real work performed untill it is forced to execute 
            // A foreach statement forces execution - any operation the inspects the results will force execution 
            /*
            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }
            */
            // behind the scenes a foreach is just using an getEnumerator like I do here... 
            var enumerator = query.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }

            // Be aware that operators can be deferred (Like where / take ) or immediate (Count / To List)
            // Deferred operators can be either streaming (like where) or non streaming (like Orderby - needs the whole dataset to know..)
            
        }
    }
}
