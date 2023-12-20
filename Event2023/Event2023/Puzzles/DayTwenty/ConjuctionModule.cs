namespace Event2023.Puzzles.DayTwenty
{
    public class ConjuctionModule : Module
    {
        public ConjuctionModule(string name) : base(name, ModuleType.Conjunction)
        {
            PreModules = new Dictionary<string, PulseType>();
        }

        public override PulseType Action(string name, PulseType pulse, Dictionary<string, Module> modules)
        {
            PreModules[name] = pulse;

            foreach (var pt in PreModules.Values)
            {
                if (pt != PulseType.High)
                {
                    return PulseType.High;
                }
            }

            return PulseType.Low;
        }
    }
}
