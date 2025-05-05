using System.Collections;
using UnityEngine;

public class FuseItem : Interactable
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public override void Pickup()
    {
        _audioSource.PlayOneShot(_audioClip, 1f);
        //bool picked = Inventory.Instance.Add(item);
        StartCoroutine(SetNotActive());
    }

    private IEnumerator SetNotActive()
    {
        yield return new WaitForSeconds(0.19f);
        gameObject.SetActive(false);
    }
}
