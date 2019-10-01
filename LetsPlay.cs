using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BisectionAlgorithm
{
    public class Program : Formulas
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bisection Algorithm.Main()");
            WhoIsGuessing();
        }
        static void WhoIsGuessing()
        {
            bool valid;
            int choice;
            Console.WriteLine("\nWho should guess the number?");
            Console.WriteLine("\n1 : User or 2 : Computer or 3 : Bisection Algorithm Demonstration\n");
            do
            {
                valid = int.TryParse(Console.ReadLine(), out choice);
                if (!valid || choice < 1 || choice > 3)
                {
                    Console.WriteLine("\nInvalid input");
                    valid = false;
                }
            } while (!valid);
            if (choice == 1)
            {
                Human();
            }
            else if (choice == 2)
            {
                Computer();
            }
            else if (choice == 3)
            {
                BisectionalAlgorithm();
            }
        }
        static void BisectionalAlgorithm()
        {
            bool valid;
            Console.WriteLine("\nWhat range do you want the computer to guess from?");
            Console.Write($"\n{startingPoint} through ");
            do
            {
                valid = int.TryParse(Console.ReadLine(), out highestValue);
                if (!valid)
                {
                    Console.WriteLine("\nInvalid input");
                }
                else if (highestValue <= startingPoint)
                {
                    Console.WriteLine($"\nRange must bigger than {startingPoint}");
                    valid = false;
                }
            } while (!valid);
            List<int> rangeOfNums = PopulateList(highestValue);
            int randValue = ComputerPicksRandom(rangeOfNums);
            middle = FindMiddle(startingPoint, highestValue);
            do
            {
                if (randValue > middle)
                {
                    Console.WriteLine($"\nValue is higher than {middle}");
                    startingPoint = middle;
                    PopulateUpperHalf(out rangeOfNums);
                    middle = FindMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
                    Console.WriteLine("\nRange Of Num is now");
                    foreach (var item in rangeOfNums)
                    {
                        Console.Write($"{item},");
                    }
                    Console.WriteLine($"\nMiddle is {middle}");
                }
                else if (randValue < middle)
                {
                    Console.WriteLine($"\nValue is lower than {middle}");
                    highestValue = middle;
                    PopulateLowerHalf(out rangeOfNums);
                    middle = FindMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
                    Console.WriteLine("\nRange Of Num is now");
                    foreach (var item in rangeOfNums)
                    {
                        Console.Write($"{item},");
                    }
                    Console.WriteLine($"\nMiddle is {middle}");
                }
            } while (randValue != middle);
            if (randValue == middle)
            {
                Console.WriteLine($"\nComputer chose {randValue}");
                Console.WriteLine($"\nThe value searched for, {randValue}, has been found ");
                ExitGame();
            }
        }
        static void Human()
        {
            bool valid;
            bool userGuessedCorrectly;
            Console.WriteLine("\nWhat range do you want the computer to guess from?");
            Console.Write($"\n{startingPoint} through ");
            do
            {
                valid = int.TryParse(Console.ReadLine(), out highestValue);
                if (!valid)
                {
                    Console.WriteLine("\nInvalid input");
                }
                else if (highestValue <= startingPoint)
                {
                    Console.WriteLine($"\nRange must bigger than {startingPoint}");
                    valid = false;
                }
            } while (!valid);
            List<int> rangeOfNums = PopulateList(highestValue);
            int randValue = ComputerPicksRandom(rangeOfNums);
            do
            {
                Console.WriteLine("\nGuess the number");
                userGuessedCorrectly = int.TryParse(Console.ReadLine(), out int userGuess);
                if (!userGuessedCorrectly)
                {
                    Console.WriteLine("\nInvalid input");
                }
                if (userGuess < randValue)
                {
                    Console.WriteLine("\nGuess was too low");
                    userGuessedCorrectly = false;
                }
                else if (userGuess > randValue)
                {
                    Console.WriteLine("\nGuess was too high");
                    userGuessedCorrectly = false;
                }
                else if (userGuess == randValue)
                {
                    userGuessedCorrectly = true;
                    Console.WriteLine($"\nYou got it! The computer chose {randValue}");
                    ExitGame();
                }
            } while (!userGuessedCorrectly);
        }
        static void Computer()
        {
            int userGuess;
            bool valid;
            List<int> rangeOfNums = PopulateList(highestValue);
            Console.WriteLine($"\nChoose a number between {startingPoint} and {highestValue}\n");
            do
            {
                valid = int.TryParse(Console.ReadLine(), out userGuess);
                if (!valid || userGuess < startingPoint || userGuess > highestValue)
                {
                    Console.WriteLine("\nInvalid Input");
                    valid = false;
                }
            } while (!valid);
            Console.WriteLine($"\nComputer will try to guess your number");
            middle = FindMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
            do
            {
                int computerguess = middle;
                Console.WriteLine($"\nComputer guesses {computerguess}");
                Console.WriteLine("\n1: Too high , 2: Too Low , 3: Correct Answer\n");
                valid = int.TryParse(Console.ReadLine(), out int result);
                if (!valid || result < 1 || result > 3)
                {
                    Console.WriteLine("\nInvalid input");
                }
                switch (result)
                {
                    case 1:
                        highestValue = middle;
                        PopulateLowerHalf(out rangeOfNums);
                        middle = FindMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
                        valid = false;
                        break;
                    case 2:
                        startingPoint = middle;
                        PopulateUpperHalf(out rangeOfNums);
                        middle = FindMiddle(rangeOfNums[0], rangeOfNums[rangeOfNums.Count - 1]);
                        valid = false;
                        break;
                    case 3:
                        Console.WriteLine($"\nComputer successfully guessed {userGuess}");
                        ExitGame();
                        break;
                }
            } while (!valid);
        }
        static void ExitGame()
        {
            Console.WriteLine("\nThanks for stopping by!");
            Thread.Sleep(500);
            Console.WriteLine("\nPress anything to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}