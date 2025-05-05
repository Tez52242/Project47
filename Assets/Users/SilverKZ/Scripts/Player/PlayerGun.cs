using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipNone;
    [SerializeField] private AudioClip _audioClipUse;
    [SerializeField] private Gun _gun;
    [SerializeField] private GameObject _crosshair;

    private Player _player;
    private bool _isAction;

    private void Start()
    {
        _player = GetComponent<Player>();
        _gun.gameObject.SetActive(false);
        _crosshair.gameObject.SetActive(false);
        _isAction = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_player.Gun)
            {
                _audioSource.PlayOneShot(_audioClipUse, 1f);
                _isAction = !_isAction;
                _gun.gameObject.SetActive(_isAction);
                _crosshair.gameObject.SetActive(_isAction);
            }
            else
            {
                _audioSource.PlayOneShot(_audioClipNone, 1f);
            }
        }
    }
}
