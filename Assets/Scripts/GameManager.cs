using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //доступ из любого скрипта

    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    // Метод для добавления очков
    public void AddScore(int amount)
    {
        score += amount; //прибавляем такое-то количество очков
        scoreText.text = "Score: " + score;
    }
}
