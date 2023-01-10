using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public TextMesh textMesh;
    private bool canRegen = true;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = "HP: " + health.ToString();
        if(health<100){
            Regenerate();
        }

        if(health <= 0){
            Destroy(gameObject);
            Destroy(textMesh);
        }
        textColor();

        
    }

    public void TakeDamage(int damageAmount){
         
         if(health>=0){
             health -= damageAmount;
             
         }
         
    }

    void textColor(){
        if(health <= 50){
            textMesh.color = Color.red;
        }
        else{
            textMesh.color = Color.white;
        }

    }


    public void Regenerate(){
        if(canRegen){
            StartCoroutine(Wait());
            health += 1;
            canRegen = false;
        
        }
        
    }

    void OnCollisionEnter(Collision coll){
        // print(coll.gameObject.name);
        string lol = coll.gameObject.GetComponent<Renderer>().material.name.Replace(" (Instance)","");
        // print(lol.Length);
        // print(lol);
    }

    public int GetHealth(){
         return health;
    }

    IEnumerator Wait(){
        yield return new WaitForSeconds(2.0f);
        canRegen = true;
    }
}
