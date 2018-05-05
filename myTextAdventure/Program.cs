using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace myTextAdventure
{
    class Game
    {
        static int score;
        static int scoreStart;
        static bool pozde;
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("School Adventure");
            Console.WriteLine("Vítejte v simulátoru školního života\n"); 
            CharName();
            Gender();
            Difficulty();
            QuestOne();
            if (score < scoreStart)
            {
                QuestTwo();             
            }
            else
            {
            }
            QuestThree();
            QuestFour();
            QuestFive();
            Console.ReadKey();            
        }
        public static string CharName()
        {
            Console.WriteLine("Jak se jmenuješ, studente?");
            string characterName = Console.ReadLine();  //implementovat kontrolu pro dementy, kteří to jenom odentrujou
            Console.WriteLine("Zdravím, {0}!\n", characterName);   
            return characterName;
        }
        public static bool Gender()
        {
            NewScreen();
            Console.WriteLine("Jsi žena nebo muž?");
            Console.WriteLine("1) Žena\n2) Muž");
            bool zena;
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Je to studentka.");
                zena = true;
            }
            else
            {
                Console.WriteLine("Je to student");
                zena = false;
            }
            return zena;
        }
        public static void Difficulty()
        {
            NewScreen();
            Console.WriteLine("Vyber si obtížnost:");
            Console.WriteLine("1) Nech mě být (testovací režim - nesmrtelnost)\n2) Normální\n3) Hardcore");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                score = 100;
                Console.WriteLine("Byla vybrána testovací obtížnost. Počáteční skóre je {0}. Každé tvé rozhodnutí tuto cifru ovlivní. Pokud klesne na nulu, znamená to pro tebe konec hry.", score);
            }
            else if (choice == 2)
            {
                score = 5;
                Console.WriteLine("Byla vybrána normální obtížnost. Počáteční skóre je {0}. Každé tvé rozhodnutí tuto cifru ovlivní. Pokud klesne na nulu, znamená to pro tebe konec hry.", score);
            }
            else
            {
                score = 2;
                Console.WriteLine("HARDCORE. Toto nebude jenom tak. Počáteční skóre je {0}. Každé tvé rozhodnutí tuto cifru ovlivní. Pokud klesne na nulu, znamená to pro tebe konec hry.", score);
            }
            scoreStart = score;
        }
        public static void GameOver()
        {
            if (score <= 0)
            {
                Console.WriteLine("\nTato hra pro tebe končí, jelikož jsi dosáhl skóre nula. Zkus to znova - třeba se ti příště povede lépe.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Tvoje skóre je: {0}\nPokud klesneš na nulu, hra končí.", score);
            }
        }
        public static void NewScreen()
        {
            Console.WriteLine("\n\nPro postup stiskni jakoukoliv klávesu...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void QuestOne()
        {
            NewScreen();
            Console.WriteLine("Jedeš autobusem do školy. Přejel jsi tu správnou zastávku. Co uděláš?");
            Console.WriteLine("1) Počkám na autobus v opačném směru\n2) Projdu se\n3) Proběhnu se");
            int choice = int.Parse(Console.ReadLine());
            pozde = true;
            if (choice == 1)
            {
                Console.WriteLine("Autobus měl zpoždění a ty přícházíš do školy po zvonění.");
                score -= 1;
            }
            else if (choice == 2)
            {
                Console.WriteLine("Šel jsi pomalu, a proto přicházíš do školy po zvonění.");
                score -= 1;
            }
            else
            {
                Console.WriteLine("Stihl jsi to jen tak tak.");
                pozde = false;
            }
            GameOver();
        }
        public static void QuestTwo()
        {
            NewScreen();
            Console.WriteLine("Na chodbě vidíš dozor.");
            Console.WriteLine("1) Vejdu dovnitř\n2) Počkám až se otočí a proklouznu\n3) Zavolám kamarádovi, ať dozor zaměstná");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Ty se toho nebojíš. Tentokrát ti to ale vyšlo. Vyhnul ses zápisu.");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Stejně tě viděl. Marná snaha. Další pozdní příchod.");
                score -= 1;
            }
            else
            {
                Console.WriteLine("Dozor se vybavuje, ty se pomalu plížíš do třídy. Pohoda.");
            }
            GameOver();            
        }
        public static void QuestThree()
        {
            NewScreen();
            Console.WriteLine("Vešel jsi do hodiny matematiky a učitel zkouší. Tipni si číslo od 1 do 5. Pokud se trefíš, dneska to na tebe nepadne.");
            Random rnd = new Random();
            int sance = rnd.Next(1, 6);
            int tip = int.Parse(Console.ReadLine()); //Implementovat kontrolu pro prázdný vstup
            if (sance == tip)
            {
                Console.WriteLine("Tak dneska ses tomu vyhnul a dokonce jsi zapůsobil. Paráda!");
                score += 1;
            }
            else
            {
                Console.WriteLine("Smůla. Měl jsi raději napsat {0}", sance);
                score -= 1;
            }
            GameOver();
        }
        public static void QuestFour()
        {
            NewScreen();
            Console.WriteLine("Dostal ses do řady v bufetu, ale přestávka není nekonečná. Pokud zvládneš opsat názvy těchto produktů v určitém čase, dostaneš se k jídlu, kterým si doplníš svůj žaludek (čti: skóre).");
            string[] produkty = { "chlebanek", "bageta", "croissant", "Pepsi", "chipsy"};
            bool success = true;
            Console.ReadKey();
            Stopwatch cas = new Stopwatch();
            cas.Start();
            for (int i = 0; i < produkty.Length; i++)      
            {
                Console.WriteLine("Napiš {0}", produkty[i]);
                string input = Console.ReadLine();
                if (input == produkty[i])
                {
                }
                else
                {
                    success = false;
                    break;
                }
            }
            cas.Stop();
            Console.WriteLine("Čas: {0}\n", cas.Elapsed);
            if (cas.Elapsed.TotalSeconds > 10 || success == false)
            {
                success = false;
                Console.WriteLine("Tak to úplně nevyšlo. Ztrácíš jeden bod.");
            }
            else
            {
                Console.WriteLine("Paráda, bez chyby a rychle. Dostáváš jeden bod.");
            }
            if (success == true)
            {
                score += 1;
            }
            else
            {
                score -= 1;
            }
            Console.WriteLine("Tady něco nehraje.");
            GameOver();
        }
        public static void QuestFive()
        {
            NewScreen();
            if (pozde == true)
            {
                Console.WriteLine("Protože jsi přišel do školy po zvonění, nestihl ses přezout a potkáváš na chodbě kantora, který kontroluje, jestli mají studenti na nohou přezuvky.");
                Console.WriteLine("1) Za žádnou cenu nenavážu oční kontakt a svižně kráčím pryč\n2) Dělám, jakoby nic");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("Akorát si na sebe strhl pozornost. Smůla.");
                }
                else
                {
                    Console.WriteLine("Ty máš ale štěstí. Zrovna tebe si fakt nevšiml.");
                }
                GameOver();
            }
            else
            {
            }
        }
    }
}
