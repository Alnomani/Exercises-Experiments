function bestSum(
    targetSum: number,
    numbers: number[],
    memo: { [key: number]: number[] | null } = {}
): number[] | null {
    if (memo[targetSum]) {
        return memo[targetSum];
    }

    if (targetSum === 0) {
        return [];
    }
    if (targetSum < 0) {
        return null;
    }
    let smallestSet: number[] | null = null;
    for (let num of numbers) {
        const remainder: number = targetSum - num;
        let result: number[] | null = bestSum(remainder, numbers, memo);
        if (result) {
            result = [...result, num];
            if (smallestSet) {
                if (result.length < smallestSet.length) {
                    smallestSet = result;
                }
            } else {
                smallestSet = result;
            }
        }
    }
    memo[targetSum] = smallestSet;
    return smallestSet;
}

console.log(bestSum(7, [2, 3]));
console.log(bestSum(7, [5, 3, 4, 7]));
console.log(bestSum(7, [2, 4]));
console.log(bestSum(8, [2, 3, 5]));
console.log(bestSum(300, [7, 14]));
