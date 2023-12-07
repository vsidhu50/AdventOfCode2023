namespace AdventOfCode2023;

public class Day6
{
    public Day6()
    {
    }

    public static int PartOne() {
        var lines = Utilities.GetInputLines(6);
        var times = Utilities.GetNums(lines[0].Split(":")[1]);
        var distances = Utilities.GetNums(lines[1].Split(":")[1]);
        var product = 1;

        for (int i = 0; i < times.Count; i++)
        {
            var count = 0;
            var record = distances[i];
            var time = times[i];
            for (int j = 0; j <= time; j++)
            {
                var distance = j * (time - j);
                if (distance > record)
                    count++;
            }
            if (count != 0)
                product *= count;
        }
        return product;
    }

    public static long PartTwo()
    {
        // used quadratic formula to solve for 0 = time * x - x^2 - record
        long x = 47566339;
        long x2 = 8433454;
        long time = 55999793;
        long record = 401148522741405;
        long distance = time * x - x * x;
        long distance2 = time * x2 - x2 * x2;
        Console.WriteLine(distance > record);
        Console.WriteLine(distance2 > record);
        return x - x2 + 1;
    }
}

