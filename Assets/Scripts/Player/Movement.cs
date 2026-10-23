using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float _speed = 6.0f;
    public float _gravity = -9.8f;

    private CharacterController _characterController;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject crosshair = GameObject.Find("Crosshair"); //¬ключаем прицел обратно при старте игры
        if (crosshair != null) 
            crosshair.SetActive(true);

        _characterController = GetComponent<CharacterController>();
        if (_characterController == null)
            Debug.Log("CharacterController is null");
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }

        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ= Input.GetAxis("Vertical") * _speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, _speed);
        movement.y = _gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}
