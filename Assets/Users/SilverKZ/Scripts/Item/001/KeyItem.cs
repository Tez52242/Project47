using UnityEngine;

public class KeyItem : PickableupItem
{
    public override void Pickup()
    {
        base.Pickup();
        
        _player.UpdateKey(true);
    }
}
