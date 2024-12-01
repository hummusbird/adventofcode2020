using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace advent_5;

class Program
{
    static void Main(string[] args)
    {
        List<string> input = File.ReadAllLines("input.txt").Select(x => x.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1')).ToList();

        int highest = 0;
        List<int> passes = [];

        for (int x = 0; x < input.Count; x++)
        {
            passes.Add(x);
        }

        input.ForEach(pass =>
        {
            int row = Convert.ToInt32(pass[..7], 2);
            int column = Convert.ToInt32(pass[7..], 2);

            int id = (row * 8) + column;
            passes.Remove(id);

            if (highest < id) { highest = id; };
        });

        //Console.WriteLine(highest);

        passes.ForEach(pass =>
        {
            Console.WriteLine(pass);
        });
    }
}
