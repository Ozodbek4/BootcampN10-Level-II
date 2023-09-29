
var list1 = new List<BlogPost>()
{
    new BlogPost (1, 1, ",", ",")
};

var list2 = new List<BlogPostService>()
{
    new BlogPostService(1, ",", ",")
};

var a = from b in list1
        join o in list2 on b.CreateID equals o.Id
        select b;


public class BlogPost
{
    public BlogPost(int id, int id1, string name, string description)
    {
        Id = id;
        CreateID = id1;
        Name = name;
        Description = description;
    }

    public int Id { get; set; }
    public int CreateID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}

public class BlogPostService
{
    public BlogPostService(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}