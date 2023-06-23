using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenadepickup : MonoBehaviour
{
   [Header("Grenade")]
public GameObject Grenade;
public GameObject PickupGrenade;

[Header("Grenade Assign Things")]
public mousemovement player;
private float radius = 2.5f;
 
private void Awake()
{
    Grenade.SetActive(false);

}

private void Update()
{
    {
        if(Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if(Input.GetKeyDown("e"))
            {
                Grenade.SetActive(true);
                PickupGrenade.SetActive(false);
                //objective Completed
            }
        }
    }
}
}
