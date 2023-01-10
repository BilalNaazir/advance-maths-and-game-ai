using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    public TextMesh textMesh;
    State states;
    void Start()
    {
        states = GetComponent<State>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "HP: " + health.ToString();
        if(health <= 0){
            Destroy(gameObject);
        }
        textColor();
    }

    public void TakeDamage(int damageAmount){
         
         if(states.currentState == "flee" && states.gaurder){
             health -= damageAmount/2;

         }
         else{
             health -= damageAmount;
         }
         
    }

    public int GetHealth(){
         return health;
    }


    

    void textColor(){
        if(health <= 50){
            textMesh.color = Color.red;
        }

    }
}
