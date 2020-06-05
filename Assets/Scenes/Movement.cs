using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
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
        return motion*moveSpeed;
    }

    public CharacterController controller;//reference CharacterController
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(UpdatePlayerMovement()*Time.deltaTime);   
    }
}
