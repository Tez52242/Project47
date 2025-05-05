using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private Collider _hitbox;

    private void Start()
    {
        _hitbox = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.UpdateHealth(-_damage);
        }
    }
}
