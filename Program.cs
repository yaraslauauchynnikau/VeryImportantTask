class Program
{
    static void Main(string[] args)
    {
        Magazine mag = new Magazine();
        Console.WriteLine("== ToShortString() ==");
        Console.WriteLine(mag.ToShortString());
        Console.WriteLine();

        Console.WriteLine("== Индексатор ==");
        Console.WriteLine($"Weekly: {mag[Frequency.Weekly]}");
        Console.WriteLine($"Monthly: {mag[Frequency.Monthly]}");
        Console.WriteLine($"Yearly: {mag[Frequency.Yearly]}");
        Console.WriteLine();

        mag.Name = "Tech Times";
        mag.Frequency = Frequency.Monthly;
        mag.ReleaseDate = new DateTime(2025, 2, 1);
        mag.Circulation = 5000;

        Console.WriteLine("== ToString() после изменения свойств ==");
        Console.WriteLine(mag.ToString());
        Console.WriteLine();

        Article a1 = new Article(new Person("Ivan", "Petrov", new DateTime(1990, 1, 1)), "C# Advanced", 8.5);
        Article a2 = new Article(new Person("Maria", "Sidorova", new DateTime(1985, 5, 10)), "AI Future", 9.3);

        sw.Restart();
        Article[][] arr3 = new Article[100][];
        for (int i = 0; i < 100; i++)
        {
            arr3[i] = new Article[1000];
            for (int j = 0; j < 1000; j++)
                arr3[i][j] = sample;
        }
        sw.Stop();
        Console.WriteLine($"Ступенчатый: {sw.ElapsedMilliseconds} ms");
    }
}
