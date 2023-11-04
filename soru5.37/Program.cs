using System;

namespace Faktöriyel
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.Write("Faktöriyelini hesaplamak istediğiniz sayıyı girin: ");
            try
            {
                uint n = uint.Parse(Console.ReadLine());
                Console.WriteLine("Sonuç: {0}", Hesapla.Faktöriyel(n));
            }
            catch
            {
                Console.WriteLine("HATA: Bir doğal sayı girmeniz gerekiyor.");
            }
        }
    }

    internal class Hesapla
    {
        internal static long Faktöriyel(uint n)
        {
            if (n == 0)
                return 1;
            return n * Faktöriyel(n-1);
        }
    }
}