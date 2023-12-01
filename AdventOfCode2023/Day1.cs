namespace AdventOfCode2023;

public class Day1
{
    public Day1()
    {
    }

    public static int PartOne()
    {
        var sum = 0;
        var lines = Utilities.GetInputLines(1);
        foreach (var line in lines)
        {
            var num = "";
            foreach (var c in line)
            {
                if (c >= '0' && c <= '9')
                {
                    if (num.Length <= 1)
                        num += c;
                    else
                        num = num[0] + "" + c;
                }
            }
            if (num.Length == 1)
                num += num;
            sum += int.Parse(num);
        }
        return sum;
    }

    public static int PartTwo()
    {
        var sum = 0;
        var lines = Utilities.GetInputLines(1);
        foreach (var line in lines)
        {
            var num = "";
            var newLine = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'o')
                {
                    if ((i + 3 <= line.Length) && line.Substring(i, 3) == "one")
                        newLine += "1";
                        
                }
                else if (line[i] == 't')
                {
                    if ((i + 3 <= line.Length) && line.Substring(i, 3) == "two")
                        newLine += "2";
                       
                    else if ((i + 5 <= line.Length) && line.Substring(i, 5) == "three")
                        newLine += "3";
                }
                else if (line[i] == 'f')
                {
                    if ((i + 4 <= line.Length) && line.Substring(i, 4) == "four")
                        newLine += "4";
                        
                    else if ((i + 4 <= line.Length) && line.Substring(i, 4) == "five")
                        newLine += "5";
                }
                else if (line[i] == 's')
                {
                    if ((i + 3 <= line.Length) && line.Substring(i, 3) == "six")
                        newLine += "6";
                    else if ((i + 5 <= line.Length) && line.Substring(i, 5) == "seven")
                        newLine += "7";
                }
                else if (line[i] == 'e')
                {
                    if ((i + 5 <= line.Length) && line.Substring(i, 5) == "eight")
                        newLine += "8";
                }
                else if (line[i] == 'n')
                {
                    if ((i + 4 <= line.Length) && line.Substring(i, 4) == "nine")
                        newLine += "9";
                }
                    newLine += line[i];
            }
            foreach (var c in newLine)
            {
                if (c > '0' && c <= '9')
                {
                    if (num.Length <= 1)
                        num += c;
                    else
                        num = num[0] + "" + c;
                }
            }
            if (num.Length == 1)
                num += num;
            sum += int.Parse(num);
        }
        return sum;
    }
}

