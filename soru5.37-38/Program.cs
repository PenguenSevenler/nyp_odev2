using System;

namespace e_number
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            uint approximation = 0;
            Console.Write("Enter the number of steps to be performed: ");
            try
            {
                approximation = Convert.ToUInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("You must enter a natural number.");
                return;
            }
            Console.Write("\n");

            try
            {
                decimal calculation = e_number(approximation);
                Console.WriteLine("Our calculation of e:\t{0}", calculation);
                Console.WriteLine("Math library's e:\t{0}", Math.E);
                Console.WriteLine("\nRelative error:\t\t{0}", RelativeError(calculation, (decimal)Math.E));
            }
            catch
            {
                Console.WriteLine("Calculation failed.");
            }
        }

        internal static long Factorial(uint number)
        {
            if (number <= 1)
                return 1;
            else
                return number * Factorial(number - 1);
        }

        internal static decimal e_number(uint step)
        {
            decimal eNumber = 0;

            if (step <= 1)
            {
                return step;
            }
            else
            {
                for(uint i = 0; i < step; i++)
                {
                    eNumber += ((decimal)1.0 / (decimal)Factorial(i));
                }
                return eNumber;
            }  
        }

        internal static decimal RelativeError(decimal calculation, decimal theoretical)
        {
            return (Math.Abs(calculation - theoretical) / theoretical);
        }
    }
}