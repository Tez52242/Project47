using System;
using System.Collections;
using UnityEngine;
using Zenject;

public abstract class PickableupItem : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private String _msg;

    private Outline _outline;
    private bool _isActive;
    protected Player _player;
    protected Item _item;
    private AudioSource _audioSource;
    private PickupTextPanel _pickupTextPanel;

    [Inject]
    private void Construct(PickupTextPanel pickupTextPanel)
    {
        _pickupTextPanel = pickupTextPanel;
    }

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
            _pickupTextPanel.Hide();
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
                _pickupTextPanel.Show(_msg); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Highlight(false);
            _isActive = false;
            _pickupTextPanel.Hide();
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
        _audioSource.PlayOneShot(_audioClip, 1f);
        Inventory.Instance.Add(_item);
        StartCoroutine(SetNotActive());
    }

    public virtual void ExitPickup()
    {
        // ���������������� � ��������
    }

    private IEnumerator SetNotActive()
    {
        yield return new WaitForSeconds(0.19f);
        gameObject.SetActive(false);
    }
}
