using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    internal class beolvas
    {
        public int ev { get; set; }
        public int minimalber { get; set; }
        public int bruttoatlagjovedelem { get; set; }
        public double benzin86 { get; set; }
        public double benzin91 { get; set; }
        public double benzin92 { get; set; }
        public double benzin95 { get; set; }
        public double gazolaj { get; set; }

        public beolvas(string sor)
        {
            string[] darabol = sor.Split(';');
            ev = Convert.ToInt32(darabol[0]);
            minimalber = Convert.ToInt32(darabol[1]);
            bruttoatlagjovedelem = Convert.ToInt32(darabol[2]);
            benzin86 = Convert.ToDouble(darabol[3]);
            benzin91 = Convert.ToDouble(darabol[4]);
            benzin92 = Convert.ToDouble(darabol[5]);
            benzin95 = Convert.ToDouble(darabol[6]);
            gazolaj = Convert.ToDouble(darabol[7]);
        }

    }
}
