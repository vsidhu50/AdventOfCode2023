namespace AdventOfCode2023;

public class Day4
{
    public Day4()
    {
    }

    public static int PartOne()
    {
        var lines = Utilities.GetInputLines(4);
        var score = 0;
        foreach (var line in lines)
        {
            var nums = line.Split(":")[1];
            var game = nums.Split("|");
            var winning = game[0].Trim().Split(" ").Where(x => x != "").Select(int.Parse);
            var have = game[1].Trim().Split(" ").Where(x => x != "").Select(int.Parse);

            var contains = 0;
            foreach (var num in winning)
            {
                if (have.Contains(num))
                    contains++;
            }
            if (contains > 0)
                score += (int) Math.Pow(2, contains - 1);
        }
        return score;
    }

    public static int PartTwo()
    {
        var lines = Utilities.GetInputLines(4);
        var copies = new Dictionary<int, int>();

        for (int i = 1; i <= lines.Count; i++)
        {
            copies.Add(i, 1);
        }

        var gameNum = 1;
        foreach (var line in lines)
        {
            var nums = line.Split(":")[1];
            var game = nums.Split("|");
            var winning = game[0].Trim().Split(" ").Where(x => x != "").Select(int.Parse);
            var have = game[1].Trim().Split(" ").Where(x => x != "").Select(int.Parse);

            var contains = 0;
            foreach (var num in winning)
            {
                if (have.Contains(num))
                    contains++;
            }
            if (contains > 0)
            {
                for (int i = 1; i <= contains; i++)
                {
                    copies[gameNum + i] += copies[gameNum];
                }
            }
            gameNum++;
                
        }
        return copies.Values.Sum();
    }
}

