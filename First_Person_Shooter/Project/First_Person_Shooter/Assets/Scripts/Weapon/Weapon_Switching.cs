using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Switching : MonoBehaviour
{
    public int default_weapon = 0;

    private void Start()
    {
        Select_Default_Weapon();
    }

    private void Update()
    {
        int previous_weapon = default_weapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(default_weapon >= transform.childCount - 1)
            {
                default_weapon = 0;
            }
            else
            {
                default_weapon++;
            }            
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(default_weapon <= transform.childCount - 1)
            {
                default_weapon = transform.childCount - 1;
            }
            else
            {
                default_weapon--;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            default_weapon = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            default_weapon = 1;
        }

        if(previous_weapon != default_weapon)
        {
            Select_Default_Weapon();
        }
    }

    private void Select_Default_Weapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == default_weapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }
}
