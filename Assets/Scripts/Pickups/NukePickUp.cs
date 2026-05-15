using UnityEngine;

public class NukePickUp : PickUp 
{
    protected override void CollectPickUp(Character reciever)
    {
        FindAnyObjectByType<GameManager>().NukeAllEnemies();
        FindAnyObjectByType<NukeAnimationScript>().TriggerFlash();
        base.CollectPickUp(reciever);
        
    }
}
