using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float _health = 50f;

    public void TakeDamage(float amount)
    {
        _health -= amount;
        Debug.Log("amount: " + amount + "   _health: " + _health);
        if (_health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
