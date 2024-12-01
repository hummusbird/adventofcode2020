namespace advent_7;

class Program
{
    static void Main(string[] args)
    {
        List<string> rules = File.ReadAllLines("input.txt").ToList();
        List<Bag> bags = [];

        rules.ForEach(rule =>
        {
            string contents = rule.Split("bags contain ")[1];

            contents = contents.Replace(".", "");
            contents = contents.Replace("bags", "");
            contents = contents.Replace("bag", "").Trim();

            bags.Add(new Bag()
            {
                colour = rule.Split(" bags contain")[0],
                bags = contents.Split(",").Select(x => string.Join(" ", x.Trim().Split(" ").Skip(1))).ToList()
            });
        });

        int c = 0;
        bags.ForEach(bag =>
        {
            if (recurse(bags, bag, "shiny gold")) { c++; }
        });

        Console.WriteLine(c);
    }

    static bool recurse(List<Bag> bags, Bag outer, string findbag)
    {
        if (outer.bags.Contains(findbag)) { return true; }
        foreach (string innerbag in outer.bags)
        {
            Bag inner = bags.Find(x => x.colour == innerbag);
            if (inner == null)
            {
                continue;
            }
            if (recurse(bags, inner, findbag))
            {
                return true;
            }
        }
        return false;
    }

    public class Bag()
    {
        public string colour = "";
        public List<string> bags;
    }
}
