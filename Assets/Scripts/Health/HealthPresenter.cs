using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPresenter
{
    private Health health;
    private HealthView view;

    public HealthPresenter (Health health, HealthView view)
    {
        this.health = health;
        this.view = view;
    }

    public void UpdateUI ()
    {
        view.Show(health.currentHP, health.maxHP);
    }

    public void Damage(float amount)
    {
        health.TakeDamage(amount);
        UpdateUI();
    }

    public void Heal(float amount)
    {
        health.Heal(amount);
        UpdateUI();
    }
}
