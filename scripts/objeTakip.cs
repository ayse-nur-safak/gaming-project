using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeTakip : MonoBehaviour
{
    public Transform fox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(fox.position);
        transform.position = fox.position;
    }
}
