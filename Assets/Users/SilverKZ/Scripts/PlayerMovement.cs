using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Setup")]
    [SerializeField] private float _walkSpeed = 1.5f;
    [SerializeField] private float _rotationSpeed = 320f;

    private CharacterController _controller;
    private Animator _animator;
    private int _animIDSpeed;
    private Quaternion _targetRotation;

    private void Awake()
    {
        AssignAnimationIDs();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(inputHorizontal, 0f, inputVertical);

        if (inputDirection.magnitude > 1f)
        {
            inputDirection.Normalize();
        }

        Vector3 move = inputDirection * _walkSpeed * Time.deltaTime;
        _controller.Move(move);

        if (move != Vector3.zero)
        {
            _targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
           
        }

        float speed = (inputDirection.normalized).magnitude;
        _animator.SetFloat(_animIDSpeed, speed);
    }
}

