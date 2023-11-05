using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class program
{
    static long factorial(int number)
    {
        if (number == 0 || number == 1)
            return 1;
        else
            return number * factorial(number - 1);


    }


    static decimal esayisi(int step)
    {
        decimal eNumber = 0;

        if (step == 1)
        {
            return 1;
        }
        else
        {
            for(int i = 0; i < step; i++)
            {
                eNumber += ((decimal)1.0/ (decimal)factorial(i));

                Console.Write("1/" + i + "! ");

                if(i != step-1)
                    Console.Write("+ ");

            }

            Console.Write("= " + eNumber);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("the e that we found : ");
            return eNumber;
        }  
    }





    static void Main(string[] args)
    {

        Console.WriteLine("" + factorial(5));

        Console.Write("input step number : ");  // ADIM SAYISI ARTTIKCA E SAYISINA YAKLASACAKSINIZ...

        int step = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(esayisi(step));

        Console.WriteLine("original e : " + Math.E);




    }
}

