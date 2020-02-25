using System;
using System.Diagnostics;


namespace GraProceduralnie
{
    class Program //klasa Program
    {
        const string zaduzo = "ZA DUŻO"; //to są stałe zmienne
        const string zamalo = "ZA MAŁO";
        const string trafiono = "TRAFIONO";


        static void Main(string[] args)
        {
            Console.WriteLine("Gra za dużo za mało");
            int a = WczytajLiczbe("Podaj dolny zapis losowania: ");
            int b = WczytajLiczbe("Podaj górny zapis losowania: ");
            int wylosowana = Losuj(a, b);
#if DEBUG
            Console.WriteLine(wylosowana);
#endif

            int licznik = 0;
            var stoper = new Stopwatch();
            stoper.Start();

            while (true)
            {
                // 2. człowiek proponuje
                licznik++; //licznik = licznik + 1;
                int propozycja = WczytajLiczbe("podaj swoją propozycję lub x aby zakończyć: ");
                string wynik = Ocena(wylosowana, propozycja);
                Console.WriteLine(wynik);
                if (wynik == trafiono)
                    break; //słuzy do tego żeby przerwac działanie pętli

            }
            stoper.Stop();
            Console.WriteLine($"liczba ruchów = {licznik}");
            Console.WriteLine($"czas gry = {stoper.Elapsed}");
            Console.WriteLine("Koniec gry");
        }

        /// <summary>
        /// losuje liczbę z podanego zakresu włącznie
        /// </summary>
        /// <param name="min">dolne ograniczenie</param>
        /// <param name="max">górne ograniczenie</param>
        /// <returns></returns>

        static int Losuj(int min = 1, int max = 100)
        {
            var min1 = Math.Min(min, max);
            var max1 = Math.Max(min, max);

            var rnd = new Random();
            var los = rnd.Next(min1, max1 + 1);

            return 0;
        }

        static int WczytajLiczbe(string prompt = "")
        {
            bool poprawnie = false;
            int wynik = 0;// APLIKACJA W TRYBIE SLEDZENIA, DEBUG TRYB ŚLEDZENIA F5, STEP OVER STRZAŁKA
            do //pętla do
            {
                Console.Write(prompt);
                string wczytano = Console.ReadLine();
                if (wczytano == "x" || wczytano == "x")
                    Environment.Exit(0);

                try
                {
                    wynik = int.Parse(wczytano);
                    poprawnie = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("niepoprawny zapis liczby. Spróbuj jeszcze raz");

                }
                catch (OverflowException)
                {
                    Console.WriteLine("przekroczony zapis liczby");
                }
                catch (Exception)
                {

                    Console.WriteLine("nieznany błąd");

                }

            }

            while (!poprawnie); //koniec pętli

            return wynik;


        }


        static String Ocena(int wylosowana, int propozycja) //małe litery - parametry,zmienne lokalne duze litery - nazwy klas, nazwy metod, funkcji, procedur
        {
            if (wylosowana < propozycja)
            {
                return zaduzo;
            }
            else if (wylosowana > propozycja)
            {
                return zamalo;
            }
            else
            {
                return trafiono;
            }
        }
    }
}