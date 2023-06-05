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
        /// 1: Give game instructions.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="path"></param>
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

            // Print lipogrammed words
            while (!GuessCorrect)
            {
                Lipogrammed = DynamicCoded.LipogrammedDynamicString(path, Lipo);
                Console.WriteLine("- " + Lipogrammed);
                GlobalVariables.CharCounter = GlobalVariables.CharCounter + Lipogrammed.Length;
                GlobalVariables.WordCounter++;
                GuessCorrect = DynamicCoded.LipoGuess(Lipo, Console.ReadLine());
            }

            // Stop watch
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Lipogram is: " + Lipo + "\nTime taken: " + elapsedTime + "\nTotal number of guesses: " + GlobalVariables.GuessCounter + "\nTotal number of words: " + GlobalVariables.WordCounter + "\nTotal number of characterss: " + GlobalVariables.CharCounter + "\nThank you for playing!\nWould you like to play again?\n'Y' or 'N', or 'S' for change of language and/or words");
            switch (Console.ReadLine().ToLower())
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