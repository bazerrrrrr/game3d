using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    private void Update()
    {
        // Game Over, то ничего не читаем
        if (Time.timeScale == 0f)
        {
            return;
        }
        // читаем клавиши A/D и W/S
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
}
