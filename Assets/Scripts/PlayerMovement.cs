using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField] private float cameraZoomSpeed;
    private float _camZoomSpeed;

    public Camera mainCamera;


    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        mainCamera = Camera.main;


        _camZoomSpeed = cameraZoomSpeed;
        cameraZoomSpeed = 1;
        CameraToggle.onCamOn += () => cameraZoomSpeed = _camZoomSpeed;
        CameraToggle.onCamOff += () => cameraZoomSpeed = 1;
    }

    private void OnDisable()
    {
        CameraToggle.onCamOn -= () => cameraZoomSpeed = _camZoomSpeed;
        CameraToggle.onCamOff -= () => cameraZoomSpeed = 1;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; //Transform makes movement coordinates local and not global.

        controller.Move(move * speed * Time.deltaTime * cameraZoomSpeed);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}