using System;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {

        string[] renkler = new string[5];
        string[] hayvanlar = { "Kedi", "Köpek", "Kuş", "Maymun" };

        int[] dizi;
        dizi = new int[5];
        renkler[0] = "Mavi";
        dizi[3] = 10;
        Console.WriteLine(hayvanlar[1]);
        Console.WriteLine(dizi[3]);
        Console.WriteLine(renkler[0]);
        Console.Write("Lütfen eleman sayisini giriniz :");
        int diziUzunlugu = int.Parse(Console.ReadLine());
        int[] sayıdizisi = new int[diziUzunlugu];

        for (int i = 0; i < diziUzunlugu; i++)
        {
            Console.Write("Lütfen {0}. sayıyı giriniz", i + 1);
            sayıdizisi[i] = int.Parse(Console.ReadLine());
        }
        int toplam = 0;
        foreach (var sayi in sayıdizisi)
            toplam += sayi;

        Console.WriteLine("Ortalama :" + toplam / diziUzunlugu);


    }

}
