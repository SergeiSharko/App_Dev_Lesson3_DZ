using System.Diagnostics.Metrics;
using System.Security;

namespace Lesson3_DZ
{
    internal class Program
    {
        //Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
        //Напишите алгоритм определяющий наличие выхода из лабиринта и выводящий на экран координаты точки выхода если таковые имеются.
        //Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте.        


        static int HasExit(int startI, int startJ, int[,] labirynth)
        {
            Stack<Tuple<int, int>> stackPath = new Stack<Tuple<int, int>>();

            if (labirynth[startI, startJ] == 0) stackPath.Push(new(startI, startJ));

            int countExit = 0;
            while (stackPath.Count > 0)
            {
                var current = stackPath.Pop();                

                if (labirynth[current.Item1, current.Item2] == 2)
                {
                    Console.WriteLine($"Путь найден по таким индексам: {current.Item1}, {current.Item2}");
                    countExit++;
                }

                labirynth[current.Item1, current.Item2] = 1;

                if (current.Item1 + 1 < labirynth.GetLength(0) && labirynth[current.Item1 + 1, current.Item2] != 1)
                {
                    stackPath.Push(new(current.Item1 + 1, current.Item2));
                }

                if (current.Item2 + 1 < labirynth.GetLength(1) && labirynth[current.Item1, current.Item2 + 1] != 1)
                {
                    stackPath.Push(new(current.Item1, current.Item2 + 1));
                }

                if (current.Item1 > 0 && labirynth[current.Item1 - 1, current.Item2] != 1)
                {
                    stackPath.Push(new(current.Item1 - 1, current.Item2));
                }

                if (current.Item2 > 0 && labirynth[current.Item1, current.Item2 - 1] != 1)
                {
                    stackPath.Push(new(current.Item1, current.Item2 - 1));
                }
            }
           
            return countExit;

        }


        static void Main(string[] args)
        {
            int[,] labirynth1 = new int[,] {
            {1, 1, 1, 2, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 2, 1, 1, 1, 0, 1 },
            {2, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 }};

            int[,] labirynth2 = new int[,] {
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }};

            var countExit = HasExit(4, 3, labirynth1);

            if (countExit == 0)
            {
                Console.WriteLine("Выходов нет!");
            }
            else
            {
                Console.WriteLine($"Количество выходов {countExit}");
            }
        }
    }
}
