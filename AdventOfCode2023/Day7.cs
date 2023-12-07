namespace AdventOfCode2023;

public class Day7
{
    public Day7()
    {
    }

    public static long PartOne()
    {
        var lines = Utilities.GetInputLines(7);
        var hands = new List<(Hand hand, int bet)>();

        foreach (var line in lines)
        {
            var hand = line.Split(" ")[0];
            var bet = int.Parse(line.Split(" ")[1]);

            var cards = new int[5];
            for (int i = 0; i < 5; i++)
            {
                cards[i] = hand[i] switch
                {
                    'A' => 14,
                    'K' => 13,
                    'Q' => 12,
                    'J' => 11,
                    'T' => 10,
                    _ => int.Parse(hand[i].ToString())
                };
            }

            Type type;
            if (cards.Count(x => x == cards.First()) == 5)
            {
                type = Type.FiveKind;
            }
            else if (cards.Any(x => cards.Count(y => y == x) == 4))
            {
                type = Type.FourKind;
            }
            else if (cards.Any(x => cards.Count(y => y == x) == 3) )
            {
                if (cards.Any(x => cards.Count(y => y == x) == 2))
                    type = Type.FullHouse;
                else
                    type = Type.ThreeKind;
            }
            else if (cards.Count(x => cards.Count(y => y == x) == 2) == 4)
            {
                type = Type.TwoPair;
            }
            else if (cards.Count(x => cards.Count(y => y == x) == 2) == 2)
            {
                type = Type.OnePair;
            }
            else
            {
                type = Type.HighCard;
            }

            Hand cardHand = new Hand
            {
                Cards = cards,
                Type = type
            };
            hands.Add((cardHand, bet));
        }
        hands = hands.OrderBy(x => x.hand).ToList();

        long sum = 0;
        for (int i = 0; i < hands.Count; i++)
        {
            sum += hands[i].bet * (i + 1);
        }
        return sum;
    }

    public static long PartTwo()
    {
        var lines = Utilities.GetInputLines(7);
        var hands = new List<(Hand hand, int bet)>();

        foreach (var line in lines)
        {
            var hand = line.Split(" ")[0];
            var bet = int.Parse(line.Split(" ")[1]);

            var cards = new int[5];
            for (int i = 0; i < 5; i++)
            {
                cards[i] = hand[i] switch
                {
                    'A' => 14,
                    'K' => 13,
                    'Q' => 12,
                    'J' => 1,
                    'T' => 10,
                    _ => int.Parse(hand[i].ToString())
                };
            }

            Type type;
            if (cards.Count(x => x == cards.First()) == 5)
            {
                type = Type.FiveKind;
            }
            else if (cards.Any(x => cards.Count(y => y == x) == 4))
            {
                if (cards.Contains(1))
                    type = Type.FiveKind;
                else
                    type = Type.FourKind;
            }
            else if (cards.Any(x => cards.Count(y => y == x) == 3))
            {
                if (cards.Count(x => x == 1) == 3)
                {
                    if (cards.Any(x => cards.Count(y => y == x) == 2))
                        type = Type.FiveKind;
                    else
                        type = Type.FourKind;
                }
                else if (cards.Count(x => x == 1) == 2)
                {
                    type = Type.FiveKind;
                }
                else if (cards.Count(x => x == 1) == 1)
                {
                    type = Type.FourKind;
                }
                else
                {
                    if (cards.Any(x => cards.Count(y => y == x) == 2))
                        type = Type.FullHouse;
                    else
                        type = Type.ThreeKind;
                }
            }
            else if (cards.Count(x => cards.Count(y => y == x) == 2) == 4)
            {
                if (cards.Count(x => x == 1) == 2)
                {
                    type = Type.FourKind;
                }
                else if (cards.Count(x => x == 1) == 1)
                {
                    type = Type.FullHouse;
                }
                else
                {
                    type = Type.TwoPair;
                }
            }
            else if (cards.Count(x => cards.Count(y => y == x) == 2) == 2)
            {
                if (cards.Contains(1))
                {
                    type = Type.ThreeKind;
                }
                else
                {
                    type = Type.OnePair;
                }
            }
            else
            {
                if (cards.Contains(1))
                {
                    type = Type.OnePair;
                }
                else
                {
                    type = Type.HighCard;
                }
            }

            Hand cardHand = new Hand
            {
                Cards = cards,
                Type = type
            };
            hands.Add((cardHand, bet));
        }
        hands = hands.OrderBy(x => x.hand).ToList();

        long sum = 0;
        for (int i = 0; i < hands.Count; i++)
        {
            sum += hands[i].bet * (i + 1);
        }
        return sum;
    }
}

public class Hand : IComparable
{
    public int[] Cards { get; set; } = new int[5];
    public Type Type { get; set; }

    public int CompareTo(object? o)
    {
        Hand other = (Hand) o;

        if (Type == other.Type)
        {
            for (int i = 0; i < 5; i++)
            {
                if (Cards[i] != other.Cards[i])
                    return Cards[i] - other.Cards[i];
            }
            return 0;
        }
        else
        {
            return Type - other.Type;
        }
    }
}

public enum Type
{
    HighCard,
    OnePair,
    TwoPair,
    ThreeKind,
    FullHouse,
    FourKind,
    FiveKind
}