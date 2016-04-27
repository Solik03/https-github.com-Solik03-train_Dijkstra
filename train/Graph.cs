using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    class Graph // класс Граф содержит карту вершин и узлов. 
    {
        public Dictionary<Vertex, List<Bone>> nodes = new Dictionary<Vertex, List<Bone>>();
        public Dictionary<int, Vertex> vert = new Dictionary<int, Vertex>();
        public void addVert(int v)
        {
            if (vert.ContainsKey(v))
                return;
            else
            {
                Vertex a = new Vertex(v);
                vert.Add(v, a);
                nodes.Add(a, new List<Bone>());
            }
        }
        public void AddNode(Vertex node, List<Bone> bones)
        {
            nodes.Add(node, bones);
        }
        public void addBone(int from, int to, float cost, DateTime ArrivalTime, DateTime DepartureTime)
        {
            nodes[vert[from]].Add(new Bone(from, vert[to], cost, ArrivalTime, DepartureTime));
        }
    }
}
