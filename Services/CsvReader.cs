using System.IO;

namespace GrapheneApp.Services
{
    public static class CsvReader
    {
        public static int[,] ReadPressureData(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int[,] grid = new int[32, 32];

            for (int i = 0; i < 32; i++)
            {
                string[] values = lines[i].Split(',');
                for (int j = 0; j < 32; j++)
                {
                    grid[i, j] = int.Parse(values[j]);
                }
            }

            return grid;
        }
    }
}
