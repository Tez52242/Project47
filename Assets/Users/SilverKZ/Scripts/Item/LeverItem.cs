using UnityEngine;

public class LeverItem : Interactable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipNone;
    [SerializeField] private AudioClip _audioClipUse;
    [SerializeField] private Animator _doorAnimator;

    private bool _first = true;

    private void Start()
    {
        _first = true;
    }

    public override void Pickup()
    {
        if (_first == true)
        {
            _first = false;
            _doorAnimator.SetTrigger("Open");
            _audioSource.PlayOneShot(_audioClipUse, 1f);
        }
        else
        {
            _audioSource.PlayOneShot(_audioClipNone, 1f);
        }
    }
}
