using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    class Bone
    {
        int nodeFirst;
        Vertex nodeSec;
        double cost;
        double weight;
        DateTime arrtime;
        DateTime deptime;
        public Bone(int _nodeFirst, Vertex _nodeSec, float _cost, DateTime _arrtime, DateTime _deptime)
        {
            nodeFirst = _nodeFirst;
            nodeSec = _nodeSec;
            Cost = _cost;
            arrtime = _arrtime;
            deptime = _deptime;
        }
        public int NodeFirst
        {
            get
            {
                return nodeFirst;
            }

            set
            {
                nodeFirst = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }

        public Vertex NodeSec
        {
            get
            {
                return nodeSec;
            }


        }

        public DateTime Arrtime
        {
            get
            {
                return arrtime;
            }

            set
            {
                arrtime = value;
            }
        }

        public DateTime Deptime
        {
            get
            {
                return deptime;
            }

            set
            {
                deptime = value;
            }
        }

        public double Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
            }
        }
    }
}
