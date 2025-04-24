using System.Collections.Generic;
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

        public static KeyValuePair<int, T>[] keyedRadixSort<T>(KeyValuePair<int, T>[] list) where T : IComparable<T>
        {
            int min = int.MaxValue;
            for(int i = 0; i < list.Length; i++)
            {
                if (list[i].Key < min)
                {
                    min = list[i].Key;
                }
            }
            int max = int.MinValue;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Key > max)
                {
                    max = list[i].Key;
                }
            }
            int radix = 10;
            int n = 0;
            KeyValuePair<int, T>[] output = new KeyValuePair<int, T>[list.Length];
            KeyValuePair<int, T>[] input = list;
            int repeatLength = (max - min).ToString().Length;
            for (int k = 0; k < repeatLength; k++)
            {
                int[] buckets = new int[radix];

                for (int i = 0; i < input.Length; i++)
                {
                    buckets[(int)((input[i].Key - min) / Math.Pow(10, n) % 10)] += 1;
                }


                for (int i = 1; i < buckets.Length; i++)
                {

                    buckets[i] = buckets[i - 1] + buckets[i];


                }


                for (int i = input.Length - 1; i >= 0; i--)
                {
                    int index = (int)((input[i].Key - min) / Math.Pow(10, n) % 10);
                    output[--buckets[index]] = input[i];
                }

                input = (KeyValuePair<int, T>[])output.Clone();
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


            KeyValuePair<int, String>[] arr2 = new KeyValuePair<int, String>[5];
            arr2[1] = new KeyValuePair<int, String>(11, "d");
            arr2[0] = new KeyValuePair<int, String>(75, "e");
            arr2[3] = new KeyValuePair<int, String>(12, "c");
            arr2[2] = new KeyValuePair<int, String>(17, "a");
            arr2[4] = new KeyValuePair<int, String>(2, "b");
            arr2 = keyedRadixSort(arr2);
            

        }
    }
}
