namespace dijk_OL
{
    using System.IO;
    using System.Security.Cryptography;

    class FileManager
    {
        public static int[,] ReadFromFile(string fileName)
        {
            string[] allLines = File.ReadAllLines(fileName);
            int nodes = int.Parse(allLines[0]);
            int[,] graph = new int[nodes, nodes];
            for (int i = 1; i < allLines.Length; i++)
            {
                int sourceNode = int.Parse(allLines[i].Split(';')[0])-1;
                int destinationNode = int.Parse(allLines[i].Split(';')[1])-1;
                int edgeValue = int.Parse(allLines[i].Split(';')[2]);
                graph[sourceNode, destinationNode] = edgeValue;
                graph[destinationNode, sourceNode] = edgeValue;
            }
            return graph;
        }
    }
}
