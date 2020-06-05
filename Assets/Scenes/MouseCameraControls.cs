using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCameraControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    float LookInputX()
    {
        return Input.GetAxisRaw("Mouse X")*sens;
    }
    float LookInputY()
    {
        return Input.GetAxisRaw("Mouse Y")*sens;
    }
    
    public Camera playerCamera; //for vertical we are adjusting the camera angle with player fixed, and vice versa for horizontal
    private float camVertAngle = 0;
    public float sens;
    void UpdateCameraRotation()
    {
        //Horizontal Rotation
        transform.Rotate(Vector3.up, LookInputX());
        
        //Vertical Rotation
        camVertAngle += LookInputY();
        camVertAngle = Mathf.Clamp(camVertAngle, -89f, 89f);
        playerCamera.transform.localEulerAngles = new Vector3(-camVertAngle, 0, 0);
    }
    void UpdateCursorState()
    {
        // Lock on Left Click
        if (Input.GetMouseButtonDown(0)) Cursor.lockState = CursorLockMode.Locked;

        // Unlock on Escape
        if (Input.GetKeyDown(KeyCode.Escape)) Cursor.lockState = CursorLockMode.None;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateCameraRotation();
        UpdateCursorState();
    }
}
