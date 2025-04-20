using UnityEngine;

public class PlayerGunMovement : MonoBehaviour
{
    [Header("Movement Setup")]
    [SerializeField] private float _walkSpeed = 1.5f;
    [SerializeField] private float _rotationSpeed = 320f;

    private CharacterController _controller;
    private Camera _camera;
    private Animator _animator;
    private bool _isMove;

    private void Awake()
    {
        _camera = Camera.main;
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AimTowardMouse();
        Move();
    }

    private void AimTowardMouse()
    {
        if (_isMove == false) return;

        Vector2 look = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray = _camera.ScreenPointToRay(new Vector2(look.x, look.y));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(inputHorizontal, 0f, inputVertical);
        _isMove = movement.magnitude > 0.1f;

        if (_isMove)
        {
            movement.Normalize();
            movement *= _walkSpeed * Time.deltaTime;
            _controller.Move(movement);
        }

        PlayAnimaton(movement);
    }

    private void PlayAnimaton(Vector3 movement)
    {
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        float velocityX = Vector3.Dot(movement.normalized, transform.right);
        _animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        _animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
    }
}
