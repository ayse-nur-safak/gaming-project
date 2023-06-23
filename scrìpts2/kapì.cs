using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapı : MonoBehaviour
{
       public  GameObject EndUI;
    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "kapı")
        {
            EndUI.SetActive(true);
        }
        
    }
}
