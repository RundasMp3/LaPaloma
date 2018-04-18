using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovement : MonoBehaviour {

    private GroundMovement ground;
    private FlyingMovement fly;
    private CharacterController controller;


    private float verticalVelocity = 8f;

    public float flyingSpeed = 16f, maxSpeed = 36f, reduccionDeVelocidad = 0.05f;

    public float gravity = 9.81f, rotateSpeed = 2.0f;
    public int numsalto = 4;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        ground = GetComponent<GroundMovement>();
        fly = GetComponent<FlyingMovement>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moveVector = Vector3.zero;

        Vector3 posY = transform.position;
        posY.y = Mathf.Clamp(transform.position.y, 0, 100);
        transform.position = posY;

        if (controller.isGrounded)
        {
            verticalVelocity = 8f;
            fly.enabled = false;
            ground.enabled = true;
        }

        transform.position += transform.forward * Time.deltaTime * flyingSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flyingSpeed < maxSpeed && numsalto < 9)
            {
                flyingSpeed += 4f;
                numsalto++;
            }
            if (flyingSpeed < 12f)
                verticalVelocity = flyingSpeed;
            else if (flyingSpeed >= 12f)
                verticalVelocity = 8f;
        }

        //UP N' DOWN
        if(Input.GetKey(KeyCode.W) )//&& transform.rotation.eulerAngles.x < 30)
        {
            transform.Rotate(3, 0, 0);
        }
        else if(Input.GetKey(KeyCode.S))// && transform.rotation.eulerAngles.x > -30)
        {
            transform.Rotate(-3, 0, 0);
        }

        //LEFT N' RIGHT
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0,rotateSpeed);
           // if (transform.rotation.eulerAngles.z > 40)
           // {
                transform.Rotate(0, -3, 0);
           // }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,0,-rotateSpeed);
           // if (transform.rotation.eulerAngles.z < 320)
           // {
                transform.Rotate(0, 3, 0);
           // }
        }

        //MAXIMA ROTACION EN X y Z
        Vector3 angle = transform.localRotation.eulerAngles;
        angle = angleMaxerX(-30, 30, angle);
        angle = angleMaxerZ(-15, 15, angle);
        transform.localRotation = Quaternion.Euler(angle);



        if (flyingSpeed < 8)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            moveVector.y = verticalVelocity;
            controller.Move(moveVector * Time.deltaTime);
        }
        else if (flyingSpeed >= 8)
        {
            verticalVelocity -= gravity / ((float)Mathf.Pow(numsalto, 2)) * Time.deltaTime;
            moveVector.y = verticalVelocity;
            controller.Move(moveVector * Time.deltaTime);
        }

    }

    private Vector3 angleMaxerX(float min, float max, Vector3 angle)
    {

        if (angle.x < 90 || angle.x > 270)
        {       // if angle in the critic region...
            if (angle.x > 180) angle.x -= 360;  // convert all angles to -180..+180
            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }
        angle.x = Mathf.Clamp(angle.x, min, max);
        if (angle.x < 0) angle.x += 360;

        return angle;
    }
    private Vector3 angleMaxerZ(float min, float max, Vector3 angle)
    {

        if (angle.z < 90 || angle.z > 270)
        {       // if angle in the critic region...
            if (angle.z > 180) angle.z -= 360;  // convert all angles to -180..+180
            if (max > 180) max -= 360;
            if (min > 180) min -= 360;
        }
        angle.z = Mathf.Clamp(angle.z, min, max);
        if (angle.z < 0) angle.z += 360;

        return angle;
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray vuelo = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(vuelo, out hit, 10) && Input.GetMouseButton(0))
        {
            fly.enabled = false;
            ground.enabled = true;
        }
    }
}
