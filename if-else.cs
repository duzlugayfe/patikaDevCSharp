int time = DateTime.Now.Hour;
if (time >= 6 && time < 11)
    Console.WriteLine("Good Morning maaam");
else if (time <= 18)
    Console.WriteLine("Have a Good Day!");
else
    Console.WriteLine("Good Night Guys");

string sonuc = time >= 6 && time < 11 ? "GÜNAYDIN!" : "Yatma MK";
Console.WriteLine("sonuç" + sonuc);