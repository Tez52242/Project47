using UnityEngine;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Slider _mouseSlider;

    private PlayerController _playerController;
    private Gun _gun;
    private float _mouseSensitivity;

    public void Handle()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _gun = FindObjectOfType<Gun>();

        LoadPrefs();
        _mouseSlider.value = _mouseSensitivity;
    }

    private void Update()
    {
        bool pausePressed = Input.GetKeyDown(KeyCode.Escape);

        if (pausePressed == true)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _playerController.enabled = false;
            if(_gun) _gun.enabled = false;

            LoadPrefs();
            _mouseSlider.value = _mouseSensitivity;
            _pausePanel.SetActive(true);
        }
    }

    public void Back()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
        _playerController.enabled = true;
        if(_gun) _gun.enabled = true;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void UpdateSensitivity()
    {
        if (!_playerController) return;

        _mouseSensitivity = _mouseSlider.value;
        _playerController.MouseSetup(_mouseSensitivity);
        SavePrefs();
    }

    private void SavePrefs()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", _mouseSensitivity);
        PlayerPrefs.Save();
    }

    private void LoadPrefs()
    {
        _mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity");
        _playerController.MouseSetup(_mouseSensitivity);
    }
}
