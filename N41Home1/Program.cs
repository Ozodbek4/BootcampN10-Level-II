using N41Home1;
using System.Threading.Tasks;

var queue =  new SafeQueue<int>();

try
{
    var lists = new List<Task>()
    {
        new (() => queue.Enqueue(1)),
        new (() => queue.Enqueue(2)),
        new (() => queue.Enqueue(3)),
        new (() => queue.Dequeue()),
        new (() => queue.Dequeue()),
        new (() => queue.Dequeue()),
        new (() => queue.Dequeue()),
        new(() => queue.Enqueue(2)),
    };
    Parallel.ForEach(lists, list => list.Start());
    await Task.WhenAll(lists);
    queue.ForEach(Console.WriteLine);
}
catch(ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}
catch
{
    Console.WriteLine("Exception");
}