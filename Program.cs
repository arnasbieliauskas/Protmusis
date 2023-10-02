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
            Console.WriteLine();
            PlayerList = Prisijungimas(name, forname, PlayerList);
            MeniuList();
            Console.WriteLine();
            Console.WriteLine();



            while (true)
            {
                Console.WriteLine("Jūsų pasirinkimas " + name);

                var input = Console.ReadLine().ToLower();

                if (input == "q")
                {
                    MeniuList();
                }

                if (input == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Įveskite savo vardą: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Įveskite savo pavardę: ");
                    forname = Console.ReadLine();
                    Console.WriteLine();
                    PlayerList = Prisijungimas(name, forname, PlayerList);

                    Console.WriteLine("Norėdami gryžti į meniu spauskite 'Q'");


                }// Prisijungimas sutvarkytas

                if (input == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Ačiū už dalyvavimą!");
                    Thread.Sleep(1500);
                    break;
                }//nutraukiamas zaidimas Dar reikes sutvarkyti

                if (input == "3")
                {
                    Console.Clear();
                    GameRuels();
                    Console.WriteLine();
                    Console.WriteLine("Norėdami gryžti į meniu spauskite 'Q'");

                }//zaidimo taisykles

                if (input == "4")
                {
                    Console.Clear();
                    gameResult(PlayerList);

                }//zaideju antspausdinimas

                if (input == "5")
                {
                    StartGame(name, PlayerList);
                    Console.WriteLine();
                    Console.WriteLine("Norėdami gryžti į meniu spauskite 'Q'");

                }//zaidimas

                else
                {
                    Console.WriteLine("Netinkamas pasirinkimas");
                }// netinkamas pasirinkimas

            }

        }

        public static Dictionary<string, int> gameResult(Dictionary<string, int> PlayerList)
        {
            List<string> playerL = new List<string>();
            playerL.Add("Pasirinkite:");
            playerL.Add("1 - Dalyvių sąrašas");
            //playerL.Add("2 - Dalyvių ir razultatų sąrašas");
            foreach (string playerlis in playerL)
            {
                Console.WriteLine(playerlis);
                Console.WriteLine();
            }

            string inputplayerList = Console.ReadLine().ToLower();

            if (inputplayerList == "Y")
            {
                foreach (string playerlis in playerL)
                {
                    Console.WriteLine(playerlis);
                    Console.WriteLine();
                    Console.Clear();
                }
            }// sugrazina i saraso meniu
            if (inputplayerList == "1")
            {

                foreach (var list in PlayerList)
                {
                    Console.WriteLine("Žaidėjas : " + list.Key);
                    Console.WriteLine();

                    Console.WriteLine("Norėdami gryžti į pagrindinį MENIU spauskite 'Q'");
                    Console.WriteLine();
                    Console.WriteLine("Norėdami gryžti į Žaidėjų sąrašo meniu spauskite 'Y'");
                    Console.WriteLine();


                }
            }// dalyviu sarasas

            if (inputplayerList == "2")
            {
                Console.Clear(); 
                //pagal kokia reiksme bus rusiuojama
                var sortedPlayerScores = PlayerList.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

                foreach (var list in sortedPlayerScores)
                {
                    //for (i = 0; i < sortedPlayerScores.Count; i++)
                    //{

                    //}


                    //        Console.WriteLine("Žaidėjas : " + list.Key + " turimi taškai: " + list.Value);
                    //        Console.WriteLine();
                    //        Console.WriteLine("Norėdami gryžti į pagrindinį MENIU spauskite 'Q'");
                    //        Console.WriteLine();
                    //        Console.WriteLine("Norėdami gryžti į Žaidėjų sąrašo meniu spauskite 'Y'");
                    //        Console.WriteLine();
                    //        Console.Clear();
                    //    }


                    //}// nesutvarkytas
                    
                }
            }
            return PlayerList;
        }
        public static Dictionary<string, int> StartGame(string name, Dictionary<string, int> PlayerList)//reikes paduoti zaideju dictionary tam kad papildyti jo value
        {
            Dictionary<string, string> gameMovie = new Dictionary<string, string>()//reikes panaudoti ToLower
            {
                {"Kuris aktorius pelnė geriausią aktoriaus Oskarą už filmus „Filadelfija“ (1993) ir „Forrest Gump“ (1994)?", "tom hanks" },
                {"Kuris aktorius pateikė balsą personažui Nemo 2003 m. Filme „Rasti Nemo“?", "aleksandras gouldas" },
                {"Amerikiečių aktorė, vaidinusi Tokijo požemio boso O-Ren Ishii vaidmenį filme „KillBill I I & II“", "lucy liu" },
                {"Kaip vadinasi 2015 m. Filmas apie pasienietį 1820-ųjų prekybos kailiais ekspedicijoje ir jo kovą už išlikimą, kai mane nugvelbė meška?", "wielebny" },
                {"Kuris 1982 m. Filmas buvo labai gerbėjų sutiktas dėl meilės tarp jauno, tėvo neturinčio priemiesčio berniuko ir pasiklydusio, geranoriško bei namuose gyvenančio svečio iš kitos planetos vaizdavimo?", "ir nežemiškas" },
            };// pirma kategorija

            Dictionary<string, string> gameSport = new Dictionary<string, string>()
            {
                {"Kas 2001 m. Buvo BBC „Metų sporto asmenybė“?", "davidas beckhamas" },
                {"Kokiomis sporto šakomis pasižymėjo Neilas Adamsas?", "dziudo" },
                {"Kuri šalis laimėjo 1982 m. Ispanijos pasaulio taurę, įveikdama Vakarų Vokietiją 3-1?", "italija" },
                {"Kuri komanda laimėjo Amerikos futbolo „Superbowl“ 1993, 1994 ir 1996 m.", "dallas cowboys" },
                {"Kuriame sporte kanadietis Connor McDavid yra kylanti žvaigždė?", "ledo ritulys" }
            };// antra kategorija

            Dictionary<string, string> gameScience = new Dictionary<string, string>()
            {
                {"Kas numetė plaktuką ir plunksną Mėnulyje, kad parodytų, jog be oro jie krenta tokiu pat greičiu?", "davidas scottas" },
                {"Kas išrado gramofoną?", "emilis berlineris" },
                {"Kiek metų užtruks iš Žemės paleidžiamas erdvėlaivis, kad pasiektų Plutono planetą?", "devyni su puse metų" },
                {"1930 m. Albertui Einšteinui ir jo kolegai buvo išduotas JAV patentas 1781541. Kam jis skirtas?", "šaldytuvsa" },
                {"Kas išrado žmogaus gaminamus gazuotus gėrimus?", "joseph priestley" }
            };// trecia kategorija

            Dictionary<string, string> gameFootball = new Dictionary<string, string>()
            {
                {"Kuris klubas laimėjo 1986 m. FA taurės finalą?", "liverpool" },
                {"Kuris vartininkas turi rekordą, kad laimėjo daugiausiai Anglijos kepurių, per savo žaidimo karjerą iškovojęs 125 kepures?", "peter shilton" },
                {"Koks yra sero Alexo Fergusono vardas?", "chapman" },
                {"Ar galite įvardyti vadybininką, kuris 1977 m. Vadovavo Anglijos nacionalinei komandai?", "ronas grinvudas" },
                {"Kuri „Lancashire“ komanda žaidžia savo namų žaidimus „Ewood Park“?", "blackburn rovers" }
            };// ketvirta kategorija                    

            List<string> kategories = new List<string>();
            kategories.Add("Pasirinkite kategorija:");
            kategories.Add("1 - Filmai");
            kategories.Add("2 - Sportas");
            kategories.Add("3 - Mokslas");
            kategories.Add("4 - Futbolas");
            kategories.Add("5 - Grįžti į pagrindinį meniu");

            foreach (string category in kategories)
            {
                Console.WriteLine(category);
            } //pasirinktu kategoriju atspausdinimas
            int choosecategories = Convert.ToInt32(Console.ReadLine());

            if (choosecategories == 1)
            {
                string[] movie = gameMovie.Keys.ToArray();
                int volum = 0;

                int index = 0;
                for (int i = 0; index < movie.Length; i++)
                {
                    Console.WriteLine(movie[index]);
                    Console.WriteLine("Atsakymas");
                    string answer = Console.ReadLine().ToLower();

                    if (gameMovie.ContainsValue(answer))
                    {
                        volum++;
                    }
                    index++;
                }

            }//gameMovie

            if (choosecategories == 2)
            {
                string[] sport = gameSport.Keys.ToArray();

                int volum = 0;

                int index = 0;
                for (int i = 0; index < sport.Length; i++)
                {
                    Console.WriteLine(sport[index]);
                    Console.WriteLine("Atsakymas");
                    string answer = Console.ReadLine().ToLower();

                    if (gameMovie.ContainsValue(answer))
                    {
                        volum++;
                    }
                    index++;
                }
                PlayerList[name] = volum;
            }//gameSport

            if (choosecategories == 3)
            {
                string[] science = gameScience.Keys.ToArray();
                int volum = 0;

                int index = 0;
                for (int i = 0; index < science.Length; i++)
                {
                    Console.WriteLine(science[index]);
                    Console.WriteLine("Atsakymas");
                    string answer = Console.ReadLine().ToLower();

                    if (gameMovie.ContainsValue(answer))
                    {
                        volum++;
                    }
                    index++;
                }
                PlayerList[name] = volum;

            }//gameScience

            if (choosecategories == 4)
            {
                string[] football = gameFootball.Keys.ToArray();
                int volum = 0;

                int index = 0;
                for (int i = 0; index < football.Length; i++)
                {
                    Console.WriteLine(football[index]);
                    Console.WriteLine("Atsakymas");
                    string answer = Console.ReadLine().ToLower();

                    if (gameMovie.ContainsValue(answer))
                    {
                        volum++;
                    }
                    index++;
                }
                PlayerList[name] = volum;
            }//gameFootball

            if (choosecategories == 5)
            {
                MeniuList();
            }//gryžti i pagrindini meniu

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
        public static Dictionary<string, int> Prisijungimas(string name, string forname, Dictionary<string, int> PlayerList)
        {
            string fullname = name + " " + forname;

            if (PlayerList.ContainsKey(fullname))
            {
                Console.WriteLine("Jūs naudojate jau egzistuojančio vartotojo paskyrą");
            }
            else
            {
                PlayerList[name + " " + forname] = 0;
                Console.WriteLine("Sveikas prisijungęs " + name);
                Console.WriteLine();
            }

            return PlayerList;

        }//neivykdo if salygos
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

