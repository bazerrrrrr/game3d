using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speed = 6.0f;
    public float _gravity = -9.8f;

    public PlayerInput playerInput;
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

        Vector3 movement = new Vector3(deltaX, 0, deltaZ); // Создаем вектор направления
        movement = Vector3.ClampMagnitude(movement, _speed); //чтобы не бегал быстрее по диагонали
        movement.y = _gravity;

        // Умножаем на Time.deltaTime, чтобы скорость не зависела от FPS
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement); 
    }
}
