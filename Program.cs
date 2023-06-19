using DynamicCodedLipograms;
using System.Diagnostics;
namespace Mainland
{
    class Program
    {
        /// <summary>
        /// Provides instructions on how to play the game.
        /// </summary>
        /// <param name="args">Nothing is passed to it at the moment. Maybe a username might occur later on.</param>
        /// <returns>Nothing.</returns>
        public static int Main(string[] args)
        {
            //Instructions
            string readmeText = File.ReadAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/readme.txt");
            Console.WriteLine(readmeText + "\n\n----------------------------------------------------------------\n");
            Console.WriteLine("Type the lipogram character and press return.\nIf you don't know the lipogram yet, press return for another word");

            string[] LanguageAndPath = DynamicCoded.GetLanguageAndPath();
            DynamicMain(LanguageAndPath[0], LanguageAndPath[1]);
            //HardCoded.HardMain();
            return (0);
        }

        /// <summary>
        /// 1: Get lipogram
        /// 2: Start stopwatch
        /// 3: Generate lipogrammed words, test user for answer
        /// 4: Loop 3 until correct answer is given
        /// 5: Print results, offer to play again.
        /// </summary>
        /// <param name="language">The language of the words the user wants to play in.</param>
        /// <param name="path">The path to the source of words the user wants to work in.</param>
        public static void DynamicMain(string language, string path)
        {
            // Declarations
            string Lipogrammed = "";
            bool GuessCorrect = false;

            // Get lipogram
            string Lipo = DynamicCoded.LipogramsDynamicCoded(language);

            // Cheat: write lipogram
            Console.WriteLine("CHEAT Lipogram is: " + Lipo);

            // Start the stopwatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Print lipogrammed words and query user.
            while (!GuessCorrect)
            {
                Lipogrammed = DynamicCoded.LipogrammedDynamicString(path, Lipo);
                Console.WriteLine("- " + Lipogrammed);
                GlobalVariables.CharCounter = GlobalVariables.CharCounter + Lipogrammed.Length;
                GlobalVariables.WordCounter++;
                string? guess = Console.ReadLine();
                GuessCorrect = DynamicCoded.LipoGuess(Lipo, guess!);
            }

            // Stop watch
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Lipogram is: " + Lipo + "\nTime taken: " + elapsedTime + "\nTotal number of guesses: " + GlobalVariables.GuessCounter + "\nTotal number of words: " + GlobalVariables.WordCounter + "\nTotal number of characterss: " + GlobalVariables.CharCounter + "\nThank you for playing!\nWould you like to play again?\nYes: 'Y'\nNo:  'N'\nChange of language and/or words: 'S'");
            string? choice = Console.ReadLine()!.ToLower();
            switch (choice)
            {
                case "y":
                    DynamicMain(language, path);
                    break;
                case "s":
                    string[] LanguageAndPath = DynamicCoded.GetLanguageAndPath();
                    DynamicMain(LanguageAndPath[0], LanguageAndPath[1]);
                    break;
                default:
                    // program ends
                    break;
            }
        }
    }
}