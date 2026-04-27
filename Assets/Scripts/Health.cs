using System;
using UnityEngine;

public class Health
{
    public Action OnHealthZero;
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
        
        
        if(GetHealthPoints() <= 0)
        {
            OnHealthZero?.Invoke();
        }
    }

    public Health(float intialHealth)
    {
        
        healthPoints = intialHealth;
    }
}
