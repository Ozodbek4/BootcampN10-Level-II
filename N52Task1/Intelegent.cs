namespace N52Task1;

public class Intelegent
{
    public List<Topic> KnownScience { get; set; }
    public Intelegent() {
        KnownScience = new List<Topic>();
    }
    //public Intelegent(List<Topic> intelegnet)
    //{
    //    KnownScience = intelegnet;
    //}
    public Intelegent Copy()
    {
        var b = new Intelegent();
        foreach (var item in KnownScience)
        {
            b.KnownScience.Add(item.Copy());
        }
        return b;
    }
}