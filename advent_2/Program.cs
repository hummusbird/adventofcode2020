List<string> lines = File.ReadAllLines("input.txt").ToList();
int p1valid = 0;
int p2valid = 0;

foreach (string line in lines)
{
    string password = line.Split(": ")[1];
    char character = char.Parse(line.Split(": ")[0].Split(" ")[1]);
    int lower = int.Parse(line.Split(": ")[0].Split(" ")[0].Split("-")[0]);
    int upper = int.Parse(line.Split(": ")[0].Split(" ")[0].Split("-")[1]);

    // part1
    int count = password.Count(x => x == character);
    if (count >= lower && count <= upper) { p1valid++; };

    // part2
    if (password[lower - 1] == character && password[upper - 1] != character) { p2valid++; }
    if (password[lower - 1] != character && password[upper - 1] == character) { p2valid++; }
}

Console.WriteLine(p2valid);