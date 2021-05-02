using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    [SerializeField] float patrol_speed = 10f; // Speed of the enemy while patroling
    [SerializeField] float wait_time = 3f; // How long its going to take the enemy to wait between patrols
    float current_wait_time = 0f; // How long the enemy has currently been waiting
    float max_x, min_x, max_z, min_z; // Dimensions for the ground
    Vector3 move_spot; // Where to move next

    private void Start()
    {
        Get_Ground_Size();
        move_spot = Get_New_Position();
    }

    private void Update()
    {
        Rotate_To_Direction();
        Patrol();
    }

    private void Get_Ground_Size()
    {
        GameObject ground = GameObject.FindWithTag("Ground"); // Finding the gameobject with the ground tag
        Renderer ground_size = ground.GetComponent<Renderer>(); // We get the renderer becoz the renderer comtains the size of the object
        min_x = (ground_size.bounds.center.x - ground_size.bounds.extents.x);
        max_x = (ground_size.bounds.center.x + ground_size.bounds.extents.x);
        min_z = (ground_size.bounds.center.z - ground_size.bounds.extents.z);
        max_z = (ground_size.bounds.center.z + ground_size.bounds.extents.z);
    }

    private Vector3 Get_New_Position()
    {
        float random_x = Random.Range(min_x, max_x); // It'll pick a random number in the x-axis
        float random_z = Random.Range(min_z, max_z); // It'll pick a random number in the z-axis
        Vector3 new_position = new Vector3(random_x, transform.position.y, random_z); // Then we'll create a vector3 using these random values
        return new_position;
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, move_spot, patrol_speed * Time.deltaTime); // Takes our position and moves the enemy to the movespot

        if (Vector3.Distance(transform.position, move_spot) <= 0.2f) // Checking if we are in that direction
        {
            if (current_wait_time <= 0) // Checking if the enemy is waiting or not
            {
                move_spot = Get_New_Position(); // If no, it will get a new position and move the enemy to that position
                current_wait_time = wait_time;
            }
            else
            {
                current_wait_time -= Time.deltaTime; // If yes, it will reduce the time
            }
        }
    }

    private void Rotate_To_Direction() // To rotate the enemy in the direction it moves
    {
        Vector3 target_direction = move_spot - transform.position; // To get the direction, we have to subtract our current position from the target position
        Vector3 new_direction = Vector3.RotateTowards(transform.forward, target_direction, 0.3f, 0f); // New direction is the direction to tunr the enemy towards
        transform.rotation = Quaternion.LookRotation(new_direction); // Will actually do the rotation
    }
}
