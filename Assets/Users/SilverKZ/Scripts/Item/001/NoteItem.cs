using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class NoteItem : Interactable
{
    [SerializeField] private Image _image;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Gun _gun;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    [Inject]
    private void Construct(UIView uiView)
    {
        _image = uiView.NoteArtImage;
    }

    public override void Pickup()
    {
        _audioSource.PlayOneShot(_audioClip, 1f);
        Time.timeScale = 0f;
        _playerController.enabled = false;
        _gun.enabled = false;
        _image.gameObject.SetActive(true);
    }
}
