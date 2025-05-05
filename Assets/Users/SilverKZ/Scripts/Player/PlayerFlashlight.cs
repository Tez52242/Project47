using UnityEngine;

public class PlayerFlashlight : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipNone;
    [SerializeField] private AudioClip _audioClipUse;
    [SerializeField] private GameObject _spotLight;

    private Player _player;
    private bool _isAction;

    private void Start()
    {
        _player = GetComponent<Player>();
        _spotLight.SetActive(false);
        _isAction = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_player.Flashlight)
            {
                _audioSource.PlayOneShot(_audioClipUse, 1f);
                _isAction = !_isAction;
                _spotLight.SetActive(_isAction);
            }
            else
            {
                _audioSource.PlayOneShot(_audioClipNone, 1f);
            }
        }
    }
}
