using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace es_30_alunni
{
    internal class Program
    {
        static Random rnd = new Random();
        const int da = 2, a = 10;
        static void Main(string[] args)
        {
            string[] cognomi = { "ABALINTOAIE", "ANDRU", "BERRINO", "BRUZZONE", "CERATTO",
                "CHIRIAC", "DALLORTO", "GAMBINO", "GIRAUDO", "GIRELLO", "GJINI",
                "KARDASH", "KOPSHTI", "LERDA", "LUBATTI", "MAGLIANO", "MARTINA", "MO",
                "PETRUCCI", "REALE", "SACCATO", "SINGH", "SIVERA" };
            int n = 4; // cognomi.Length;
            int[] voti = new int[n];// vettore parallelo
            caricaVoti(voti, n);
            int[] frequenze = new int[a-da+1];
            stampa(cognomi, voti, n);
            frequenze_voti(voti, n, frequenze);
            string alunno;
            alunno = inputString("inserire cognome da ricercare");
            int posizione;
            posizione = found_posizione(cognomi, n, alunno);
            if (posizione == -1)
            {
                Console.WriteLine($"{alunno} non c'è");
            }
            else
            {
                Console.WriteLine($"{alunno} ha meritato il voto {voti[posizione].ToString()}");
            }
            visualizzaSecchione(cognomi, voti, n);
            modificaVoto(cognomi, voti);
            Console.ReadKey();

        }
        public static void modificaVoto(string[] cognomi, int[] voti)
        {
            string alunno;
            int posizione;
            int numeroVuoto;
            alunno = inputString("inserire alunno di cui vuyoi modficiare il voto");
            posizione = found_posizione(cognomi, cognomi.Length, alunno);
            if(posizione == -1)
            {
                Console.WriteLine("non c'è");
            }
            else
            {
                numeroVuoto= 
            }
        }
        private static void visualizzaSecchione(string[] cognomi, int[] voti, int n)
        {
            int max = da;
            string secchioni = "";
            for( int i = 0; i < n; i++)
            {
                if (voti[i] > max)
                {
                    max = voti[i];
                    secchioni = cognomi[i]; 
                }else if( voti[i] == max)
                {
                    secchioni += ", " + cognomi[i];
                }
            }

            Console.WriteLine($"il voto più alto è {max.ToString()} conseguito da {secchioni}");
        }

        private static int found_posizione(string[] cognomi, int n, string alunno)
        {
            int position = -1;
            int sup = 0, inf = n - 1, meta;
            do
            {
                meta = (sup + inf) / 2;
                if (cognomi[meta].CompareTo(alunno) == 1)
                {
                    inf = meta - 1;
                }else if (cognomi[meta].CompareTo(alunno) == -1)
                {
                    sup = meta + 1;
                }
                else
                {
                    position = meta;
                }
            }
            while(position == -1 && sup<=inf);
            return position;
        }

        private static string inputString(string v)
        {

            string s = "";
            do
            {
                Console.WriteLine(v);
                s = Console.ReadLine().ToUpper().Trim();
            } while (s.Length < 2);


            return s;
        }
        private static void frequenze_voti(int[]voti, int n, int[] frequenze)
        {
            int indice;
            double percentuale;
            for(int i = 0; i< frequenze.Length; i++)
            {
                frequenze[i]= 0;
            }


            for(int i = 0; i<n; i++)
            {
                indice = voti[i] - da;
                frequenze[indice]++;
            }

            Console.WriteLine("\nvoto\tpercentuale");
            //calcolo percentuali %
            for (int i = 0; i< frequenze.Length; i++)
            {
                if (frequenze[i] != 0)
                { 
                    percentuale = (double)frequenze[i] / n* 100;
                    percentuale = Math.Round(percentuale, 2);
                    Console.WriteLine((i + da).ToString().PadLeft(3) + " " + percentuale.ToString().PadLeft(8) + "%");
                }
            }
        }
        private static void caricaVoti(int[] voti, int n)
        {
            for (int i = 0; i < n; i++)
            {
                voti[i] = rnd.Next(da,a+1);
            }

        }

        private static void stampa(string[] cognomi, int[] voti, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (voti[i] > 8)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    if (voti[i] < 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                }
                Console.WriteLine((i + 1).ToString().PadLeft(3) + ") " + cognomi[i].PadRight(13, '.') + voti[i].ToString().PadLeft(3, '.'));

            }
            Console.ResetColor();
        }
    }
}
