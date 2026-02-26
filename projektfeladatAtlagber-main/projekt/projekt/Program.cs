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
             //2. feladat Mucsi Tamás
            Console.WriteLine($"2. feladat: Összesen {Adatok.Count()} év adatait tartalmazza a lista");




            //4. feladat Mucsi Tamás

            int szamlalo = 0;

            foreach (var item in Adatok)
            {
                if (item.benzin92 != 0) {
                szamlalo++;
                }
            }
            Console.WriteLine($"4. feladat: {szamlalo} évig volt elérhető a 92-es üzemanyag");




            //6. feladat Mucsi Tamás
            var rendezett = Adatok.OrderBy(x => x.ev).ToList();
            Console.WriteLine($"6. feladat\n" +
                $"\tMinimálbérből {Math.Round((Adatok.First().minimalber/Adatok.First().gazolaj),2)} liter gázolajat lehetett vásárolni\n" +
                $"\tÁtlagbérből {Math.Round((Adatok.First().bruttoatlagjovedelem / Adatok.First().benzin86), 2)} liter 86-ost vagy {Math.Round((Adatok.First().bruttoatlagjovedelem / Adatok.First().benzin92), 2)} liter 92-est vagy {Math.Round((Adatok.First().bruttoatlagjovedelem / Adatok.First().gazolaj), 2)} liter gázolajat lehetett vásárolni\n" +
                $"\tA minimálbér {Adatok.First().ev}-ben az átlagbér {Math.Round((Convert.ToDouble(Adatok.First().minimalber) / Convert.ToDouble(Adatok.First().bruttoatlagjovedelem)), 2) * 100}%-a volt");



            //8. feladat Mucsi Tamás
            Console.WriteLine("8. feladat:");
            foreach (var item in rendezett)
            {
                if (item.benzin95 != 0)
                {
                    if (item.gazolaj > item.benzin95)
                    {
                        Console.WriteLine($"\t{item.ev} évben volt drágább a gázolaj");
                    }
                }
            }

            // 9. feladat Popány Dávid
            Console.WriteLine("9. feladat:");
            double elozoev_g = Adatok[0].gazolaj;
            foreach (var item in Adatok)
            {
                if (item.gazolaj < elozoev_g)
                {
                    Console.WriteLine($"\t{item.ev}-ben csökkent a gázolaj ára.");
                    
                }
                elozoev_g = item.gazolaj;
            }
            double elozoev_b = Adatok[0].benzin95;
            foreach (var item in Adatok)
            {
                if (item.benzin95 < elozoev_b)
                {
                    Console.WriteLine($"\t{item.ev}-ben csökkent a 95-ös benzin ára.");

                }
                elozoev_b = item.benzin95;
            }


            //10. feladat Mucsi Tamás

            int ev = 0;
            double kulonbseg = 100;
            foreach (var item in Adatok)
            {
                if (item.benzin95 != 0)
                {

                    if ((item.benzin95 - item.gazolaj < kulonbseg) && (item.benzin95 > item.gazolaj))
                    {
                        ev = item.ev;
                        kulonbseg = item.benzin95 - item.gazolaj;
                    }
                }
            }
            Console.WriteLine($"10. feladat: A legkisebb különbség éve: {ev}, a különbség: {Math.Round(kulonbseg,2)} Ft");



            Console.ReadKey();
        }
    }
}
