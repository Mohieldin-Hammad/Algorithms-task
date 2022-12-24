using System;


class primsMST
{
    // Number of vertices
    static int V = 5;

    public static void Main()
    {
        /* Let us create the following graph
        2 3
        (0)--(1)--(2)
        | / \ |
        6| 8/ \5 |7
        | / \ |
        (3)-------(4)
            9 */

        int[,] graph =
        new int[,]  { { 0, 2, 0, 6, 0 },
                      { 2, 0, 3, 8, 5 },
                      { 0, 3, 0, 0, 7 },
                      { 6, 8, 0, 0, 9 },
                      { 0, 5, 7, 9, 0 } };

        // Another graph for testing
        //new int[,]  { {  0,  9, 75,  0,  0},
        //              {  9,  0, 95, 19, 42},
        //              { 75, 95,  0, 51, 66},
        //              {  0, 19, 51,  0, 31},
        //              {  0, 42, 66, 31,  0} };

        primMST(graph);
        Console.ReadKey();
    }


    static void primMST(int[,] graph)
    {
        int[] parent = new int[V];
        int[] key = new int[V];
        bool[] mstSet = new bool[V];

        // Initialize all keys
        // as INFINITE
        for (int i = 0; i < V; i++)
        {
            key[i] = int.MaxValue;   // ----> represent infinity oo
            mstSet[i] = false;
        }

        key[0] = 0;
        parent[0] = -1;
        for (int count = 0; count < V - 1; count++)
        {
            // Pick thd minimum key vertex
            int u = minKey(key, mstSet);
            mstSet[u] = true;
            for (int v = 0; v < V; v++)
                if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                {
                    parent[v] = u;
                    key[v] = graph[u, v];
                }
        }
        printMST(parent, graph);
    }


    static int minKey(int[] key, bool[] mstSet)
    {
        int min = int.MaxValue, min_index = -1;
        for (int v = 0; v < V; v++)
            if (mstSet[v] == false && key[v] < min)
            {
                min = key[v];
                min_index = v;
            }
        return min_index;
    }


    static void printMST(int[] parent, int[,] graph)
    {
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < V; i++)
            Console.WriteLine(parent[i] + " - " + i + "\t"
                              + graph[i, parent[i]]);
    }


}