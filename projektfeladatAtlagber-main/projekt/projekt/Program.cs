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


            // 3. Feladat Tóth Dániel
            foreach (var item in Adatok)
            {
                if (item.benzin95 != 0)
                {
                    Console.WriteLine($"3. Feladat: {item.ev}-től volt elérhető a 95ös üzemanyag.");
                    break;
                }
            }
            
            //4. feladat Mucsi Tamás

            int szamlalo = 0;

            foreach (var item in Adatok)
            {
                if (item.benzin92 != 0) {
                szamlalo++;
                }
            }
            Console.WriteLine($"4. feladat: {szamlalo} évig volt elérhető a 92-es üzemanyag");

            // 5. Feladat Tóth Dániel
            Console.WriteLine("5. Feladat: A 86-os benzin a következő években volt elérhető:");
            foreach (var item in Adatok)
            {
                if (item.benzin86 != 0)
                {
                    Console.WriteLine($"\t {item.ev}");
                }
            }


            //6. feladat Mucsi Tamás
            var rendezett = Adatok.OrderBy(x => x.ev).ToList();
            Console.WriteLine($"6. feladat\n" +
                $"\tMinimálbérből {Math.Round((Adatok.First().minimalber/Adatok.First().gazolaj),2)} liter gázolajat lehetett vásárolni\n" +
                $"\tÁtlagbérből {Math.Round((Adatok.First().bruttoatlagjovedelem / Adatok.First().benzin86), 2)} liter 86-ost vagy {Math.Round((Adatok.First().bruttoatlagjovedelem / Adatok.First().benzin92), 2)} liter 92-est vagy {Math.Round((Adatok.First().bruttoatlagjovedelem / Adatok.First().gazolaj), 2)} liter gázolajat lehetett vásárolni\n" +
                $"\tA minimálbér {Adatok.First().ev}-ben az átlagbér {Math.Round((Convert.ToDouble(Adatok.First().minimalber) / Convert.ToDouble(Adatok.First().bruttoatlagjovedelem)), 2) * 100}%-a volt");

             // 7. Feladat Tóth Dániel
            
             int legdragabb95 = 1;
             int legolcsobb95 = 1000000;
             int legdragabbev = 1;
             int legolcsobbev = 1;
            
            
             Console.WriteLine($"7. Feladat: ");
             foreach (var item in Adatok)
             {
                 if (item.benzin95 != 0) {
                     if (legdragabb95 < item.minimalber / item.benzin95)
                     {
                         legdragabb95 = item.minimalber / Convert.ToInt32(item.benzin95);
                         legdragabbev = item.ev;
                     }
            
                     if (legolcsobb95 > item.minimalber / item.benzin95)
                     {
                         legolcsobb95 = item.minimalber / Convert.ToInt32(item.benzin95);
                         legolcsobbev = item.ev;
                     }
                 }
            
             }
             Console.WriteLine($"{legdragabbev}-évben volt a legalacsonyabb az üzemanyagár a minimálbérhez viszonyítva ({legdragabb95} liter)");
             Console.WriteLine($"{legolcsobbev}-évben volt a legdrágább az üzemanyagár a minimálbérhez viszonyítva ({legolcsobb95} liter)");
            
             int atl_legdragabb95 = 1;
             int atl_legolcsobb95 = 1000000;
             int atl_legdragabbev = 1;
             int atl_legolcsobbev = 1;
            
            
             foreach (var item in Adatok)
             {
                 if (item.benzin95 != 0)
                 {
                     if (atl_legdragabb95 < item.bruttoatlagjovedelem / item.benzin95)
                     {
                         atl_legdragabb95 = item.bruttoatlagjovedelem / Convert.ToInt32(item.benzin95);
                         atl_legdragabbev = item.ev;
                     }
            
                     if (atl_legolcsobb95 > item.bruttoatlagjovedelem / item.benzin95)
                     {
                         atl_legolcsobb95 = item.bruttoatlagjovedelem / Convert.ToInt32(item.benzin95);
                         atl_legolcsobbev = item.ev;
                     }
                 }
            
             }
             Console.WriteLine($"{atl_legdragabbev}-évben volt a legalacsonyabb az üzemanyagár a átlagbérhez viszonyítva ({atl_legdragabb95} liter)");
             Console.WriteLine($"{atl_legolcsobbev}-évben volt a legdrágább az üzemanyagár a átlagbérhez viszonyítva ({atl_legolcsobb95} liter)");
            
             var szazalek = Adatok.Find(x => x.ev == atl_legdragabbev);
             Console.WriteLine($"{atl_legdragabbev}-évben az átlagbér {Math.Round((Convert.ToDouble(szazalek.minimalber) / Convert.ToDouble(szazalek.bruttoatlagjovedelem) * 100),2)}-a volt a minimálbér.");


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

