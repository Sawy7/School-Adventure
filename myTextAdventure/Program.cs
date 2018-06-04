﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Security.Permissions;

namespace myTextAdventure
{
    class Game
    {
        static int score;
        static int scoreStart;
        static bool pozde;
        static string charName;
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
            QuestSix();
            QuestSeven();
            QuestFinal();
            EndScreen();            
        }
        public static void QSkip() //metoda pro přeskakování questů (cheat-code koncept)
        {
            NewScreen();
            Console.WriteLine("Zadejte suffix questu, do kterého chcete skočit\nNabídka: one - seven; final");
        	string qNum = Console.ReadLine();
            qNum = "Quest" + char.ToUpper(qNum[0]) + qNum.Substring(1);
            score = 100;
            Game game = new Game();
            game.CallAnything(qNum);
            Console.WriteLine("Test questu dokončen. Pro zavření okna stiskněte libovolnou klávesu.");
            Console.ReadKey();
        	Environment.Exit(0);
        }
        public void CallAnything(string calledMethod)
        {
            Type t = this.GetType();
            MethodInfo method = t.GetMethod(calledMethod);
            method.Invoke(this, null);
        }
        public static void CharName()
        {
            Console.WriteLine("Jak se jmenuješ, studente?");
            charName = Console.ReadLine(); 
            if (charName == "") //Kontrola pro zamezení pádu hry po vynechání zadání jména. Díky Honzo P.!
            {
                Console.WriteLine("Zkus to znova."); //Snaha vložit do samostané funkce - příliš mnoho odkazů
            	NewScreen();
            	CharName();
            }
            else if (charName == "qskip")
            {
                QSkip();
            }
            else
            {
            	Console.WriteLine("Zdravím, {0}!\n", charName);
            }
        }
        public static bool Gender()
        {
            NewScreen();
            Console.WriteLine("Jsi žena nebo muž?");
            Console.WriteLine("1) Žena\n2) Muž");
            bool zena = true;
            string choiceText = Console.ReadLine();
            if (choiceText == "1" || choiceText == "2")
            {
                int choice = int.Parse(choiceText);
                if (choice == 1)
                {
                    Console.WriteLine("Je to studentka.");
                    zena = true;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Je to student");
                    zena = false;
                }
            }            
            else
            {
                Console.WriteLine("Zkus to znova.");
                Gender();
            }
            return zena;
        }
        public static void Difficulty()
        {
            NewScreen();
            Console.WriteLine("Vyber si obtížnost:");
            Console.WriteLine("1) Nech mě být (testovací režim - nesmrtelnost)\n2) Normální\n3) Hardcore");
            string choiceText = Console.ReadLine();
            if (choiceText == "1" || choiceText == "2" || choiceText == "3")
            {
                int choice = int.Parse(choiceText);
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
                else if (choice == 3)
                {
                    score = 2;
                    Console.WriteLine("HARDCORE. Toto nebude jenom tak. Počáteční skóre je {0}. Každé tvé rozhodnutí tuto cifru ovlivní. Pokud klesne na nulu, znamená to pro tebe konec hry.", score);
                }
            }
            else
            {
                Console.WriteLine("Zkus to znova.");
                Difficulty();
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
        public static int RandomGen(int minimum, int maximum)
        {
        	//Console.WriteLine("Rozsah je: {0} a {1}", minimum, maximum);
        	Random rnd = new Random();
        	int randomOut = rnd.Next(minimum, maximum);
        	return randomOut;
        }
        public static void QuestOne() //Jízda do školy
        {
            NewScreen();
            Console.WriteLine("Jedeš autobusem do školy. Přejel jsi tu správnou zastávku. Co uděláš?");
            Console.WriteLine("1) Počkám na autobus v opačném směru\n2) Projdu se\n3) Proběhnu se");
            string choiceText = Console.ReadLine();
            if (choiceText == "1" || choiceText == "2" || choiceText == "3")
            {
                int choice = int.Parse(choiceText);
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
            else
            {
                Console.WriteLine("Zkus to znova.");
                QuestOne();
            }
            pozde = true;  
        }
        public static void QuestTwo() //Dozor na chodbě
        {
            NewScreen();
            Console.WriteLine("Na chodbě vidíš dozor.");
            Console.WriteLine("1) Vejdu dovnitř\n2) Počkám až se otočí a proklouznu\n3) Zavolám kamarádovi, ať dozor zaměstná");
            string choiceText = Console.ReadLine();
            if (choiceText == "1" || choiceText == "2" || choiceText == "3")
            {
                int choice = int.Parse(choiceText);
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
            else
            {
                Console.WriteLine("Zkus to znova.");
                QuestTwo();
            }
        }
        public static void QuestThree() //Hodina matematiky
        {
            NewScreen();
            Console.WriteLine("Vešel jsi do hodiny matematiky a učitel zkouší. Tipni si číslo od 1 do 5. Pokud se trefíš, dneska to na tebe nepadne.");
            int sance = RandomGen(1, 6);
            string tipText = Console.ReadLine();
            if (tipText == "1" || tipText == "2" || tipText == "3" || tipText == "4" || tipText == "5")
            {
                int tip = int.Parse(tipText);
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
            else
            {
                Console.WriteLine("Zkus to znova. Tipni číslo od 1 do 5.");
                QuestThree();
            }
        }
        public static void QuestFour() //Bufet
        {
            NewScreen();
            Console.WriteLine("Dostal ses do řady v bufetu, ale přestávka není nekonečná. Pokud zvládneš opsat názvy těchto produktů, které se postupně budou zobrazovat, v určitém čase, dostaneš se k jídlu, kterým si doplníš svůj žaludek (čti: skóre).");
            string[] produkty = {"chlebánek", "bageta", "croissant", "Pepsi", "chipsy"};
            bool success = true;
            Console.ReadKey();
            Stopwatch cas = new Stopwatch();
            cas.Start();
            for (int i = 0; i < produkty.Length; i++)      
            {
                Console.WriteLine("Napiš: {0}", produkty[i]);
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
            if (cas.Elapsed.TotalSeconds > 25 || success == false)
            {
                success = false;
                Console.WriteLine("Tak to úplně nevyšlo. Ztrácíš jeden bod.");
                score -= 1;
            }
            else
            {
                Console.WriteLine("Paráda, bez chyby a rychle. Dostáváš jeden bod.");
                score += 1;
            }
            GameOver();
        }
        public static void QuestFive() //Přezuvky
        {  
            if (pozde == true)
            {
                NewScreen();
                Console.WriteLine("Protože jsi přišel do školy po zvonění, nestihl ses přezout a potkáváš na chodbě kantora, který kontroluje, jestli mají studenti na nohou přezuvky.");
                Console.WriteLine("1) Za žádnou cenu nenavážu oční kontakt a svižně kráčím pryč\n2) Dělám, jakoby nic");
                string choiceText = Console.ReadLine();
                if (choiceText == "1" || choiceText == "2")
                {
                    int choice = int.Parse(choiceText);
                if (choice == 1)
                {
                    Console.WriteLine("Akorát si na sebe strhl pozornost. Smůla.");
                    score -= 1;
                }
                else
                {
                    Console.WriteLine("Ty máš ale štěstí. Zrovna tebe si fakt nevšiml. Dostáváš bod navíc.");
                    score += 1;
                }
                GameOver();
                }
                else
                {
                    Console.WriteLine("Zkus to znova.");
                    QuestFive();
                } 
            }
            else
            {
            }
        }
        public static void QuestSix() //Kopírka
        {
        	NewScreen();
        	Console.WriteLine("Potřebuješ si okopírovat papír do hodiny. Stiskni klávesu pro vložení peněz do automatu.");
        	Console.ReadKey();
        	Console.WriteLine("Kopírka se zasekla.");
        	Console.WriteLine("1) Kopnu do ní\n2) Pokusím se najít příčinu a opravit problém sám\n3) Zajdu na vrátnici");
            string choiceText = Console.ReadLine();
            if (choiceText == "1" || choiceText == "2" || choiceText == "3")
            {
                int choice = int.Parse(choiceText);
                if (choice == 1)
                {
                    Console.WriteLine("Tak to nepomohlo. A navíc si tě dozor pozval do kabinetu. Z toho nebude nic dobrého..");
                    score -= 1;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Nakonec to byl posunutý zásobník na papíry. Hotovo..");
                }
                else
                {
                    Console.WriteLine("Tohle trvá věčnost. Nemáš kopii a do hodiny jdeš pozdě.");
                    score -= 1;
                }
                GameOver();
            }
            else
            {
                Console.WriteLine("Zkus to znova.");
                QuestSix();
            }
        }
        public static void QuestSeven() //Ajina
        {
        	NewScreen();
        	Console.WriteLine("Přícházíš do hodiny angličtiny. Tvým úkolem v tomto testu je přepsat zobrazená čísla do numerické podoby. Pokud napíšeš do pole cokoliv jiného než číslo, bude odpověď považována za chybnou. Až budeš připraven stiskni jakoukoliv klávesu.");
        	int nahodneCislo;
        	string[] vsechnyDesitky = {"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety", ""};
        	string[] vsechnyJednotky = {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", ""};
        	string[] divnaCisla = {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
        	int desitky;
        	int jednotky;
        	string desitkySlovo;
        	string finalniCislo;
        	
        	int zadanoUzivatelem;
        	for (int i = 1; i < 7; i++)
        	{
        		NewScreen();
        		nahodneCislo = RandomGen(1, 100);
        		if (nahodneCislo < 10)
        		{
        			desitky = 0;
        		}
        		else
        		{
        			desitky = (nahodneCislo - (nahodneCislo%10))/10;
        		}
        		if (desitky < 2)
        		{
        			desitkySlovo = "";
        		}
        		else
        		{
        			desitkySlovo = vsechnyDesitky[desitky-2];
        		}
				jednotky = nahodneCislo - (desitky*10);        	
        		string jednotkySlovo = vsechnyJednotky[jednotky];
        		if (jednotkySlovo == "")
        		{
        			finalniCislo = desitkySlovo;
        		}
        		else if (desitkySlovo == "")
        		{
        			finalniCislo = jednotkySlovo;
        		}
        		else
        		{
        			finalniCislo = desitkySlovo + "-" + jednotkySlovo;;
        		}
        		if (nahodneCislo > 9 && nahodneCislo < 20)
        		{
        		 	finalniCislo = divnaCisla[nahodneCislo-10];
        		}
                finalniCislo = char.ToUpper(finalniCislo[0]) + finalniCislo.Substring(1);
        		Console.WriteLine("Zapište číslo {0}", finalniCislo);
                string zadanoUzivatelemText = Console.ReadLine();
                bool jeCislo = true;
                foreach (char c in zadanoUzivatelemText)
                {
                    if (c < '0' || c > '9')
                    {
                        jeCislo = false;
                    }
                    else
                    {
                        jeCislo = true;
                    }
                }
                if (jeCislo == true)
                {
                    zadanoUzivatelem = int.Parse(zadanoUzivatelemText);
                    if (zadanoUzivatelem == nahodneCislo)
                    {
                        Console.WriteLine("Správná odpověď, neztrácíš žádný bod.");
                    }
                    else
                    {
                        score -= 1;
                        Console.WriteLine("Špatná odpověď, ztrácíš jeden bod.");
                    }
                }
        		else
                {
                    score -= 1;
                    Console.WriteLine("Špatná odpověď, ztrácíš jeden bod.");
                }
        	}
        	GameOver();
        }
        public static void QuestFinal() //Ucitel IVT
        {
        	NewScreen();
        	Console.WriteLine("Dostal jsi se až k poslední události tvého školního dne. Zjišťuješ, že nemáš projekt z programování do hodin IKT. Budeš muset svého učitele přesvědčit, že jsi výuku nezanedbal a jsi schopen něco naprogramovat.");
        	NewScreen();
        	string[] otazky = {"V jakém programovacím jazyce je tato hra napsána? (2 slova, malým)", "Do jakého datového typu obyčejně zapisujeme slova a celé věty?", "Kolik je 5 na druhou?", "Která firma stojí za programovacím jazykem C#? (velké první písmeno)", "Co napíšete, pokud chcete, aby program čekal na stisknutí libovolné klávesy?"};
        	string[] odpovedi = {"c sharp", "string", "25", "Microsoft", "Console.ReadKey();"};
        	int poradi = RandomGen(0, 5);
            for (int i = poradi; i < 5; i++) {
            	Console.WriteLine(otazky[i]);
            	string odpovedInput = Console.ReadLine();
            	if (odpovedInput == odpovedi[i])
            	{
            		Console.WriteLine("Správná odpověď, neztrácíš žádný bod.");
            	}
            	else 
            	{
            		score -= 1;
            		Console.WriteLine("Špatná odpověď, ztrácíš jeden bod.");
            	}
            	GameOver();
            	NewScreen();
            }
            for (int i = 0; i < poradi; i++) {
            	Console.WriteLine(otazky[i]);
            	string odpovedInput = Console.ReadLine();
            	if (odpovedInput == odpovedi[i])
            	{
            		Console.WriteLine("Správná odpověď, neztrácíš žádný bod.");
            	}
            	else 
            	{
            		score -= 1;
            		Console.WriteLine("Špatná odpověď, ztrácíš jeden bod.");
            	}
            	GameOver();
            	NewScreen();
            }
        }
        public static void EndScreen()
        {
        	Console.WriteLine("Nějakým způsobem se ti to podařilo dotáhnout až sem. Gratuluji! Jsi vítěz a za odměnu dostáváš dobrý pocit.\nPokud bys chtěl získat všechny soubory k tomuto malému projektu v přehledné formě online, neváhej a navštiv můj Github na http://github.com/Sawy7");
        	Console.WriteLine("\nTvé finální skóre je: {0}", score);
        	Console.ReadKey();
        }
    }
}
