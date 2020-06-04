using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow1 : MonoBehaviour
{
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public Transform PlayerTransform;

    private Vector3 _cameraOffset;

    // public bool LookAtPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        // Debug.Log(SmoothFactor);
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        // print ("works");
    }
}
