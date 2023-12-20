namespace Event2023.Puzzles.DayTwenty
{
    public class FlipFlopModule : Module
    {
        public FlipFlopModule(string name) : base(name, ModuleType.FlipFlip)
        {
        }

        public override PulseType Action(string name, PulseType pulse, Dictionary<string, Module> modules)
        {
            if (pulse == PulseType.Low)
            {
                if (!Status)
                {
                    Status = true;
                    return PulseType.High;
                }
                else
                {
                    Status = false;
                    return PulseType.Low;
                }
            }

            return PulseType.None;
        }
    }
}
