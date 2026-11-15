using SO_Lista3;

Console.WriteLine("1 - Zadanie 1 \n2 - Zadanie 2 ");
Console.WriteLine("Wybor: ");
switch (Console.ReadLine()) {
    case "1": Zad1.Run(); break;
    case "2": Zad2.Run(); break;
    default: Console.WriteLine("Nieznana opcja"); break;
}
