using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    public class GraphEdge
    {
        private List<GraphVertex> vertices = new List<GraphVertex>();
        public IReadOnlyCollection<GraphVertex> Vertices { get { return vertices; } }

        public int Number { get; private set; }
        public int Cost { get; private set; }

        public GraphEdge(int number, int cost)
        {
            Number = number;
            Cost = cost;
        }

        /// <summary>
        /// Adds a vertex to this edge's collection of vertices. Does nothing if the vertex is null or the edge is already connected
        /// to a vertex with the same number.
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
    }
}
