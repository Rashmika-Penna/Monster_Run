using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzle_flash = null;
    [SerializeField] GameObject hit_effect = null; // It is a gameobject instead of particle effect becoz we want it to be instantiated and disappear after a while
    [SerializeField] Camera main_camera = null;
    [SerializeField] Ammo ammo_slot = null;
    [SerializeField] Ammo_Type ammo_type;
    [SerializeField] float range = 100f; // Distnace of raycasting
    [SerializeField] int damage = 0;    
    [SerializeField] float time_between_shots = 0;
    [SerializeField] Text ammo_display_text;
    [SerializeField] AudioClip gun_shot = null;
    [SerializeField] [Range(0, 1)] float gun_shot_volume = 0;
    RaycastHit hit;
    bool can_shoot = true;

    private void Update()
    {
        Display_Ammo();
        if(Input.GetMouseButtonDown(0) && can_shoot == true)
        {
            AudioSource.PlayClipAtPoint(gun_shot, Camera.main.transform.position, gun_shot_volume);
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        can_shoot = false;

        if(ammo_slot.Get_Current_Ammo(ammo_type) > 0)
        {
            Play_Muzzle_Flash();
            Shooting_Ray();
            ammo_slot.Reduce_Current_Ammo(ammo_type);
        }

        yield return new WaitForSeconds(time_between_shots);
        can_shoot = true;
        // Or else reload
    }

    private void Shooting_Ray()
    {
        if (Physics.Raycast(main_camera.transform.position, main_camera.transform.TransformDirection(Vector3.forward), out hit, range))
        {
            Particle_Effect(hit);
            Enemy_Health enemy = hit.transform.GetComponent<Enemy_Health>();
            if (enemy == null)
            {
                return;
            }
            enemy.Take_Damage(damage);
        }
        else
        {
            return;
        }
    }

    private void Play_Muzzle_Flash()
    {
        muzzle_flash.Play();
    }

    private void Particle_Effect(RaycastHit hit)
    {
        GameObject impact = Instantiate(hit_effect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

    private void Display_Ammo()
    {
        int current_ammo = ammo_slot.Get_Current_Ammo(ammo_type);
        ammo_display_text.text = current_ammo.ToString();
    }
}
