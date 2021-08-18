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

            IEnumerable<Employee> developers = new Employee[]
            {
              new Employee { Id = 1, Name = "Scott" },
              new Employee { Id = 2, Name = "Chris" }
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
            // lambda function
            foreach (var employee in developers.Where(s => s.Name.StartsWith("S")))
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
