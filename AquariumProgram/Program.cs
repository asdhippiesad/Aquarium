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
            int maxFishCount = 10;

            Aquarium aquarium = new Aquarium();

            while (isSwim)
            {
                const string AddFishCommand = "1";
                const string RemoveFishCommand = "2";
                const string ExitCommand = "3";

                aquarium.ShorFish();

                Console.WriteLine($"{AddFishCommand} -- Add fish.\n" +
                                  $"{RemoveFishCommand} -- Remove fish.\n" +
                                  $"{ExitCommand} -- Exit.\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddFishCommand:
                        aquarium.CreateFish(maxFishCount);
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

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Fish
    {
        public Fish(int age, int maxAge)
        { 
            Age = age;
            MaxAge = maxAge;
        }

        public int Age { get; private set; }
        public int MaxAge { get; private set; }

        public bool IsAlive;

        public void Live(int agingRate)
        {
            Age += agingRate;

            if (Age >= MaxAge)
            {
                IsAlive = false;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{MaxAge}, {Age}");
            UpdateAge();
        }

        public bool IsDie()
        {
            return IsAlive = false;
        }

        public void UpdateAge()
        {
            if (Age < MaxAge)
            {
                Age++;
            }
            else
            {
                IsDie();
                Console.WriteLine($"Рыбки больше с нами нет.(");
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _fish = new List<Fish>();

        public int FishCount { get { return _fish.Count; } }

        public void CreateFish(int maxFishCount)
        {
            if (FishCount < maxFishCount)
            {
                Fish newFish = new Fish(0, 0);

                _fish.Add(newFish);

                Console.WriteLine($"Добвлена новая рыба: {FishCount}.");
            }
            else
            {
                Console.WriteLine($"Ошибка, количество рыб не должно привышать {maxFishCount} штук.");
            }
        }

        public void ShorFish()
        {
            Console.WriteLine($"Количество рыб в аквариуме: {FishCount}.");

            for (int i = 0; i < FishCount; i++)
            {
                Fish fish = _fish[i];
                fish.ShowInfo();
                fish.Live(FishCount);
            }
        }

        public void RemoveFish()
        {
            Console.WriteLine("Введите Номер рыбки, чтобы удалить: ");

            if (FishCount > 0)
            {
                if (int.TryParse(Console.ReadLine(), out int fishIndex) && fishIndex >= 1 && fishIndex < _fish.Count)
                {

                    _fish.RemoveAt(fishIndex);
                    Console.WriteLine($"Удаленная рыба: {fishIndex}.");
                }
            }
            else
            {
                Console.WriteLine("Аквариум пуст.");
            }
        }
    }
}
