using System;
using System.Collections.Generic;
// using Features.Linq;
using System.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            // demo func and lambda 
            // Linq mostly uses the Func type
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            // buildin delegate type that returns void 
            Action<int> write = x => Console.WriteLine(x);
            write(square(add(3,5)));
            Console.WriteLine("*******");

            // To demonstrate that both array and List implement IEnumerable...
            IEnumerable<Employee> developers = new Employee[]
            {
              new Employee { Id = 1, Name = "Scott" },
              new Employee { Id = 2, Name = "Chris" },
              new Employee { Id = 4, Name = "Michael" }
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
               new Employee {Id = 3, Name = "Alex"}
            };

            foreach (var item in sales)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("**********");
            Console.WriteLine(sales.Count());
            Console.WriteLine("**********");

            // essentially a foreach, but the hard way - IEnumerable is the perfect interface for hiding the source of data
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            Console.WriteLine("**********");
            
            // named method approach
            foreach (var employee in developers.Where(NameStartsWithS))
            {
                Console.WriteLine(employee.Name);
            }
            Console.WriteLine("**********");
            // delegate (anonymous function)
            foreach (var employee in developers.Where(delegate (Employee employee)
        {
                return employee.Name.StartsWith("S");
            }))
            {
                Console.WriteLine(employee.Name);
            }

            Console.WriteLine("**********");
            // lambda function - see it as a simplified anonymous function
            // with this lambda you are building/providing a Func predicate
            foreach (var employee in developers.Where(e => e.Name.StartsWith("S")))
            {
                Console.WriteLine(employee.Name);
            }
            Console.WriteLine("*********");
            // Many of the Linq methods take an IEnumerable and return one - which means you can chain methods... 
            var query = developers.Where(e => e.Name.Length == 5).OrderBy(e => e.Name);

            // query syntax - has to end with select or group
            var query2 = from developer in developers
                         where developer.Name.Length == 5
                         orderby developer.Name
                         select developer;
            
            foreach (var employee in query)
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }
    }
}
