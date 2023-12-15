namespace Event2023.Puzzles.DayFifteen
{
    public abstract class DayFifteenBase
    {
        protected int hash(string step)
        {
            var cur = 0;
            foreach (var ch in step)
            {
                int curCode = (int)ch;
                cur += curCode;
                cur *= 17;
                cur %= 256;
            }

            //Console.WriteLine($"{step}      ->       {cur}");
            return cur;
        }
    }
}
