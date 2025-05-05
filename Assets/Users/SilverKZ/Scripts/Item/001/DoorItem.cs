using System;
using UnityEngine;

public class DoorItem : Interactable
{
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] protected int _ID;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioClip _audioClipNone;
    [SerializeField] protected AudioClip _audioClipUse;

    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _text;
    [SerializeField] private String _msg;

    private bool _isOpen = false;

    private void Start()
    {
        _isOpen = false;
    }

    public override void Pickup()
    {
        if (_isOpen == true) return;

        if (Inventory.Instance.Ñheck(_ID) == true)
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
                _textPanel.SetActive(true);
                _text.text = _msg;
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

        _textPanel.SetActive(false);
        
    }
}
