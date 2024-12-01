using System.Runtime.InteropServices.Marshalling;

namespace advent_6;

class Program
{
    static void Main(string[] args)
    {
        List<string> groups = File.ReadAllText("input.txt").Split("\n\n").ToList();

        int count = 0;

        // groups.ForEach(text => { count += text.Replace("\n", "").Distinct().Count(); });

        groups.ForEach(group =>
        {
            List<string> people = group.Split("\n").ToList();

            string questions = people[0];

            people.ForEach(person =>
            {
                questions = string.Join("", person.Intersect(questions));
            });

            count += questions.Count();
        });

        Console.WriteLine(count);
    }
}
