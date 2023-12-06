public class WorkoutDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}

public class SetDTO {
    public long Id {get ;set;}
    public int Amount { get;set;}
    public int Distance {get; set;}
    public SetType Type {get;set;}
}
