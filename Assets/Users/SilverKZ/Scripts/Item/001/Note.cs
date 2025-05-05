using System.Collections;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Gun _gun;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

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
        _gun.enabled = true;
        gameObject.SetActive(false);
    }
}
