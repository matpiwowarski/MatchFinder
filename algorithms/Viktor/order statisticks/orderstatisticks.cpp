
// C++ implementation of randomized quickSelect 
2
#include<iostream> 
3
#include<climits> 
4
#include<cstdlib> 
5
using namespace std; 
6
?
7
int randomPartition(int arr[], int l, int r); 
8
?
9
// This function returns k'th smallest element in arr[l..r] using 
10
// QuickSort based method. ASSUMPTION: ELEMENTS IN ARR[] ARE DISTINCT 
11
int kthSmallest(int arr[], int l, int r, int k) 
12
{ 
13
    // If k is smaller than number of elements in array 
14
    if (k > 0 && k <= r - l + 1) 
15
    { 
16
        // Partition the array around a random element and 
17
        // get position of pivot element in sorted array 
18
        int pos = randomPartition(arr, l, r); 
19
?
20
        // If position is same as k 
21
        if (pos-l == k-1) 
22
            return arr[pos]; 
23
        if (pos-l > k-1) // If position is more, recur for left subarray 
24
            return kthSmallest(arr, l, pos-1, k); 
25
?
26
        // Else recur for right subarray 
27
        return kthSmallest(arr, pos+1, r, k-pos+l-1); 
28
    } 
29
?
30
    // If k is more than the number of elements in the array 
31
    return INT_MAX; 
32
} 
33
?
34
void swap(int *a, int *b) 
35
{ 
36
    int temp = *a; 
37
    *a = *b; 
38
    *b = temp; 
39
} 
40
?
41
// Standard partition process of QuickSort(). It considers the last 
42
// element as pivot and moves all smaller element to left of it and 
43
// greater elements to right. This function is used by randomPartition() 
44
int partition(int arr[], int l, int r) 
45
{ 
46
    int x = arr[r], i = l; 
47
    for (int j = l; j <= r - 1; j++) 
48
    { 
49
        if (arr[j] <= x) 
50
        { 
51
            swap(&arr[i], &arr[j]); 
52
            i++; 
53
        } 
54
    } 
55
    swap(&arr[i], &arr[r]); 
56
    return i; 
57
} 
58
?
59
// Picks a random pivot element between l and r and partitions 
60
// arr[l..r] around the randomly picked element using partition() 
61
int randomPartition(int arr[], int l, int r) 
62
{ 
63
    int n = r-l+1; 
64
    int pivot = rand() % n; 
65
    swap(&arr[l + pivot], &arr[r]); 
66
    return partition(arr, l, r); 
67
} 
68
?
69
// Driver program to test above methods 
70
int main() 
71
{ 
72
    int arr[] = {12, 3, 5, 7, 4, 19, 26}; 
73
    int n = sizeof(arr)/sizeof(arr[0]), k = 3; 
74
    cout << "K'th smallest element is " << kthSmallest(arr, 0, n-1, k); 
75
    return 0; 
76
}
77
?