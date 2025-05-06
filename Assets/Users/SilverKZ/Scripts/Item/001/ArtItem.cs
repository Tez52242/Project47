using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ArtItem : Interactable
{
    [SerializeField] private int _ID;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioClip _audioClipNone;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _mirrorBroken;
    [SerializeField] private string _msg;

    public Image _image;
    public PickupTextPanel _pickupTextPanel;
    public bool _isBroken;

    [Inject]
    private void Construct(PickupTextPanel pickupTextPanel, UIView uiView)
    {
        _image = uiView.MirrorArtImage;
        _pickupTextPanel = pickupTextPanel;

        _isBroken = false;
    }

    public override void Pickup()
    {
        Debug.Log("ArtItem");

        if (Inventory.Instance.Check(_ID) == true)
        {
            Debug.Log("ArtItem - true");

            _audioSource.PlayOneShot(_audioClip, 0.4f);
            Time.timeScale = 0f;
            _playerController.enabled = false;
            Inventory.Instance.Remove(_ID);
            _image.gameObject.SetActive(true);
            _isBroken = true;
        }
        else
        {
            Debug.Log("ArtItem - false");
            _pickupTextPanel.Show(_msg);
            _audioSource.PlayOneShot(_audioClipNone, 1f);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0) && _isBroken) OnClick();
    }

    private void OnClick()
    {
        Time.timeScale = 1f;

        _playerController.enabled = true;

        _image.gameObject.SetActive(false);

        _mirrorBroken.SetActive(true);

        _key.SetActive(true);

        gameObject.SetActive(false);
    }

    public override void ExitPickup()
    {
        _pickupTextPanel.Hide();
    }
}
