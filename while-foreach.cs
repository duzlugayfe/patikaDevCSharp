class Program
{
    static void Main(string[] args)
    {
        Console.Write("Lütfen Bir Sayi Giriniz ! ");
        int sayi = int.Parse(Console.ReadLine());
        int sayac = 1;
        int toplam = 0;
        while (sayac <= sayi)
        {
            toplam += sayac;
            sayac++;

        }
        Console.WriteLine(toplam / sayi);
        // a dan z ye kadar tüm harfleri console a yazdır 
        char character = 'a';
        while (character <= 'z')
        {
            Console.Write(character);
            character++;
            Console.Write(character);
            character++;
        }

        Console.WriteLine("*-*-*-*ForEach-*-*-*");
        string[] arabalar = { "BMV", "Ford", "Toyota", "Nissan" };
        foreach (var araba in arabalar)
        {
            Console.WriteLine(" " + araba);
        }


    }
}