using System;
using System.Threading;
using static homework4.DED;

namespace homework4
{
    public enum BadWords
    {
        Макаронина,
        Жирный,
        Рыбина,
        Вонючка,
        Воришка,
        Клоп,
        Козявка
    }
    public enum GrouchinessLevels
    {
        LifeThreatening,
        Dangerous,
        Increased,
        Ordinary,
        Light
    }
    public struct DED
    {
        public string name;
        public GrouchinessLevels level;
        public string[] replics;
        public byte bruise;
        public static byte Babka(ref DED ded, params string[] array)
        {
            foreach (string replica in array)
            {
                if (BadWords.IsDefined(typeof(BadWords), replica))
                {
                    ded.bruise++;
                }
            }
            return (ded.bruise);
        }
    }
    public class Program
    {
        public static void Swap(ref int a, ref int b, params int[] array)
        {
            byte number_a = 21, number_b = 21;
            for (byte i = 0; i < array.Length; i++)
            {
                if (array[i] == a)
                {
                    number_a = i;
                }
                if (array[i] == b)
                {
                    number_b = i;
                }
            }
            if (number_a > 20 || number_b > 20)
            {
                throw new IndexOutOfRangeException("Один или оба введённых элемента не принадлежат массиву.\n");
            }
            else
            {
                int k = array[number_a];
                array[number_a] = array[number_b];
                array[number_b] = k;
            }
            Console.WriteLine("Получившийся массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
        public static double ArrayDo(ref long product, out double average, params int[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                product = product * array[i];
            }
            average = sum / array.Length;
            return (sum);
        }
        public static void Third(string str)
        {
            int number;
            bool flag = Int32.TryParse(str, out number);
            if (!flag)
            {
                throw new FormatException("Введённые данные имеют неверный формат.\n");
            }
            else
            {
                switch (str)
                {
                    case "1": Console.WriteLine("  #\n  #\n  #\n  #\n  #"); break;
                    case "2": Console.WriteLine("###\n  #\n###\n#\n###"); break;
                    case "3": Console.WriteLine("###\n  #\n###\n  #\n###"); break;
                    case "4": Console.WriteLine("# #\n# #\n###\n  #\n  #"); break;
                    case "5": Console.WriteLine("###\n#\n###\n  #\n###"); break;
                    case "6": Console.WriteLine("###\n#\n###\n# #\n###"); break;
                    case "7": Console.WriteLine("###\n  #\n #\n#"); break;
                    case "8": Console.WriteLine("###\n# #\n###\n# #\n###"); break;
                    case "9": Console.WriteLine("###\n# #\n###\n  #\n###"); break;
                    case "0": Console.WriteLine("###\n# #\n# #\n# #\n###"); break;
                    default: Console.BackgroundColor = ConsoleColor.Red; Console.WriteLine("красный"); Thread.Sleep(3000); Console.ResetColor(); break;
                }
            }
        }
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Задание 1:\nМассив случайных чисел: ");
                int[] numbers = new int[20];
                Random n = new Random();
                for (int i = 0; i < 20; i++)
                {
                    numbers[i] = n.Next(200);
                    Console.Write($"{numbers[i]} ");
                }
                Console.WriteLine("");
                bool flag;
                int first;
                do
                {
                    Console.Write("Введите первый элемент (потом Enter): ");
                    flag = Int32.TryParse(Console.ReadLine(), out first);
                } while (!flag);
                int second;
                do
                {
                    Console.Write("Введите второй элемент (потом Enter): ");
                    flag = Int32.TryParse(Console.ReadLine(), out second);
                } while (!flag);
                try
                {
                    Swap(ref first, ref second, numbers);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }

            Console.WriteLine("");

            {
                Console.WriteLine("Задание 2:");
                int[] numbers = new int[10];
                Random n = new Random();
                for (int i = 0; i < 10; i++)
                {
                    numbers[i] = n.Next(50);
                    Console.Write($"{numbers[i]} ");
                }
                long product = 1;
                double average = 0;
                Console.WriteLine($"\nСумма элементов = {ArrayDo(ref product, out average, numbers)}\nПроизведение = {product}\nСреднее арифметическое = {average}");
            }

            Console.WriteLine("");
            
            {
                Console.WriteLine("Задание 3:");
                bool flag = false;
                do
                {
                    Console.Write("Введите число от 0 до 9 (потом Enter): ");
                    string input = Console.ReadLine();
                    if (input == "закрыть" || input == "exit")
                    {
                        Console.WriteLine("Пока! Хорошего дня!!");
                        break;
                    }
                    else
                    {
                        try
                        {
                            Third(input);
                        }
                        catch (FormatException ex)
                        {
                            Console.Write($"Ошибка: {ex.Message}");
                        }
                    }
                } while (!flag);
            }

            Console.WriteLine("");

            {
                Console.WriteLine("Задание 4:");
                DED ded1 = new DED();
                ded1.name = "Васильич";
                ded1.level = GrouchinessLevels.Light;
                ded1.replics = new string[5] { "Гад", "Жирный", "Макаронина", "Казнокрад", "Воришка" };
                ded1.bruise = 0;
                Console.WriteLine($"Синяков у первого деда: {Babka(ref ded1, ded1.replics)}");

                DED ded2 = new DED();
                ded2.name = "Кузьмич";
                ded2.level = GrouchinessLevels.Ordinary;
                ded2.replics = new string[6] { "Алкоголик", "Рыбина", "Гад", "Клоп", "Таракан", "Грубиян" };
                ded2.bruise = 0;
                Console.WriteLine($"Синяков у второго деда: {Babka(ref ded2, ded2.replics)}");

                DED ded3 = new DED();
                ded3.name = "Дмитрич";
                ded3.level = GrouchinessLevels.Increased;
                ded3.replics = new string[7] { "Козявка", "Гад", "Рыбина", "Жирный", "Школота", "Козёл", "Сморчок" };
                ded3.bruise = 0;
                Console.WriteLine($"Синяков у третьего деда: {Babka(ref ded3, ded3.replics)}");

                DED ded4 = new DED();
                ded4.name = "Николаич";
                ded4.level = GrouchinessLevels.Dangerous;
                ded4.replics = new string[8] { "Гад", "Клоп", "Козявка", "Грубиян", "Жирдяй", "Жердяй", "Юлейка", "Макаронина" };
                ded4.bruise = 0;
                Console.WriteLine($"Синяков у четвёртого деда: {Babka(ref ded4, ded4.replics)}");

                DED ded5 = new DED();
                ded5.name = "Петрович";
                ded5.level = GrouchinessLevels.LifeThreatening;
                ded5.replics = new string[9] { "Макаронина", "Жирный", "Рыбина", "Вонючка", "Воришка", "Клоп", "Козявка", "Гад", "Саботажник" };
                ded5.bruise = 0;
                Console.WriteLine($"Синяков у пятого деда: {Babka(ref ded5, ded5.replics)}");
            }

            Console.WriteLine("");

        }
    }
}