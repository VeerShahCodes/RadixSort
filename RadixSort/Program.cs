using System.Drawing;
using System.Runtime.InteropServices.Marshalling;

namespace RadixSort
{
    internal class Program
    {
        public static uint[] RadixSort(uint[] list)
        {
            uint max = list.Max<uint>();
            uint radix = 10;
            int n = 0;
            Console.WriteLine(max.ToString().Length);
            uint[] output = new uint[list.Length];
            uint[] input = list;
            for (int k = 0; k < max.ToString().Length; k++)
            {
                int[] buckets = new int[radix];

                for (int i = 0; i < input.Length; i++)
                {
                    buckets[(int)(input[i] / Math.Pow(10, n) %10)] += 1;
                }


                for (int i = 1; i < buckets.Length; i++)
                {

                    buckets[i] = buckets[i - 1] + buckets[i];

                    
                }


                for (int i = input.Length - 1; i >= 0; i--)
                {
                    uint index = (uint)(input[i] / Math.Pow(10, n) % 10);
                    output[--buckets[index]] = input[i];
                }

                input = (uint[])output.Clone();
                n++;
            }


            return output;
            

        }
        static void Main(string[] args)
        {
            uint[] arr = new uint[1000];
            Random random = new Random();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = (uint)random.Next(1000);
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            arr = RadixSort(arr);
            ;
        }
    }
}
