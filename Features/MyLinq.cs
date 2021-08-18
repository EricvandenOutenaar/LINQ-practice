using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Linq
{
    // Linq builds on extension methods that extend IEnumerable<T>
    // You can create extension methods on any type
    // But you can't replace/reimplement/hide excisting instance methods
    // Extension methods allow you to implement any functionality against any type, without changing the underlying type 
    public static class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;

            foreach (var item in sequence)
            {
                count++;
            }
            return count;
        }
    }
}
