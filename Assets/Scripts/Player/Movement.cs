using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speed = 6.0f;
    public float _gravity = -9.8f;

    public PlayerInput playerInput; //ссылка на скрипт управления
    private CharacterController _characterController;

    private void Start()
    {
        //прячем мышку
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject crosshair = GameObject.Find("Crosshair"); //Включаем прицел обратно при старте игры
        if (crosshair != null) 
            crosshair.SetActive(true);

        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("CharacterController is null");
    }

    private void Update()
    {
        //остановка времени в Game Over 
        if (Time.timeScale == 0f)
        {
            return;
        }

        // Берем данные из скрипта PlayerInput
        float deltaX = playerInput.horizontalInput * _speed;
        float deltaZ = playerInput.verticalInput * _speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, _speed);
        movement.y = _gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement); 
    }
}
