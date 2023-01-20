using static Skyscrapers.Constants;

namespace Skyscrapers
{
    public class GUI
    {
        public static void ShowArray<T>(T[] array)
        {
            try { Console.Write(array[0]); } catch { return; }
            for (int i = 1; i < array.Length; i++) { Console.Write(String.Concat(" ", array[i])); }
            Console.WriteLine();
        }
        public static void ShowArray<T>(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                try { Console.Write(array[i, 0]); } catch { return; }
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    Console.Write(String.Concat(" ", array[i, j]));
                }
                Console.WriteLine();
            }
        }
        public static void ChangeColor(ConsoleColor backgroundcolor = ConsoleColor.Black, ConsoleColor foregroundcolor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundcolor;
            Console.ForegroundColor = foregroundcolor;
            return;
        }
        public static void ShowField(int[,] array, bool isClear = true, bool isError = false, string error = inputformat)
        {

            if (isClear) { Console.Clear(); }
            if (isError) { Console.WriteLine(error); }
            int capX = array.GetLength(0);
            int capY = array.GetLength(1);
            ChangeColor(YELLOW, BLACK);
            Console.Write("  ");
            for (int j = 1; j < capY - 1; j++)
            {
                Console.Write(String.Concat(array[0, j], " "));
            }
            Console.Write(" ");
            ChangeColor(BLACK, WHITE);
            Console.WriteLine();
            for (int i = 1; i < capX - 1; i++)
            {
                ChangeColor(YELLOW, BLACK);
                Console.Write(String.Concat(array[i, 0], " "));
                ChangeColor(BLACK, WHITE);
                for (int j = 1; j < capY - 2; j++)
                {
                    Console.Write(String.Concat(array[i, j], " "));
                }
                Console.Write(array[i, capY - 2]);
                ChangeColor(YELLOW, BLACK);
                Console.Write(String.Concat(" ", array[i, capY - 1]));
                ChangeColor(BLACK, WHITE);
                Console.WriteLine();
            }
            ChangeColor(YELLOW, BLACK);
            Console.Write("  ");
            for (int j = 1; j < capY - 1; j++)
            {
                Console.Write(String.Concat(array[capX - 1, j], " "));
            }
            Console.Write(" ");
            ChangeColor(BLACK, WHITE);
            Console.WriteLine();
            return;
        }
    }
}
