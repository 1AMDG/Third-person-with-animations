using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterRoom1 : MonoBehaviour {

    public GameObject ccamC;
    public GameObject ccamM;
    public GameObject ccamZ;

    // Start is called before the first frame update
    void Start () {
        ccamM.SetActive (true);
        ccamC.SetActive (false);
        ccamZ.SetActive (false);

    }

    void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.tag == "Player") {
            ccamM.SetActive (false);
            ccamC.SetActive (false);
            ccamZ.SetActive (true);
        }
    }
    void OnTriggerExit (Collider collider) {
        if (collider.gameObject.tag == "Player") {
            ccamM.SetActive (true);
            ccamC.SetActive (false);
            ccamZ.SetActive (false);
        }
    }
}