using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject crosshair;// Прицел

    public AudioSource clickSound;
    public GameObject backgroundMusic;
    public AudioSource deathMusic;

    public void Show()
    {
        gameOverPanel.SetActive(true); //панель проигрыша
        Time.timeScale = 0f;

        //возвращение мышки
        Cursor.lockState = CursorLockMode.None;   
        Cursor.visible = true;

        //скрытие прицела
        if (crosshair != null )
        {
            crosshair.SetActive(false);
        }

        //выкл музыка игрового момента
        if (backgroundMusic != null)
        {
            backgroundMusic.SetActive(false);
        }

        //вкл другую музыку
        if (deathMusic != null)
        {
            deathMusic.Play();
        }
    }

    public void ToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (clickSound != null) clickSound.Play();

        Time.timeScale = 1f; //время возвращаем в норму
        Invoke("LoadMenuScene", 0.4f); //задержка на 0,4 сек
    }
    void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
