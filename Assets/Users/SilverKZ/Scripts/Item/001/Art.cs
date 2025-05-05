using UnityEngine;

public class Art : Interactable
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _mirror;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _mirrorBroken;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mirror.SetActive(false);
            Time.timeScale = 1f;
            _playerController.enabled = true;
            gameObject.SetActive(false);
            _mirrorBroken.SetActive(true);
            _key.SetActive(true);
        }
    }
}
