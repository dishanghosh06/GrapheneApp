using System;

namespace GrapheneApp.Views
{
    public static class HeatMap
    {
        public static void Print(int[,] grid)
        {
            Console.WriteLine("\nPressure Heatmap (32×32):\n");

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    int value = grid[row, col];
                    PrintCell(value);
                }

                Console.ResetColor();
                Console.WriteLine();
            }

            Console.ResetColor();
        }

        private static void PrintCell(int value)
        {
            if (value < 5)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(".");
            }
            else if (value < 30)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("░");
            }
            else if (value < 80)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("▓");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("█");
            }
        }
    }
}
