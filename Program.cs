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

        displayCoinStrategyFor([5, 10, 25, 10]);
        displayCoinStrategyFor([1, 3, 6, 3, 1, 3]);

        void displayCoinStrategyFor(int[] inputCoinList){
            GameStrategy output = getCoinStrategy(inputCoinList);
            output.strategy.Reverse();
            Console.WriteLine($"{output.aSum} {output.bSum} [{string.Join(", ", output.strategy)}]");
        }

        GameStrategy getCoinStrategy(int[] coinValueList){
            if (coinValueList.Length == 1) return new GameStrategy(0, coinValueList[0]);
            GameStrategy rightSums = getCoinStrategy(coinValueList[1..]);
            GameStrategy leftSums = getCoinStrategy(coinValueList[..(coinValueList.Length - 1)]);
            if (coinValueList.Length % 2 == 0){
                return alicesTurn(coinValueList, rightSums, leftSums);
            }else{
                return bobsTurn(coinValueList, rightSums, leftSums);
            }

        }
        
        GameStrategy alicesTurn(int[] coinValueList, GameStrategy rightSums, GameStrategy leftSums)
        {
            int rightCoin = coinValueList[coinValueList.Length - 1];
            rightSums.aSum += coinValueList[0];
            leftSums.aSum += rightCoin;
            GameStrategy result = rightSums.aSum > leftSums.aSum ? rightSums : leftSums;
            int highestCoin = rightSums.aSum > leftSums.aSum ? coinValueList[0] : rightCoin;
            result.strategy.Add(highestCoin);
            return result;
        }

        GameStrategy bobsTurn(int[] coinValueList, GameStrategy rightSums, GameStrategy leftSums){
            rightSums.bSum += coinValueList[0];
            leftSums.bSum += coinValueList[coinValueList.Length - 1];
            return  rightSums.bSum > leftSums.bSum ? rightSums : leftSums;
        }
    }
}

public struct GameStrategy
{
    public int aSum;
    public int bSum;
    public List<int> strategy;
    public GameStrategy(int aSum, int bSum)  
    {  
        this.aSum = aSum;
        this.bSum = bSum;
        this.strategy = new List<int>();
    } 
}