using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject crosshair;

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
    }

    public void ToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
