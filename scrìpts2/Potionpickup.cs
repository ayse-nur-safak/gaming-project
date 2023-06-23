using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potionpickup : MonoBehaviour
{
       [Header("Potion")]
public GameObject Potion;
public GameObject PickupPotion;

[Header("Potion Assign Things")]
public mousemovement player;
private float radius = 2.5f;
 
private void Awake()
{
    Potion.SetActive(false);

}

private void Update()
{
    {
        if(Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if(Input.GetKeyDown("e"))
            {
                Potion.SetActive(true);
                PickupPotion.SetActive(false);
                    //objective Completed
                    ObjectivesComplete.ocurrence.GetObjectivesDone(false, true, false);
                }
        }
    }
}
}
