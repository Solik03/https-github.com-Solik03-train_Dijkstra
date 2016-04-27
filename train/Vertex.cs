using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    class Vertex : IComparable //класс где хранится вершина графа
    {
        Vertex prev;
        int index;
        double koef;
        DateTime arrTime;
        public Vertex(int index1)
        {
            index = index1;
            koef = float.MaxValue;
        }
        public int Index
        {
            get
            {
                return index;
            }

        }

        public double Koef
        {
            get
            {
                return koef;
            }

            set
            {
                koef = value;
            }

        }

        public Vertex Prev
        {
            get
            {
                return prev;
            }

            set
            {
                prev = value;
            }
        }

        public DateTime ArrTime
        {
            get
            {
                return arrTime;
            }

            set
            {
                arrTime = value;
            }
        }

        public int CompareTo(object obj)
        {
            Vertex second = (Vertex)obj;
            return this.koef.CompareTo(second.koef);
        }
        public override string ToString()
        {
            return this.index.ToString();
        }
    }
}
