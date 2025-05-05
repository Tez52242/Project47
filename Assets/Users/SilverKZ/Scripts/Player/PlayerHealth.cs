using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipNone;
    [SerializeField] private AudioClip _audioClipUse;

    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_player.Aid > 0 && _player.Health < _player.MaxHealth)
            {
                _audioSource.PlayOneShot(_audioClipUse, 1f);
                _player.UpdateAid(-1);
                _player.UpdateHealth(1);
            }
            else
            {
                _audioSource.PlayOneShot(_audioClipNone, 1f);
            }
        }
    }
}
