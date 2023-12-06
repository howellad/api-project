namespace Api.Models
{
    public class Workout
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class Set
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public int Distance { get; set; }
        public SetType Type { get; set; }
    }

    public enum SetType
    {
        Warmup,
        MainSet,
        PostSet,
        PreSet,
        KickSet
    }
}