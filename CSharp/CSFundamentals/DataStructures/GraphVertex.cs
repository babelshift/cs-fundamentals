using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals.DataStructures
{
    public class GraphVertex
    {
        public int Number { get; private set; }

        private List<GraphEdge> edges = new List<GraphEdge>();
        public IReadOnlyCollection<GraphEdge> Edges { get { return edges; } }

        public GraphVertex(int number)
        {
            Number = number;
        }

        /// <summary>
        /// Adds a connecting edge to the vertex. Does nothing if the edge is null or if the vertex is already connected
        /// to an edge with the same number.
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(GraphEdge edge)
        {
            // don't add null edges
            if (edge == null)
                return;
            // don't add duplicates
            if (edges.Any(e => e.Number == edge.Number))
                return;

            edge.AddVertex(this);
            edges.Add(edge);
        }
    }
}
