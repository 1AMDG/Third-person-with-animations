using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    public Player1 script1;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
         GameObject script1 = GameObject.Find("rotfix character");
         script1.GetComponent<Player1>().enabled = true;
        // anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isAiming", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)){
            anim.SetBool("isAiming", true);
            script1.GetComponent<Player1>().enabled = false;
            
        } else {
            anim.SetBool("isAiming", false);
            script1.GetComponent<Player1>().enabled = true;
        }
    }
}
