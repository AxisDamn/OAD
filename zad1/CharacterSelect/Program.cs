using System;

namespace CharacterSelect
{
    public abstract class Postac
    {
        public string Nazwa { get; set; }
        public int Sila { get; set; }
        public int Inteligencja { get; set; }
        public int Obrona { get; set; }
        public int Mana { get; set; }

        public abstract void Attack();
        public abstract void UseSpecial();
        public virtual void Describe()
        {
            Console.WriteLine($"Postać: {Nazwa}");
            Console.WriteLine($"Statystyki -> Siła: {Sila} | Inteligencja: {Inteligencja} | Obrona: {Obrona} | Mana: {Mana}");
        }
    }

    // 1. rycerz
    public class Rycerz : Postac
    {
        public Rycerz(string imie = "Rycerz")
        {
            Nazwa = string.IsNullOrWhiteSpace(imie) ? "Rycerz" : imie;
            Sila = 25;
            Inteligencja = 5;
            Obrona = 30;
            Mana = 10;
        }

        public override void Attack()
        {
            int obrazenia = Sila * 3;
            Console.WriteLine($"{Nazwa} wykonuje potężne cięcie mieczem!");
            Console.WriteLine($"Obrażenia: {obrazenia} (Siła: {Sila} * 3)");
        }

        public override void UseSpecial()
        {
            Console.WriteLine($"{Nazwa} używa umiejętności specjalnej: Boska Tarcza!");
            Console.WriteLine("Obrona wzrasta, a postać ignoruje nadchodzące ciosy!");
        }
    }

    // 2. lucznik
    public class Lucznik : Postac
    {
        public Lucznik(string imie = "Łucznik")
        {
            Nazwa = string.IsNullOrWhiteSpace(imie) ? "Łucznik" : imie;
            Sila = 18;
            Inteligencja = 12;
            Obrona = 15;
            Mana = 20;
        }

        public override void Attack()
        {
            int obrazenia = Sila * 3;
            Console.WriteLine($"{Nazwa} wypuszcza zabójczą strzałę z łuku!");
            Console.WriteLine($"Obrażenia: {obrazenia} (Siła: {Sila} * 3)");
        }

        public override void UseSpecial()
        {
            Console.WriteLine($"{Nazwa} używa umiejętności specjalnej: Grad Strzał!");
            Console.WriteLine("Deszcz strzał spada na przeciwnika z ogromną siłą!");
        }
    }

    // 3. paladyn
    public class Paladyn : Postac
    {
        public Paladyn(string imie = "Paladyn")
        {
            Nazwa = string.IsNullOrWhiteSpace(imie) ? "Paladyn" : imie;
            Sila = 20;
            Inteligencja = 20;
            Obrona = 25;
            Mana = 30;
        }

        public override void Attack()
        {
            int obrazenia = Sila * 3;
            Console.WriteLine($"{Nazwa} uderza świętym młotem!");
            Console.WriteLine($"Obrażenia: {obrazenia} (Siła: {Sila} * 3)");
        }

        public override void UseSpecial()
        {
            Console.WriteLine($"{Nazwa} używa umiejętności specjalnej: Święte Uzdrowienie!");
            Console.WriteLine("Blask światła przywraca zdrowie i odnawia manę!");
        }
    }

    public static class Program
    {
        public static void Main()
        {
            Console.Title = "Character Select - OAD";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== WYBÓR POSTACI ===");
                Console.WriteLine("1) Rycerz");
                Console.WriteLine("2) Łucznik");
                Console.WriteLine("3) Paladyn");
                Console.WriteLine("0) Wyjście");
                Console.Write("Wybierz klasę [0-3]: ");

                var input = Console.ReadLine();
                if (input == "0") break;

                Postac wybranaPostac = null;

                switch (input)
                {
                    case "1":
                        Console.Write("Podaj imię postaci (Enter = domyślne): ");
                        wybranaPostac = new Rycerz(Console.ReadLine());
                        break;
                    case "2":
                        Console.Write("Podaj imię postaci (Enter = domyślne): ");
                        wybranaPostac = new Lucznik(Console.ReadLine());
                        break;
                    case "3":
                        Console.Write("Podaj imię postaci (Enter = domyślne): ");
                        wybranaPostac = new Paladyn(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór. Naciśnij Enter…");
                        Console.ReadKey();
                        continue;
                }

                bool powrot = false;
                while (!powrot)
                {
                    Console.Clear();
                    Console.WriteLine(">>> Utworzono postać!");
                    wybranaPostac.Describe();

                    Console.WriteLine("\nCo chcesz zrobić?");
                    Console.WriteLine("1. Atak");
                    Console.WriteLine("2. Umiejętność specjalna");
                    Console.WriteLine("3. Powrót (wybór innej postaci)");
                    Console.Write("\nWybierz opcję (1-3): ");

                    var akcja = Console.ReadLine();
                    Console.WriteLine();

                    switch (akcja)
                    {
                        case "1":
                            wybranaPostac.Attack();
                            break;
                        case "2":
                            wybranaPostac.UseSpecial();
                            break;
                        case "3":
                            powrot = true;
                            break;
                        default:
                            Console.WriteLine("Nieznana akcja.");
                            break;
                    }

                    if (!powrot)
                    {
                        Console.WriteLine("\nNaciśnij Enter, aby kontynuować...");
                        Console.ReadKey();
                    }
                }
            }

            Console.WriteLine("\nDzięki za grę! Do zobaczenia 👋");
        }
    }
}