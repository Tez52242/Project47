using UnityEngine;

public class AidPickup : PickupItem 
{
    public override void Pickup()
    {
        base.Pickup();
        _player.UpdateAid(_item.Amount);
    }
}
