using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController controller;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private float verticalVelocity;
    public float gravity = 14.0f;
    private float jumpForce = 6.0f;
    private float flightSpeed = 12.0f;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    private float playerSpeed = 5.0f;
    private float rotateSpeed = 5.0f;
    public float fall = 1.0f;
    public float currYRot;
    private float v;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Vector3 moveVector = Vector3.zero;
        RaycastHit hit;
        Ray vuelo = new Ray(transform.position, Vector3.down);

        Debug.DrawRay(transform.position, Vector3.down * 2);

        float h;


        v = 0;
        h = horizontalSpeed * Input.GetAxis("Mouse X");
        fall = 2f;
        if (transform.rotation.z != 0 && transform.rotation.x != 0 && controller.isGrounded)
        {
            currYRot = transform.eulerAngles.y;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, currYRot, 0), 2f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * playerSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * Time.deltaTime * playerSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }

        verticalVelocity -= gravity * Time.deltaTime * fall;





        moveVector.y = verticalVelocity;
        controller.Move(moveVector * Time.deltaTime);
    }
}
