using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public float maxHP;
    public float currentHP;

    public Health(float max) //создаем здоровье
    {
        maxHP = max;
        currentHP = max;
    }
    public void TakeDamage(float damage)
    {
        currentHP = currentHP - damage;
        if (currentHP < 0) // если ушло в минус, то приравниваем к нулю
        {
            currentHP = 0;
        }
    }
}
