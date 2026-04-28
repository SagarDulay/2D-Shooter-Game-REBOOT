using UnityEngine;

public class HealthPickUp : PickUp
{

    [SerializeField] private float amountOfHealth;
    protected override void CollectPickUp(Character reciever)
    {
        reciever.healthModule.IncreaseHealth(Random.Range(10, 50));
        base.CollectPickUp(reciever);
    }
}
