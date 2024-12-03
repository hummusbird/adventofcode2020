namespace advent_9;

class Program
{
    static void Main(string[] args)
    {
        long[] input = File.ReadAllLines("input.txt").Select(long.Parse).ToArray();

        int len = 25;
        long invalid = 0;

        for (int i = len; i < input.Length; i++)
        {
            long current = input[i];
            List<long> preamble = input[(i - len)..i].ToList();

            while (preamble.Count > 1)
            {
                long search = preamble[0];
                preamble.Remove(preamble[0]);

                if (preamble.Exists(x => x == current - search)) { break; }
            }

            if (preamble.Count == 1) { invalid = current; break; };
        }

        Console.WriteLine("Part 1: " + invalid);

        // Part 2

        for (int slicesize = 2; slicesize < input.Length; slicesize++)
        {
            for (int start = 0; start + slicesize < input.Length; start++)
            {
                if (input[start..(start + slicesize)].Sum() == invalid)
                {
                    Console.WriteLine("Part 2: " + (input[start..(start + slicesize)].Order().First() + input[start..(start + slicesize)].Order().Last()));
                    Environment.Exit(0);
                };
            }
        }
    }
}
