using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Rigidbody theBullet; 
    public float speed = 40f;
    public Transform target;
    private bool canShoot = true;
    
    public void Shoot(){
        if(canShoot){
            transform.LookAt(target);
            Rigidbody bulletObject = Instantiate(theBullet, transform.position + transform.forward, transform.rotation);
            bulletObject.velocity = transform.TransformDirection(0, 0, speed);  
            Destroy(bulletObject.gameObject, 2);
            canShoot = false;

            StartCoroutine(Wait());
        }
        

    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    
}
