using System;
using System.Collections;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _text;
    [SerializeField] private String _msg;

    private Outline _outline;
    private bool _isActive;
    protected Player _player;
    protected Item _item;
    private AudioSource _audioSource;

    private void Awake()
    {
        _item = gameObject.GetComponent<Item>();
        _outline = GetComponent<Outline>();
        _audioSource = GetComponent<AudioSource>();
        _isActive = false;
    }

    private void Update()
    {
        if (_isActive == false) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            _textPanel.SetActive(false);
            Pickup();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Highlight(true);
            _isActive = true;
            _player = player;

            if (_msg.Length > 0)
            {
                _textPanel.SetActive(true); 
                _text.text = _msg;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Highlight(false);
            _isActive = false;
            _textPanel.SetActive(false);
            ExitPickup();
        }
    }

    private void Highlight(bool isHighlighted)
    {
        if (_outline != null)
        {
            _outline.enabled = isHighlighted;
        }
    }

    public virtual void Pickup()
    {
        // переопределяется в потомках

        _audioSource.PlayOneShot(_audioClip, 1f);
        Inventory.Instance.Add(_item);
        StartCoroutine(SetNotActive());
    }

    public virtual void ExitPickup()
    {
        // переопределяется в потомках
    }

    private IEnumerator SetNotActive()
    {
        yield return new WaitForSeconds(0.19f);
        gameObject.SetActive(false);
    }
}
