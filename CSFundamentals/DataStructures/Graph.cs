using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    public class Graph
    {
        private int connectingEdgeCount = 0;

        private List<GraphVertex> vertices = new List<GraphVertex>();

        public IReadOnlyCollection<GraphVertex> Vertices { get { return vertices; } }
        public int VertexCount { get { return vertices.Count; } }
        public int ConnectingEdgeCount { get { return connectingEdgeCount; } }

        /// <summary>
        /// Adds the vertex to the graph. Does nothing if the vertex is null or if a vertex with the same number is already in the graph.
        /// </summary>
        /// <param name="vertex"></param>
        public void AddVertex(GraphVertex vertex)
        {
            // don't add null vertices
            if (vertex == null)
                return;
            // don't add duplicate vertices
            if (vertices.Any(v => v.Number == vertex.Number))
                return;
            vertices.Add(vertex);
        }

        /// <summary>
        /// Adds a connecting edge with a cost to two vertices identified by the passed numbers. Does nothing if the vertices do not already exist
        /// in the graph.
        /// </summary>
        /// <param name="vertexNumber1"></param>
        /// <param name="vertexNumber2"></param>
        /// <param name="cost"></param>
        public void AddConnectingEdge(int vertexNumber1, int vertexNumber2, int cost)
        {
            GraphEdge newEdge = new GraphEdge(connectingEdgeCount, cost);

            // might need to improve these lookups, they're probably O(n)
            GraphVertex vertex1 = vertices.FirstOrDefault(v => v.Number == vertexNumber1);
            if (vertex1 == null)
                return;

            GraphVertex vertex2 = vertices.FirstOrDefault(v => v.Number == vertexNumber2);
            if (vertex2 == null)
                return;

            vertex1.AddEdge(newEdge);
            vertex2.AddEdge(newEdge);

            connectingEdgeCount++;
        }
    }
}
