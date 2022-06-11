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
        private List<Fish> _fishesList = new List<Fish>();
        private int _capacity = 4;

        public void Work()
        {
            bool _isWorking = true;
            AddToList();

            while (_isWorking)
            {
                ShowFishesList();
                UpdateFishesAge();
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
                        DeleteFishes();
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
                for (int i = 0; i < _fishesList.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {_fishesList[i].Species}");
                }

                Console.WriteLine("Выберите рыбу");
                string input = Console.ReadLine();
                int number;

                if (int.TryParse(input, out number))
                {
                    if (number - 1 <= _fishesList.Count)
                    {
                        _fishes.Add(new Fish(_fishesList[number - 1].Species));
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

        private void AddToList()
        {
            _fishesList.Add(new Fish("Золотая рыбка"));
            _fishesList.Add(new Fish("Гуппи"));
            _fishesList.Add(new Fish("Сом"));
            _fishesList.Add(new Fish("Скат"));
            _fishesList.Add(new Fish("Пиранья"));
        }

        private void DeleteFishes()
        {
            ShowFishesList();
            Console.WriteLine("Какую рыбу вы хотите убрать?");
            string input = Console.ReadLine();
            int number;

            if (int.TryParse(input, out number))
            {
                if (number <= _fishes.Count)
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

        private void DeleteDeadFish()
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
            Years = random.Next(minYears,maxYears);
            return Years;
        }
    }
}