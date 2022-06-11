using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Aquarium aquarium = new Aquarium();
            aquarium.Work();
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes = new List<Fish>();
        private bool _isWorking = true;

        public void Work()
        {
            while (_isWorking)
            {
                ShowAquariumInfo();
                UpdateFishAge();
                DeleteDeadFish();
                Console.WriteLine();
                Console.WriteLine("1. Добавить рыбу в аквариум");
                Console.WriteLine("2. Убрать рыбу из аквариума");
                Console.WriteLine("3. Выход");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewFish();
                        break;
                    case "2":
                        DeleteFish();
                        break;
                    case "3":
                        _isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
        }

        private void AddNewFish()
        {
            int maxFishes = 4;

            if (_fishes.Count <= maxFishes)
            {
                Console.WriteLine("Список рыб для добавления:");
                Console.WriteLine("1. Золотая рыбка");
                Console.WriteLine("2. Гуппи");
                Console.WriteLine("3. Сом");
                Console.WriteLine("4. Скат");
                Console.WriteLine("5. Пиранья");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _fishes.Add(new Fish("Золотая рыбка"));
                        break;
                    case "2":
                        _fishes.Add(new Fish("Гуппи"));
                        break;
                    case "3":
                        _fishes.Add(new Fish("Сом"));
                        break;
                    case "4":
                        _fishes.Add(new Fish("Скат"));
                        break;
                    case "5":
                        _fishes.Add(new Fish("Пиранья"));
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }

                Console.Clear();
            }
            else 
            {
                Console.WriteLine("Аквариум полон");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DeleteFish()
        {
            ShowAquariumInfo();
            Console.WriteLine("Какую рыбу вы хотите убрать?");
            string input = Console.ReadLine();
            int number;
            int.TryParse(input, out number);
            _fishes.RemoveAt(number - 1);
            Console.Clear();
        }

        private void ShowAquariumInfo()
        {
            if (_fishes.Count > 0)
            {
                for (int i = 0; i < _fishes.Count; i++)
                {
                    Console.Write($"{i + 1}.");
                    _fishes[i].ShowFishInfo();
                }
            }
            else
            {
                Console.WriteLine("В аквариуме пусто");
            }
        }

        private void UpdateFishAge()
        {
            foreach (var fish in _fishes)
            {
                fish.Age();
            }             
        }

        private void DeleteDeadFish()
        {
            int dyingAge = 11;

            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].Years == dyingAge)
                {
                    Console.WriteLine($"{_fishes[i].Species} умерла от старости");
                    _fishes.RemoveAt(i);
                }
            }
        }
    }

    class Fish
    { 
        public string Species { get; private set; }
        public int Years { get; protected set; }

        public Fish(string species)
        {
            Species = species;
            Years = SetYears();
        }

        public void Age()
        {
            Years++;
        }

        public void ShowFishInfo()
        {
            Console.WriteLine(Species + " " + Years);
        }

        private int SetYears()
        {
            Random random = new Random();
            int minYears = 1;
            int maxYears = 6;
            Years = random.Next(minYears,maxYears);
            return Years;
        }
    }
}