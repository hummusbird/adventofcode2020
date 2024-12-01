namespace advent_3;

class Program
{
    static void Main(string[] args)
    {
        long a = Slope(1, 1);
        long b = Slope(3, 1);
        long c = Slope(5, 1);
        long d = Slope(7, 1);
        long e = Slope(1, 2);
        Console.WriteLine(a * b * c * d * e);
    }

    static int Slope(int across, int down)
    {
        List<string> row = File.ReadAllLines("input.txt").ToList();
        int x = 0;
        int trees = 0;

        for (int y = 0; y < row.Count; y += down)
        {
            char[] print = row[y].ToCharArray();

            if (row[y][x] == '#')
            {
                trees++;
                print[x] = 'X';
            }
            else { print[x] = 'O'; }

            Console.WriteLine(print);

            x += across;
            x %= row[y].Length;
        }

        return trees;
    }
}
