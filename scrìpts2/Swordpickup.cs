using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordpickup : MonoBehaviour
{
      [Header("Sword")]
public GameObject Sword;
public GameObject PickupSword;

[Header("Sword Assign Things")]
public mousemovement player;
private float radius = 2.5f;
 
private void Awake()
{
    Sword.SetActive(false);

}

private void Update()
{
    {
        if(Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if(Input.GetKeyDown("e"))
            {
                Sword.SetActive(true);
                PickupSword.SetActive(false);
                //objective Completed
            }
        }
    }
}
}
