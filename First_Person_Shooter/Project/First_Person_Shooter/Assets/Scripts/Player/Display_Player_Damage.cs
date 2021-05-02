using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_Player_Damage : MonoBehaviour
{
    [SerializeField] Canvas player_damage_canvas;
    [SerializeField] float damage_show_time = 0.2f;

    private void Start()
    {
        player_damage_canvas.enabled = false;
    }

    public void Show_Damage()
    {
        StartCoroutine(Show_Damage_Canvas());
    }

    IEnumerator Show_Damage_Canvas()
    {
        player_damage_canvas.enabled = true;
        yield return new WaitForSeconds(damage_show_time);
        player_damage_canvas.enabled = false;
    }
}
