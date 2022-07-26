using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22._07._22
{
    class Array
    {
        public static void Print(int[] _args)
        {
            for (int i = 0; i < _args.Length; i++)
            {
                Console.Write(_args[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        public static void Print(string[] _args)
        {
            for (int i = 0; i < _args.Length; i++)
            {
                Console.Write(_args[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        public static void mySort(int[] _args)
        {
            for (int i = 0; i < _args.Length; i++)
            {
                for (int j = 0; j < _args.Length - 1; j++)
                {
                    if (_args[j] > _args[j + 1])
                    {
                        int tmp = _args[j];
                        _args[j] = _args[j + 1];
                        _args[j + 1] = tmp;
                    }
                }
            }
            Array.Print(_args);
        }
        public static void mySort(string[] _args)
        {
            int[] _intArgs = new int[_args.Length];
            for (int i = 0; i < _args.Length; i++)
            {
                _intArgs[i] = int.Parse(_args[i]);
            }
            for (int i = 0; i < _intArgs.Length; i++)
            {
                for (int j = 0; j < _intArgs.Length - 1; j++)
                {
                    if (_intArgs[j] > _intArgs[j + 1])
                    {
                        int tmp = _intArgs[j];
                        _intArgs[j] = _intArgs[j + 1];
                        _intArgs[j + 1] = tmp;
                    }
                }
            }
            Array.Print(_intArgs);
        }
        public static void FindEven(string[] _args)
        {
            int[] _intArgs = new int[_args.Length];
            for (int i = 0; i < _args.Length; i++)
            {
                _intArgs[i] = int.Parse(_args[i]);
            }
            for (int i = 0; i < _intArgs.Length; i++)
            {
                if (_intArgs[i] % 2 == 0)
                {
                    Console.Write(_intArgs[i]);
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }

    }
    class CommandLine
    {
        public static int[] Numbers;
        public static int[] GetNumbers()
        {

            return Numbers;
        }
        public static void AddNumbers(int _number, int index)
        {
            Numbers[index] = _number;
        }
        public static void DetectedNumbers(string[] _args)
        {
            try
            {
                OutputOfNumbers(_args);
                OutputOfNewNumbers(_args);
                Console.Write("Полученный массив: ");
                Array.Print(_args);
                Console.WriteLine();
                Console.Write("Сортированный массив: ");
                Array.mySort(_args);
                Console.WriteLine();
                Console.Write("Четные числа массива: ");
                Array.FindEven(_args);
            }
            catch
            {
                Console.WriteLine("Программа требует ввода аргументов командной строки.");
            }
        }
        static void OutputOfNumbers(string[] _args)
        {
            bool IsInputNeed = true;
            for (int i = 0; i < _args.Length; i++)
            {
                Console.Write("Аргумент {1}: {0}", _args[i], i);
                Converter.Convert2Int(_args[i], out int _Number, out bool _success);
                if (_success)
                {
                    Console.Write(" - это число {0}", _Number);
                }
                else
                {
                    Converter.Convert2Int(_args[i], IsInputNeed, out _Number);
                    _args[i] = _Number.ToString();
                    AddNumbers(_Number, i);
                    Console.Write("Получили число - {0}", _Number);
                }
                Console.WriteLine();
            }
        }
        static void OutputOfNewNumbers(string[] _args)
        {
            foreach (var item in _args)
            {
                Console.WriteLine("Получено число {0}", item);
            }
        }
    }
    class Converter
    {
        public static void Convert2Int(string _input, out int res, out bool _success)
        {
            try
            {
                res = int.Parse(_input);
                _success = true;
            }
            catch
            {
                res = 0;
                _success = false;
            }
        }
        public static void Convert2Int(string _input, bool IsInputNeed, out int res)
        {
            bool IsConverted = false;
            if (IsInputNeed)
            {
                try
                {
                    res = int.Parse(_input);
                }
                catch
                {
                    do
                    {
                        try
                        {
                            res = int.Parse(Console.ReadLine());
                            IsConverted = true;
                        }
                        catch
                        {
                            Console.WriteLine("Введено не число, повторите ввод...");
                            res = 0;
                        }
                    } while (!IsConverted);
                }
            }
            else
            {
                Convert2Int(_input, out res, out bool _success);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            try
            {
                string[] _args = new string[args.Length];
                int[] _intArgs = new int[args.Length];
                for (int i = 0; i < args.Length; i++)
                {
                    _args[i] = args[i]; 
                }
                CommandLine.DetectedNumbers(_args);
                _intArgs = CommandLine.GetNumbers();
                
            }
            catch
            {
                Console.WriteLine("Программа требует ввода аргументов командной строки.");
            }
        }
    }
}
