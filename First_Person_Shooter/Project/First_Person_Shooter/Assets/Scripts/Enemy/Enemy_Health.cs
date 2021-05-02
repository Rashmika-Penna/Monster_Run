using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] Transform drop_point;
    [SerializeField] GameObject drop_item;
    public Health_Bar health_bar;
    public bool drops;
    bool is_dead = false;

    public bool Is_Dead()
    {
        return is_dead;
    }

    private void Start()
    {
        health_bar.Set_Max_Health(health);
    }

    public void Take_Damage(int damage)
    {
        BroadcastMessage("Provoke_On_Taking_Damage");
        health -= damage;
        health_bar.Set_Health(health);

        if (health <= 0)
        {

            Die();
        }
    }

    private void Die()
    {
        if(is_dead)
        {
            return;
        }

        is_dead = true;
        GetComponent<Animator>().SetTrigger("Die");

        if (drops)
        {
            Instantiate(drop_item, drop_point.position, drop_point.rotation);
        }

        Destroy(gameObject,1f);
    }
}
