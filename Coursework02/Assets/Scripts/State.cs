using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum States{
        idle,
        chase,
        attack,
        flee,
    };

public class State : MonoBehaviour
{
    public bool melee;
    public bool gaurder;
    public Transform target;
    public Transform enemy;
    public string state;
    Unit unit;
    Invisible invis;
    Idle stay;
    EnemyShoot shoot;
    Flee run;
    Health hp;
    Move fleeSpawn;
    
    public string currentState;
    public TextMesh stateText;
    Transform spawnLoc;

    public States States {get; protected set;}

    void Awake(){
        unit = GetComponent<Unit>();
        invis = GetComponent<Invisible>();
        stay = GetComponent<Idle>();
        shoot = GetComponent<EnemyShoot>();
        run = GetComponent<Flee>();
        fleeSpawn = GetComponent<Move>();
        hp = GetComponent<Health>(); 
        
    }

    void Start()
    {   
        currentState = (States.idle).ToString();
        spawnLoc = enemy;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.position.y > 0 || enemy.position.y < 0){
            enemy.position = new Vector3(enemy.position.x, 0f, enemy.position.z);
        }
        if(target){
            stateText.text = "State: " + currentState;
            switch(currentState){
                case "idle":
                    stateText.color = Color.green;
                    unit.startNow = false;
                    stay.DoStay();
                    currentState = SetState(CondValue(enemy, target));
                    break;
                
                case "chase":
                    stateText.color = Color.black;
                    invis.invisNow = false;
                    unit.startNow = true;
                    unit.Move(enemy, target);
                    currentState = SetState(CondValue(enemy, target));
                    break;
                
                case "attack":
                    if(target){
                        invis.invisNow = false;
                        stateText.color = Color.red;
                        shoot.Shoot();
                        currentState = SetState(CondValue(enemy, target));
                        
                    }
                    else{
                        print("dead");
                    }
                    break;

                case "flee":
                    stateText.color = Color.yellow;
                    if(melee){
                        fleeSpawn.Spawn();
                    }
                    else{
                        run.RunAway();
                    }
                    currentState = SetState(CondValue(enemy, target));
                    break;
            }
        }
        
    }

    

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Unwalkable"){
            print(coll.gameObject.tag);
        }

    }

    public int CondValue(Transform enemy, Transform target){
        
        if (Vector3.Distance(enemy.position, target.position) <= 60 && Vector3.Distance(enemy.position, target.position) >= 25){
            return 0;
        }
        else if (Vector3.Distance(enemy.position, target.position) < 25){
            return 1;
        }

        else {
            return 2;
        }
    } 

    public string SetState(int condValue){
        
        if(condValue == 0){
            var initial = new List<Actions<string>>{
                new Actions<string> {Probability = 0 / 100.0, Action = (States.idle).ToString()},
                new Actions<string> {Probability = 100 / 100.0, Action = (States.chase).ToString()},
                new Actions<string> {Probability = 0 / 100.0, Action = (States.attack).ToString()},
            };
            return CalculateAction(initial);
        //50idle, 40move, 10attack
        }
        else if(condValue == 1){
            var initial = new List<Actions<string>>{
                new Actions<string> {Probability = (80.0/100.0 * hp.health) / 100.0, Action = (States.attack).ToString()},
                new Actions<string> {Probability = (20.0/100.0 * hp.health) / 100.0, Action = (States.chase).ToString()},
                new Actions<string> {Probability = (100 - hp.health)  / 100.0, Action = (States.flee).ToString()},
            };

            return CalculateAction(initial);
        //80attack, 20move, 0flee
        }
        else {
            var initial = new List<Actions<string>>{
                new Actions<string> {Probability = 100 / 100.0, Action = (States.idle).ToString()},
                new Actions<string> {Probability = 0 / 100.0, Action = (States.chase).ToString()},
            };
            return CalculateAction(initial);
        //80idle, 20move
        } 
    }

    public string CalculateAction(List<Actions<string>> initial){
        var converted = new List<Actions<string>>(initial.Count);
        var sum = 0.0;

        foreach (var action in initial.Take(initial.Count - 1))
        {
            sum += action.Probability;
            converted.Add(new Actions<string> {Probability = sum, Action = action.Action});
        }
        converted.Add(new Actions<string> {Probability = 1.0, Action = initial.Last().Action});
            
        var rnd = new Random();
        float probability = Random.Range(0.0f, 1.0f);
        
        var selected = converted.SkipWhile(i => i.Probability < probability).First();
        return selected.Action;

    }

    public class Actions<T>{
        public double Probability { get; set; }
        public T Action { get; set; }
    }
}
