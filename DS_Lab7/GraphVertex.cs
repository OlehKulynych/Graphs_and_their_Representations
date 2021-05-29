using System;
using System.Collections.Generic;

namespace DS_Lab7
{
    public class GraphVertex 
    {

        public string Name { get; }

        public List<GraphEdge> Edges { get; }

        public GraphVertex(string vertexName)
        {
            Name = vertexName;
            Edges = new List<GraphEdge>();
        }

        public void AddEdge(GraphEdge newEdge)
        {
            Edges.Add(newEdge);
        }

        public void AddEdge(string edgeName, GraphVertex vertexStart, GraphVertex vertexEnd)
        {
            AddEdge(new GraphEdge(edgeName, vertexStart, vertexEnd));
        }


        public override string ToString() => Name;
    }

}
