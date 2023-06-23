using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypickup : MonoBehaviour
{
    [Header("Key")]
public GameObject Key;
public GameObject PickupKey;

[Header("Key Assign Things")]
public mousemovement player;
private float radius = 2.5f;
 
private void Awake()
{
    Key.SetActive(false);

}

private void Update()
{
    {
        if(Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            if(Input.GetKeyDown("e"))
            {
                Key.SetActive(true);
                PickupKey.SetActive(false);
                //objective Completed
            }
        }
    }
}
}
