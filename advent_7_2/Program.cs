namespace advent_7_2;

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

            List<KeyValuePair<string, int>> bagslist = [];

            contents.Split(",").Select(x => x.Trim()).ToList().ForEach(x =>
            {
                if (x.Contains("no")) { return; }
                bagslist.Add(new KeyValuePair<string, int>(string.Join(" ", x.Split(" ").Skip(1)), int.Parse(x.Split(" ")[0])));
            });

            bags.Add(new Bag()
            {
                colour = rule.Split(" bags contain")[0],
                bags = bagslist
            });
        });

        long c = recurse(bags, bags.Find(x => x.colour == "shiny gold"));

        Console.WriteLine(c);
    }

    static long recurse(List<Bag> bags, Bag outer)
    {
        long c = 0;
        if (outer.bags.Count == 0) { return c; }

        foreach (KeyValuePair<string, int> content in outer.bags)
        {
            c += content.Value;
            Bag innerbag = bags.Find(x => x.colour == content.Key);

            c += recurse(bags, innerbag) * content.Value;
        }

        return c;
    }

    public class Bag()
    {
        public string colour = "";
        public List<KeyValuePair<string, int>> bags;
    }
}
