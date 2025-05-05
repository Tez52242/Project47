using System;
using System.Collections;
using UnityEngine;

public class Flashlight : Interactable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public override void Pickup()
    {
        _audioSource.PlayOneShot(_audioClip, 1f);
        _player.UpdateFlashlight(true);
        StartCoroutine(SetNotActive());
        //PlayerHealth.Instance.Heal(healAmount);
        //Inventory.Instance.Remove(this);
    }

    private IEnumerator SetNotActive()
    {
        yield return new WaitForSeconds(0.19f);
        gameObject.SetActive(false);
    }
}
