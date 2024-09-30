using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Cards;

internal class Program
{
    static void Main(string[] args)
    {
        List<Card> list = new List<Card>();

        string[] cardsInfo = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < cardsInfo.Length; i += 2)
        {
            string cardFace = cardsInfo[i];
            string cardSuit = cardsInfo[i + 1];

            try
            {
                Card card = CreateCard(cardFace, cardSuit);
                list.Add(card);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(string.Join(" ", list));
    }

    static Card CreateCard(string cardFace, string cardSuit)
    {
        return new Card(cardFace, cardSuit);
    }


    public class Card
    {
        // TODO with enum!
        //    bool isValidCorps = Enum.TryParse<Corps>(tokens[5], out Corps corps);

        //    if (!isValidCorps)
        //    {
        //        throw new Exception();
        //    }

        private List<string> Faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        //private List<string> Suits = new() { "S", "H", "D", "C" };
        private Dictionary<string, string> Suits = new()
        {
        {"S","\u2660"},
        {"H", "\u2665"},
        {"D", "\u2666"},
        {"C", "\u2663"},
        };

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Suit = suit;
            Face = face;
        }

        public string Suit
        {
            get { return suit; }
            set
            {
                if (!Suits.ContainsKey(value.ToUpper()))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = value.ToUpper();

            }
        }

        public string Face
        {
            get { return face; }
            set
            {
                if (!Faces.Contains(value.ToUpper()))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value.ToUpper();
            }
        }

        public override string ToString()
        {
            return $"[{Face}{Suits[suit]}]";
        }
    }

}