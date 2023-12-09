namespace AdventOfCode2023;

public class Day9
{
	public Day9()
	{
	}

	public static long PartOne()
	{
		var lines = Utilities.GetInputLines(9);
		long sum = 0;
		foreach (var line in lines) {
			var nums = Utilities.GetNums(line);
            var lists = new List<List<int>>
            {
                nums
            };
            int i = 0;
			var currList = lists[0];
			while (currList.Any(x => x != 0))
			{
				var newList = new List<int>();
				for (int j = 0; j < currList.Count - 1; j++)
				{
					newList.Add(currList[j + 1] - currList[j]);
				}
				lists.Add(newList);
				i++;
                currList = lists[i];
            }
            var total = lists.Sum(x => x.Last());
			sum += total;
		}

		return sum;
	}

	public static long PartTwo()
	{
        var lines = Utilities.GetInputLines(9);
        long sum = 0;
        foreach (var line in lines)
        {
            var nums = Utilities.GetNums(line);
            var lists = new List<List<int>>
            {
                nums
            };
            int index = 0;
            var currList = lists[0];
            while (currList.Any(x => x != 0))
            {
                var newList = new List<int>();
                for (int j = 0; j < currList.Count - 1; j++)
                {
                    newList.Add(currList[j + 1] - currList[j]);
                }
                lists.Add(newList);
                index++;
                currList = lists[index];

            }
            for (int i = lists.Count - 1; i > 0; i--)
            {
                currList = lists[i];
                var prevList = lists[i - 1];
                prevList.Insert(0, prevList.First() - currList.First());
            }
            var first = lists[0][0];
            sum += first;
        }

        return sum;
    }
}

