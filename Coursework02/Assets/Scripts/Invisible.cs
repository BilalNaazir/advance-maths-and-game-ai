using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    public bool invisNow;
    public void GoInvisible()
    {
        if(invisNow){
            gameObject.SetActive(false);
        }
        else{
            gameObject.SetActive(true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
