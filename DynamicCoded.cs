/// <summary>
/// The lipogram generation implementation.
/// </summary>
namespace DynamicCodedLipograms
{
    /// <summary>
    /// Dynamically generating words with their lipogram taken away.
    /// </summary>
    class DynamicCoded
    {
        /// <summary>
        /// Generates a random lipogram from the correct alphabet/script.
        /// </summary>
        /// <param name="language">The alphabet/script required</param>
        /// <returns>A string of one of the members of the respective alphabet.</returns>
        public static string LipogramsDynamicCoded(string language)
        {
            List<string> products = new List<string>();
            List<string> Lipos = new List<string>();
            switch (language)
            {
                case "1":
                    Lipos.AddRange(new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });
                    break;
                case "2":
                    Lipos.AddRange(new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ä", "ö", "ü", "ß" });
                    break;
                case "3":
                    Lipos.AddRange(new[] { "అ", "ఆ", "ఇ", "ఈ", "ఉ", "ఊ", "ఋ", "ౠ", "ఌ", "ౡ", "ఎ", "ఏ", "ఐ", "ఒ", "ఓ", "ఔ", "అం", "అః", "క", "ఖ", "గ", "ఘ", "ఙ", "చ", "ఛ", "జ", "ఝ", "ఞ", "ట", "ఠ", "డ", "ఢ", "ణ", "త", "థ", "ద", "ధ", "న", "ప", "ఫ", "బ", "భ", "మ", "య", "ర", "ల", "వ", "శ", "ష", "స", "హ", "ళ", "క్ష", "ఱ" });
                    break;
                default:
                    break;
            }
            Random rnd = new Random();
            int LipoPosition = rnd.Next(Lipos.Count - 1);
            return (Lipos[LipoPosition]);
        }

        /// <summary>
        /// Queries user for their language and resource choice. The WordsRepo folder must be in the same folder as the exectuable file.
        /// </summary>
        /// <returns>A string array of two elements: [0] is language choice, [1] is the path to the resource choice.</returns>
        public static string[] GetLanguageAndPath()
        {
            Console.WriteLine("Choose your language:\n1: English\n2: Deutsch\n3: Telugu");
            string? language = Console.ReadLine();
            string source = "";
            switch (language)
            {
                case "1":
                    Console.WriteLine("Choose your resource:\n1: Ulysses Chapter 1, James Joyce\n2: New York Times article on birds\n3: English dictionary (exhaustive)");
                    string? choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            source = "UlyssesChp1.txt";
                            break;
                        case "2":
                            source = "NYTarticle.txt";
                            break;
                        case "3":
                            source = "Dictionary.txt";
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Wählen Sie Ihre Worte:\n1: Die Welt Von Gestern, Stefan Zweig\n2: Ein Artikel über die Franz-Josef-Land-Expedition\n3: Deutsches Wörterbuch (gründlich)");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            source = "DieWeltVonGestern.txt";
                            break;
                        case "2":
                            source = "FranzJosefLand.txt";
                            break;
                        case "3":
                            source = "DeutschWörterbuch.txt";
                            break;
                        default:
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("మీ పదాలను ఎంచుకోండి:\n1: తెలుగు నిఘంటువు\n2: సీతాకల్యాణం\n3: వలస పక్షుల వ్యాసం");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            source = "TeluguDictionary.txt";
                            break;
                        case "2":
                            source = "Seethakalyanam.txt";
                            break;
                        case "3":
                            source = "MigratoryBirdsTelugu.txt";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/WordsRepo/" + source;
            string[] LanguageAndPath = new string[] { language!, path };
            return (LanguageAndPath);
        }

        /// <summary>
        /// Generates a random word from the language and resource choice.
        /// </summary>
        /// <param name="path">The path to the user requested resource.</param>
        /// <returns>A random word  with being lipogrammed.</returns>
        public static string GetOriginalWord(string path)
        {
            string[] words = File.ReadAllLines(path);

            //Random number between 0 and number of words - 1. 
            Random rnd = new Random();
            int wordPosition = rnd.Next(words.Length - 1);

            // Get a word from one of the 
            return (words[wordPosition]);

        }

        /// <summary>
        /// Generates a word from the user-requested source, and removes all instances of the lipogram character.
        /// </summary>
        /// <param name="path">The path to the user requested resource.</param>
        /// <param name="Lipo">The lipogram</param>
        /// <returns>A lipogrammed word.</returns>
        public static string LipogrammedDynamicString(string path, string Lipo)
        {
            bool match = false;
            string OrigString = "";
            while (!match)
            {
                OrigString = GetOriginalWord(path);
                if (OrigString.Contains(Lipo))
                {
                    match = true;
                }
            }
            string Lower = OrigString.ToLower();
            for (int i = 0; i < Lipo.Length; i++)
            {
                Lower = Lower.Replace(Lipo.ToLower(), "");
                //Lower = Lower.Replace(@Lipos[i].ToLower(), "");
            }
            return (Lower);
        }

        /// <summary>
        /// Determines whether the user has guessed the correct lipogram. If the guess is not empty, then the number of guesses increases.
        /// </summary>
        /// <param name="Lipo">The correct lipogram</param>
        /// <param name="LipoGuess">The user's guess at the lipogram.</param>
        /// <returns>Whether the user's guess is correct.</returns>
        public static bool LipoGuess(string Lipo, string LipoGuess)
        {
            if (LipoGuess != "")
            {
                GlobalVariables.GuessCounter++;
            }
            if (Lipo == LipoGuess.ToLower())
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
    /// <summary>
    /// These variables provide a summary of the user's performance.
    /// </summary>
    class GlobalVariables
    {
        public static int GuessCounter = 0;
        public static int WordCounter = 1;
        public static int CharCounter = 0;
    }
}