using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public float maxHP;
    public float currentHP;

    public Health(float max)
    {
        maxHP = max;
        currentHP = max;
    }
    public void TakeDamage(float damage)
    {
        currentHP = currentHP - damage;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
    }

    public void Heal(float amout)
    {
        currentHP = currentHP + amout;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
