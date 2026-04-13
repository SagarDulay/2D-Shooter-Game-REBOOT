using UnityEngine;

public class Health
{
    private float healthPoints;

    public float GetHealthPoints()
    {
        return healthPoints;
    }



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
