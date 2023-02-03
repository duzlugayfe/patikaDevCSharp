try
{
    int a = int.Parse("string");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine("değer giriniz");
    Console.WriteLine(ex);
}

catch (FormatException ex)
{
    Console.WriteLine("veri uyumsuz");
    Console.WriteLine(ex);
}
