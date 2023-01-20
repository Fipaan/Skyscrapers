using static Skyscrapers.Global;
using static Skyscrapers.Constants;
using static Skyscrapers.FieldArrayMethods;
using static Skyscrapers.GUI;
using Skyscrapers;

public class Program
{
    /// <summary>
    /// Request user input in range between 2 and cap
    /// </summary>
    /// <param name="cap"></param>
    /// <returns></returns>
    public static int GetSize(int cap)
    {
        int size = 0;
        while (size < 2 || size > cap)
        {
            try
            {
                Console.Write("size:");
                size = int.Parse(Console.ReadLine());
            }
            catch { Console.WriteLine("Invalid input"); continue; }
            if (size < 2)
            {
                Console.WriteLine("Invalid input. Size must be more than 2");
                continue;
            }
            else if (size > cap) { Console.WriteLine($"Invalid input. Size must be less than {cap}"); }
        }
        return size;
    }
    public static void Game(int cap = 13, types type = types.lrud)
    {
        int size = GetSize(cap);
        int[,] created = FieldArray(size, type);
        int[,] input = FieldForGame(created);
        string[]? temp;
        string? readline;
        int x, y, value;
        const string keyword = "83m^X1n8YI";
        bool isClear = false;
        bool isError = true;
        string error = inputformat;
        while (!EqualsArray(created, input))
        {
            ShowField(input, isClear, isError, error);
            if (!isClear) { isClear = true; }
            if (isError) { isError = false; }
            Console.Write("Input:");
            readline = Console.ReadLine();
            if(readline == "faq1")
            {
                error = "Input have two versions:\n1) First - up to down, second - left to right, third - number, that inserted in this position\nFor example: 5 1 3 (fifth number from up, first number from left, three inserted)\n2) First - up to down, next numbers inserted in order left to right. Count of inputs: size + 1\nExample for size = 5: 3 1 2 3 4 5 (insert in third row from up numbers from left to right 1 2 3 4 5)";
                isError = true;
                continue;
            }
            if(readline == "faq2")
            {
                error = "Each row or column contains skyscrapers of different height (from 1 to size)\nNumbers outside the grid indicate how many skyscrapers are visible from that direction";
                isError = true;
                continue;
            }
            temp = readline.Split(" ");
            if (temp[0] == keyword) { ShowArray(created); isClear = false; continue; }
            if (temp.Length == 3)
            {
                try
                {
                    x = int.Parse(temp[0]);
                    y = int.Parse(temp[1]);
                    value = int.Parse(temp[2]);
                }
                catch { error = String.Concat("Invalid input\n", inputformat); isError = true; continue; }
                try
                {
                    if(value > size)
                    {
                        error = String.Concat("Out of size\n", inputformat);
                        isError = true;
                        continue;
                    }
                    else { input[x, y] = value; }
                } catch { error = String.Concat("Out of Range\n", inputformat); isError = true; continue; }
            }
            else if (temp.Length == size + 1)
            {
                try
                {
                    x = int.Parse(temp[0]);
                    for (int j = 1; j < size + 1; j++)
                    {
                        input[x, j] = int.Parse(temp[j]);
                    }
                }
                catch { error = String.Concat("Invalid input\n", inputformat); isError = true; continue; }
            }
            else { error = String.Concat("Invalid input\n", inputformat); isError = true; continue; }
        }
        ShowField(input);
        ChangeColor(GREEN, WHITE);
        Console.Write("Congratulations!");
        ChangeColor(BLACK, WHITE);
        Console.WriteLine();
    }
    public static void Main(string[] args)
    {
        Debug.RepeatN(10, 500, types.randmin);
        //Game(cap: 30, type: types.randmin);
    }
}