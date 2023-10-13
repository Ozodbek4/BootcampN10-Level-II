namespace N52Task1;

public class Topic
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Topic Copy()
    {
        var c = new Topic();
        var randokm = new Random();
        var s = "Assalomu alaykum";
        c.Id = Id;
        c.Name = s.Substring(0,randokm.Next(s.Length)-1);
        return c;
    }
}
