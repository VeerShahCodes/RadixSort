using System.Drawing;
using System.Runtime.InteropServices.Marshalling;

namespace RadixSort
{
    internal class Program
    {
        public static int[] RadixSort(int[] list)
        {
            int min = list.Min<int>();
            int max = list.Max<int>();
            int radix = 10;
            int n = 0;
            int[] output = new int[list.Length];
            int[] input = list;
            int repeatLength = (max-min).ToString().Length;
            for (int k = 0; k < repeatLength; k++)
            {
                int[] buckets = new int[radix];

                for (int i = 0; i < input.Length; i++)
                {
                    buckets[(int)((input[i] - min)/ Math.Pow(10, n) %10)] += 1;
                }


                for (int i = 1; i < buckets.Length; i++)
                {

                    buckets[i] = buckets[i - 1] + buckets[i];

                    
                }


                for (int i = input.Length - 1; i >= 0; i--)
                {
                    int index = (int)((input[i] - min) / Math.Pow(10, n) % 10);
                    output[--buckets[index]] = input[i];
                }

                input = (int[])output.Clone();
                n++;
            }


            return output;
            

        }
        static void Main(string[] args)
        {
            int[] arr = new int[1000];
            Random random = new Random();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = (int)random.Next(-1000, 1000);
            }

            arr = RadixSort(arr);
            ;
        }
    }
}
