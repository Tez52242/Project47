using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _runSpeed = 9f;

    [SerializeField] private float _mouseSensitivity = 2f;
    [SerializeField] private Transform _cameraHolder;

    // Crosshair
    [SerializeField] private bool _crosshair = true;
    [SerializeField] private Image _crosshairObject; 
    [SerializeField] private Sprite _crosshairImage;
    [SerializeField] private Color _crosshairColor = Color.white;

    // Head Bob
    [SerializeField] private bool _enableHeadBob = true;
    [SerializeField] private float _bobSpeed = 10f;
    [SerializeField] private Vector3 _bobAmount = new Vector3(.15f, .05f, 0f);

    private CharacterController _controller;
    private float _gravity = -9.81f;
    private Vector3 _velocity;
    private float _xRotation = 0f;
    private bool _isMove = false;
    private bool _isRuning = false;
    private float _timer = 0;
    private Vector3 _jointOriginalPos;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        _jointOriginalPos = _cameraHolder.localPosition;

        if (_crosshair)
        {
            Debug.Log(_crosshairObject.sprite);
            _crosshairObject.sprite = _crosshairImage;
            _crosshairObject.color = _crosshairColor;
        }
        else
        {
            _crosshairObject.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Мышь
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 40f); 

        _cameraHolder.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // Скорость в зависимости от шифта
        float currentSpeed = _walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = _runSpeed;
            _isRuning = true;
        }
        else
        {
            _isRuning = false;
        }

        // Движение
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * h + transform.forward * v).normalized;
        _controller.Move(move * currentSpeed * Time.deltaTime);

        // Двигается?
        if (h != 0 || v != 0)
        {
            _isMove = true;
        }
        else
        {
            _isMove = false;
        }

        // Гравитация
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        if (_controller.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        HeadBob();
    }

    private void HeadBob()
    {
        if (_enableHeadBob == false) return;

        if (_isMove)
        {
            if (_isRuning)
            {
                _timer += Time.deltaTime * (_bobSpeed + _runSpeed);
            }
            else
            {
                _timer += Time.deltaTime * _bobSpeed;
            }
            // Применяет движение HeadBob
            _cameraHolder.localPosition = new Vector3(
                _jointOriginalPos.x + Mathf.Sin(_timer) * _bobAmount.x, 
                _jointOriginalPos.y + Mathf.Sin(_timer) * _bobAmount.y, 
                _jointOriginalPos.z + Mathf.Sin(_timer) * _bobAmount.z);
        }
        else
        {
            // Сбрасывается, когда останавливается
            _timer = 0;
            _cameraHolder.localPosition = new Vector3(
                Mathf.Lerp(_cameraHolder.localPosition.x, _jointOriginalPos.x, Time.deltaTime * _bobSpeed), 
                Mathf.Lerp(_cameraHolder.localPosition.y, _jointOriginalPos.y, Time.deltaTime * _bobSpeed), 
                Mathf.Lerp(_cameraHolder.localPosition.z, _jointOriginalPos.z, Time.deltaTime * _bobSpeed));
        }
    }

    public void MouseSetup(float value)
    {
        _mouseSensitivity = Math.Clamp(value, 0.1f, 10f);
    }
}
