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
        health = new Health(maxHealth);
        presenter = new HealthPresenter(health, healthView);
        presenter.UpdateUI();
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
            gameOver.Show();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

}
