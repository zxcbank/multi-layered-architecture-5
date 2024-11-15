using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Repository<T> where T : IHasId
{
    private readonly List<T> _items;

    public IReadOnlyCollection<T> Items => _items;

    public Repository()
    {
        _items = new List<T>();
    }

    public Repository(IEnumerable<T> items)
    {
        _items = items.ToList();
    }

    public Repository<T> AddItem(T item)
    {
        _items.Add(item);
        return this;
    }

    public T? FindItem(int id)
    {
        return _items.Find(x => x.Id == id);
    }
}