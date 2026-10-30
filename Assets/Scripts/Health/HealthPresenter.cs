using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPresenter // св€зываем модель (Health) и отображение (HealthView)
{
    private Health health;
    private HealthView view;

    public HealthPresenter (Health health, HealthView view)
    {
        this.health = health;
        this.view = view;
    }

    public void UpdateUI () // ќбновл€ет картинку на основе данных из модели
    {
        view.Show(health.currentHP, health.maxHP);
    }

    public void Damage(float amount) // ћетод дл€ нанесени€ урона
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
