using UnityEngine;

public class GunPickup : PickupItem 
{
    public override void Pickup()
    {
        base.Pickup();
        _player.UpdateGun(true);
    }
}
