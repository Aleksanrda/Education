using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba4._2
{
    public class Graph
    {
        private int v;
        private LinkedList<int>[] adjacencyList;

        public Graph(int v)
        {
            this.v = v;
            adjacencyList = new LinkedList<int>[this.v];

            for (int i = 0; i < v; ++i)
            {
                adjacencyList[i] = new LinkedList<int>();
            }

        }

        public void AddEdge(int v, int w)
        {
            adjacencyList[v].AddLast(w);
            adjacencyList[w].AddLast(v);
        }

        public bool IsCyclic()
        {
            bool[] visited = new bool[v];

            for(int i = 0; i < v; i++)
            {
                visited[i] = false;
            }

            for(int j = 0; j < v; j++)
            {
                if(!visited[j])
                {
                    if(IsCyclicUtil(j, visited, -1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // A recursive function that uses visited[] and parent to detect
        // cycle in subgraph reachable from vertex v.

        private bool IsCyclicUtil(int v, bool[] visited, int parent)
        {
            visited[v] = true;
            int i;

            IEnumerator<int> it = adjacencyList[v].GetEnumerator();
            while (it.MoveNext())
            {
                i = it.Current;

                // If an adjacent is not visited, then recur for that
                // adjacent
                if (!visited[i])
                {
                    if (IsCyclicUtil(i, visited, v))
                        return true;
                }

                // If an adjacent is visited and not parent of current
                // vertex, then there is a cycle.
                else if (i != parent)
                    return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a graph given in the above diagram
            Graph g1 = new Graph(5);
            g1.AddEdge(1, 0);
            g1.AddEdge(0, 2);
            g1.AddEdge(2, 0);
            g1.AddEdge(0, 3);
            g1.AddEdge(3, 4);
            if (g1.IsCyclic())
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't contains cycle");

            Graph g2 = new Graph(3);
            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);
            if (g2.IsCyclic())
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't contains cycle");
            Console.ReadKey();
        }
   
    }
}
