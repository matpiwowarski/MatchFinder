
// A Dynamic Programming based solution for 0-1 Knapsack problem
4
?
5
#include<stdio.h>
6
?
7
  
8
?
9
// A utility function that returns maximum of two integers
10
?
11
int max(int a, int b) { return (a > b)? a : b; }
12
?
13
  
14
?
15
// Returns the maximum value that can be put in a knapsack of capacity W
16
?
17
int knapSack(int W, int wt[], int val[], int n)
18
?
19
{
20
?
21
   int i, w;
22
?
23
   int K[n+1][W+1];
24
?
25
  
26
?
27
   // Build table K[][] in bottom up manner
28
?
29
   for (i = 0; i <= n; i++)
30
?
31
   {
32
?
33
       for (w = 0; w <= W; w++)
34
?
35
       {
36
?
37
           if (i==0 || w==0)
38
?
39
               K[i][w] = 0;
40
?
41
           else if (wt[i-1] <= w)
42
?
43
                 K[i][w] = max(val[i-1] + K[i-1][w-wt[i-1]],  K[i-1][w]);
44
?
45
           else
46
?
47
                 K[i][w] = K[i-1][w];
48
?
49
       }
50
?
51
   }
52
?
53
  
54
?
55
   return K[n][W];
56
?
57
}
58
?
59
  
60
?
61
int main()
62
?
63
{
64
?
65
    int val[] = {60, 100, 120};
66
?
67
    int wt[] = {10, 20, 30};
68
?
69
    int  W = 50;
70
?
71
    int n = sizeof(val)/sizeof(val[0]);
72
?
73
    printf("%d", knapSack(W, wt, val, n));
74
?
75
    return 0;
76
?
77
}