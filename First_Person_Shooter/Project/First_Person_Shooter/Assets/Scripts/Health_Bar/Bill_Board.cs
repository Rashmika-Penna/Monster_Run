using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bill_Board : MonoBehaviour
{
    //[SerializeField] Transform main_camera = null;
    Transform main_camera = null;

    private void Start()
    {
        main_camera = FindObjectOfType<AudioListener>().transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + main_camera.forward);
    }
}
