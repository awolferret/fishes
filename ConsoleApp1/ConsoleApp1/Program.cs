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
        private List<string> _species = new List<string>();
        private int _capacity = 4;

        public void Work()
        {
            bool _isWorking = true;
            _species = CreateNewSpecies();

            while (_isWorking)
            {
                ShowFishesList();
                UpdateFishesAge();
                DeleteDeadFishes();
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
            if (_fishes.Count <= _capacity)
            {
                for (int i = 0; i < _species.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {_species[i]}");
                }

                Console.WriteLine("Выберите рыбу");
                string input = Console.ReadLine();
                int number;

                if (int.TryParse(input, out number))
                {
                    if (number > 0 && number <= _species.Count)
                    {
                        _fishes.Add(new Fish(_species[number - 1]));
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка");
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

        private List<string> CreateNewSpecies()
        {
            List<string> list = new List<string>();
            list.Add(new string("Золотая рыбка"));
            list.Add(new string("Гуппи"));
            list.Add(new string("Сом"));
            list.Add(new string("Скат"));
            list.Add(new string("Пиранья"));
            return list;
        }

        private void DeleteFish()
        {
            if (_fishes.Count > 0)
            {
                ShowFishesList();
                Console.WriteLine("Какую рыбу вы хотите убрать?");
                string input = Console.ReadLine();
                int number;

                if (int.TryParse(input, out number))
                {
                    if (number > 0 && number <= _fishes.Count)
                    {
                        _fishes.RemoveAt(number - 1);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
            }
            else
            {
                Console.WriteLine("В аквариуме пусто");
            }
        }

        private void ShowFishesList()
        {
            if (_fishes.Count > 0)
            {
                for (int i = 0; i < _fishes.Count; i++)
                {
                    Console.Write($"{i + 1}.");
                    _fishes[i].ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("В аквариуме пусто");
            }
        }

        private void UpdateFishesAge()
        {
            foreach (var fish in _fishes)
            {
                fish.Age();
            }             
        }

        private void DeleteDeadFishes()
        {
            int dyingAge = 11;

            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].Years == dyingAge)
                {
                    Console.WriteLine($"{_fishes[i].Species} умерла от старости");
                    _fishes.RemoveAt(i);
                    i--;
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
            Years = ChooseAge();
        }

        public void Age()
        {
            Years++;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Species + " " + Years);
        }

        private int ChooseAge()
        {
            Random random = new Random();
            int minYears = 1;
            int maxYears = 6;
            int age = random.Next(minYears,maxYears);
            return age;
        }
    }
}