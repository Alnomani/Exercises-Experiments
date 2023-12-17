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
    // Console.WriteLine("[{0}]", string.Join(", ", rightSlice));
    // Console.WriteLine("[{0}]", string.Join(", ", leftSlice));
*/
int[] inputCoinList = [5, 10, 25, 10];
Console.WriteLine(getCoinStrategy(inputCoinList));
inputCoinList = [1, 3, 6, 3, 1, 3];
Console.WriteLine(getCoinStrategy(inputCoinList));

(int aSum, int bSum) getCoinStrategy(int[] coinValueList){
    if(coinValueList.Length == 1) return (0, coinValueList[0]);
    int[] rightSlice = coinValueList[1..];
    int[] leftSlice = coinValueList[..(coinValueList.Length-1)];
    var rightSums = getCoinStrategy(rightSlice);
    var leftSums = getCoinStrategy(leftSlice);
    (int aSum, int bSum) returnSums = (0,0);
    if(coinValueList.Length % 2 == 0){
        // Alice's turn.
        rightSums.aSum += coinValueList[0]; 
        leftSums.aSum += coinValueList[coinValueList.Length-1];
        returnSums = rightSums.aSum > leftSums.aSum ? rightSums: leftSums;
    }else{
        // Bob's turn.
        rightSums.bSum += coinValueList[0]; 
        leftSums.bSum += coinValueList[coinValueList.Length-1];
        returnSums = rightSums.bSum > leftSums.bSum ? rightSums: leftSums;        
    }
    return returnSums;
}
