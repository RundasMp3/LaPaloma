using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour {

    private GroundMovement ground;
    private FlyingMovement fly;
    private CharacterController controller;

    private float verticalVelocity, currYRot;

    public float gravity = 9.81f, jumpForce = 6.0f, playerSpeed = 5.0f, rotateSpeed = 4.0f;
    private int numsalto = 0;
    public float flyingSpeed = 0f;
    private bool canFly = true, yanosaltespls = false;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        ground = GetComponent<GroundMovement>();
        fly = GetComponent<FlyingMovement>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector3 moveVector = Vector3.zero;

        if(yanosaltespls)
        {
            verticalVelocity = -10f;
            yanosaltespls = false;
        }

        //CORRECCION DE ROTACION AL ATERRIZAR
        if (transform.rotation.z != 0 && transform.rotation.x != 0 && controller.isGrounded)
        {
            currYRot = transform.eulerAngles.y;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, currYRot, 0), 2f);
        }

        //TIPO DE SALTO
        if (canFly)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !controller.isGrounded)
            {
                flyingSpeed += 4f;
                numsalto++;
                if (flyingSpeed < 12f)
                    verticalVelocity = flyingSpeed;
                else if (flyingSpeed >= 12f)
                {
                    yanosaltespls = true;
                    numsalto = 0;
                    flyingSpeed = 0f;
                    ground.enabled = false;
                    fly.enabled = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && flyingSpeed < 10)
            {
                verticalVelocity = jumpForce;
                numsalto++;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            {
                verticalVelocity = jumpForce;
                numsalto++;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !controller.isGrounded && numsalto < 2)
            {
                flyingSpeed += 4f;
                numsalto++;
            }
        }
        //CAMINAR FRENTE Y ATRAS
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(Vector3.up, 180);

        }
        if(Input.GetKey(KeyCode.W) && !controller.isGrounded && flyingSpeed == 0f)
        {
            transform.position += transform.forward * Time.deltaTime * playerSpeed / 1.5f;
        }
        else if (Input.GetKey(KeyCode.W) && controller.isGrounded)
        {
            transform.position += transform.forward * Time.deltaTime * playerSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && controller.isGrounded)
        {
            transform.position += transform.forward * Time.deltaTime * playerSpeed;
        }

        //ROTACIONES
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }

        //VELOCIDAD DE VUELO
        if(!controller.isGrounded)
        {
            transform.position += transform.forward * Time.deltaTime * flyingSpeed;
        }
        if(controller.isGrounded)
        {
            flyingSpeed = 0f;
            numsalto = 0;
        }

        //"GRAVEDAD"
        if (flyingSpeed < 8)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            moveVector.y = verticalVelocity;
            controller.Move(moveVector * Time.deltaTime);
        }
        else if (flyingSpeed >= 8)
        {
            verticalVelocity -= gravity/numsalto * Time.deltaTime;
            moveVector.y = verticalVelocity;
            controller.Move(moveVector * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inside"))
        {
            canFly = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Inside"))
        {
            canFly = true;
        }
    }

}
