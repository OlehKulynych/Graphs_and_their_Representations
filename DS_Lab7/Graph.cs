using System;
using System.Collections.Generic;
using System.Linq;

namespace DS_Lab7
{
    public class Graph
    {
        public List<GraphVertex> Vertices { get; }

        public List<GraphEdge> Edges { get; set; }

        public int[,] AdjacencyMatrix { get; set; }

        public int[,] IncidenceMatrix { get; set; }
        public bool IsOrientedGraph { get; }

        public Graph(bool isOrientedGraph)
        {
            Vertices = new List<GraphVertex>();
            Edges = new List<GraphEdge>();
            IsOrientedGraph = isOrientedGraph;
            AdjacencyMatrix = new int[,] { };
            IncidenceMatrix = new int[,] { };
        }

        public Graph(int[,] adjacencyMatrix, int size, bool isOrientedGraph)
        {
            Vertices = new List<GraphVertex>();
            Edges = new List<GraphEdge>();
            IsOrientedGraph = isOrientedGraph;
            AdjacencyMatrix = new int[,] { };
            IncidenceMatrix = new int[,] { };

            FillGraphFromAdjacencyMatrix(adjacencyMatrix, size);
            FillMatrix(adjacencyMatrix, AdjacencyMatrix, size, size);
            FillIncidenceMatrixFromEdgesList();
        }

        public void AddVertex(string vertexName)
        {
            Vertices.Add(new GraphVertex(vertexName));
        }


        private void FillGraphFromAdjacencyMatrix(int[,] adjacencyMatrix, int size)
        {
            Vertices.Clear();
            Edges.Clear();

            for (int i = 0; i < size; i++)
            {
                AddVertex($"v{i + 1}");
            }

            int e = 1;

            if (IsOrientedGraph)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (adjacencyMatrix[i, j] == 1)
                        {
                            Vertices[i].AddEdge($"e{j + 1}", Vertices[i], Vertices[j]);
                            GraphEdge temp = new GraphEdge($"e{e}", Vertices[i], Vertices[j]);
                            Edges.Add(temp);
                            e++;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        if (adjacencyMatrix[i, j] == 1)
                        {
                            Vertices[i].AddEdge($"e{j + 1}", Vertices[i], Vertices[j]);
                            GraphEdge temp = new GraphEdge($"e{e}", Vertices[i], Vertices[j]);
                            Edges.Add(temp);
                            e++;
                        }
                    }
                }
            }
        }

        private void FillMatrix(int[,] inputMatrix, int[,] changeMatrix, int row, int column)
        {
            if (changeMatrix == null) throw new ArgumentNullException(nameof(changeMatrix));

            changeMatrix = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    changeMatrix[i, j] = inputMatrix[i, j];
                }
            }
        }

        private void FillIncidenceMatrixFromEdgesList()
        {
            IncidenceMatrix = new int[Vertices.Count, Edges.Count];

            if (IsOrientedGraph)
            {
                for (int i = 0; i < Vertices.Count; i++)
                {
                    for (int j = 0; j < Edges.Count; j++)
                    {
                        if (Vertices[i].Equals(Edges[j].ConnectedVertexStart) && Vertices[i].Equals(Edges[j].ConnectedVertexEnd))
                        {
                            IncidenceMatrix[i, j] = 2;
                        }
                        else if (Vertices[i].Equals(Edges[j].ConnectedVertexStart))
                        {
                            IncidenceMatrix[i, j] = -1;
                        }
                        else if (Vertices[i].Equals(Edges[j].ConnectedVertexEnd))
                        {
                            IncidenceMatrix[i, j] = 1;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Vertices.Count; i++)
                {
                    for (int j = 0; j < Edges.Count; j++)
                    {
                        if (Vertices[i].Equals(Edges[j].ConnectedVertexStart) && Vertices[i].Equals(Edges[j].ConnectedVertexEnd))
                        {
                            IncidenceMatrix[i, j] = 2;
                        }
                        else if (Vertices[i].Equals(Edges[j].ConnectedVertexStart) || Vertices[i].Equals(Edges[j].ConnectedVertexEnd))
                        {
                            IncidenceMatrix[i, j] = 1;
                        }
                    }
                }
            }
        }

        public void PrintEdgesList()
        {
            if (Edges.Count != 0)
            {
                foreach (var i in Edges)
                {
                    Console.Write($"{i} : ");
                    Console.WriteLine($"{i.ConnectedVertexStart}, {i.ConnectedVertexEnd}");
                }
            }
            else
            {
                Console.WriteLine("The adjacency matrix is not filled.");
            }
            Console.Write("\n");
        }

        public void PrintIncidenceMatrix()
        {
            try
            {
                Console.Write(new String(' ', Vertices.Last().Name.Length + 6));
                for (int i = 0; i < Edges.Count; i++)
                {
                    Console.Write($"{Edges[i],4}");
                }
                Console.Write("\n");            
                Console.WriteLine(new String('-', Vertices.Last().Name.Length + 7 + Edges.Count * 4));
                for (int i = 0; i < Vertices.Count; i++)
                {
                    Console.Write($"|{Vertices[i],4} |");

                    for (int j = 0; j < Edges.Count; j++)
                    {
                        Console.Write($"{IncidenceMatrix[i, j],4}");
                    }

                    Console.WriteLine(" |");
                }
                Console.WriteLine(new String('-', Vertices.Last().Name.Length + 7 + Edges.Count * 4));

            }
            catch (Exception)
            {
                Console.WriteLine("The adjacency matrix is not filled.");
            }
        }
    }

}
