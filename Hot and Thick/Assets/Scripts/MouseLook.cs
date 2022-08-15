using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Make mouse disappear when you start the game.
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //Camera won't look up and down beyond 90 degrees.

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Quaternion is responsible for rotation.
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
