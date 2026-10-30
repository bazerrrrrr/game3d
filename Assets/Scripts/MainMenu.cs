using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource clickSound;
    public void PlayGame()
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }
        Invoke("LoadGameScene", 0.4f);
    }
    void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Debug.Log("Вы вышли из игры");
        Application.Quit();
    }
}
