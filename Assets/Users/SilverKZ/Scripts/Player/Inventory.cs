using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<Item> _items = new List<Item>();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(int id)
    {
        foreach (var item in _items)
        {
            if (item.ID == id)
            {
                _items.Remove(item);
                return;
            }
        }
    }
    
    public bool Check(int id)
    {
        foreach (var item in _items)
        {
            if (item.ID == id)
            {
                return true;
            }
        }

        return false;
    }
}
