using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    public float moveSpeed; // means the player can adjust
    private float yVelocity;

    float MoveInputX()
    {
        return Input.GetAxis("Horizontal");
    }
    float MoveInputY()
    {
        return Input.GetAxis("Vertical");
    }
    // Start is called before the first frame update
    Vector3 UpdatePlayerMovement()
    {
        Vector3 motion = transform.right * MoveInputX() + transform.forward * MoveInputY();
        if (motion.magnitude > 1) motion.Normalize();
        return motion * moveSpeed;
    }
    Vector3 UpdatePlayerGravity()
    {
        if (Physics.Raycast(groundCheck.position, Vector3.down, 1.1f, groundLayer)) //1.1 instead of 1 because default skin width of Character Controller is 0.08
        {
            yVelocity = -0.01f; //why though
        }
        else {
            yVelocity += -9.81f * Time.deltaTime;
        }
        return new Vector3(0, yVelocity, 0);
    }
    public CharacterController controller;//reference CharacterController
    public Transform groundCheck;
    public LayerMask groundLayer; // referencing the ground layer
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move((UpdatePlayerMovement()+UpdatePlayerGravity())*Time.deltaTime);   
    }
}
