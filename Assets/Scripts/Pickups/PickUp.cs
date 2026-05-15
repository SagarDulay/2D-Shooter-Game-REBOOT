using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody.CompareTag("Player"))
        {
            Character temporaryCharacter = collision.attachedRigidbody.GetComponent<Character>();
            CollectPickUp(temporaryCharacter);
        }
        
    }

    protected virtual void CollectPickUp(Character reciever)
    {
        Destroy(gameObject);
    }
}
