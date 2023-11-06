using System;

public class Program
{
    internal int fact(int n)//faktoriyel fonksiyonu
    {
        int sonuc=1;
        for(int i=n;i>0;i--)
        {
            sonuc=sonuc*i;
        }
        return sonuc;
    }
    
    public static void Main(string[] args)
    {
        int n;
        double e=0;
        Program f= new Program();
        Console.WriteLine("step number of calculating e: ");
        n=Convert.ToInt32(Console.ReadLine());
        for(int i=0;i<n;i++) //e yi hesaplayan for dongusu
        {
            e=e+(1/(double)f.fact(i));
        }
        Console.WriteLine($"My e with {n} step: {e}\nMath libs e: {Math.E}");
    }
}