using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Transform cam;
    public Animator animator;

    CharacterController control;
    
    //CAMERA
    Vector3 camForward;
    Vector3 camRight;

    Vector2 input;
    Vector2 lookAround;
    

    //physics
    Vector3 intent;
    Vector3 velo;
    float speed = 3;
    float accel = 15;
    float turnSpeed = 14;

    void Start(){
        control = GetComponentInChildren<CharacterController>();
        // animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
    }

    void Update (){
        DoInput();
        CalculateCamera();
        DoMove();
    }
    // void CamRotate(){
    //     heading += Input.GetAxis("Mouse X")*Time.deltaTime*180;
    //     camPivot.rotation = Quaternion.Euler(0,heading,0);
    // }
    void DoInput(){
        // if(Input.GetMouseButton(1)){
        //     CamRotate();
        // }

        input = new Vector2 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
        lookAround = new Vector2 (Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Vertical"));
    }
    void CalculateCamera(){
        // print ("workywokry");
        // Transform camTransform = cam.gameObject.GetComponent<PlayerFollow1>().ManualUpdateCameraFDFJSFDJIFJ();

        camForward = cam.transform.forward;
        camRight = cam.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    void DoMove(){
        intent = camForward*input.y + camRight*input.x;

        if (!animator.GetBool("isAiming")) {
            if(input.magnitude > 0){
                Quaternion rot = Quaternion.LookRotation(intent);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, turnSpeed*Time.deltaTime);
            }

            velo = Vector3.Lerp(velo, transform.forward*input.magnitude*speed, accel*Time.deltaTime);
        } else {
            velo = Vector3.Lerp(velo, transform.TransformPoint(-intent)*speed, accel*Time.deltaTime);    
            
            
        }

        control.Move(velo*Time.deltaTime);

        animator.SetBool("isWalking", input.magnitude > 0 );

    }
}
