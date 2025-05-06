using UnityEngine;

public class GunPickup : PickableupItem 
{
    public override void Pickup()
    {
        base.Pickup();
        _player.UpdateGun(true);
    }
}
