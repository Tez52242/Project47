using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private int _amount;

    public int ID { get { return _id; } private set { } }
    public string Name { get { return _name; } private set { } }
    public int Amount { get { return _amount; } private set { } }

    public virtual void Use()
    {
        Debug.Log("Использован предмет: " + _name);
        // переопределяется в потомках
    }
}
