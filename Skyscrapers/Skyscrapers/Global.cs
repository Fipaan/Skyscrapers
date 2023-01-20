using System.Diagnostics.Metrics;

namespace Skyscrapers
{
    public class Global
    {
        public static Random random = new Random();
        /// <summary>
        /// Generate one-dimensional array with random mismatched numbers
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static int[] RandomNumbers(int size)
        {
            int temp;
            int[] numbers = new int[size];
            int[] output = new int[size];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = i + 1;
            }
            for (int i = 0; i < size; i++)
            {
                temp = random.Next(size - i);
                output[i] = numbers[temp];
                numbers[temp] = numbers[^(i + 1)];
            }
            return output;
        }
        /// <summary>
        /// Get random number in range max, exclude exceptions
        /// </summary>
        /// <param name="max"></param>
        /// <param name="exceptions"></param>
        /// <returns></returns>
        public static int RandomNumber(int max, int[] exceptions)
        {
            int[] nums = RandomNumbers(max);
            bool temp = true;
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < exceptions.Length; j++)
                {
                    if (nums[i] == exceptions[j])
                    {
                        temp = false;
                    }
                }
                if (temp)
                {
                    return nums[i];
                }
                temp = true;
            }
            return -1;
        }
        /// <summary>
        /// Detect element in one-dimensional array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool DetectInArray<T>(T[] array, T element)
        {
            foreach (T value in array) { if (Equals(element, value)) { return true; } }
            return false;
        }
        /// <summary>
        /// Detect element in two-dimensional array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool DetectInArray<T>(T[,] array, T element)
        {
            foreach (T value in array) { if (Equals(element, value)) { return true; } }
            return false;
        }
        /// <summary>
        /// Delete all zero, and repeatable numbers
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] RemainMismatched(int[] array)
        {
            int size = array.Length;
            int[] output = new int[size];
            int counter = 0;
            bool isMismatched = true;
            for(int i = 0; i < size; i++)
            {
                if (array[i] == 0) { continue; }
                for(int j = 0; j < counter && isMismatched; j++)
                {
                    if (output[j] == array[i])
                    {
                        isMismatched = false;
                    }
                }
                if (isMismatched) { output[counter] = array[i]; counter++; }
                isMismatched = true;
            }
            int[] resizeOutput = new int[counter];
            for(int i = 0; i < counter; i++)
            {
                resizeOutput[i] = output[i];
            }
            return resizeOutput;
        }
        /// <summary>
        /// Return one-dimensional array with mismatched numbers by plus in position [I, J]
        /// </summary>
        /// <param name="array"></param>
        /// <param name="I"></param>
        /// <param name="J"></param>
        /// <returns></returns>
        public static int[] Exceptions(int[,] array, int I, int J)
        {
            int capX = array.GetLength(0);
            int capY = array.GetLength(0);
            int[] numbers = new int[capX + capY];
            for (int i = 0; i < capX; i++)
            {
                numbers[i] = array[i, J];
            }
            for (int j = 0; j < capY; j++)
            {
                numbers[capX + j] = array[I, j];
            }
            int[] exceptions = RemainMismatched(numbers);
            return exceptions;
        }
        /// <summary>
        /// Return one-dimensional array with numbers, that can be in position [I, J]
        /// </summary>
        /// <param name="array"></param>
        /// <param name="I"></param>
        /// <param name="J"></param>
        /// <returns></returns>
        public static int[] Inclusions(int[,] array, int I, int J)
        {
            int size = array.GetLength(0);
            if (array[I, J] != 0) { return new int[size + 1]; }
            int[] exceptons = Exceptions(array, I, J);
            int[] inclusions = new int[size - exceptons.Length];
            if (inclusions.Length == 0) { return inclusions; }
            bool isEquals = false;
            int counter = 0;
            for(int i = 1; i < size + 1; i++)
            {
                for(int j = 0; j < exceptons.Length; j++)
                {
                    if(i == exceptons[j])
                    {
                        isEquals = true;
                    }
                }
                if(!isEquals) { inclusions[counter] = i; counter++; }
                isEquals = false;
            }
            return inclusions;
        }
        /// <summary>
        /// If generated field equals input return true, else return false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="generated"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool EqualsArray<T>(T[,] generated, T[,] input)
        {
            int sizeX = generated.GetLength(0);
            int sizeY = generated.GetLength(1);
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    if (!Equals(generated[i, j], input[i + 1, j + 1])) { return false; }
                }
            }
            return true;
        }
        public static int CountInArray<T>(T[,] array, T value)
        {
            int counter = 0;
            foreach(T item in array) { if (Equals(item, value)) { counter++; } }
            return counter;
        }
        public static int CountInArray<T>(T[] array, T value)
        {
            int counter = 0;
            foreach (T item in array) { if (Equals(item, value)) { counter++; } }
            return counter;
        }
        public static T[] GetRow<T>(T[,] array, int index)
        {
            int size = array.GetLength(1);
            T[] output = new T[size];
            for(int i = 0; i < size; i++)
            {
                output[i] = array[index, i];
            }
            return output;
        }
        public static T[] GetColumn<T>(T[,] array, int index)
        {
            int size = array.GetLength(1);
            T[] output = new T[size];
            for (int i = 0; i < size; i++)
            {
                output[i] = array[i, index];
            }
            return output;
        }
    }    
}