using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Slider _mouseSlider;

    private float _mouseSensitivity;

    private void Start()
    {
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

            LoadPrefs();
            _mouseSlider.value = _mouseSensitivity;
            _pausePanel.SetActive(true);
        }
    }

    public void Back()
    {
        _playerController.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void UpdateSensitivity()
    {
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
        _mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1f);
    }
}
