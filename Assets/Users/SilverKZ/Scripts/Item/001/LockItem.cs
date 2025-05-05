using System;
using UnityEngine;

public class LockItem : Interactable
{
    [SerializeField] private int _ID;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipNone; 
    [SerializeField] private AudioClip _audioClipUse;
    [SerializeField] private Door _door;
    [SerializeField] private LockedDoor _lockedDoor;

    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _text;
    [SerializeField] private String _msg1;
    [SerializeField] private String _msg2;

    private bool _first = true;

    public override void Pickup()
    {
        if (Inventory.Instance.Ñheck(_ID) == true) 
        {
            _audioSource.PlayOneShot(_audioClipUse, 1f);
            Inventory.Instance.Remove(_ID);
            _door.enabled = true;
            _lockedDoor.enabled = false;
            _first = false;

            if (_msg1.Length > 0)
            {
                _textPanel.SetActive(true);
                _text.text = _msg2;
            }
        } 
        else 
        {
            if (_first == true && _msg1.Length > 0)
            {
                _textPanel.SetActive(true);
                _text.text = _msg1;
            }

            _audioSource.PlayOneShot(_audioClipNone, 1f);
        }
    }

    public override void ExitPickup()
    {
        _textPanel.SetActive(false);
    }
}
