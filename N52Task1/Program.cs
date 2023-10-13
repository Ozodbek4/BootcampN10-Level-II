using N52Task1;

var intelegent = new Intelegent
{
    KnownScience = new List<Topic> {
    new Topic{Id=Guid.NewGuid(),Name="nima"},
    new Topic{Id=Guid.NewGuid(),Name="nima"},
    new Topic{Id=Guid.NewGuid(),Name="nima"},
}
};
var b = intelegent.Copy();
var a = intelegent.KnownScience.ZipIntersect(b.KnownScience, top => top.Id);
foreach (var (x,y) in a)
{
    Console.WriteLine($"{x.Name} -  {y.Name}");
}