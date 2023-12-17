function canConstruct(target, wordBank, memo) {
    if (memo === void 0) { memo = {}; }
    if (memo[target])
        return true;
    if (wordBank.includes(target))
        return true;
    for (var splitIdx = 1; splitIdx < target.length; splitIdx++) {
        var leftSplit = target.slice(0, splitIdx);
        var rightSplit = target.slice(splitIdx, target.length);
        var leftEval = canConstruct(leftSplit, wordBank);
        var rightEval = canConstruct(rightSplit, wordBank);
        if (leftEval && rightEval) {
            memo[target] = true;
            return true;
        }
    }
    memo[target] = false;
    return false;
}
// console.log(canConstruct("abcd", ["abc", "d", "a"]));
// console.log(canConstruct("abcdef", ["ab", "abc", "cd", "def", "abcd"]));
console.log(canConstruct("abcdef", ["ab", "abc", "cd", "def", "abcd"]));
console.log(canConstruct("skateboard", ["bo", "rd", "ate", "t", "ska", "sk", "boar"]));
console.log(canConstruct("enterapotentpot", ["a", "p", "ent", "enter", "ot", "o", "t"]));
console.log(canConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", [
    "e",
    "ee",
    "eee",
    "eeee",
    "eeeee",
    "eeeeee",
]));
