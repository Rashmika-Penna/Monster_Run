using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] Canvas game_over = null;
    [SerializeField] Canvas mini_map = null;
 
    private void Start()
    {
        game_over.enabled = false;
    }

    public void Handle_Player_Death()
    {
        game_over.enabled = true;
        mini_map.enabled = false;
        Time.timeScale = 0;
        FindObjectOfType<Weapon_Switching>().enabled = false;
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // And make it visible to the player
    }
}
