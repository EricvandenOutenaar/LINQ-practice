using System;
using System.Collections.Generic;
using System.Text;

namespace Queries
{
    public static class MyLinq
    {
        // this is to show how you can implement a filter yourselve
        // Linq does it a bit different but the principle is the same - extension method on IEnumarable of T
        // And a predicate - delegate that takes a Type arg and returns a bool to perform the logic
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source,
                                               Func<T, bool> predicate)
        {
            // without deferred execution
            //var result = new List<T>();

            //foreach (var item in source)
            //{
            //    if (predicate(item))
            //    {
            //        result.Add(item);
            //    }

            //}

            //return result;

            // deferred execution
            // yield will help you build an IEnumerable 
            // in any method where you use this yield return syntax the return type needs to be IEnumerable or IEnumarable <T> or IEnumarator / IEnurmerator<T>
            // you are building a data structure that contains a sequence of items you can iterate over
            // execution in this filter method will start when you try to pull somethin out of the IEnumerable
            // execution will begin and continue untill you hit the first yield statement, execution is handed to caller (it yields return/ jumps out of 
            // the filter method for a sec ) -caller can do something
            // with the item , like console writeline - 
            // then continues with next iteration, execution will pick up, till it hits the next yield and so on
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
            {

            }
        }
    }
}
