using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _audioSource.PlayOneShot(_audioClip, 1f);
            StartCoroutine(SetNotActive(player));
            
        }
    }

    private IEnumerator SetNotActive(Player player)
    {
        yield return new WaitForSeconds(0.5f);
        player.UpdateHealth(-_damage);
    }
}
