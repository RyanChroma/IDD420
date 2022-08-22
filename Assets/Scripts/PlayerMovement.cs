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
    public Camera thermalCamera;

    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        mainCamera.enabled = true;
        thermalCamera.enabled = false;

        _camZoomSpeed = cameraZoomSpeed;
        cameraZoomSpeed = 1;
        GhostCamera.onCamOn += () => cameraZoomSpeed = _camZoomSpeed;
        GhostCamera.onCamOff += () => cameraZoomSpeed = 1;
    }

    private void OnDisable()
    {
        GhostCamera.onCamOn -= () => cameraZoomSpeed = _camZoomSpeed;
        GhostCamera.onCamOff -= () => cameraZoomSpeed = 1;
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

        if (Input.GetMouseButtonDown(1)) //GetMouseButtonDown(1) means holding down right click.
        {
            mainCamera.enabled = !mainCamera.enabled;
            thermalCamera.enabled = !thermalCamera.enabled;
        }
        else if (Input.GetMouseButtonUp(1)) //This is letting go of right click.
        {
            mainCamera.enabled = !mainCamera.enabled;
            thermalCamera.enabled = !thermalCamera.enabled;
        }
    }
}