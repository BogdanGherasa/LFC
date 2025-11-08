using System;
using MyApp;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AutomatFinitDeterminist afd = new AutomatFinitDeterminist();
            if(afd.verifyAutonom())
            {
                Console.WriteLine("Automatul este valid.");
                afd.afiseazaTabel();
            }
            else
            {
                Console.WriteLine("Automatul nu este valid.");
            }
        }
    }
}