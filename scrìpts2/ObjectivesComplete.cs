using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesComplete : MonoBehaviour
{
    [Header("Objectives to complete")]
    public Text objective1;
    public Text objective2;
    public Text objective3;
    
    public static ObjectivesComplete ocurrence;

    private void Awake()
    {
        ocurrence = this;
    }
    public void GetObjectivesDone(bool obj1, bool obj2, bool obj3)
    {
        if(obj2 == true)
        {
            objective2.text = "1. Completed";
            objective2.color = Color.green;
        }
        else
        {
            objective2.text = "1. Collect Three Potions and Get The Sword";
            objective2.color = Color.white;
        }


        if(obj1 == true)
        {
            objective1.text = "2. Completed";
            objective1.color = Color.green;
        }
        else
        {
            objective1.text = "2. Collect Three Pumpkins and Get The Elixir";
            objective1.color = Color.white;
        }


        if(obj3 == true)
        {
            objective3.text = "3. Completed";
            objective3.color = Color.green;
        }
        else
        {
            objective3.text = "3. Find and Rescue The Fairy, Get The Key and RUN!!!";
            objective3.color = Color.white;
        }
    }
}
