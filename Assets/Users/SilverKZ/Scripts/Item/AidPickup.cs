using UnityEngine;

public class AidPickup : PickableupItem 
{
    public override void Pickup()
    {
        base.Pickup();
        _player.UpdateAid(_item.Amount);
    }
}
