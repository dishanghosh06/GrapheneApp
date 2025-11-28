namespace GrapheneApp.Services
{
    public static class DataAnalyzer
    {
        public static int CalculatePeakPressure(int[,] grid)
        {
            int max = 0;
            foreach (int value in grid)
            {
                if (value > max)
                    max = value;
            }
            return max;
        }

        public static double CalculateContactArea(int[,] grid, int threshold = 5)
        {
            int activePixels = 0;

            foreach (int value in grid)
            {
                if (value >= threshold)
                    activePixels++;
            }

            return (activePixels / 1024.0) * 100;
        }
    }
}
