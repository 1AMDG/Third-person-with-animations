using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        // anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isAiming", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)){
            anim.SetBool("isAiming", true);
        } else {
      

            anim.SetBool("isAiming", false);
        }
    }
}
