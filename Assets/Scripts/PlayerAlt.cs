using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float playerSpeed = 10f;
    public float sprintSpeed = 20f;
    public float jumpVelocity = 4f;

    private bool isMoving = false;
    private bool isSprinting = false;
    private bool isCrouching = false;
    private bool isJumping = false;

    Vector3 moveDirection;
    Rigidbody rigidPlayer;
    // on game start
    void Awake () {
        isMoving = false;
        isSprinting = false;
        //looks for the rigidbody (of the parent of this script)
        rigidPlayer = GetComponent<Rigidbody> ();

    } // per frame 
    void Update () {
        float horizontalMove = Input.GetAxisRaw ("Horizontal");
        float verticalMove = Input.GetAxisRaw ("Vertical");
        //collects player's direction of movement
        moveDirection = (horizontalMove * transform.right + verticalMove * transform.forward).normalized;

    }

    void FixedUpdate () {
        // calls the move method in a fixed update so the physics cannot change
        Move ();
        if (Input.GetKey (KeyCode.LeftShift)) {
            Sprint ();
        }
        if(Input.GetButtonDown("Jump")){
            rigidPlayer.velocity = Vector3.up * jumpVelocity;
        }
    }

    void Move () {
        Vector3 yReset = new Vector3 (0, rigidPlayer.velocity.y, 0); //y axis velocity returns to normal since it was changed in the moveDirection vector3 variable
        rigidPlayer.velocity = moveDirection * playerSpeed * Time.deltaTime; //the actual movement in velocity
        rigidPlayer.velocity += yReset; // adds the y axis vector3 velocity on top of the player's vector3 velocity which got set to 0 in moveDirection
    }
    void Sprint () {
        // same as move but for sprinting (left shift hold)
        Vector3 yReset = new Vector3 (0, rigidPlayer.velocity.y, 0);
        rigidPlayer.velocity = moveDirection * sprintSpeed * Time.deltaTime;
        rigidPlayer.velocity += yReset;
    }
}