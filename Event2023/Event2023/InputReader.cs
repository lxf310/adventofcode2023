namespace Event2023
{
    public class InputReader
    {
        public List<string> ReadInputs(string filename)
        {
            if (string.IsNullOrEmpty(filename)) throw new ArgumentNullException(nameof(filename));

            if (!File.Exists(filename)) throw new ArgumentException();

            var lines = File.ReadAllLines(filename);
            var ret = new List<string>();
            foreach (var line in lines)
            {
                var cleanLine = line.Replace("\n", "").Replace("\r", "");
                if (!string.IsNullOrWhiteSpace(cleanLine))
                {
                    ret.Add(cleanLine);
                }
            }

            return ret;
        }
    }
}
