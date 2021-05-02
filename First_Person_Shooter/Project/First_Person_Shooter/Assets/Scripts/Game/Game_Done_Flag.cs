using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Done_Flag : MonoBehaviour
{
    [SerializeField] Canvas game_done_canvas = null;
    [SerializeField] Canvas mini_map = null;

    private void Start()
    {
        game_done_canvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            game_done_canvas.enabled = true;
            mini_map.enabled = false;
            Time.timeScale = 0;
            FindObjectOfType<Weapon_Switching>().enabled = false;
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;
        }
    }
}
