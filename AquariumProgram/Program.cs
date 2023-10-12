
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquariumProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isSwim = true;

            Aquarium aquarium = new Aquarium();

            while (isSwim)
            {
                const string AddFishCommand = "1";
                const string RemoveFishCommand = "2";
                const string ExitCommand = "3";

                aquarium.ShowFishes();

                Console.WriteLine($"{AddFishCommand} -- Add fish.\n" +
                                  $"{RemoveFishCommand} -- Remove fish.\n" +
                                  $"{ExitCommand} -- Exit.\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddFishCommand:
                        aquarium.CreateFish();
                        break;

                    case RemoveFishCommand:
                        aquarium.RemoveFish();
                        break;

                    case ExitCommand:
                        isSwim = false;
                        break;

                    default:
                        Console.WriteLine("Incorrect data entered.");
                        break;
                }

                aquarium.ShowUpdateAge();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Fish
    {
        private int _maxAge = 5;

        public Fish()
        {
            Age = 0;
        }

        public int Age { get; private set; }
        public bool IsAlive => Age < _maxAge;

        public void ShowInfo()
        {
            Console.WriteLine($"{_maxAge}/{Age}");
        }
        public void Die()
        {
            Age = _maxAge;
        }

        public void UpdateAge()
        {
            if (IsAlive)
            {
                Age++;
            }
            else
            {
                Die();
                Console.WriteLine($"Рыбки больше с нами нет.(");
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes = new List<Fish>();

        public int MaxFishCount { get; } = 5;
        public int FishCount => _fishes.Count;

        public void CreateFish()
        {

            if (FishCount < MaxFishCount) 
            { 
                _fishes.Add(new Fish());

                Console.WriteLine($"Добвлена новая рыба: {FishCount}.");
            }
            else
            {
                Console.WriteLine($"Ошибка, количество рыб не должно привышать {MaxFishCount} штук.");
            }
        }

        public void ShowUpdateAge()
        {
            foreach (Fish fishes in _fishes)
            {
                fishes.UpdateAge();
            }
        }

        public void ShowFishes()
        {
            Console.WriteLine($"Количество рыб в аквариуме: {FishCount}.");

            for (int i = 0; i < _fishes.Count; i++)
            {
                Console.WriteLine($"Рыбы: {i + 1}");
                _fishes[i].ShowInfo();
            }
        }

        public void RemoveFish()
        {
            Console.WriteLine("Введите Номер рыбки, чтобы удалить: ");

            if (FishCount > 0)
            {
                if (int.TryParse(Console.ReadLine(), out int fishIndex) && fishIndex >= 0 && fishIndex < _fishes.Count)
                {
                    _fishes.RemoveAt(fishIndex);
                    Console.WriteLine($"Удаленная рыба: {fishIndex}.");
                }
                else
                {
                    Console.WriteLine("Рыбки с таким номером нет.");
                }
            }
            else
            {
                Console.WriteLine("Аквариум пуст.");
            }
        }
    }
}