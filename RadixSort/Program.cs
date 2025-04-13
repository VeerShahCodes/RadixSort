namespace RadixSort
{
    internal class Program
    {
        public static void RadixSort(uint[] list)
        {
            //uint min = list.Min<uint>();
            uint max = list.Max<uint>();
            uint radix = 10;
            int[] buckets = new int[radix];
            int n = 0;
            //count digits
            for(int i = 0; i < )//figure out how many digits in number so u can loop ther adix sojsorijseopirj
            for(int i = 0; i < list.Length; i++)
            {
                buckets[(int)(list[i] / Math.Pow(10, n) % Math.Pow(10, n + 1))] += 1;
            }
            //offset
            for(int i = 1; i < buckets.Length; i++)
            {
                buckets[i] = buckets[i - 1] + buckets[i];
            }
            //output
            uint[] output = new uint[list.Length];
            for(int i = list.Length - 1; i > -1; i--)
            {
                uint index = (uint)(list[i] / Math.Pow(10, n) % Math.Pow(10, n + 1))
                output[--buckets[index]] = list[i];
            }
            //n digit = (num / 10^n) % 10^(n+1)



            ;

        }
        static void Main(string[] args)
        {
            uint[] arr = new uint[5];
            Random random = new Random();
            for(int i = 0; i < 5; i++)
            {
                arr[i] = (uint)random.Next(10);
            }
            RadixSort(arr);
        }
    }
}
