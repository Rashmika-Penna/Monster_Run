using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{   
    // For the enemy to follow the player
    [SerializeField] float chase_range = 15f;
    [SerializeField] float turn_speed = 5f;
    NavMeshAgent enemy;
    Enemy_Health enemy_health_script;
    float distance_to_target = Mathf.Infinity; // TO comsider all the characters in the world and not just limit it to a particular range
    Transform player = null;

    // Provoking the enemy
    bool is_provoked = false;
    

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemy_health_script = GetComponent<Enemy_Health>();
        player = FindObjectOfType<Player_Health>().transform;
    }

    private void Update()
    {
        if(enemy_health_script.Is_Dead())
        {
            enabled = false; // TUrning off this script so that the script doesn't work on the enemy becoz the calculatons will still go on
            enemy.enabled = false; // Turning off navmesh agent also becoz it will still work on the dead enemy
        }

        distance_to_target = Vector3.Distance(player.position, transform.position);

        if (is_provoked)
        {
            Engage_With_Target();
        }
        else if (distance_to_target <= chase_range)
        {
            is_provoked = true;
        }
    }    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, chase_range);
    }    

    private void Engage_With_Target()
    {
        Face_Player_While_Attacking();

        if (distance_to_target >= enemy.stoppingDistance)
        {            
            Chase_Player();
        }
        else if(distance_to_target <= enemy.stoppingDistance)
        {            
            Attack_Player();
        }
    }    

    private void Chase_Player()
    {
        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetTrigger("Move");
        enemy.SetDestination(player.position);  
    }

    private void Attack_Player()
    {
        GetComponent<Animator>().SetBool("Attack", true);
    }  
    
    private void Face_Player_While_Attacking()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion look_rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look_rotation, Time.deltaTime * turn_speed);
    }

    public void Provoke_On_Taking_Damage()
    {
        is_provoked = true;
    }
}
