using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // Тут храним нажатия клавиш, чтобы другие скрипты их читали
    public float horizontalInput;
    public float verticalInput;

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        //это само чтение
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
}
