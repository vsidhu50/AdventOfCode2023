using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day2
{
    public Day2()
    {
    }

    public static int PartOne()
    {
        var sum = 0;
        var RED = 12;
        var GREEN = 13;
        var BLUE = 14;
        var id = 1;
        var games = Utilities.GetInputLines(2);

        foreach (var line in games)
        {
            var game = line.Split(":")[1];
            var sets = game.Split(";");
            var isPossible = true;

            foreach (var set in sets)
            {
                var redRegex = new Regex(".* (\\d+) red.*");
                var match = redRegex.Match(set);
                var red = match.Success ? int.Parse(match.Groups[1].Value) : 0;
                var greenRegex = new Regex(".* (\\d+) green.*");
                match = greenRegex.Match(set);
                var green = match.Success ? int.Parse(match.Groups[1].Value) : 0;
                var blueRegex = new Regex(".* (\\d+) blue.*");
                match = blueRegex.Match(set);
                var blue = match.Success ? int.Parse(match.Groups[1].Value) : 0;

                isPossible = isPossible && red <= RED && green <= GREEN && blue <= BLUE;
            }

            if (isPossible)
                sum += id;
            id++;
        }
        return sum;
    }

    public static int PartTwo()
    {
        var sum = 0;
        
        var games = Utilities.GetInputLines(2);

        foreach (var line in games)
        {
            var game = line.Split(":")[1];
            var sets = game.Split(";");
            var RED = 0;
            var GREEN = 0;
            var BLUE = 0;

            foreach (var set in sets)
            {
                var redRegex = new Regex(".* (\\d+) red.*");
                var match = redRegex.Match(set);
                var red = match.Success ? int.Parse(match.Groups[1].Value) : 0;
                var greenRegex = new Regex(".* (\\d+) green.*");
                match = greenRegex.Match(set);
                var green = match.Success ? int.Parse(match.Groups[1].Value) : 0;
                var blueRegex = new Regex(".* (\\d+) blue.*");
                match = blueRegex.Match(set);
                var blue = match.Success ? int.Parse(match.Groups[1].Value) : 0;

                if (red > RED)
                    RED = red;
                if (green > GREEN)
                    GREEN = green;
                if (blue > BLUE)
                    BLUE = blue;
            }

            sum += (RED * GREEN * BLUE);
        }
        return sum;
    }
}

