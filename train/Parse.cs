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
    class Parse //класс для парсинга data.xml
    {
        string path;

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public Parse(string path)
        {
            this.Path = path;
        }
        public List<_train> addGraph(List<_train> tr)
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(Path);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(" In the derectory not file " + e.Message);
            }
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут 
                if (xnode.Attributes.Count > 0)
                {
                    int id = int.Parse(xnode.Attributes["TrainId"].Value);
                    int Depid = int.Parse(xnode.Attributes["DepartureStationId"].Value);
                    int Arrid = int.Parse(xnode.Attributes["ArrivalStationId"].Value);
                    string price1 = xnode.Attributes["Price"].Value;
                    float price = Convert.ToSingle(price1, new CultureInfo("en-US"));
                    DateTime arrtime = DateTime.Parse(xnode.Attributes["ArrivalTimeString"].Value);
                    DateTime deptime = DateTime.Parse(xnode.Attributes["DepartureTimeString"].Value);
                    if (arrtime < deptime)
                    {
                        arrtime = arrtime.AddDays(1);
                    }
                    tr.Add(new _train(id, Depid, Arrid, price, arrtime, deptime));
                }

            }
            return tr;
        }
        public void addBone(List<_train> tr, Graph graph)
        {
            foreach (_train i in tr)
            {
                graph.addVert(i.DepartureStationId1);
                graph.addVert(i.ArrivalStationId1);
                graph.addBone(i.DepartureStationId1, i.ArrivalStationId1, i.Price1, i.ArrivalTimeString1, i.DepartureTimeString1);
            }
        }

    }
}
