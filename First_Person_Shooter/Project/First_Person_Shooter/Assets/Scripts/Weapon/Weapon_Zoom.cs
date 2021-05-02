using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Zoom : MonoBehaviour
{
    [SerializeField] Camera main_camera = null;
    [SerializeField] float zoom_out = 60f;
    [SerializeField] float zoom_in = 25f;

    bool zoomed_in = false;

    private void OnDisable()
    {
        Zoom_Out();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomed_in == false)
            {
                Zoom_In();
            }
            else
            {
                Zoom_Out();
            }
        }        
    }

    private void Zoom_In()
    {
        zoomed_in = true;
        main_camera.fieldOfView = zoom_in;
        GetComponent<Animator>().SetBool("Aiming", true);
    }

    private void Zoom_Out()
    {
        zoomed_in = false;
        main_camera.fieldOfView = zoom_out;
        GetComponent<Animator>().SetBool("Aiming", false);
    }

}
