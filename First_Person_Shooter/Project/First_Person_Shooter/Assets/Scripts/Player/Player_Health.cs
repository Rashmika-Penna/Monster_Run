using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    [SerializeField] int health = 100;

    public void Player_Damage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            GetComponent<Death>().Handle_Player_Death();
        }
    }
}
