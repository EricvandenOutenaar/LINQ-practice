using System;

namespace Introduction
{
    class Program
    {
        
        static void Main(string[] args)
        {
        Me _before = new Me();
        _before.Run();            
        Allen _after = new Allen();
        Console.WriteLine("********");
        _after.Run();
        }
    }
}
