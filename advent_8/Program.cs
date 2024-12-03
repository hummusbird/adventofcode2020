namespace advent_8;

class Program
{
    static void Main(string[] args)
    {
        List<KeyValuePair<string, int>> instructions = File.ReadAllLines("input.txt").Select(x => { var p = x.Split(" "); return new KeyValuePair<string, int>(p[0], int.Parse(p[1])); }).ToList();

        // Part 1

        int p1acc = 0;
        List<int> p1indexes = [];

        for (int i = 0; true; i++)
        {
            if (p1indexes.Contains(i)) { break; }
            p1indexes.Add(i);

            switch (instructions[i].Key)
            {
                case "nop":
                    break;

                case "acc":
                    p1acc += instructions[i].Value;
                    break;

                case "jmp":
                    i += instructions[i].Value - 1;
                    break;
            }
        }

        Console.WriteLine("Part 1: " + p1acc);

        // Part 2

        int p2acc = 0;
        int swapped = 0;
        bool running = true;

        while (running)
        {
            p2acc = 0;
            List<int> p2indexes = [];
            List<KeyValuePair<string, int>> instr = instructions.ToList();

            int index = instr.IndexOf(instr.Where(x => x.Key == "nop" || x.Key == "jmp").Skip(swapped).FirstOrDefault());
            instr[index] = instr[index].Key == "jmp" ? new KeyValuePair<string, int>("nop", instr[index].Value) : new KeyValuePair<string, int>("jmp", instr[index].Value);

            for (int j = 0; true; j++)
            {
                if (j >= instr.Count()) { running = false; break; }
                if (p2indexes.Contains(j)) { break; }
                p2indexes.Add(j);

                switch (instr[j].Key)
                {
                    case "nop":
                        break;

                    case "acc":
                        p2acc += instr[j].Value;
                        break;

                    case "jmp":
                        j += instr[j].Value - 1;
                        break;
                }
            }

            swapped++;
        }

        Console.WriteLine("Part 2: " + p2acc);
    }
}
