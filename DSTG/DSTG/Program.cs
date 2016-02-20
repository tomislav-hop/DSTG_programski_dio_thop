using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTG
{
    class Program
    {
        public struct zupanija 
        {
            public string naziv;
            public int brojGlasaca;
        }

        public struct kandidat
        {
            public string naziv;
            public float sumaGlasova;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Unesite broj kandidata: ");
            string brojKandidata = Console.ReadLine();

            Console.WriteLine("Unesite broj zupanija: ");
            string brojZupanija = Console.ReadLine();

            int brojK = 0;
            int brojZ = 0;

            brojK = Convert.ToInt32(brojKandidata);
            brojZ = Convert.ToInt32(brojZupanija);
            
            
            kandidat[] kandidati = new kandidat[brojK];
            zupanija[] zupanije = new zupanija[brojZ];

            Console.WriteLine("\n===========UNOS KANDIDATA===========");

            for (int i = 0; i < brojK; i++)
            {
                Console.WriteLine("Unesite naziv kandidata: ");
                kandidati[i].naziv = Console.ReadLine();
            }

            Console.WriteLine("\n===========UNOS ZUPANIJA===========");

            for (int i = 0; i < brojZ; i++)
            {
                Console.WriteLine("Unesite naziv zupanije: ");
                zupanije[i].naziv = Console.ReadLine();
            }

            int[,] podatci = new int[brojK, brojZ];

            Console.WriteLine("\n===========UNOS BROJA GLASACA===========");

            for (int i=0; i < brojK; i++)
            {
                for (int j = 0; j < brojZ; j++) 
                {
                    Console.WriteLine("Unesite broj glasaca za kandidata "+ kandidati[i].naziv +" u zupaniji "+ zupanije[j].naziv +":");
                    podatci[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < brojK; i++) 
            {
                for (int j = 0; j < brojZ; j++) 
                {
                    float brojKandidatovihGlasova = podatci[i, j];
                    int koeficijent = 0;
                    for (int k = 0; k < brojK; k++) 
                    {
                        if (brojKandidatovihGlasova > podatci[k, j])
                        {
                            koeficijent++;
                        }    
                    }
                    kandidati[i].sumaGlasova += koeficijent * podatci[i, j];
                }
            }

            Console.WriteLine("\n===========ISPIS SUMA GLASOVA ZA KANDIDATE===========");
            for (int i = 0; i < brojK; i++) 
            {
                Console.WriteLine("Kandidat " + kandidati[i].naziv + " ima sumu glasova od: " + kandidati[i].sumaGlasova +"\n");
            }

            Array.Sort<kandidat>(kandidati, (x, y) => x.sumaGlasova.CompareTo(y.sumaGlasova));


            Console.WriteLine("\n===========ISPIS SUMA GLASOVA ZA KANDIDATE SORTIRANO===========");
            for (int i = brojK-1; i >= 0; i--)
            {
                Console.WriteLine("Kandidat " + kandidati[i].naziv + " ima sumu glasova od: " + kandidati[i].sumaGlasova + "\n");
            }

            string kraj = Console.ReadLine();
        }
    }
}
