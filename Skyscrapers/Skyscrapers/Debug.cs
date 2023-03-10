using static Skyscrapers.FieldArrayMethods;
using static Skyscrapers.Constants;
using static Skyscrapers.Global;

namespace Skyscrapers
{
    public class Debug
    {
        public static long Debugging(int size, types type)
        {
            long starttime = DateTime.Now.Ticks;
            int[,] output = new int[0, 0];
            switch (type)
            {
                case types.lrud:
                    do
                    {
                        output = FieldArrayLRUD(size);
                    } while (DetectInArray(output, -1));
                    break;
                case types.randmin:
                    do
                    {
                        output = FieldArrayRandMin(size);
                    } while (DetectInArray(output, 0));
                    break;
                default:
                    break;
            }
            long endtime = DateTime.Now.Ticks;
            long delta = endtime - starttime;
            //Console.WriteLine($"Field generated by type {type} with size {size} in time {delta}");
            //Console.Write("Done! ");
            return delta;
        }
        public static void toN(int n, types type)
        {
            for(int i = 3; i < n; i++)
            {
                FieldArray(i, type, true);
            }
        }
        public static void RepeatN(int n, int count, types type)
        {
            long delta;
            long averagedelta = 0;
            for (int i = 0; i < count; i++)
            {
                delta = Debugging(n, type);
                averagedelta = (averagedelta * i + delta) / (i + 1);
            }
            //Console.WriteLine();
            Console.WriteLine($"Average time: {averagedelta}");
        }
    }
}
