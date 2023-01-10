using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;



public class Shoot : MonoBehaviour
{

    
    public Rigidbody theBullet; 
    public float speed = 40f;
   

    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0)) {
            Rigidbody bulletObject = Instantiate(theBullet, transform.position + transform.forward, transform.rotation);
            bulletObject.velocity = transform.TransformDirection(0, 0, speed);

            Destroy(bulletObject.gameObject, 2);
            if(bulletObject.position == transform.position){
                print("hello");
            }
            
        }
        
    }

    

}

    


