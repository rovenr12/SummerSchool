using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCController : MonoBehaviour
 {
     [SerializeField] Camera camera;
    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] float verticalRange = 45f;
    [SerializeField] float speed = 12f;
    [SerializeField] Rigidbody rigidBody;
    
    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start() {
        if (camera == null) {
            camera = Camera.main;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        RotatePlayer();
        Move();
    }

    void Move() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (x != 0 || z != 0) {
            Vector3 move = transform.right * x + transform.forward * z;
            
            rigidBody.velocity = move * speed;
        }
        else {
            rigidBody.velocity = new Vector3(0, 0, 0);
        }
    }

    void RotatePlayer() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        
        xRotation = Mathf.Clamp(xRotation, -verticalRange, verticalRange);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    
}
