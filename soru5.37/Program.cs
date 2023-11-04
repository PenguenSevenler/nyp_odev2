using System;

namespace Faktöriyel
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            bool argüman_var = args.Length >= 1;
            if (!argüman_var)
            {
                Console.Write("Faktöriyelini hesaplamak istediğiniz sayıyı girin: ");
            }
            try
            {
                uint n = 0;
                if (argüman_var)
                    n = uint.Parse(args[0]);
                else
                    n = uint.Parse(Console.ReadLine());

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