namespace HardCodedLipograms
{
    /// <summary>
    /// First implementation of the lipogram algorithm, but not generated randomly.
    /// </summary>
    class HardCoded
    {

        public static string[] LipogramsHardCoded()
        {
            string[] Lipos = new string[] { "i", "en", "t" };
            return (Lipos);
        }

        public static string OriginalStringGeneratorHardCoded()
        {
            string Orig = "This sentence is lackng its ego";
            return (Orig);
        }

        public static string LipogrammedHardString()
        {
            string OrigString = OriginalStringGeneratorHardCoded();
            string Lower = OrigString.ToLower();
            string[] Lipos = LipogramsHardCoded();
            for (int i = 0; i < Lipos.Length; i++)
            {
                Lower = Lower.Replace(@Lipos[i].ToLower(), "");
            }
            return (Lower);
        }
        public static void HardMain()
        {
            Console.WriteLine(HardCoded.OriginalStringGeneratorHardCoded());
            Console.WriteLine(HardCoded.LipogrammedHardString());
        }
    }
}