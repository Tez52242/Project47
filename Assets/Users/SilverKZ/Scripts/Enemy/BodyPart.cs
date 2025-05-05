using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private float _damageMultiplier = 1.0f;

    public float DamageMultiplier { get { return _damageMultiplier; } private set { } }
}
