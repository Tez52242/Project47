using UnityEngine;

public class BulletPickup : PickupItem
{
    [SerializeField] private int _bulletAmount = 5;
    //[SerializeField] private AudioSource _audioSource;
    //[SerializeField] private AudioClip _audioClip;

    public override void Pickup()
    {
        base.Pickup();
        //_audioSource.PlayOneShot(_audioClip, 1f);
        _player.UpdateBullet(_bulletAmount);
        //StartCoroutine(SetNotActive());
        //PlayerHealth.Instance.Heal(healAmount);
        //Inventory.Instance.Remove(this);
    }
    /*
    private IEnumerator SetNotActive()
    {
        yield return new WaitForSeconds(0.19f);
        gameObject.SetActive(false);
    }
    */
}
