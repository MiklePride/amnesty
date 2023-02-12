using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Prison prison = new Prison();

            prison.ShowInfo();

            prison.Amnesty();

            Console.WriteLine();

            prison.ShowInfo();

            Console.ReadLine();
        }
    }
}

class Prison
{
    private List<Prisoner> _prisoners = new List<Prisoner>();

    public Prison()
    {
        _prisoners.Add(new Prisoner("Степанов Иван Викторович"));
        _prisoners.Add(new Prisoner("Вологодин Антон Виниаминович"));
        _prisoners.Add(new Prisoner("Карпов Евгений Николаевич"));
        _prisoners.Add(new Prisoner("Гриднев Алексей Сергеевич"));
        _prisoners.Add(new Prisoner("Казаков Дмитрий Викторович"));
        _prisoners.Add(new Prisoner("Пашутин Станислав Валереевич"));
        _prisoners.Add(new Prisoner("Растров Гектор Аркадиевич"));
        _prisoners.Add(new Prisoner("Лопушков Анатолий Михайлович"));
        _prisoners.Add(new Prisoner("Поспелов Руслан Артемович"));
        _prisoners.Add(new Prisoner("Алихандров Геннадий Александрович"));
    }

    public void ShowInfo()
    {
        foreach (var prisoner in _prisoners)
        {
            prisoner.ShowInfo();
        }
    }

    public void Amnesty()
    {
        string amnestyCrime = "Антиправительственное";

        var filteredPrisoners = _prisoners.Where(prisoner => prisoner.Crime != amnestyCrime).ToList();

        _prisoners = filteredPrisoners;
    }
}

class Prisoner
{
    private static Random _random = new Random();

    private string _fullName;

    public Prisoner(string fullName)
    {
        _fullName = fullName;

        int typeCrimesCount = 4;

        int randomCrimeNumber = _random.Next(typeCrimesCount);

        if ((Crimes)randomCrimeNumber == Crimes.AntiGovernment)
            Crime = "Антиправительственное";

        if ((Crimes)randomCrimeNumber == Crimes.Murder)
            Crime = "Убийство";

        if ((Crimes)randomCrimeNumber == Crimes.Theft)
            Crime = "Кража";

        if ((Crimes)randomCrimeNumber == Crimes.DrugTrade)
            Crime = "Наркоторговля";
    }

    public string Crime { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"фио: {_fullName} Преступление: {Crime}");
    }

    enum Crimes : byte
    {
        AntiGovernment,
        Murder,
        Theft,
        DrugTrade
    }
}
