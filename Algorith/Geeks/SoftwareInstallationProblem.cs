using System;
using System.Collections.Generic;
using System.Text;

namespace Algorith.Geeks
{
  public  class SoftwareInstallationProblem
    {

        public static void Run(String[] args)
        {
            List<char> softwares = new List<char>();
            softwares.Add('A');
            softwares.Add('B');
            softwares.Add('C');
            softwares.Add('D');
            softwares.Add('E');
            softwares.Add('F');
            int vertices = softwares.Count;
            Graph graph = new Graph(vertices);
            graph.AddEdge('A', 'B', softwares);
            graph.AddEdge('A', 'C', softwares);
            //graph.AddEdge('A', 'F', softwares);
            graph.AddEdge('B', 'D', softwares);
            graph.AddEdge('B', 'E', softwares);
            graph.AddEdge('C', 'D', softwares);
            graph.AddEdge('D', 'E', softwares);
            graph.TopologicalSorting(softwares);
        }
        class Node
        {
            public char destination;
            public char source;

            public Node(char _source, char _destination)
            {
                this.source = _source;
                this.destination = _destination;
            }


        }

        class Graph
        {

            List<Node>[] adjList;
            int vertices;
            public Graph(int _vertices)
            {
                vertices = _vertices;
                adjList = new List<Node>[_vertices];
                for (int i = 0; i < _vertices; i++)
                {
                    adjList[i] = new List<Node>();

                }

            }

            public void AddEdge(char source, char destination, List<char> softwares)
            {
                Node node = new Node(source, destination);
                adjList[softwares.IndexOf(source)].Add(node);

            }

            public void TopologicalSorting(List<char> softwares)
            {
                bool[] visited = new bool[vertices];

                Stack<char> stack = new Stack<char>();

                //visit from each node if not already visited
                for (int i = 0; i < vertices; i++)
                {
                    if (!visited[i])
                    {
                        TopologicalSortUtil(softwares[i], visited, stack, softwares);

                    }
                }

                Console.WriteLine("Software Sequence");

                int size = stack.Count;

                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(stack.Pop() + " ");

                }
            }

            private void TopologicalSortUtil(char sftwr, bool[] visited, Stack<char> stack, List<char> softwares)
            {
          
                int index = softwares.IndexOf(sftwr);
                visited[index] = true;
                for (int i = 0; i < adjList[softwares.IndexOf(sftwr)].Count; i++)
                {
                    var node = adjList[index][i];
                
                    if (!visited[softwares.IndexOf(node.destination)])
                    {
                        TopologicalSortUtil(node.destination, visited, stack, softwares);

                    }
                }

                stack.Push(sftwr);
            }
        }
    }
}
