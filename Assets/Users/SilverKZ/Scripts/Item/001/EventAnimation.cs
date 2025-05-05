using UnityEngine;

public class EventAnimation : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipUse;
    [SerializeField] private AudioClip _audioClipNone;

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_audioClipUse, 0.1f);
    }
}
