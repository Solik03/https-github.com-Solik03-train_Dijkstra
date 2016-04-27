using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace train
{
    class Program
    {
        static void Main(string[] args)
        {
            Parse parse= new Parse("data.xml");
            StreamWriter sw = new StreamWriter("train.txt", false, System.Text.Encoding.Default); //файл для записи результатов
            List<_train> tr = new List<_train>();
            Graph graph = new Graph();
            parse.addGraph(tr);
            parse.addBone(tr, graph);
            foreach (Vertex i in graph.nodes.Keys)
            {
                Dijkstra.dijkstra(graph, i, "cost", sw);// алгоритм по цене
            }
            foreach (Vertex i in graph.nodes.Keys)
            {
                Dijkstra.dijkstra(graph, i, "time", sw);//алгоритм по времени в пути
            }
            foreach (Vertex i in graph.nodes.Keys)
            {
                Dijkstra.dijkstra(graph, i, "time*cost", sw);//алгоритм цена * время в пути
            }
            sw.Close();
        }
    }
}
