List<int> expenses = File.ReadAllLines("input.txt").Select(int.Parse).ToList();

foreach (int expense in expenses)
{
    // advent_1
    // if (expenses.Contains(2020 - expense))
    // {
    //     Console.WriteLine(expense * (2020 - expense));
    //     Environment.Exit(0);
    // };

    int remain = 2020 - expense;
    foreach (int x in expenses)
    {
        if (expenses.Contains(remain - x))
        {
            Console.WriteLine($"{expense} {x} {remain - x}");
            Console.WriteLine(expense * x * (remain - x));
            Environment.Exit(0);
        }
    }
}