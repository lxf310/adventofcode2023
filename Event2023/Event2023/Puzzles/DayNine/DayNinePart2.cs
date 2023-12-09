namespace Event2023.Puzzles.DayNine
{
    public class DayNinePart2 : DayNineBase
    {
        public override int Next(List<int> history)
        {
            var memo = GetMemo(history);
            var curFirst = 0;

            for (int i = memo.Count - 1; i > 0; i--)
            {
                var tmp = memo[i - 1].First() - curFirst;
                curFirst = tmp;
            }

            return curFirst;
        }
    }
}
