using System;
using System.Text.RegularExpressions;

namespace MyApp
{
    class AutomatFinitDeterminist
    {
        public HashSet<string> Stari { get; set; } = new HashSet<string> { "q0", "q1", "q2" };
        public HashSet<char> Alfabet { get; set; } = new HashSet<char> { 'a', 'b' };
        public Dictionary<(string, char), string> Tranzitii { get; set; } = new Dictionary<(string, char), string>
        {
            { ("q0", 'a'), "q1" },
            { ("q0", 'b'), "q0" },
            { ("q1", 'a'), "q2" },
            { ("q1", 'b'), "q0" },
            { ("q2", 'a'), "q2" },
            { ("q2", 'b'), "q2" }
        };
        public string StareInitiala { get; set; } = "q0";
        public HashSet<string> StariFinale { get; set; } = new HashSet<string> { "q2" };


        public bool verifyAutonom()
        {
            if (StareInitiala != null && !Stari.Contains(StareInitiala))
            {
                return false;
            }
            if (!StariFinale.IsSubsetOf(Stari))
            {
                return false;
            }

            foreach (var key in Tranzitii.Keys)
            {
                var (stare, simbol) = key;
                if (!Stari.Contains(stare) || !Alfabet.Contains(simbol) || !Stari.Contains(Tranzitii[key]))
                {
                    return false;
                }
            }
            return true;


        }
        public void afiseazaTabel()
        {
            Console.WriteLine("===== Tabel Tranzitii =====");


            Console.Write("Stare\t");
            foreach (var symbol in Alfabet)
            {
                Console.Write(symbol + "\t");
            }
            Console.WriteLine();


            foreach (var state in Stari)
            {
                Console.Write(state + "\t");

                foreach (var symbol in Alfabet)
                {
                    if (Tranzitii.ContainsKey((state, symbol)))
                    {
                        Console.Write(Tranzitii[(state, symbol)] + "\t");
                    }
                    else
                    {
                        Console.Write("-\t");
                    }
                }

                Console.WriteLine(); // terminăm rândul curent
            }
        }



        public bool checkWord(string cuvant)
        {
            string stareCurenta = StareInitiala;

            foreach (char simbol in cuvant)
            {
                if (!Alfabet.Contains(simbol))
                {
                    Console.WriteLine($"Simbol invalid: '{simbol}' (nu face parte din alfabet)");
                    return false;
                }

                var cheie = (stareCurenta, simbol);
                if (Tranzitii.ContainsKey(cheie))
                {
                    stareCurenta = Tranzitii[cheie];
                }
                else
                {
                    Console.WriteLine($"Nu exista tranzitie din '{stareCurenta}' cu simbolul '{simbol}'.");
                    return false;
                }
            }

            if (StariFinale.Contains(stareCurenta))
            {
                Console.WriteLine($"Cuvantul '{cuvant}' este ACCEPTAT (stare finala: {stareCurenta})");
                return true;
            }
            else
            {
                Console.WriteLine($"Cuvantul '{cuvant}' este RESPINS (stare finala: {stareCurenta})");
                return false;
            }

        }
    }
}