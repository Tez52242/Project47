using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Outline _outline;
    private bool _isActive;
    protected Player _player;  

    private void Start() 
    {
        _outline = GetComponent<Outline>();
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
            Highlight(true);
            _isActive = true;
            _player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            Highlight(false);
            _isActive = false;
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
    }

    public virtual void ExitPickup()
    {
        // переопределяется в потомках
    }
}
