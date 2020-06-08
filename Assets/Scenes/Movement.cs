using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    public float moveSpeed; //in Unity UI this will appear as a variable "Move Speed"
    private float Speed;
    public float jumpPower;
    private float yVelocity;

    float MoveInputX()
    {
        return Input.GetAxis("Horizontal");
    }
    float MoveInputY()
    {
        return Input.GetAxis("Vertical");
    }
    float MoveInputZ()
    {
        jumpPower = Mathf.Clamp(jumpPower, -10f, 10f);
        return jumpPower*Input.GetAxis("Jump");
    }
    Vector3 UpdatePlayerMovement()
    {
        Vector3 motion = transform.right * MoveInputX() + transform.forward * MoveInputY() + transform.up * MoveInputZ();
        if (motion.magnitude > 1) motion.Normalize();   // this makes sure digaonal movement is the same speed as forward or sideways
        if (Input.GetKey(KeyCode.LeftShift))    //Hold Left Shift key to run
        {
            Speed = 2*moveSpeed;    // run = 2x walking speed
        }
        else
        {
            Speed = moveSpeed;
        }
        return motion*Speed;
    }
    public Transform capsuleP1;
    public Transform capsuleP2;
    public LayerMask groundLayer; // referencing the ground layer
    Vector3 UpdatePlayerGravity()
    {
        if (Physics.CapsuleCast(capsuleP1.position, capsuleP2.position, 0.51f, Vector3.down, 0f, groundLayer)) //note default skin width of Character Controller is 0.08
        {
            yVelocity = -0.01f;
        }
        else 
        {
            yVelocity += -9.81f * Time.deltaTime;
        }
        return new Vector3(0, yVelocity, 0);
    }
    public CharacterController controller;//reference CharacterController
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move((UpdatePlayerMovement()+UpdatePlayerGravity())*Time.deltaTime);   
    }
}
