using System;
using UnityEngine;
using Zenject;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipNone;

    [SerializeField] private String _msg;

    private bool _isActive = false;
    protected Player _player;
    private PickupTextPanel _pickupTextPanel;

    [Inject]
    private void Construct(PickupTextPanel pickupTextPanel)
    {
        _pickupTextPanel = pickupTextPanel;
    }

    private void Start()
    {
        _isActive = false;
    }

    protected void Update()
    {
        if (_isActive == false) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _isActive = true;
            _player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _isActive = false;
            ExitPickup();
        }
    }

    private void Pickup()
    {
        if (_msg.Length > 0)
        {
            _pickupTextPanel.Show(_msg);
        }

        _audioSource.PlayOneShot(_audioClipNone, 1f);
    }

    private void ExitPickup()
    {
        _pickupTextPanel.Hide();
    }
}
