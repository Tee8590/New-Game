using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform playerObj;
    public Transform orientation;
    public Rigidbody rigidbody;

    public KeyCode camKey = KeyCode.F1;

    public float rotationSpeed;

    public Transform combactLookAt;
    public CameraStyle currentStyle;
    bool combactCameraOn = true;
    public enum CameraStyle
    {
        Basic,
        Combact
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        if(currentStyle == CameraStyle.Basic)
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, viewDir.normalized, Time.deltaTime * rotationSpeed);
        }
        else if(currentStyle == CameraStyle.Combact)
        {
            
        Vector3 directionCombactLookAt = player.position - new Vector3(transform.position.x, combactLookAt.position.y, transform.position.z);
        playerObj.forward = directionCombactLookAt.normalized;

        }
    }
    public void CameraKey()
    {
        if(Input.GetKey(camKey))
        {
            combactCameraOn = !combactCameraOn;
        }
    }
    
}
