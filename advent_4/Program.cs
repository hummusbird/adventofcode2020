using System.Text.RegularExpressions;

namespace advent_4;

class Program
{
    static void Main(string[] args)
    {
        int valid = 0;
        List<string> passports = File.ReadAllText("input.txt").Split("\n\n").ToList();
        List<string> requirements = ["byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"];

        passports.ForEach(passport =>
        {
            // bool has = true;
            // requirements.ForEach(requirement =>
            // {
            //     if (!passport.Contains(requirement))
            //     {
            //         has = false;
            //     }
            // });
            // if (has) { valid++; }

            passport = passport.Replace("\n", " ");
            List<KeyValuePair<string, string>> data = passport.Split(" ").Select(x => { var p = x.Split(':'); return new KeyValuePair<string, string>(p[0], p[1]); }).ToList();

            bool pass = true;

            requirements.ForEach(requirement =>
            {
                KeyValuePair<string, string> kvp = data.SingleOrDefault(kvp => kvp.Key == requirement);
                if (requirement == kvp.Key)
                {
                    if (kvp.Key == "byr" && int.Parse(kvp.Value) >= 1920 && int.Parse(kvp.Value) <= 2002) { /* do nothing */ }
                    else if (kvp.Key == "iyr" && int.Parse(kvp.Value) >= 2010 && int.Parse(kvp.Value) <= 2020) { /* do nothing */ }
                    else if (kvp.Key == "eyr" && int.Parse(kvp.Value) >= 2020 && int.Parse(kvp.Value) <= 2030) { /* do nothing */ }
                    else if (kvp.Key == "hgt")
                    {
                        if (kvp.Value.Contains("cm") && int.Parse(kvp.Value.Split("c")[0]) >= 150 && int.Parse(kvp.Value.Split("c")[0]) <= 193) { /* do nothing */ }
                        else if (kvp.Value.Contains("in") && int.Parse(kvp.Value.Split("i")[0]) >= 59 && int.Parse(kvp.Value.Split("i")[0]) <= 76) { /* do nothing */ }
                        else { pass = false; }
                    }
                    else if (kvp.Key == "hcl" && kvp.Value.StartsWith('#'))
                    {
                        if (Regex.IsMatch(kvp.Value.Substring(1, 6), @"\A\b[0-9a-fA-F]+\b\Z")) {/* do nothing */ }
                        else { pass = false; }
                    }
                    else if (kvp.Key == "ecl" && (kvp.Value == "amb" || kvp.Value == "blu" || kvp.Value == "brn" || kvp.Value == "gry" || kvp.Value == "grn" || kvp.Value == "hzl" || kvp.Value == "oth")) { /* do nothing */}
                    else if (kvp.Key == "pid" && kvp.Value.Length == 9) { /* do nothing */ }
                    else { pass = false; }
                }
                else { pass = false; }
            });

            if (pass) { valid++; }
        });

        Console.WriteLine(valid);
    }
}
