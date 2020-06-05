using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {
        public Vector2 mouseLook;
        public Vector2 smoothV;
        public float sensitivity;
        public float smoothing;

        public Animator animator;

        public GameObject character;
        void Start () {
            Cursor.lockState = CursorLockMode.Locked; //locks cursor
            ; //gets the parent of script (should be main camera)
        }

        void Update () {
            //stores mouse movement value
            if (animator.GetBool("isAiming")) {
                    Vector2 vct2 = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
                    //smooth camera using lerp
                    smoothV.x = Mathf.Lerp (smoothV.x, vct2.x, 1 / smoothing);
                    smoothV.y = Mathf.Lerp (smoothV.y, vct2.y, 1 / smoothing);
                    //adds the smoothing to mouseLook
                    mouseLook += smoothV;
                    //the actual rotations below for x and y (the Y rotation (left right) is the CHARACTERS rotation, while the X rotation (up down) is the actual MAIN CAMERA)
                    transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
                    character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);
                }
            }
        }