using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafFeladat_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var graf = new Graf(6);

            graf.Hozzaad(0, 1);
            graf.Hozzaad(1, 2);
            graf.Hozzaad(0, 2);
            graf.Hozzaad(2, 3);
            graf.Hozzaad(3, 4);
            graf.Hozzaad(4, 5);
            graf.Hozzaad(2, 4);

            // graf.Torol(0, 1);

            Console.WriteLine("A szélességi bejárás algoritmusa");
            graf.SzelessegiBejar(3);


            Console.WriteLine();
            Console.WriteLine("A mélységi bejárás bejárás algoritmusa");
            graf.MelysegiBejar(4);

            Console.WriteLine();
            Console.WriteLine("Összefüggőség");
            Console.WriteLine(graf.Osszefuggo(3));

            Console.WriteLine();
            Console.WriteLine("Feszítőfa");
            Console.WriteLine(graf.Feszitofa(3) + "\n");


            Console.WriteLine(graf);
            Console.ReadLine();
        }
    }
}
