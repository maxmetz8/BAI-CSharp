using System;
using System.Collections.Generic;

namespace BAI
{
    public class BAI_Afteken1
    {
        /// ------------------------------------------------------------
        /// <summary>
        /// Filtert een lijst. Hierbij worden alle elementen die maar
        /// 1x voorkomen verwijderd
        /// </summary>
        /// <param name="lijst">De lijst die wordt doorlopen
        /// (wordt in functie veranderd)</param>
        /// ------------------------------------------------------------
        public static void Opdr1FilterList(List<int> lijst)
        {
            //gebruik van dictionary als eis van opdracht
            //Dictionary gebruikt om waarde en aantal voorkomen bij te houden
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (int item in lijst)
            {
                if (dict.ContainsKey(item)) {
                    dict[item]++; //als item al in dictionary voorkomt, verhoog aantal
               } 
                else dict[item] = 1;//als item nog niet in dictionary staat, voeg toe met aantal 1
            } 
            //verwijderen van elementen die maar 1x voorkomen zonder lambda expressie
            List<int> teVerwijderenItems = new List<int>();

            foreach (int item in dict.Keys) //
            {
                if (dict[item] == 1)
                {
                    teVerwijderenItems.Add(item);
                }
            }
            foreach (int item in teVerwijderenItems)
            {
                lijst.Remove(item);
            }
        }

        /// ------------------------------------------------------------
        /// <summary>
        /// Maakt een queue van de getallen 1 t/m 50 (in die volgorde
        /// toegevoegd)
        /// </summary>
        /// <returns>Een queue met hierin 1, 2, 3, .., 50</returns>
        /// ------------------------------------------------------------
        public static Queue<int> Opdr2aQueue50()
        {
            Queue<int> q = new Queue<int>();
            // For loop dat draait van 1 t/m 50.
            for (int i = 1; i <= 50; i++)   
                
            {     // Voegt het huidige getal toe naar de achterkant van de queue(rij).
                q.Enqueue(i);               
            }
            
            return q;    
        }
        
        /// ------------------------------------------------------------
        /// <summary>
        /// Haalt alle elementen uit een queue. Voegt elk element dat
        /// deelbaar is door 4 toe aan een stack
        /// </summary>
        /// <param name="queue">De queue die uitgelezen wordt</param>
        /// <returns>De stack met hierin de elementen die deelbaar zijn
        /// door 4</returns>
        /// ------------------------------------------------------------
        public static Stack<int> Opdr2bStackFromQueue(Queue<int> queue)
        {
            Stack<int> stack = new Stack<int>();
            
            // Zolang de queue niet leeg is 
            while (queue.Count > 0)
            {
                // Haalt het element item uit de queue 
               var element =  queue.Dequeue();
               
               // Checkt of het element deelbaar is door 4 
               if (element % 4 == 0)
               {
                   // Als het deelbaar door 4 is dan push hij het element aan de stack
                   stack.Push(element); 
               }
            }
            
            return stack;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Maakt een stack met hierin unieke random getallen</summary>
        /// <param name="lower">De ondergrens voor elk getal (inclusief)</param>
        /// <param name="upper">De bovengrens voor elk getal (inclusief)</param>
        /// <param name="count">Het aantal getallen</param>
        /// <returns>De stack met unieke random getallen</returns>
        /// ------------------------------------------------------------
        public static Stack<int> Opdr3RandomNumbers(int lower, int upper, int count)
        {
            Stack<int> stack = new Stack<int>();

            //Het gebruiken van een HashSet is essentieel om ervoor te zorgen dat de getallen uniek zijn maar ook dat het toevoegen van een getal O(1) is
            // want het checken of een getal al in de HashSet zit is O(1) en bij een List of de contains methode is dit O(n). De test wordt anders te traag
            HashSet<int> uniekeGetallen = new HashSet<int>();

            //random getallen genereren
            Random random = new Random();

            // Blijf getallen genereren zolang het aantal unieke getallen kleiner is dan count
            while (uniekeGetallen.Count < count)
            {
                //Genereer een random getal tussen lower en upper waarbij upper inclusief is dus +1 krijgt
                int randomGetal = random.Next(lower, upper + 1);

                // Voeg alleen toe aan de stack als het getal uniek is
                if (uniekeGetallen.Add(randomGetal))
                {
                    stack.Push(randomGetal);
                }
            }

            return stack;
        }


        /// ------------------------------------------------------------
        /// <summary>
        /// Drukt een IEnumerable (List, Stack, Queue, ..) van getallen
        /// af naar de Console
        /// <param name="enu">De IEnumerable om af te drukken</param>
        /// ------------------------------------------------------------
        static void PrintEnumerable(IEnumerable<int> enu)
        {
            foreach (int i in enu)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            List<int> list;
            Queue<int> queue;
            Stack<int> stack;

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1 : FilterList ===");
            list = new List<int>() { 1, 3, 5, 7, 3, 8, 9, 5 };
            PrintEnumerable(list);
            Opdr1FilterList(list);
            PrintEnumerable(list);

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 2 : Stack / Queue ===");
            queue = Opdr2aQueue50();
            PrintEnumerable(queue);
            stack = Opdr2bStackFromQueue(queue);
            PrintEnumerable(stack);

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 3 : Random number ===");
            stack = Opdr3RandomNumbers(100, 150, 10);
            PrintEnumerable(stack);
            stack = Opdr3RandomNumbers(10, 15, 6);
            PrintEnumerable(stack);
            stack = Opdr3RandomNumbers(10_000, 50_000, 40_001);
        }
    }
}
