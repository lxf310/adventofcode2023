namespace Event2023
{
    public class Helper
    {
        public static long GCD(long a, long b) // greatest common dividor
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static List<string> ReadInputs(string filename, bool removeWhiteLine = true)
        {
            if (string.IsNullOrEmpty(filename)) throw new ArgumentNullException(nameof(filename));

            if (!File.Exists(filename)) throw new ArgumentException();

            var lines = File.ReadAllLines(filename);
            var ret = new List<string>();
            foreach (var line in lines)
            {
                var cleanLine = line.Replace("\n", "").Replace("\r", "");
                if (removeWhiteLine)
                {
                    if (!string.IsNullOrWhiteSpace(cleanLine))
                    {
                        ret.Add(cleanLine);
                    }
                }
                else
                {
                    ret.Add(cleanLine);
                }
            }

            return ret;
        }
    }
}
