namespace Event2023.Puzzles.DayTwenty
{
    public abstract class Module
    {
        public Module(string name, ModuleType type)
        {
            Name = name;
            Status = false;
            //Pulse = PulseType.Low;
            Type = type;
        }

        public string Name { get; set; }
        public List<string> NextModuleName { get; set; }
        public Dictionary<string, PulseType> PreModules { get; set; }
        public bool Status { get; set; }
        //public PulseType Pulse { get; set; }
        public ModuleType Type { get; set; }
        public abstract PulseType Action(string name, PulseType pulse, Dictionary<string, Module> modules);
    }
}
