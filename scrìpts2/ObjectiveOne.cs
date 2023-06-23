using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveOne : MonoBehaviour
{
    [Header("Pumpkins")]
    public GameObject Pumpkin;
    public GameObject PickupPumpkin;

    [Header("Pumpkins Assign Things")]
    public mousemovement player;
    private float radius = 2.5f;

    private void Awake()
    {
        Pumpkin.SetActive(false);

    }

    private void Update()
    {
        {
            if (Vector3.Distance(transform.position, player.transform.position) < radius)
            {
                if (Input.GetKeyDown("e"))
                {
                    Pumpkin.SetActive(true);
                    PickupPumpkin.SetActive(false);
                    //objective Completed
                    ObjectivesComplete.ocurrence.GetObjectivesDone(true, true, false);
                }
            }
        }
    }

}