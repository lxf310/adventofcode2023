namespace Event2023.Puzzles.DayNine
{
    public class DayNinePart1 : DayNineBase
    {
        public override int Next(List<int> history)
        {
            var memo = GetMemo(history);

            for (int i = memo.Count - 1; i > 0; i--)
            {
                var tmp = memo[i].Last() + memo[i - 1].Last();
                memo[i - 1].Add(tmp);
            }

            return memo[0].Last();
        }
    }
}
