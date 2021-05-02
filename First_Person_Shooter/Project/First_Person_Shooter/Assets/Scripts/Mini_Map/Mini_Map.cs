using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Map : MonoBehaviour
{
    [SerializeField] Transform player;
    
    private void LateUpdate()
    {
        Vector3 new_position = player.position;
        new_position.y = transform.position.y;
        transform.position = new_position;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
