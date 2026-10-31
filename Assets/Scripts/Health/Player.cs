using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    public HealthView healthView;
    public GameOver gameOver;

    private Health health;
    private HealthPresenter presenter;

    private void Start()
    {
        health = new Health(maxHealth); //создание цифр
        presenter = new HealthPresenter(health, healthView); //связывание с UI
        presenter.UpdateUI(); //начальное здоровье показываем
    }

    public void TakeDamage(float amount)
    {
        presenter.Damage(amount);
        if (health.currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameOver != null)
        {
            gameOver.Show(); //показываем экран смерти
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))  // Тестовая кнопка H 
        {
            TakeDamage(10);
        }
    }

}
