// interface StrNumberArrayDict {
//     [key: string]: number[];
// }
var __spreadArray = (this && this.__spreadArray) || function (to, from, pack) {
    if (pack || arguments.length === 2) for (var i = 0, l = from.length, ar; i < l; i++) {
        if (ar || !(i in from)) {
            if (!ar) ar = Array.prototype.slice.call(from, 0, i);
            ar[i] = from[i];
        }
    }
    return to.concat(ar || Array.prototype.slice.call(from));
};
function bestSum(targetSum, numbers, memo) {
    if (memo === void 0) { memo = {}; }
    if (memo[targetSum]) {
        return memo[targetSum];
    }
    if (targetSum === 0) {
        return [];
    }
    if (targetSum < 0) {
        return null;
    }
    var smallestSet = null;
    for (var _i = 0, numbers_1 = numbers; _i < numbers_1.length; _i++) {
        var num = numbers_1[_i];
        var remainder = targetSum - num;
        var result = bestSum(remainder, numbers, memo);
        if (result) {
            result = __spreadArray(__spreadArray([], result, true), [num], false);
            if (smallestSet) {
                if (result.length < smallestSet.length) {
                    smallestSet = result;
                }
            }
            else {
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
