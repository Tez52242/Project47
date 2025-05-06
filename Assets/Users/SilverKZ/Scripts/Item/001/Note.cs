using System.Collections;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private PlayerController _playerController;
    private Gun _gun;

    private void OnEnable()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _gun = FindObjectOfType<Gun>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audioSource.PlayOneShot(_audioClip, 1f);
            StartCoroutine(SetNotActive());
            Time.timeScale = 1f;
        }
    }

    private IEnumerator SetNotActive()
    {
        yield return new WaitForSeconds(0.5f);
        _playerController.enabled = true;
        if(_gun) _gun.enabled = true;
        gameObject.SetActive(false);
    }
}
