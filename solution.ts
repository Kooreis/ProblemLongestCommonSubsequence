Here is a TypeScript console application that solves the problem:

```typescript
function longestCommonSubsequence(str1: string, str2: string): string {
    const matrix = Array(str2.length + 1).fill(null).map(() => Array(str1.length + 1).fill(null));

    for (let i = 0; i <= str1.length; i += 1) {
        matrix[0][i] = '';
    }

    for (let i = 0; i <= str2.length; i += 1) {
        matrix[i][0] = '';
    }

    for (let i = 1; i <= str2.length; i += 1) {
        for (let j = 1; j <= str1.length; j += 1) {
            if (str1[j - 1] === str2[i - 1]) {
                matrix[i][j] = matrix[i - 1][j - 1] + str1[j - 1];
            } else {
                matrix[i][j] = matrix[i - 1][j].length > matrix[i][j - 1].length
                    ? matrix[i - 1][j]
                    : matrix[i][j - 1];
            }
        }
    }

    return matrix[str2.length][str1.length];
}

console.log(longestCommonSubsequence('ABCDEF', 'AEDNEK'));
```

This program uses dynamic programming to build a matrix of longest common subsequences. It then returns the longest common subsequence found at the bottom right of the matrix.