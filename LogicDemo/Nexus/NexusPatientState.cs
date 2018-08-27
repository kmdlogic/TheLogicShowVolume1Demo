namespace LogicDemo.Nexus
{
    public class NexusPatientState
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public NexusPatientStateType Type { get; set; }
        public bool Active { get; set; }
        public bool DefaultObject { get; set; }
    }
}