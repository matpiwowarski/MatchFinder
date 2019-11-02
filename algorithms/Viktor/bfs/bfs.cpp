C# IMPLEMENTATION

// Program to print BFS traversal from a given 
6
// source vertex. BFS(int s) traverses vertices 
7
// reachable from s. 
8
#include<iostream> 
9
#include <list> 
10
?
11
using namespace std; 
12
?
13
// This class represents a directed graph using 
14
// adjacency list representation 
15
class Graph 
16
{ 
17
    int V; // No. of vertices 
18
?
19
    // Pointer to an array containing adjacency 
20
    // lists 
21
    list<int> *adj; 
22
public: 
23
    Graph(int V); // Constructor 
24
?
25
    // function to add an edge to graph 
26
    void addEdge(int v, int w); 
27
?
28
    // prints BFS traversal from a given source s 
29
    void BFS(int s); 
30
}; 
31
?
32
Graph::Graph(int V) 
33
{ 
34
    this->V = V; 
35
    adj = new list<int>[V]; 
36
} 
37
?
38
void Graph::addEdge(int v, int w) 
39
{ 
40
    adj[v].push_back(w); // Add w to v’s list. 
41
} 
42
?
43
void Graph::BFS(int s) 
44
{ 
45
    // Mark all the vertices as not visited 
46
    bool *visited = new bool[V]; 
47
    for(int i = 0; i < V; i++) 
48
        visited[i] = false; 
49
?
50
    // Create a queue for BFS 
51
    list<int> queue; 
52
?
53
    // Mark the current node as visited and enqueue it 
54
    visited[s] = true; 
55
    queue.push_back(s); 
56
?
57
    // 'i' will be used to get all adjacent 
58
    // vertices of a vertex 
59
    list<int>::iterator i; 
60
?
61
    while(!queue.empty()) 
62
    { 
63
        // Dequeue a vertex from queue and print it 
64
        s = queue.front(); 
65
        cout << s << " "; 
66
        queue.pop_front(); 
67
?
68
        // Get all adjacent vertices of the dequeued 
69
        // vertex s. If a adjacent has not been visited, 
70
        // then mark it visited and enqueue it 
71
        for (i = adj[s].begin(); i != adj[s].end(); ++i) 
72
        { 
73
            if (!visited[*i]) 
74
            { 
75
                visited[*i] = true; 
76
                queue.push_back(*i); 
77
            } 
78
        } 
79
    } 
80
} 
81
?
82
// Driver program to test methods of graph class 
83
int main() 
84
{ 
85
    // Create a graph given in the above diagram 
86
    Graph g(4); 
87
    g.addEdge(0, 1); 
88
    g.addEdge(0, 2); 
89
    g.addEdge(1, 2); 
90
    g.addEdge(2, 0); 
91
    g.addEdge(2, 3); 
92
    g.addEdge(3, 3); 
93
?
94
    cout << "Following is Breadth First Traversal "
95
        << "(starting from vertex 2) \n"; 
96
    g.BFS(2); 
97
?
98
    return 0; 
99
} 