using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.BusinessLogic;

public class Repository<T> where T : IIdentifiable
{
    private readonly Dictionary<long, T> _items;

    public IReadOnlyDictionary<long, T> Items => _items;

    public Repository()
    {
        _items = new Dictionary<long, T>();
    }

    public Repository(Dictionary<long, T> items)
    {
        _items = items;
    }

    public Repository<T> AddItem(T item)
    {
        _items.Add(item.Id, item);
        return this;
    }

    public T? FindItem(int id)
    {
        return _items[id];
    }
}