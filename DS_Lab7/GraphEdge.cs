using System;
namespace DS_Lab7
{
    public class GraphEdge
    {
        public string Name { get; }

        public GraphVertex ConnectedVertexStart { get; }
        public GraphVertex ConnectedVertexEnd { get; }
        public GraphEdge(string edgeName, GraphVertex connectedVertexStart, GraphVertex connectedVertexEnd)
        {
            Name = edgeName;
            ConnectedVertexStart = connectedVertexStart;
            ConnectedVertexEnd = connectedVertexEnd;
        }

        public override string ToString() => Name;
    }

}
