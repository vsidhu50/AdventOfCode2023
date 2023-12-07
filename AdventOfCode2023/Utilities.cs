namespace AdventOfCode2023;

public class Utilities
{
    public Utilities()
    {
    }

    public static List<string> GetInputLines(int day)
    {
        return File.ReadAllText($"/Users/vsidhu/Projects/AdventOfCode2023/AdventOfCode2023/Input/Day{day}.txt").Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList(); ;
    }

    public static List<string> GetInputParagraphs(int day)
    {
        return File.ReadAllText($"/Users/vsidhu/Projects/AdventOfCode2023/AdventOfCode2023/Input/Day{day}.txt").Split("\n\n", StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public static List<int> GetInputNums(int day)
    {
        return File.ReadAllText($"/Users/vsidhu/Projects/AdventOfCode2023/AdventOfCode2023/Input/Day{day}.txt").Split(new string[] { " ", "\t", Environment.NewLine, ",", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
    }

    public static List<long> GetInputLongs(int day)
    {
        return File.ReadAllText($"/Users/vsidhu/Projects/AdventOfCode2023/AdventOfCode2023/Input/Day{day}.txt").Split(new string[] { " ", "\t", Environment.NewLine, ",", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToList();
    }

    public static char[,] GetInputGridChars(int day)
    {
        var rows = GetInputLines(day);
        var numRows = rows.Count;
        var numCols = rows[0].Length;
        var grid = new char[numRows, numCols];

        for (int i = 0; i < numRows; i++)
            for (int j = 0; j < numCols; j++)
                grid[i, j] = rows[i][j];

        return grid;
    }

    public static int[,] GetInputGridInts(int day)
    {
        var rows = GetInputLines(day);
        var numRows = rows.Count;
        var numCols = rows[0].Length;
        var grid = new int[numRows, numCols];

        for (int i = 0; i < numRows; i++)
            for (int j = 0; j < numCols; j++)
                grid[i, j] = (int)char.GetNumericValue(rows[i][j]);

        return grid;
    }

    public static List<int[][]> GetInt2DArrays(List<string> input)
    {
        return input.Select(x => x.Split('\n', StringSplitOptions.RemoveEmptyEntries)).Select(x => x.Select(y => y.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(z => int.Parse(z)).ToArray()).ToArray()).ToList();
    }

    public static List<string> GetLines(string input)
    {
        return input.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public static List<string> GetWords(string input)
    {
        return input.Split(new string[] { " ", "\t", Environment.NewLine, ",", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public static List<int> GetNums(string input)
    {
        return input.Split(new string[] { " ", "\t", Environment.NewLine, ",", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    }
}
