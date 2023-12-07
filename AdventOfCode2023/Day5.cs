namespace AdventOfCode2023;

public class Day5
{
    public Day5()
    {
    }

    public static long PartOne()
    {
        var maps = Utilities.GetInputParagraphs(5);
        var seeds = maps[0].Split(":")[1].Trim().Split(" ").Select(long.Parse).ToList();
        var seedsMap = new List<(long seed, bool mapped)>();
        foreach (var seed in seeds)
        {
            seedsMap.Add((seed, false));
        }
        maps.RemoveAt(0);

        foreach (var map in maps)
        {
            var lines = Utilities.GetLines(map);
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var nums = line.Split(" ");
                var destStart = long.Parse(nums[0]);
                var sourceStart = long.Parse(nums[1]);
                var length = long.Parse(nums[2]);

                for (int i = 0; i < seedsMap.Count; i++)
                {
                    var seed = seedsMap[i].seed;
                    var mapped = seedsMap[i].mapped;
                    if (!mapped && seed >= sourceStart && seed < sourceStart + length)
                    {
                        seedsMap[i] = (destStart + (seed - sourceStart), true);
                    }
                }

            }
            for (int i = 0; i < seedsMap.Count; i++)
            {
                seedsMap[i] = (seedsMap[i].seed, false);
            }
        }
        return seedsMap.Select(x => x.seed).Min();
    }

    public static long PartTwo()
    {
        var maps = Utilities.GetInputParagraphs(0);
        var seedPairs = maps[0].Split(":")[1].Trim().Split(" ").Select(long.Parse).ToList();

        var seedRanges = new List<(long start, long length)>();
        for (int i = 0; i < seedPairs.Count; i += 2)
        {
            seedRanges.Add((seedPairs[i], seedPairs[i + 1]));
        }

        var seedsMap = new List<((long start, long length) seedRange, bool mapped)>();
        foreach (var seedRange in seedRanges)
        {
            seedsMap.Add((seedRange, false));
        }
        maps.RemoveAt(0);

        foreach (var map in maps)
        {
            var lines = Utilities.GetLines(map);
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var nums = line.Split(" ");
                var destStart = long.Parse(nums[0]);
                var sourceStart = long.Parse(nums[1]);
                var length = long.Parse(nums[2]);
                var seedsMapCount = seedsMap.Count;

                for (int i = 0; i < seedsMapCount; i++)
                {
                    var seedRange = seedsMap[i].seedRange;
                    var mapped = seedsMap[i].mapped;
                    var seedStart = seedRange.start;
                    var rangeLength = seedRange.length;
                    if (!mapped && seedStart >= sourceStart && seedStart < sourceStart + length)
                    {
                        if (length <= seedStart - sourceStart + rangeLength)
                        {
                            seedsMap[i] = ((destStart + (seedStart - sourceStart), rangeLength), true);
                        }
                        else
                        {
                            var remainingLength = seedStart - sourceStart + rangeLength - length;
                            seedsMap[i] = ((destStart + (seedStart - sourceStart), length), true);
                            seedsMap.Add(((seedStart + length, remainingLength), false));
                            seedsMapCount++;
                        }
                    }
                }

            }
            for (int i = 0; i < seedsMap.Count; i++)
            {
                seedsMap[i] = (seedsMap[i].seedRange, false);
            }
        }
        return seedsMap.Select(x => x.seedRange.start).Min();
    }
}


