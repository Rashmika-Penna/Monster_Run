using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Pickup : MonoBehaviour
{
    [SerializeField] int ammo_amount = 5;
    [SerializeField] Ammo_Type ammo_type;
    [SerializeField] AudioClip item_collection_sound = null;
    [SerializeField] [Range(0, 1)] float item_collection_volume = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(item_collection_sound, Camera.main.transform.position, item_collection_volume);
            FindObjectOfType<Ammo>().Increase_Current_Ammo(ammo_type, ammo_amount);
            Destroy(gameObject);
        }
    }
}
