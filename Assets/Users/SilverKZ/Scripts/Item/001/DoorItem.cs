using System;
using UnityEngine;
using Zenject;

public class DoorItem : Interactable
{
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] protected int _ID;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioClip _audioClipNone;
    [SerializeField] protected AudioClip _audioClipUse;

    [SerializeField] private String _msg;

    private bool _isOpen = false;
    private PickupTextPanel _pickupTextPanel;

    [Inject]
    private void Construct(PickupTextPanel pickupTextPanel)
    {
        _pickupTextPanel = pickupTextPanel;
    }


    private void Start()
    {
        _isOpen = false;
    }

    public override void Pickup()
    {
        if (_isOpen == true) return;

        if (Inventory.Instance.Check(_ID) == true)
        {
            _audioSource.PlayOneShot(_audioClipUse, 1f);
            //Inventory.Instance.Remove(_ID);
            _doorAnimator.SetTrigger("Open");
            _isOpen = true;
        }
        else
        {
            if (_msg.Length > 0)
            {
                _pickupTextPanel.Show(_msg);
            }

            _audioSource.PlayOneShot(_audioClipNone, 1f);
        }
    }

    public override void ExitPickup()
    {
        if (_isOpen == true)
        {
            _audioSource.PlayOneShot(_audioClipUse, 1f);
            _doorAnimator.SetTrigger("Close");
            _isOpen = false;
        }

        _pickupTextPanel.Hide();
    }
}
