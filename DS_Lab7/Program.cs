using System;
using System.Collections.Generic;
namespace DS_Lab7
{


    class Program
    {
        static void FillArray(int[,] array, int row, int column)
        {
            List<int> result = new List<int>();
            List<string> inpArrayList = new List<string>();
            char[] separators = { ' ', '.', ',', '\n' };
            int tempNumber;

            while (result.Count < row * column)
            {
                inpArrayList.Clear();
                inpArrayList.AddRange(Console.ReadLine()?.Split(separators, StringSplitOptions.RemoveEmptyEntries) ?? throw new InvalidOperationException());

                foreach (var j in inpArrayList)
                {
                    if (Int32.TryParse(j, out tempNumber) && (tempNumber == 0 || tempNumber == 1))
                    {
                        result.Add(tempNumber);
                    }
                }
            }

            int counter = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = result[counter];
                    counter++;
                }
            }
        }

        static void StartProgram()
        {
            Graph graph = new Graph(false);
            int sizeAdjacencyMatrix;
            int[,] inputAdjacencyMatrix;
            bool isOrientedGraph;

            bool isStart = true;

            while (isStart)
            {

                while (true)
                {
                    try
                    {
                        Console.Write("Enter size of array: ");
                        sizeAdjacencyMatrix = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error input...");

                    }
                }


                while (true)
                {
                    try
                    {
                        int n;
                        Console.Write("Is oriented graph: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        if (n == 0)
                        {
                            isOrientedGraph = false;
                        }
                        else if (n == 1)
                        {
                            isOrientedGraph = true;
                        }
                        else
                        {
                            throw new Exception();
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error input...");

                    }
                }

                inputAdjacencyMatrix = new int[sizeAdjacencyMatrix, sizeAdjacencyMatrix];

                Console.WriteLine("Fill adjacency matrix:");
                FillArray(inputAdjacencyMatrix, sizeAdjacencyMatrix, sizeAdjacencyMatrix);

                graph = new Graph(inputAdjacencyMatrix, sizeAdjacencyMatrix, isOrientedGraph);


                Console.WriteLine("\nIncidence matrix: ");

                graph.PrintIncidenceMatrix();


                Console.WriteLine("\nEdges list");

                graph.PrintEdgesList();

                Console.WriteLine("Do u want continue? \n 1 - Yes\n Another number to exit");
                Console.Write("Enter number: ");
                try
                {
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num == 1)
                    {
                        isStart = true;
                        Console.Write("\n");
                    }
                    else
                    {
                        isStart = false;
                    }
                }
                catch (Exception)
                {
                    isStart = false;
                }
            }
        }


        static void Main(string[] args)
        {
            StartProgram();
        }
    }
}
