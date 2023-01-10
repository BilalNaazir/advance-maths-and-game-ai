using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    public Transform target;
    private bool canShoot;
    Vector3[] positionArray = new [] { new Vector3(45, 0f, 45), new Vector3(45, 0f, -45)};

    public void RunAway(){
        if(target){
            StartCoroutine(Wait());
        }
        
    }

    IEnumerator Wait(){
        if(target){
            yield return new WaitForSeconds(3f);
            float highest =0f;
            int highestIndex = -1;
            for (int i = 0; i < positionArray.Length; i++){
                float distance = Vector3.Distance(positionArray[i], target.position);
                if(distance > highest){
                    highest = distance;
                    highestIndex = i;
                }
            }
            transform.position = positionArray[highestIndex];
        }
        
    }
    
}
