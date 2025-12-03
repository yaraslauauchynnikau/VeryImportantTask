namespace project
{
    enum Frequency
    {
        Weekly,
        Monthly,
        Yearly
    }
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public Person(string name, string surname, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
        }

        public Person() : this("Имя", "Фамилия", DateTime.Now)
        {
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, {Birthday.ToShortDateString()}";
        }
    }
    class Article
    {
       
        public Person Author { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }

        public Article(Person author, string title, double rating)
        {
            Author = author;
            Title = title;
            Rating = rating;
        }

        public Article(): this(new Person(), "Без названия", 0.0)
        {
        }

        public override string ToString()
        {
            return $"Автор: {Author}, Статья: \"{Title}\", Рейтинг: {Rating}";
        }
    }
    class Magazine
    {
        private string name;
        private Frequency frequency;
        private DateTime releaseDate;
        private int circulation;
        private Article[] articles;

        public Magazine(string name, Frequency frequency, DateTime releaseDate, int circulation)
        {
            this.name = name;
            this.frequency = frequency;
            this.releaseDate = releaseDate;
            this.circulation = circulation;
            this.articles = new Article[0];
        }

        public Magazine(): this("Без названия", Frequency.Weekly, DateTime.Now, 0)
        {
        }

        public string Name { get => name; set => name = value; }
        public Frequency Frequency { get => frequency; set => frequency = value; }
        public DateTime ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public int Circulation { get => circulation; set => circulation = value; }
        public Article[] Articles { get => articles; set => articles = value; }

        public double AverageRating
        {
            get
            {
                if (articles.Length == 0) return 0;
                return articles.Average(a => a.Rating);
            }
        }
        public bool this[Frequency freq]
        {
            get => frequency == freq;
        }

        public void AddArticles(params Article[] items)
        {
            articles = articles.Concat(items).ToArray();
        }

        public override string ToString()
        {
            string articleList = string.Join("\n", articles.Select(a => a.ToString()));
            return $"Журнал: {Name}\n" +
                   $"Периодичность: {Frequency}\n" +
                   $"Дата выхода: {ReleaseDate.ToShortDateString()}\n" +
                   $"Тираж: {Circulation}\n" +
                   $"Статьи:\n{articleList}\n" +
                   $"Средний рейтинг: {AverageRating}\n";
        }

        public virtual string ToShortString()
        {
            return $"Журнал: {Name}, {Frequency}, {ReleaseDate.ToShortDateString()}, Тираж: {Circulation}, Средний рейтинг: {AverageRating}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
