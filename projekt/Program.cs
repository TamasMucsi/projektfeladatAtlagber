using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("atlagber.csv", encoding:Encoding.UTF8);
            string fejlec = sr.ReadLine();
            List<beolvas>Adatok = new List<beolvas>();
            while (!sr.EndOfStream) {
             Adatok.Add(new beolvas(sr.ReadLine()));
            }




        }
    }
}
