using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject camM;
    public GameObject camC;
    public bool isMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        isMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && isMenu == false){
            Cursor.visible = true;
            isMenu = true;
        }
        else if (Input.GetKeyDown("escape") && isMenu == true){
                Cursor.visible = false;
                isMenu = false;
            }
        
        if (Input.GetMouseButton(1)){
            camC.SetActive(true);
            camM.SetActive(false);
        }
        else if (Input.GetMouseButtonUp(1)){
            camM.SetActive(true);
            camC.SetActive(false);
        }
    }
}