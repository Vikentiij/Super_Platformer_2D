using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timer = 1f;
    
  //  void Start()
  //  {
   //     Destroy(gameObject,timer);      (less control)
   // }

    void Update()
    {
        timer = timer - Time.deltaTime;
        if(timer <= 0){
            Destroy(gameObject);       //more control
        }



    }
}
