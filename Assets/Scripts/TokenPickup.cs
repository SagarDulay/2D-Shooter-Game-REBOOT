using UnityEngine;

public class TokenPickUp : PickUp
{
    [SerializeField] private int tokenValue;

    protected override void CollectPickUp(Character reciever)
    {
        FindAnyObjectByType<GameManager>().AddToScore(tokenValue);
        base.CollectPickUp(reciever);

    }
}
