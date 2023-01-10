using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    float duration = 2f;
    public int damageAmount;
    public int damageAmountPlayer;


    private float lifeTimer;
    // Start is called before the first frame update
    void Start(){
        damageAmount = 10;
        damageAmountPlayer = 5;
        lifeTimer = duration; 
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Seeker"){
            
            Destroy(gameObject);
            if(coll.gameObject.GetComponent<Health>().GetHealth()<50){
                coll.gameObject.GetComponent<Health>().TakeDamage(DealDamageAsymmetry(1, 8));
            }
            else{
                coll.gameObject.GetComponent<Health>().TakeDamage(DealDamageSymmetry(1, 8));
                
            }

        }

        if(coll.gameObject.name == "Target"){
            coll.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmountPlayer);
            Destroy(gameObject);
               
        }
        
        

    }

    int DealDamageAsymmetry(int min, int max){
        int roll1 =  Random.Range(min, max);
        int roll2 =  Random.Range(min, max);
        int roll3 =  Random.Range(min, max);

        int min3 = Mathf.Min(roll1, Mathf.Min(roll2, roll3));
        int damage = roll1 + roll2 + roll3 - min3;

        return damage;
    }

    int DealDamageSymmetry(int min, int max){
        int roll1 =  Random.Range(min, max);
        int roll2 =  Random.Range(min, max);

        int damage = roll1+ roll2;

        return damage;
    }
}
