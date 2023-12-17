function canConstruct(
    target: string,
    wordBank: string[],
    memo: { [key: string]: boolean } = {}
): boolean {
    if (memo[target]) return true;
    if (wordBank.includes(target)) return true;

    for (let splitIdx = 1; splitIdx < target.length; splitIdx++) {
        let leftSplit = target.slice(0, splitIdx);
        let rightSplit = target.slice(splitIdx, target.length);
        let leftEval = canConstruct(leftSplit, wordBank);
        let rightEval = canConstruct(rightSplit, wordBank);
        // console.log(`${leftSplit}:${leftEval} ${rightSplit}:${rightEval}`);
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
console.log(
    canConstruct("skateboard", ["bo", "rd", "ate", "t", "ska", "sk", "boar"])
);
console.log(
    canConstruct("enterapotentpot", ["a", "p", "ent", "enter", "ot", "o", "t"])
);
console.log(
    canConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", [
        "e",
        "ee",
        "eee",
        "eeee",
        "eeeee",
        "eeeeee",
    ])
);
