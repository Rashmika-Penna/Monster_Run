using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] Ammo_Slot[] ammo_slots;

    [System.Serializable]
    private class Ammo_Slot
    {
        public Ammo_Type ammo_type;
        public int ammo_amount;
    }

    public int Get_Current_Ammo(Ammo_Type ammo_type)
    {
        return Get_Ammo_Slot(ammo_type).ammo_amount;
    }

    public void Reduce_Current_Ammo(Ammo_Type ammo_type)
    {
        Get_Ammo_Slot(ammo_type).ammo_amount--;
    }

    public void Increase_Current_Ammo(Ammo_Type ammo_type, int ammo_amount)
    {
        Get_Ammo_Slot(ammo_type).ammo_amount += ammo_amount;
    }

    private Ammo_Slot Get_Ammo_Slot(Ammo_Type ammo_type)
    {
        foreach(Ammo_Slot slot in ammo_slots)
        {
            if(slot.ammo_type == ammo_type)
            {
                return slot;
            }
        }
        return null;
    }
}
