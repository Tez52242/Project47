using System;
using UnityEngine;

public class LockFreeItem : Interactable
{
    [SerializeField] private AudioSource _audioSource;
    //[SerializeField] private AudioClip _audioClipUse;
    [SerializeField] private AudioClip _audioClipNone;
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private bool _active = true;

    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _text;
    [SerializeField] private String _msg;

    private bool _isOpen = false;
    private bool _activad;

    private void Start()
    {
        _isOpen = false;
        _activad = _active;
    }

    public override void Pickup()
    {
        if (_activad == true && _isOpen == false) 
        {
            //_audioSource.PlayOneShot(_audioClipUse, 1f);
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
            //_audioSource.PlayOneShot(_audioClipUse, 1f);
            _doorAnimator.SetTrigger("Close");
            _isOpen = false;
        }

        _textPanel.SetActive(false);
    }

    public void Actived(bool value)
    {
        _activad = value;
    }
}
