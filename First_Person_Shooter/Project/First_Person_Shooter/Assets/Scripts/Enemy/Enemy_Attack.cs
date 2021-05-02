using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    Player_Health target;
    [SerializeField] int damage = 10;
    [SerializeField] AudioClip enemy_attack = null;
    [SerializeField] [Range(0,1)] float enemy_attack_volume = 0;

    private void Start()
    {
        target = FindObjectOfType<Player_Health>();
    }

    public void Attack_Animation_Event()
    {
        if(target == null)
        {
            return;
        }
        AudioSource.PlayClipAtPoint(enemy_attack, Camera.main.transform.position, enemy_attack_volume);
        target.GetComponent<Player_Health>().Player_Damage(damage);
        target.GetComponent<Display_Player_Damage>().Show_Damage();
    }

}
