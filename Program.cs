/*
    Coins in a Line
    In this game, an even number, n, of coins, of various
    denominations, are placed in a line.
    Two players, who we will call Alice and Bob, take turns removing
    one of the coins from either end of the remaining line of coins.
    The player who removes a set of coins with larger total value than
    the other player wins and gets to keep the money. The loser gets
    nothing.
    Alice’s goal: get the most.
*/

internal class Program
{
    private static void Main(string[] args)
    {
        CoinGameSolver.DisplayCoinStrategyFor([5, 10, 25, 10]);
        CoinGameSolver.DisplayCoinStrategyFor([1, 3, 6, 3, 1, 3]);
    }
}

public struct GameStrategy(int aSum, int bSum)
{
    public int aSum = aSum;
    public int bSum = bSum;
    public List<int> strategy = [];
}

public static class CoinGameSolver
{
    private static readonly Dictionary<int[], GameStrategy> numberNames = [];

    public static void DisplayCoinStrategyFor(int[] inputCoinList)
    {
        GameStrategy output = GetCoinStrategy(inputCoinList);
        output.strategy.Reverse();
        Console.WriteLine($"{output.aSum} {output.bSum} [{string.Join(", ", output.strategy)}]");
    }

    private static GameStrategy GetCoinStrategy(int[] coinValueList)
    {
        if (numberNames.TryGetValue(coinValueList, out GameStrategy value))
            return value;
        if (coinValueList.Length == 1)
            return new GameStrategy(0, coinValueList[0]);
        GameStrategy right = GetCoinStrategy(coinValueList[1..]);
        GameStrategy left = GetCoinStrategy(coinValueList[..^1]);

        if (coinValueList.Length % 2 == 0)
        {
            return AlicesTurn(coinValueList, right, left);
        }
        else
        {
            return BobsTurn(coinValueList, right, left);
        }
    }

    private static GameStrategy AlicesTurn(int[] coinValues, GameStrategy right, GameStrategy left)
    {
        right.aSum += coinValues[0];
        left.aSum += coinValues[^1];
        GameStrategy result = right.aSum > left.aSum ? right : left;
        int highestCoin = right.aSum > left.aSum ? coinValues[0] : coinValues[^1];
        result.strategy.Add(highestCoin);
        numberNames.Add(coinValues, result);
        return result;
    }

    private static GameStrategy BobsTurn(int[] coinValueList, GameStrategy right, GameStrategy left)
    {
        right.bSum += coinValueList[0];
        left.bSum += coinValueList[^1];
        GameStrategy result = right.bSum > left.bSum ? right : left;
        numberNames.Add(coinValueList, result);
        return result;
    }
}
