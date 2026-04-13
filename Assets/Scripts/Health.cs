using UnityEngine;

public class Health
{
    public float healthPoints;



    public void IncreaseHealth(float ToIncrease)
    {
        healthPoints += ToIncrease;
    }

    public void DecreaseHealth(float ToDecrease)
    {
        healthPoints -= ToDecrease;
    }

    public Health(float intialHealth)
    {
        
        healthPoints = intialHealth;
    }
}
