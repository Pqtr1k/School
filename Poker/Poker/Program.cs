using Poker;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Poker
{
    //KARTY
    public class Karty
    {
        public string Symbol { get; set; }
        public string Type { get; set; }

        public Karty(string symbol, string type)
        {
            Symbol = symbol;
            Type = type;
        }
        public override string ToString()
        {
            return Type + Symbol;
        }
    }

    //TALIA
    public class Talia
    {
        public List<Karty> cards;
        public string[] types = { "9", "10", "Walet", "Dama", "Król", "As" };
        public string[] symbols = { "Karo", "Pik", "Trefl", "Kier" };

        //TALIA.DOBIERANIE KART
        public Karty Karty_dobierane()
        {
            Karty card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        public Talia()
        {
            cards = new List<Karty>();
            foreach (var type in types)
            {
                foreach (var symbol in symbols)
                {
                    cards.Add(new Karty(symbol, type));
                }
            }
        }
    }

    //STÓŁ
    public class Stol : Talia
    {
        public Stol()
        {
            foreach (var type in types)
            {
                foreach (var symbol in symbols)
                {
                    cards.Add(new Karty(symbol, type));
                }
            }
        }
        //STÓŁ.TASOWANIE
        public void Tasowanie()
        {
            Random random = new Random();

            for (int i = cards.Count; i < 0; i--)
            {
                int d = random.Next(cards.Count + 1);
                Karty temp = cards[i];
                cards[i] = cards[d];
                cards[d] = temp;
            }
        }
    }

    //GRA
    public class Game
    {
        private Talia talia;
        private Stol stol;
        private List<Karty> gracz;

        public Game()
        {
            talia = new Talia();
            stol = new Stol();
            gracz = new List<Karty>();
        }

        //Ilosc kart
        public void Example(int ilKart)
        {
            stol.Tasowanie();
            for (int i = 0; i < ilKart; i++)
            {
                gracz.Add(stol.Karty_dobierane());
            }
        }

        //public void Dobieranie_nowych_kart()
        //{
        //for(int i = 0;i < gracz.Count; i++)
        //{
        //.Add(stol.Karty_dobierane());
        //}
        //}

        //Dobieranie nowych kart dla gracza
        public void Dobieranie_nowych_kart(List<int> indeksy)
        {
            foreach (int index in indeksy)
            {
                gracz[index] = stol.Karty_dobierane();
            }
        }
        //Wybieranie karty
        public void Wystaw()
        {
            Console.WriteLine("Wybierz karte: ");
            foreach (var card in gracz)
            {
                Console.WriteLine(card);
            }
        }
    }

    //MAIN
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Example(5);
            game.Wystaw();

            Console.WriteLine("Podaj karty, które chcesz odrzucić lub zachowaj wszystkie naciskając enter");
            string dane = Console.ReadLine();

            //Sprawdzanie czy dane wpisane przez gracze istnieja
            if (!string.IsNullOrWhiteSpace(dane))
            {
                //rozdzielanie danych za pomoca ","
                string indexesStr = dane.Split(',')[0];
                List<int> indeksy = new List<int>();

                foreach(var indexStr in indexesStr)
                {
                    int index;
                    if (int.TryParse(indexesStr, out index))
                    {
                        indeksy.Add(index);
                    }
                    game.Dobieranie_nowych_kart(indeksy);
                    game.Wystaw();
                }
            }
        }
    }
}