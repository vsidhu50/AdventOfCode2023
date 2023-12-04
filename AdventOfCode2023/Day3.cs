namespace AdventOfCode2023;

public class Day3
{
    public Day3()
    {
    }

    public static int PartOne()
    {
        var grid = Utilities.GetInputGridChars(3);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        var sum = 0;

        for (int i = 0; i < numRows; i++)
        {
            var num = "";
            var isAdjacent = false;
            for (int j = 0; j < numCols; j++)
            {
                if (char.IsDigit(grid[i, j]))
                {
                    num += grid[i, j];
                    isAdjacent = isAdjacent || IsAdjacent(i, j, numRows, numCols, grid);

                    if (j == numCols - 1 && isAdjacent)
                    {
                        sum += int.Parse(num);
                    }
                }
                else
                {
                    if (isAdjacent)
                    {
                        sum += int.Parse(num);
                    }

                    num = "";
                    isAdjacent = false;
                }
            }
        }

        return sum;
    }

    public static int PartTwo()
    {
        var grid = Utilities.GetInputGridChars(3);
        var numRows = grid.GetLength(0);
        var numCols = grid.GetLength(1);
        var newGrid = new string[numRows, numCols];

        var sum = 0;

        for (int i = 0; i < numRows; i++)
        {
            var num = "";
            for (int j = 0; j < numCols; j++)
            {
                newGrid[i, j] = char.ToString(grid[i, j]);
                if (char.IsDigit(grid[i, j]))
                {
                    num += grid[i, j];

                    if (j == numCols - 1)
                    {
                        for (int k = 0; k < num.Length; k++)
                        {
                            newGrid[i, j - k] = num;
                        }
                    }
                }
                else
                {
                    if (num != "")
                    {
                        for (int k = 0; k < num.Length; k++)
                        {
                            newGrid[i, j - k - 1] = num;
                        }
                    }

                    num = "";
                }
            }
        }

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                if (grid[i, j] == '*')
                {
                    sum += GearRatio(i, j, numRows, numCols, newGrid);
                }
            }
        }

        return sum;
    }

    private static int GearRatio(int row, int col, int numRows, int numCols, string[,] grid)
    {
        var nums = new List<int>();
        var num = 0;

        // check below
        if (row < numRows - 1)
        {
            var left = 0;
            var center = 0;
            var right = 0;

            if (int.TryParse(grid[row + 1, col], out num))
            {
                center = num;
            }
            // check right
            if (col < numCols - 1)
            {
                if (int.TryParse(grid[row + 1, col + 1], out num))
                {
                    right = num;
                }
            }
            // check left
            if (col > 0)
            {
                if (int.TryParse(grid[row + 1, col - 1], out num))
                {
                    left = num;
                }
            }

            if (center != 0)
            {
                nums.Add(center);
            }
            else
            {
                if (right != 0)
                {
                    nums.Add(right);
                }
                if (left != 0)
                {
                    nums.Add(left);
                }
            }
        }
        // check above
        if (row > 0)
        {
            var left = 0;
            var center = 0;
            var right = 0;

            if (int.TryParse(grid[row  - 1, col], out num))
            {
                center = num;
            }
            // check right
            if (col < numCols - 1)
            {
                if (int.TryParse(grid[row - 1, col + 1], out num))
                {
                    right = num;
                }
            }
            // check left
            if (col > 0)
            {
                if (int.TryParse(grid[row - 1, col - 1], out num))
                {
                    left = num;
                }
            }

            if (center != 0)
            {
                nums.Add(center);
            }
            else
            {
                if (right != 0)
                {
                    nums.Add(right);
                }
                if (left != 0)
                {
                    nums.Add(left);
                }
            }
        }
        // check right
        if (col < numCols - 1)
        {
            if (int.TryParse(grid[row, col + 1], out num))
            {
                nums.Add(num);
            }
        }
        // check left
        if (col > 0)
        {
            if (int.TryParse(grid[row, col - 1], out num))
            {
                nums.Add(num);
            }
        }

        return nums.Count == 2 ? nums[0] * nums[1] : 0;
    }

    private static bool IsAdjacent(int row, int col, int numRows, int numCols, char[,] grid)
    {
        // check below
        if (row < numRows - 1)
        {
            if (IsSymbol(grid[row + 1, col]))
            {
                return true;
            }
            // check right
            if (col < numCols - 1)
            {
                if (IsSymbol(grid[row + 1, col + 1]))
                {
                    return true;
                }
            }
            // check left
            if (col > 0)
            {
                if (IsSymbol(grid[row + 1, col - 1]))
                {
                    return true;
                }
            }
        }
        // check above
        if (row > 0)
        {
            if (IsSymbol(grid[row - 1, col]))
            {
                return true;
            }
            // check right
            if (col < numCols - 1)
            {
                if (IsSymbol(grid[row - 1, col + 1]))
                {
                    return true;
                }
            }
            // check left
            if (col > 0)
            {
                if (IsSymbol(grid[row - 1, col - 1]))
                {
                    return true;
                }
            }
        }
        // check right
        if (col < numCols - 1)
        {
            if (IsSymbol(grid[row, col + 1]))
            {
                return true;
            }
        }
        // check left
        if (col > 0)
        {
            if (IsSymbol(grid[row, col - 1]))
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsSymbol(char c)
    {
        return !char.IsDigit(c) && c != '.';
    }
}

