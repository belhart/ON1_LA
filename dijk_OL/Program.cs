using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dijk_OL
{
    class GFG
    {
        private static readonly int NO_PARENT = -1;
        public void dijkstra(int[,] adjacencyMatrix, int startVertex, int dstVertex)
        {
            int nVertices = adjacencyMatrix.GetLength(0);
            int[] shortestDistances = new int[nVertices];
            bool[] added = new bool[nVertices];
            for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
            {
                shortestDistances[vertexIndex] = int.MaxValue;
                added[vertexIndex] = false;
            }  
            shortestDistances[startVertex] = 0;
            int[] parents = new int[nVertices]; 
            parents[startVertex] = NO_PARENT; 
            for (int i = 1; i < nVertices; i++)
            {
                int nearestVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
                {
                    if (!added[vertexIndex] && shortestDistances[vertexIndex] < shortestDistance)
                    {
                        nearestVertex = vertexIndex;
                        shortestDistance = shortestDistances[vertexIndex];
                    }
                }
                added[nearestVertex] = true;
                for (int vertexIndex = 0; vertexIndex < nVertices; vertexIndex++)
                {
                    int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];
                    if (edgeDistance > 0 && ((shortestDistance + edgeDistance) < shortestDistances[vertexIndex]))
                    {
                        parents[vertexIndex] = nearestVertex;
                        shortestDistances[vertexIndex] = shortestDistance + edgeDistance;
                    }
                }
            }

            printSolution(startVertex, shortestDistances, parents, dstVertex);
        } 
        private static void printSolution(int startVertex, int[] distances, int[] parents, int dstVertex)
        {
            Console.WriteLine("star and end node : " + (startVertex + 1 )+ " -> " + (dstVertex + 1));
            Console.Write("shortest path value: " + distances[dstVertex] + "\nusing nodes in order: ");
            printPath(dstVertex, parents);
        }  
        private static void printPath(int currentVertex, int[] parents)
        {  
            if (currentVertex == NO_PARENT)
            {
                return;
            }
            printPath(parents[currentVertex], parents);
            Console.Write((currentVertex+1) + " ");
        }

        public static void Main()
        {
            int[,] graph = FileManager.ReadFromFile("airportconnections.txt");
            GFG t = new GFG();
            Console.Write("Source node: ");
            int srcNode = int.Parse(Console.ReadLine());
            Console.Write("Destination node: ");
            int dstNode = int.Parse(Console.ReadLine());
            t.dijkstra(graph, srcNode-1 , dstNode-1);
            Console.ReadLine();
        }
    }
}