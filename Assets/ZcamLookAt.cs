using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZcamLookAt : MonoBehaviour
{
    public Transform zCamLook;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(zCamLook);
    }
}
