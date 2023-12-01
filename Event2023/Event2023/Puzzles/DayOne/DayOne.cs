namespace Event2023.Puzzles.DayOne
{
    public class DayOne
    {
        private readonly INumberReader _numberReader;

        public DayOne(INumberReader numberReader)
        {
            _numberReader = numberReader ?? throw new ArgumentNullException(nameof(numberReader));
        }

        public int Total(List<string> inputs)
        {
            if (inputs == null || !inputs.Any()) return 0;

            int ret = 0;
            foreach (var input in inputs)
            {
                ret += _numberReader.Read(input);
            }

            return ret;
        }
    }
}
