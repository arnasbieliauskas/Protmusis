using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Protmusis
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> PlayerList = new Dictionary<string, int>();

            string name = "";
            string forname = "";
            Console.WriteLine("Sveiki atvykę! ");
            Console.WriteLine("Pažaidžiam QUIZZZ žaidimą?");
            Console.WriteLine();

            Console.WriteLine("Prisiregistruokite");
            Console.WriteLine();
            Console.WriteLine("Įveskite savo vardą: ");
            name = Console.ReadLine();
            Console.WriteLine("Įveskite savo pavardę: ");
            forname = Console.ReadLine();
            string fullname = name + " " + forname;
            Console.WriteLine();
            PlayerList = Prisiregistravimas(name, forname, PlayerList);
            Console.Clear();
            Console.WriteLine("Sveikas prisijungęs: " + name);
            Console.WriteLine();

            MeniuList();
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                var input = Console.ReadLine().ToLower();

                if (input == "q")
                {
                    Console.Clear();
                    Console.WriteLine("Jūsų pasirinkimas " + name);
                    Console.WriteLine();
                    MeniuList();
                    Console.WriteLine();
                }// sugryzti i meniu

                if (input == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Įveskite savo vardą: ");
                    string name2 = Console.ReadLine();
                    Console.WriteLine("Įveskite savo pavardę: ");
                    string forname2 = Console.ReadLine();
                    Console.WriteLine();
                    PlayerList = Prisiregistravimas(name, forname, PlayerList);

                    Console.WriteLine("Norėdami gryžti į meniu spauskite 'Q'");
                }// Prisijungimas 

                if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine(name + " ačiū už dalyvavimą!");
                    Thread.Sleep(1500);
                    break;
                }//nutraukiamas zaidimas 

                if (input == "3")
                {
                    Console.Clear();
                    Console.WriteLine("                                               Žaidėjas " + name);
                    GameRuels();
                    Console.WriteLine();
                    Console.WriteLine("Norėdami gryžti į meniu spauskite 'Q'");

                }//zaidimo taisykles

                if (input == "4")
                {
                    Console.Clear();
                    Console.WriteLine("                                               Žaidėjas " + name);
                    Console.WriteLine();
                    gameResult(fullname, PlayerList);
                    Console.WriteLine();
                    //Console.WriteLine("Norėdami gryžti į meniu spauskite 'Q'");

                }//zaideju antspausdinimas (neveikia Y)

                if (input == "5")
                {
                    Console.Clear();
                    Console.WriteLine("                                               Žaidėjas " + name);
                    Console.WriteLine();
                    StartGame(fullname, PlayerList);
                    Console.WriteLine();
                    Console.WriteLine("Norėdami gryžti į meniu spauskite 'Q'");
                }// zaidimas

                if (input == "6")
                {
                    Console.Clear();
                    Console.Clear();
                    Console.WriteLine("                                               Žaidėjas " + name);
                    Console.WriteLine();
                    NaujoRegistravimas(name, forname, PlayerList);
                    Console.WriteLine();
                    Console.WriteLine("Norėdami gryžti į meniu spauskite 'Q'");
                }// naujo zaidejo registravimas
            }
        }
        public static Dictionary<string, int> NaujoRegistravimas(string name1, string forname1, Dictionary<string, int> PlayerList)
        {
            Console.WriteLine("Įveskite savo vardą: ");
            string name2 = Console.ReadLine();
            Console.WriteLine("Įveskite savo pavardę: ");
            string forname2 = Console.ReadLine();

            string fullname = name2 + " " + forname2;

            if (PlayerList.ContainsKey(fullname))
            {
                Console.WriteLine("Jūs naudojate jau egzistuojančio vartotojo paskyrą");
            }
            else
            {
                PlayerList[fullname] = 0;
                Console.WriteLine("Sveikas prisijungęs " + name2);
                Console.WriteLine();
            }
            return PlayerList;
        }
        public static Dictionary<string, int> gameResult(string name, Dictionary<string, int> PlayerList)
        {
            List<string> playerL = new List<string>();
            playerL.Add("Pasirinkite:");
            playerL.Add("1 - Dalyvių sąrašas");
            playerL.Add("2 - Dalyvių ir razultatų sąrašas");
            Console.Clear();
            Console.WriteLine("                                               Žaidėjas " + name);
            Console.WriteLine();
            foreach (string playerlis in playerL)
            {
                Console.WriteLine(playerlis);
                Console.WriteLine();
            }

            string inputplayerList = Console.ReadLine().ToLower(); // q veikia bet neveikia y

            if (inputplayerList == "Y")
            {
                Console.Clear();
                Console.WriteLine("                                               Žaidėjas " + name);
                Console.WriteLine();
                foreach (string playerlis in playerL)
                {
                    Console.WriteLine(playerlis);
                    Console.WriteLine();
                    Console.Clear();
                }
            }// sugrazina i saraso meniu
            if (inputplayerList == "1")
            {
                Console.Clear();
                Console.WriteLine("                                            Žaidėjas " + name);
                Console.WriteLine();
                foreach (var list in PlayerList)
                {
                    Console.WriteLine("Žaidėjas : " + list.Key);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Norėdami gryžti į pagrindinį MENIU spauskite 'Q'");

                Console.WriteLine("Norėdami gryžti į Žaidėjų sąrašo meniu spauskite 'Y'");
                Console.WriteLine();

            }// dalyviu sarasas
            if (inputplayerList == "2")
            {
                Console.Clear();
                Console.WriteLine("                                             Žaidėjas " + name);
                Console.WriteLine();
                //pagal kokia reiksme bus rusiuojama
                var sortedPlayerScores = PlayerList.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                int volum1 = 0;
                foreach (var list in sortedPlayerScores)
                {
                    if (volum1 < 10)
                    {
                        Console.Write((volum1 + 1) + " )");
                    }

                    for (int i = 0; i <= volum1 && volum1 < 3; i++)
                    {
                        Console.Write(" * ");
                    }

                    Console.WriteLine(list.Key + " turimi taškai: " + list.Value);
                    Console.WriteLine();

                    volum1++;
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Norėdami gryžti į pagrindinį MENIU spauskite 'Q'");
                Console.WriteLine("Norėdami gryžti į Žaidėjų sąrašo meniu spauskite 'Y'");
                Console.WriteLine();

            }// dalyviu sarasas su rezultatais
            return PlayerList;
        }
        public static Dictionary<string, int> StartGame(string name1, Dictionary<string, int> PlayerList)//reikes paduoti zaideju dictionary tam kad papildyti jo value
        {
            Dictionary<string, string> gameMovie = new Dictionary<string, string>()//reikes panaudoti ToLower
            {
                {"Kuriame filme vaidina Keanu Reeves?\r\n a) \"Pirmasis kraujas\" \r\n b) \"Transformeriai\" \r\n c) \"Matrix\" \r\n d) \"Alkai\"", "c" },
                {"Kas yra žinomas kaip 'Žiedo valdovas' 'Žiedų valdovo' filme?\r\n a) Aragorn\r\n b) Gandalfas\r\n c) Frodo\r\n d) Legolas", "c" },
                {"Koks yra Tarantino filmo 'Pulp Fiction' pagrindinis veikėjas?\r\na) Vincent Vega\r\nb) Jack Dawson\r\nc) Forrestas Gampas\r\nd) Hannibalas Lecteris", "a" },
                {"Kas yra 'Harry Potter' knygų ir filmų pagrindinis veikėjas?\r\na) Ronas Weasley\r\nb) Hermiona Granger\r\nc) Draco Malfoy\r\nd) Harry Potter", "d" },
                {"Kuriame filme pasirodo 'Terminatorius' vaidinamas Arnold Schwarzenegger?\r\na) \"Predatorius\"\r\nb) \"Terminatorius 2: teismas dienos šviesoje\"\r\nc) \"Aliens\"\r\nd) \"Rambo\"", "b" },
            };// pirma kategorija 5 klausimai

            Dictionary<string, string> gameSport = new Dictionary<string, string>()
            {
                {"Kuris sportininkas laikomas 'The Greatest' (Didžiausiu) bokso pasaulyje?\r\na) Mike Tyson\r\nb) Muhammad Ali\r\nc) Manny Pacquiao\r\nd) Sugar Ray Robinson", "b" },
                {"Kiekvieno NFL futbolo komandos sezono pradžioje paprastai vyksta vienas stebuklingas rungtynių vakaras. Kaip jis vadinamas?\r\na) Įšaldytasis tundra\r\nb) Pradedamosios rungtynės\r\nc) Šeimos diena\r\nd) Super Bowl", "b" },
                {"Kas yra \"Wimbledon\" teniso turnyro specialumas?\r\na) Diržas\r\nb) Smuikas\r\nc) Raudonas kilimėlis\r\nd) Žalia aikštelė?", "d" },
                {"Kuriame mieste vyksta kasmetinis \"Tour de France\" dviračių lenktynių turas?\r\na) Londonas\r\nb) Paryžius\r\nc) Barselona\r\nd) Romos", "b" },
                {"Kiekvienas krepšininkas svajoja laimėti \"NBA\" čempionato žiedą. Kokia komanda daugiausia kartų laimėjo šį žiedą?\r\na) Los Angeles Lakers\r\nb) Boston Celtics\r\nc) Chicago Bulls\r\nd) Miami Heat", "a" }
            };// antra kategorija

            Dictionary<string, string> gameScience = new Dictionary<string, string>()
            {
                {"Kas yra H2O cheminė formulė?\r\na) Anglies dioksidas\r\nb) Vanduo\r\nc) Amoniakas\r\nd) Oksigenas", "b" },
                {"Kas yra periodinės lentelės pirmasis elementas?", "c" },
                {"Kas yra populiariausia mokslinė teorija apie visatos atsiradimą?", "d" },
                {"Kas yra genetinės medžiagos molekulė, kuri yra atsakinga už paveldimumą?\r\na) Rūgštis\r\nb) DNR (deoksiribonukleorūgštis)\r\nc) Fermentas\r\nd) Karbonatas?", "b" },
                {"Koks elementas sudaro daugumą Žemės atmosferos?\r\na) Azotas\r\nb) Hidrogenas\r\nc) Deguonis\r\nd) Anglis", "a" }
            };// trecia kategorija

            List<string> kategories = new List<string>();
            kategories.Add("Pasirinkite kategorija:");
            kategories.Add("1 - Filmai");
            kategories.Add("2 - Sportas");
            kategories.Add("3 - Mokslas");

            foreach (string category in kategories)
            {
                Console.WriteLine(category);
            } //pasirinktu kategoriju atspausdinimas

            int choosecategories = Convert.ToInt32(Console.ReadLine());

            if (choosecategories == 1)
            {
                Console.Clear();
                string[] movie = gameMovie.Values.ToArray();
                string[] moviequestion = gameMovie.Keys.ToArray();
                int volum = 0;
                int index = 0;
                for (int i = 0; index < moviequestion.Length; i++)
                {
                    Console.WriteLine(moviequestion[index]);
                    Console.WriteLine("Atsakymas");
                    string answer = Console.ReadLine().ToLower();

                    if (movie[index].Contains(answer))
                    {
                        volum++;
                    }


                    index++;
                    Console.Clear();
                }
                PlayerList[name1] = volum;

            }//gameMovie

            if (choosecategories == 2)
            {
                Console.Clear();
                string[] sport = gameSport.Values.ToArray();
                string[] sportquestion = gameSport.Keys.ToArray();
                int volum = 0;
                int index = 0;
                for (int i = 0; index < sportquestion.Length; i++)
                {
                    Console.WriteLine(sportquestion[index]);
                    Console.WriteLine("Atsakymas");
                    string answer = Console.ReadLine().ToLower();

                    if (sport[index].Contains(answer))
                    {
                        volum++;
                    }


                    index++;
                    Console.Clear();
                }
                PlayerList[name1] = volum;
                Console.Clear();

            }//gameSport

            if (choosecategories == 3)
            {
                Console.Clear();
                string[] science = gameScience.Values.ToArray();
                string[] sciencequestion = gameScience.Keys.ToArray();
                int volum = 0;
                int index = 0;
                for (int i = 0; index < sciencequestion.Length; i++)
                {
                    Console.WriteLine(sciencequestion[index]);
                    Console.WriteLine("Atsakymas");
                    string answer = Console.ReadLine().ToLower();

                    if (science[index].Contains(answer))
                    {
                        volum++;
                    }
                    index++;
                    Console.Clear();
                }
                PlayerList[name1] = volum;

            }//gameScience    

            return PlayerList;
        }
        public static void GameRuels()
        {
            List<string> gameruels = new List<string>();

            gameruels.Add("1. Žaidimo esmė");
            gameruels.Add("QUIZZZ - intelektualus, kuriame varžovai varžosi tarpusavyje, kurie surinks kuo daugiau taškų į užduodamus klausimus.");

            foreach (string s in gameruels)
            {
                Console.WriteLine(s);
            }


        }
        public static Dictionary<string, int> Prisiregistravimas(string name, string forname, Dictionary<string, int> PlayerList)
        {

            PlayerList[name + " " + forname] = 0;
            Console.WriteLine("Sveikas prisijungęs " + name);
            Console.WriteLine();
            return PlayerList;

        }
        public static void MeniuList()
        {
            List<string> meniu = new List<string>();

            meniu.Add("Meniu: ");
            meniu.Add("1 - Prisijungimas");
            meniu.Add("2 - Atsijungti");
            meniu.Add("3 - Žaidimo taidyklės");
            meniu.Add("4 - Žaidimo dalyvių ir jų rezultatų peržiūra");
            meniu.Add("5 - Start game");
            meniu.Add("6 - Registruotis naujam žaidėju");
            foreach (string men in meniu)
            {
                Console.WriteLine(men);
            }


        }
    }
}




