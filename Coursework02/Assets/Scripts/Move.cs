using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   	public CharacterController character;
    public Transform target;
	float speed = 7;

    public void Spawn(){
        Vector3 moveDirection = transform.position - target.position;
        character.Move(moveDirection.normalized * speed * Time.deltaTime);
        
    }
	

    
}
