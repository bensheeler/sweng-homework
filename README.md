## 1. Descriptive Statistics

 A local charity needs to analyze data about contributions. Write a library  which accepts a semicolon-delimited collection of human-keyed monetary contributions as a string (e.g. `“5 ; $ 123.42; $5,401.56”`) and returns three statistics about them: average, median, and range all rounded to two decimal places.

If no valid contributions are entered, the library should simply return 0 for all three metrics.

```
Example input:
$2,550.50; 1000; $6345.45; 7,565.65;12,568.68;$6356.56;2550.5; 500.45

Example output:
Average: 4929.72
Median: 4447.98
Range: 12068.23
```

## 2. Commissions
A financial firm pays commissions to advisors based on seniority and account fees. An account fee is the present value of the account multiplied by [basis points](http://www.investopedia.com/terms/b/basispoint.asp) in a tiered structure:

* less than $50,000 = 5 bps
* greater than or equal to $50,000 = 6 bps
* greater than or equal to $100,000 = 7 bps

An advisor’s commission is a percentage of the account fee based on their seniority:

* Senior = 100%
* Experienced = 50%
* Junior = 25%

Build a calculator which reads data from a JSON string and produces a commission report: each rep name and their commission rounded to two decimal places. 

Important tips:
* It is safe to assume that Advisor names are globally unique
* We expect there to be **thousands** of advisors and accounts in the input data, so me mindful of potential performance issues.
* An advisor who does not have any accounts should have a commission of 0.
* It's ok to bring in a NuGet package to help with JSON parsing.

```
Example input:
{
  "advisors": [
    {
      "name": "Joe",
      "level": "Junior"
    },
    {
      "name": "Karen",
      "level": "Senior"
    }
  ],
  "accounts": [
    {
      "advisor": "Joe",
      "presentValue": 65000
    },
    {
      "advisor": "Karen",
      "presentValue": 49000
    }
  ]
}

Example output:
Joe: 9.75
Karen: 24.50
```
