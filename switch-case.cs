int month = 3;

///expression
switch (month)
{
    case 1:
        Console.WriteLine("Ocak");
        break;
    case 2:
        Console.WriteLine("Subat");
        break;
    case 3:
        Console.WriteLine("Mart");
        break;
    case 4:
        Console.WriteLine("Nisan");
        break;
    case 5:
        Console.WriteLine("Mayıs");
        break;
    case 6:
        Console.WriteLine("Haziran");
        break;
    case 7:
        Console.WriteLine("Temmuz");
        break;
    case 8:
        Console.WriteLine("Ağustos");
        break;
    case 9:
        Console.WriteLine("EYLÜL");
        break;
    case 10:
        Console.WriteLine("EKİM");
        break;
    case 11:
        Console.WriteLine("Kasım");
        break;
    case 12:
        Console.WriteLine("ARALIK");
        break;
    default:
        Console.WriteLine("Yanlıs Veri Girisi");
        break;
}

switch (month)
{
    case 12:
    case 1:
    case 2:
        Console.WriteLine("kış mevsimi");
        break;
    case 6:
    case 7:
    case 8:
        Console.WriteLine("YAZ MEVSİMİ");
        break;
    case 9:
    case 10:
    case 11:
        Console.WriteLine("SON BAHAR");
        break;
    case 3:
    case 4:
    case 5:
        Console.WriteLine("ILK BAHAR");
        break;

    default:
        Console.WriteLine("Yanlıs Veri Girişi");
        break;
}