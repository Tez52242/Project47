using UnityEngine;

public class KeyItem : PickupItem
{
    public override void Pickup()
    {
        _player.UpdateKey(true);
    }
}
