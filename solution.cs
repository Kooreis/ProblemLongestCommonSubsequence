Here is a JavaScript solution for finding the longest common subsequence between two strings:

```javascript
function lcs(X, Y) {
    let m = X.length;
    let n = Y.length;
    let L = Array(m + 1).fill().map(() => Array(n + 1).fill(0));

    for (let i = 0; i <= m; i++) {
        for (let j = 0; j <= n; j++) {
            if (i == 0 || j == 0)
                L[i][j] = 0;
            else if (X[i - 1] == Y[j - 1])
                L[i][j] = L[i - 1][j - 1] + 1;
            else
                L[i][j] = Math.max(L[i - 1][j], L[i][j - 1]);
        }
    }

    let index = L[m][n];
    let lcs = Array(index + 1).fill('\0');

    let i = m, j = n;
    while (i > 0 && j > 0) {
        if (X[i - 1] == Y[j - 1]) {
            lcs[index - 1] = X[i - 1];
            i--; j--; index--;
        }
        else if (L[i - 1][j] > L[i][j - 1])
            i--;
        else
            j--;
    }

    return lcs.join('');
}

console.log(lcs("AGGTAB", "GXTXAYB"));
```

This program uses a dynamic programming approach to find the longest common subsequence between two strings. It first creates a 2D array to store the lengths of the longest common subsequences for different substrings of the input strings. It then fills this array by comparing the characters of the input strings. If the current characters are the same, it increments the length of the longest common subsequence found so far. If the current characters are different, it takes the maximum length found so far. Finally, it constructs the longest common subsequence by tracing back from the bottom right corner of the array.