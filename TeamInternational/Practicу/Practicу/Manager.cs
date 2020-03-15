using Practicу.Models;
using Practicу.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicу
{
    class Manager
    {
        private readonly IFibonacci _fibonacci;
        private readonly IFactorial _factorial;
        private readonly Linq _linq = new Linq();
        private readonly List<Animal> _animals;

        public Manager(IFibonacci fibonacci, IFactorial factorial, List<Animal> animals)
        {
            _fibonacci = fibonacci;
            _factorial = factorial;
            _animals = animals;
        }

        public void Run()
        {
            try
            {
                Console.WriteLine("1 - Execute method fibonacci");

                Console.WriteLine("2 - Execute method factorial");

                Console.WriteLine("3 - Group animals ");

                Console.WriteLine("4 - Group numbers into even and odd");

                Console.WriteLine("5 - exit");

                int inputNumber = 0;

                while (inputNumber != 5)
                {
                    Console.WriteLine("Input one of number to execute command you want, please ");

                    bool inputData = int.TryParse(Console.ReadLine(), out inputNumber);

                    while (!inputData)
                    {
                        Console.WriteLine("Not valid");
                        Console.WriteLine("You input wrong data, please try enter number again");
                        inputData = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    while (inputNumber < 1 && inputNumber > 5)
                    {
                        Console.WriteLine("You input wrong number, please enter number again");
                        inputData = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    if (inputNumber == 1)
                    {
                        int inputFibonacciNumber = 0;

                        Console.WriteLine("Input positive number");

                        bool inputUserFibonacciNumber = int.TryParse(Console.ReadLine(), out inputFibonacciNumber);

                        while (!inputUserFibonacciNumber)
                        {
                            Console.WriteLine("Not valid");
                            Console.WriteLine("You input wrong data, please try enter number again");
                            inputUserFibonacciNumber = int.TryParse(Console.ReadLine(), out inputFibonacciNumber);
                        }

                        var fibonacciResult = _fibonacci.GetMemberFibonacci(inputFibonacciNumber);
                        Console.WriteLine("Fibonacci result is " + fibonacciResult);
                    }
                    else if (inputNumber == 2)
                    {
                        int inputFactorialNumber = 0;

                        Console.WriteLine("Input positive number");

                        bool inputUserFactorialNumber = int.TryParse(Console.ReadLine(), out inputFactorialNumber);

                        while (!inputUserFactorialNumber)
                        {
                            Console.WriteLine("Not valid");
                            Console.WriteLine("You input wrong data, please try enter number again");
                            inputUserFactorialNumber = int.TryParse(Console.ReadLine(), out inputFactorialNumber);
                        }

                        var factorialResult = _factorial.GetFactorial(inputFactorialNumber);

                        Console.WriteLine("Factorial result is " + factorialResult);
                    }
                    else if (inputNumber == 3)
                    {
                        var groupByMeal = _linq.GroupAnimalByFavouriteMeal(_animals);

                        foreach (var group in groupByMeal)
                        {
                            Console.WriteLine("Favourite meal {0} ", group.Key);

                            foreach (var animal in group)
                            {
                                Console.WriteLine("{0}", animal.Name);
                            }
                        }
                    }
                    else if (inputNumber == 4)
                    {
                        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        var divisionResult = _linq.DivideNumbersIntoEvenAndOdd(numbers);

                        foreach (var group in divisionResult)
                        {
                            Console.WriteLine("Group key {0} ", group.Key);

                            foreach (var number in group)
                            {
                                Console.WriteLine("{0}", number);
                            }
                        }
                    }
                }
            }
            catch (Exception m)
            {
                Console.WriteLine(m);
            }
        }
    }
}