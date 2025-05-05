using UnityEngine;
using UnityEngine.UI;

public class Safe : Interactable
{
    [SerializeField] private Image _image;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _openSafe;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Gun _gun;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioClip _audioClick;
    [SerializeField] private AudioClip _audioError;
    [SerializeField] private string _correctCode = "2804";
    [SerializeField] private TMPro.TextMeshProUGUI _displayText;

    private string _currentInput = "";
    private bool _isOpen;
    private bool _isError;

    private void Start()
    {
        _isOpen = false;
        _isError = false;
    }

    private void UpdateDisplay()
    {
        _displayText.text = _currentInput;
    }

    private void Unlock()
    {
        _isOpen = true;
        _currentInput = "Open";
        UpdateDisplay();
    }

    public void AddDigit(string digit)
    {
        _audioSource.PlayOneShot(_audioClick, 1f);

        if (_isOpen == true) return;

        if (_isError == true)
        {
            _currentInput = "";
            _isError = false;
        }

        if (_currentInput.Length < 4) // ограничение длины
        {
            _currentInput += digit;
            UpdateDisplay();
        }
    }

    public void SubmitCode()
    {
        _audioSource.PlayOneShot(_audioClick, 1f);

        if (_isOpen == true) return;

        if (_currentInput == _correctCode)
        {
            Unlock();
        }
        else
        {
            _audioSource.PlayOneShot(_audioError, 1f);
            _isError = true;
            _currentInput = "Error";
            UpdateDisplay();
        }
    }

    public void ClearInput()
    {
        _audioSource.PlayOneShot(_audioClick, 1f);

        if (_isOpen == true) return;

        _currentInput = "";
        UpdateDisplay();
    }

    public override void Pickup()
    {
        _audioSource.PlayOneShot(_audioClip, 1f);

        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _playerController.enabled = false;
        _gun.enabled = false;

        _image.gameObject.SetActive(true);
        _currentInput = "";
        UpdateDisplay();
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerController.enabled = true;
        _gun.enabled = true;
        _image.gameObject.SetActive(false);

        if (_isOpen == true)
        {
            gameObject.SetActive(false);
            _openSafe.SetActive(true);
            _key.gameObject.SetActive(true);
        }
    }
}
