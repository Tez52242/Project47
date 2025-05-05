using UnityEngine;
using UnityEngine.UI;

public class ArtItem : Interactable
{
    [SerializeField] private int _ID;
    [SerializeField] private Image _image;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioClip _audioClipNone;
    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _text;

    public override void Pickup()
    {
        if (Inventory.Instance.Сheck(_ID) == true)
        {
            _audioSource.PlayOneShot(_audioClip, 0.4f);
            Time.timeScale = 0f;
            _playerController.enabled = false;
            Inventory.Instance.Remove(_ID);
            _image.gameObject.SetActive(true);
        }
        else
        {
            _textPanel.SetActive(true);
            _text.text = "Как же меня все бесит, так и хочется что нибудь сломать!";
            _audioSource.PlayOneShot(_audioClipNone, 1f);
        }
    }

    public override void ExitPickup()
    {
        _textPanel.SetActive(false);
    }
}
