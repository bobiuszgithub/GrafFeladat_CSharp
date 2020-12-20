using System;
using System.Collections.Generic;

namespace GrafFeladat_CSharp
{
    /// <summary>
    /// Irányítatlan, egyszeres gráf.
    /// </summary>
    class Graf
    {
        int csucsokSzama;
        /// <summary>
        /// A gráf élei.
        /// Ha a lista tartalmaz egy(A, B) élt, akkor tartalmaznia kell
        /// a(B, A) vissza irányú élt is.
        /// </summary>
        readonly List<El> elek = new List<El>();
        /// <summary>
        /// A gráf csúcsai.
        /// A gráf létrehozása után új csúcsot nem lehet felvenni.
        /// </summary>
        readonly List<Csucs> csucsok = new List<Csucs>();

        /// <summary>
        /// Létehoz egy úgy, N pontú gráfot, élek nélkül.
        /// </summary>
        /// <param name="csucsok">A gráf csúcsainak száma</param>
        public Graf(int csucsok)
        {
            this.csucsokSzama = csucsok;

            // Minden csúcsnak hozzunk létre egy új objektumot
            for (int i = 0; i < csucsok; i++)
            {
                this.csucsok.Add(new Csucs(i));
            }
        }

        /// <summary>
        /// Hozzáad egy új élt a gráfhoz.
        /// Mindkét csúcsnak érvényesnek kell lennie:
        /// 0 &lt;= cs &lt; csúcsok száma.
        /// </summary>
        /// <param name="cs1">Az él egyik pontja</param>
        /// <param name="cs2">Az él másik pontja</param>
        public void Hozzaad(int cs1, int cs2)
        {
            if (cs1 < 0 || cs1 >= csucsokSzama ||
                cs2 < 0 || cs2 >= csucsokSzama)
            {
                throw new ArgumentOutOfRangeException("Hibas csucs index");
            }

            // Ha már szerepel az él, akkor nem kell felvenni
            foreach (var el in elek)
            {
                if (el.Csucs1 == cs1 && el.Csucs2 == cs2)
                {
                    return;
                }
            }

            elek.Add(new El(cs1, cs2));
            elek.Add(new El(cs2, cs1));
        }


        public void Torol(int cs1, int cs2)
        {
            //El e1 = new El(cs1, cs2);
            //El e2 = new El(cs2, cs1);
            //elek.Remove(e1);
            //elek.Remove(e2);

            //int index = 0;
            //int index2 = 0;
            //for (int i = 0; i < elek.Count; i++)
            //{
            //    if (elek[i] == e1)
            //    {
            //        index = i;
            //    }
            //    if (elek[i] == e2)
            //    {
            //        index2 = i;
            //    }
            //}

            //elek.RemoveAt(index);
            //elek.RemoveAt(index2);
        }


        public void SzelessegiBejar(int kezdopont)
        {
            //Kezdetben egy pontot sem jártunk be
            HashSet<int> bejart = new HashSet<int>();


            // A következőnek vizsgált elem a kezdőpont
            Queue<int> kovetkezok = new Queue<int>();
            kovetkezok.Enqueue(kezdopont);
            bejart.Add(kezdopont);



            // Amíg van következő, addig megyünk
            //Ciklus amíg következők nem üres:
            while (kovetkezok.Count > 0)
            {
                // A sor elejéről vesszük ki
                kezdopont = kovetkezok.Dequeue();

            }

            // Elvégezzük a bejárási műveletet, pl. a konzolra kiírást:
            Console.WriteLine(this.csucsok[kezdopont]);


            foreach (var item in this.elek)
            {
                // Megkeressük azokat az éleket, amelyek k-ból indulnak
                // Ha az él másik felét még nem vizsgáltuk, akkor megvizsgáljuk
                if (item.Csucs1 == kezdopont && !bejart.Contains(item.Csucs2))
                {
                    kovetkezok.Enqueue(item.Csucs2);
                    bejart.Add(item.Csucs2);
                }
            }
            // Jöhet a sor szerinti következő elem


        }


        public void MelysegiBejar(int kezdopont)
        {
            HashSet<int> bejart = new HashSet<int>();


            Stack<int> kovetkezok = new Stack<int>();
            kovetkezok.Push(kezdopont);
            bejart.Add(kezdopont);

            while (kovetkezok.Count > 0)
            {
                kezdopont = kovetkezok.Pop();


                Console.WriteLine(csucsok[kezdopont]);
            }

            


            foreach (var item in elek)
            {
                if (item.Csucs1 == kezdopont && !bejart.Contains(item.Csucs2))
                {
                    kovetkezok.Push(item.Csucs2);
                    bejart.Add(item.Csucs2);
                }
            }

          


        }

        public bool Osszefuggo(int kezdopont)
        {
            HashSet<int> bejart = new HashSet<int>();



            Queue<int> kovetkezok = new Queue<int>();
            kovetkezok.Enqueue(0);
            bejart.Add(0);

            while (kovetkezok.Count > 0)
            {
                kezdopont = kovetkezok.Dequeue();
            }

            foreach (var item in elek)
            {
                if (item.Csucs1 == kezdopont && !bejart.Contains(item.Csucs2))
                {
                    kovetkezok.Enqueue(item.Csucs2);
                    bejart.Add(item.Csucs2);
                }
            }

            if (bejart.Equals(csucsokSzama))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Graf Feszitofa(int kezdopont)
        {
            Graf fa = new Graf(this.csucsokSzama);



            HashSet<int> bejart = new HashSet<int>();
            Queue<int> kovetkezok = new Queue<int>();


            kovetkezok.Enqueue(0);
            bejart.Add(0);

            while (kovetkezok.Count > 0)
            {
                kezdopont = kovetkezok.Dequeue();
            }

            foreach (var item in elek)
            {
                if (item.Csucs1 == kezdopont)
                {
                    if (!bejart.Contains(item.Csucs2))
                    {
                        kovetkezok.Enqueue(item.Csucs2);
                        bejart.Add(item.Csucs2);
                        fa.Hozzaad(item.Csucs1, item.Csucs2);
                    }
                }
            }
            return fa;
        }

        public override string ToString()
        {
            string str = "Csucsok:\n";
            foreach (var cs in csucsok)
            {
                str += cs + "\n";
            }
            str += "Elek:\n";
            foreach (var el in elek)
            {
                str += el + "\n";
            }
            return str;
        }
    }
}