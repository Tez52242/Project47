using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private bool _isActive = false;

    protected Player _player;
    private bool _isOpen;

    private void Start()
    {
        _isOpen = false;
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
        if (_isOpen == true) return;

        _doorAnimator.SetTrigger("Open");
        _isOpen = true;
    }

    private void ExitPickup()
    {
        if (_isOpen == false) return;

        _doorAnimator.SetTrigger("Close");
        _isOpen = false;
    }
}
