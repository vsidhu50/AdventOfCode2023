namespace AdventOfCode2023;


public class Day8
{
    public Day8()
    {
    }

    public static int PartOne()
    {
        var paragraphs = Utilities.GetInputParagraphs(8);
        var instructions = paragraphs[0];
        var lines = Utilities.GetLines(paragraphs[1]);
        var nodes = new Dictionary<string, (string left, string right)>();

        foreach (var line in lines)
        {
            var newLine = line.Replace("(", "").Replace(")", "").Replace(" ", "").Split("=");
            var node = newLine[0];
            var left = newLine[1].Split(",")[0];
            var right = newLine[1].Split(",")[1];
            nodes.Add(node, (left, right));
        }

        var count = 0;

        var curr = "AAA";
        while (curr != "ZZZ")
        {
            var direction = instructions[count % instructions.Length];
            if (direction == 'L')
            {
                curr = nodes[curr].left;
            }
            else
            {
                curr = nodes[curr].right;
            }
            count++;
        }
        return count;
    }

    public static long PartTwo()
    {
        var paragraphs = Utilities.GetInputParagraphs(8);
        var instructions = paragraphs[0];
        var lines = Utilities.GetLines(paragraphs[1]);
        var nodes = new Dictionary<string, (string left, string right)>();
        var startingNodes = new List<string>();
        var allZ = new List<(int distance, bool reached)>();

        foreach (var line in lines)
        {
            var newLine = line.Replace("(", "").Replace(")", "").Replace(" ", "").Split("=");
            var node = newLine[0];
            var left = newLine[1].Split(",")[0];
            var right = newLine[1].Split(",")[1];
            nodes.Add(node, (left, right));
            if (node[2] == 'A')
            {
                startingNodes.Add(node);
                allZ.Add((0, false));
            }
        }

        var count = 0;

        var currNodes = startingNodes;
        while (!allZ.All(x => x.reached))
        {
            var direction = instructions[count % instructions.Length];
            for (int i = 0; i < currNodes.Count; i++)
            {
                if (direction == 'L')
                {
                    currNodes[i] = nodes[currNodes[i]].left;
                }
                else
                {
                    currNodes[i] = nodes[currNodes[i]].right;
                }
                if (!allZ[i].reached && currNodes[i][2] == 'Z')
                {
                    allZ[i] = (count + 1, true);
                }
            }
            
            count++;
        }
        long product = 1;
        foreach (var num in allZ.Select(x => x.distance))
        {
            product *= num;
        }

        return Lcm(allZ.Select(x => (long) x.distance));
    }

    private static long Gcf(long n1, long n2)
    {
        if (n2 == 0)
        {
            return n1;
        }
        else
        {
            return Gcf(n2, n1 % n2);
        }
    }

    private static long Lcm(IEnumerable<long> numbers)
    {
        return numbers.Aggregate((S, val) => S * val / Gcf(S, val));
    }
}


