﻿using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gra za dużo za mało");

            // 1. komputer losuje
            Random los = new Random(); // tworze obiekt typu Random
            int wylosowana = los.Next(1, 100+1);
            Console.WriteLine(wylosowana);
            Console.WriteLine("wylosowałem liczbę od 1 do 100.\nOdgadnij ją!");

            // 2. człowiek proponuje
            Console.Write("Podaj swoją propozycję: ");
            int propozycja = int.Parse(Console.ReadLine());

            // 3. komputer ocenia
            if( propozycja < wylosowana )
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("za mało");
                Console.ResetColor();
            }
            else if( propozycja > wylosowana )
            {
              
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Za dużo");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Trafiono");
                Console.ResetColor();
            }
        }
    }
}
