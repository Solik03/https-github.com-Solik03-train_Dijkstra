using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    class Dijkstra // Реализация алгоритма (Находит кратчайшие пути от одной из вершин графа до всех остальных)
    {
        static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }
        static public double SubtractTime(DateTime date1, DateTime date2)
        {
            double time1 = ConvertToUnixTimestamp(date1);
            double time2 = ConvertToUnixTimestamp(date2);
            return time1 = time1 - time2;
        }
        static public void dijkstra(Graph graph, Vertex vertex, string param, StreamWriter sw)
        {
            List<Vertex> pq = new List<Vertex>();
            vertex.Koef = 0;
            vertex.Prev = vertex;
            foreach (Vertex z in graph.nodes.Keys)
            {
                pq.Add(z);
            }
            while (pq.Count != 0)
            {
                Vertex current = pq.Min();
                pq.Remove(current);
                foreach (Bone b in graph.nodes[current])

                {
                    if (param == "cost")
                    {
                        b.Weight = b.Cost;
                    }
                    if (current.Koef != 0 && param != "cost")
                    {
                        if (current.ArrTime < b.Arrtime)
                            current.ArrTime = current.ArrTime.AddDays(1);
                        b.Weight = SubtractTime(current.ArrTime, b.Arrtime) / 60;
                    }
                    if (current.Koef == 0 && param != "cost")
                    {
                        b.Weight = SubtractTime(b.Arrtime, b.Deptime) / 60;
                    }
                    if (param == "time*cost")
                    {
                        b.Weight = b.Cost * b.Weight;
                    }
                    if (b.NodeSec.Koef > b.Weight + current.Koef)
                    {
                        b.NodeSec.Koef = b.Weight + current.Koef;
                        b.NodeSec.Prev = current;
                        b.NodeSec.ArrTime = b.Arrtime;
                    }
                }
            }
            // Запись данных в файл train.txt
            if (param == "cost")
            {
                sw.WriteLine("Лучший путь по цене!");
            }
            if (param == "time")
            {
                sw.WriteLine("Лучший путь по времени поездки(включая ожидания на станции)! Coefficient в мин. ");
            }
            if (param == "time*cost")
            {
                sw.WriteLine("Лучший путь по времени и стоимости поездки! (Coefficient = cost * time ) ");
            }
            foreach (Vertex a in graph.vert.Values)
            {
                Vertex cur = a;
                List<Vertex> arr = new List<Vertex>();
                StringBuilder sb = new StringBuilder();
                if (a.Koef == 0)
                {
                    arr.Add(vertex);
                    continue;
                }
                try
                {
                    while (cur.Prev != vertex)
                    {
                        arr.Add(cur);
                        cur = cur.Prev;
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(" The station is not connected (Error Bone) " + e.Message);
                }
                arr.Add(cur);
                arr.Add(cur.Prev);
                arr.Reverse();
                a.Koef = Math.Round(a.Koef, 2);
                foreach (Vertex ver in arr)
                {
                    sw.Write(ver.ToString() + " -> ");
                }
                sw.WriteLine("Coefficient = " + a.Koef.ToString());
            }
            foreach (Vertex z in graph.nodes.Keys)// перезаписываем Koef = ∞ 
            {
                z.Koef = float.MaxValue;
            }
        }
    }
}
