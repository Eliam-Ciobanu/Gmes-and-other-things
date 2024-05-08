using System;

namespace Game
{
    public class Car
    {
        public int horsePower;
        public int maxSpeed;
        public bool aerodynamic;
        public double weight;
        public bool lost;
        public double prize;
        public string model;
    }

    class Player
    {
        public string name = "null";
        public double money;
        public Car car = new Car();
    }

    class Program
    {
        private static Player player = new Player();
        private static Car[] racers = new Car[3]; // Initialize the array with size 3

        private static string[] carBrands = { "Audi", "Mercedes", "Bmw", "Ferrari" };

        static void FirstMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("|     Salutare!          |");
            Console.WriteLine("|Vrei să începi Car Race?|");
            Console.WriteLine("|  Apasă pe orice tastă  |");
            Console.WriteLine("--------------------------");
            Console.ReadKey();
        }

        static void NameSelection()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("  Care este numele tău?   ");
            Console.WriteLine("--------------------------");
            // Care este numele
            string raspuns = Console.ReadLine();
            player.name = raspuns;

            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("| Numele tau este " + raspuns + "?");
            Console.WriteLine("| Apasă ENTER pentru Da  |");
            Console.WriteLine("|                        |");
            Console.WriteLine("---------------------------");
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                NameSelection();
            }
        }

        static void GameMenu()
        {
            Console.Clear();
            Console.WriteLine("Curse în așteptare:");
            for (int i = 0; i < racers.Length; i++)
            {
                Console.WriteLine("----------------");
                Console.WriteLine($"Curse #{i + 1}: {racers[i].model}");
                Console.WriteLine($"Viteza Maximă: {racers[i].maxSpeed} km/h");
                Console.WriteLine($"Putere Motor: {racers[i].horsePower} CP");
                Console.WriteLine("----------------");
                Console.WriteLine();
            }

            Console.WriteLine("Selectează o cursă:");
            Console.WriteLine("Apasă tasta corespunzătoare cursei sau 'X' pentru a reveni la meniu.");

            char input;
            do
            {
                input = Console.ReadKey().KeyChar;
                int raceIndex = input - '1';
                if (raceIndex >= 0 && raceIndex < racers.Length)
                {
                    // Implement race logic here
                    StartRace(racers[raceIndex]);
                    return;
                }
                else if (input == 'X' || input == 'x')
                {
                    Menu();
                    return;
                }
                else
                {
                    Console.WriteLine("\nTe rog selectează o opțiune validă.");
                }
            } while (true);
        }

        static void StartRace(Car selectedCar)
        {
            Console.Clear();
            Console.WriteLine($"Ai ales să concurezi cu un {selectedCar.model}!");
            // Implement race logic here
            // For example, you could simulate the race and determine the winner
            // Update player's money based on the race outcome
            // Display race results
            // Allow the player to return to the main menu
            Console.WriteLine("\nApasă orice tastă pentru a reveni la meniu.");
            Console.ReadKey();
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------");
            Console.WriteLine("|         1.Play          |");
            Console.WriteLine("|     2.Check Balance     |");
            Console.WriteLine("|         3.Exit          |");
            Console.WriteLine("--------------------------");
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.D3)
            {
                Console.Clear();
                Console.WriteLine("Ai închis jocul!");
                return;
            }
            else if (input.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine("--------------------------");
                Console.WriteLine($"Jucătorul {player.name} are {player.money} bani.");
                Console.WriteLine("--------------------------");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Menu();
                }
            }
            else if (input.Key == ConsoleKey.D1)
            {
                Console.Clear();
                GameMenu(); // Call the GameMenu method to start the game
            }
        }

        static void Main(string[] args)
        {
            FirstMenu();
            NameSelection();
            player.money = 100.00;
            var rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                racers[i] = new Car();
                racers[i].weight = rand.Next(400, 2000);
                racers[i].maxSpeed = rand.Next(120, 300);
                racers[i].horsePower = rand.Next(65, 1000);
                racers[i].model = carBrands[rand.Next(0, carBrands.Length)]; // Use carBrands.Length to avoid index out of range
            }

            Menu();
        }
    }
}

