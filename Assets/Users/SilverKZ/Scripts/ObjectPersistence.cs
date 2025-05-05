using UnityEngine;

public class ObjectPersistence : MonoBehaviour
{
    private static ObjectPersistence instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // если дублируется при переходе на сцену
        }
    }
}
