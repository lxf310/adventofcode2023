namespace Event2023.Puzzles.DayFour
{
    public abstract class DayFourBase
    {
        protected List<string> fillList(string input)
        {
            var numbers = new List<string>();
            foreach (var number in input.Trim().Split(' '))
            {
                if (!string.IsNullOrWhiteSpace(number))
                    numbers.Add(number.Trim());
            }

            return numbers;
        }
    }
}
