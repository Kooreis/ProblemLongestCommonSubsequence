```cpp
#include <iostream>
#include <string>
#include <vector>

std::string longestCommonSubsequence(std::string str1, std::string str2) {
    int m = str1.length();
    int n = str2.length();
    std::vector<std::vector<int>> dp(m+1, std::vector<int>(n+1, 0));

    for (int i = 1; i <= m; i++) {
        for (int j = 1; j <= n; j++) {
            if (str1[i-1] == str2[j-1]) {
                dp[i][j] = dp[i-1][j-1] + 1;
            } else {
                dp[i][j] = std::max(dp[i-1][j], dp[i][j-1]);
            }
        }
    }

    std::string result = "";
    int i = m, j = n;
    while (i > 0 && j > 0) {
        if (str1[i-1] == str2[j-1]) {
            result = str1[i-1] + result;
            i--;
            j--;
        } else if (dp[i-1][j] > dp[i][j-1]) {
            i--;
        } else {
            j--;
        }
    }

    return result;
}

int main() {
    std::string str1, str2;
    std::cout << "Enter first string: ";
    std::cin >> str1;
    std::cout << "Enter second string: ";
    std::cin >> str2;

    std::string lcs = longestCommonSubsequence(str1, str2);
    std::cout << "Longest Common Subsequence: " << lcs << std::endl;

    return 0;
}
```