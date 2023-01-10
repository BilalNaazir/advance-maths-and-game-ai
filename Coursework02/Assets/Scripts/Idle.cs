using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    // Start is called before the first frame update

    public void DoStay(){

    }

    void Start()
    {
        transform.position = Vector3.MoveTowards(transform.position,transform.position,Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
