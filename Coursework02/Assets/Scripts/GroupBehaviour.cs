using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupBehaviour : MonoBehaviour
{
    public Transform target;
    State states;
    public GameObject npc1;
    State states1;
    public GameObject npc2;
    State states2;

    void Start()
    {
        states = GetComponent<State>();
        states1 = npc1.GetComponent<State>();
        states2 = npc2.GetComponent<State>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(npc1 && target){
            if (((states1.currentState=="chase" || states.currentState == "chase") && states2.currentState == "idle") || ((states1.currentState=="chase" || states2.currentState == "chase") && states.currentState == "idle") || ((states.currentState=="chase" || states2.currentState == "chase") && states1.currentState == "idle")){
                states.currentState = "chase";
                states1.currentState = "chase";
                states2.currentState = "chase";
                
            }
        }
              
    }
}
