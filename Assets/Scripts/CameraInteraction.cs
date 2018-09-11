using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour {

    public Camera cam;
    public CharSpawner spawner;

    Character curCharacter;

    void Update ()
    {
        CamInput();
    }

    void CamInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RayLogic();
        }
    }

    void RayLogic()
    {
        if (cam != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit != false)
            {
                if (hit.transform.tag == "Character")
                {
                    curCharacter = hit.transform.GetComponent<Character>();
                    curCharacter.Move();
                }
                else
                {
                    SpawnCharacter();
                }
            }                  
        }
    }

    void SpawnCharacter()
    {
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = -5;
        spawner.SpawnObject(pos);
    }

}
