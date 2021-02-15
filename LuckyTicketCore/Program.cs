using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;


namespace LuckyTicketCore
{
    class Program
    {
        static void Main()
        {
            ConsoleKeyInfo mainkey;
            WriteLine("Для старта нажмите клавишу...");
            mainkey = ReadKey();



            while (true)
            {
                Clear();
                WriteLine("Введите номер билета:");
                ConsoleKeyInfo key;
                var rule = @"[0-9]";
                var sb = new StringBuilder();

                while (true)
                {
                    key = ReadKey(true);
                    if (sb.Length > 4)
                    {
                        if (key.Key == ConsoleKey.Enter) break;
                    }

                    if (Regex.IsMatch(key.KeyChar.ToString(), rule))
                    {
                        sb.Append(key.KeyChar);
                        Write(key.KeyChar);
                        if (sb.Length == 8) break;
                    }
                }

                if (sb.Length % 2 == 1) sb.Insert(0, "0");

                int[] array = new int[sb.Length];
                string array_str = sb.ToString();
                for (int i = 0; i < sb.Length; i++)
                {
                    array[i] = Int32.Parse(array_str[i].ToString());
                }

                WriteLine();

                int sum1 = 0, sum2 = 0;

                for (int i = 0; i < array.Length / 2; i++)
                {
                    if (i != (array.Length / 2) - 1)
                    {
                        sum1 += array[i];
                        Write(array[i] + " + ");
                    }
                    else
                    {
                        sum1 += array[i];
                        Write(array[i] + " = ");
                        WriteLine(sum1);
                    }
                }

                for (int i = array.Length / 2; i < array.Length; i++)
                {
                    if (i != array.Length - 1)
                    {
                        sum2 += array[i];
                        Write(array[i] + " + ");
                    }
                    else
                    {
                        sum2 += array[i];
                        Write(array[i] + " = ");
                        WriteLine(sum2);
                    }
                }

                if (sum1 == sum2)
                {
                    WriteLine("Поздравляю! Билетик счастливый!");
                }
                else
                {
                    WriteLine("Увы, билетик не счастливый!");
                }
                WriteLine("Для выхода нажмите Escape, для продолженния любую клавишу...");
                mainkey = ReadKey();
                if (mainkey.Key == ConsoleKey.Escape) break;
            }
        }
    }
    }

