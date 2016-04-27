using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    class _train
    {
        int TrainId { get; set; }
        int DepartureStationId { get; set; }
        int ArrivalStationId { get; set; }
        float Price { get; set; }
        DateTime ArrivalTimeString { get; set; }
        DateTime DepartureTimeString { get; set; }

        public int TrainId1
        {
            get
            {
                return TrainId;
            }

            set
            {
                TrainId = value;
            }
        }

        public int DepartureStationId1
        {
            get
            {
                return DepartureStationId;
            }

            set
            {
                DepartureStationId = value;
            }
        }

        public int ArrivalStationId1
        {
            get
            {
                return ArrivalStationId;
            }

            set
            {
                ArrivalStationId = value;
            }
        }

        public float Price1
        {
            get
            {
                return Price;
            }

            set
            {
                Price = value;
            }
        }

        public DateTime ArrivalTimeString1
        {
            get
            {
                return ArrivalTimeString;
            }

            set
            {
                ArrivalTimeString = value;
            }
        }

        public DateTime DepartureTimeString1
        {
            get
            {
                return DepartureTimeString;
            }

            set
            {
                DepartureTimeString = value;
            }
        }
     public _train(int TrainId,
        int DepartureStationId,
        int ArrivalStationId,
        float Price,
        DateTime ArrivalTimeString,
        DateTime DepartureTimeString)
        {
            TrainId1 = TrainId;
            Price1 = Price;
            DepartureStationId1 = DepartureStationId;
            ArrivalStationId1 = ArrivalStationId;
            DepartureTimeString1 = DepartureTimeString;
            ArrivalTimeString1 = ArrivalTimeString;
        }
        public _train()
        {
        }
    }
}
