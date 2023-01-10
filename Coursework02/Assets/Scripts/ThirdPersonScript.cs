using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Transform player;

    public float speed = 9f;
    public float turnSmoothTime = 0.1f;
    

    float turnSmoothVelocity;
    // Update is called once per frame

    void Awake(){
        
    }

    void Update()
    {
        if(player){
            
            // if(transform.position.x <51f){
                
            // }
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            if(direction.magnitude >= 0.1f){
                
                
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir * speed * Time.deltaTime);
            }
            
            if(player.position.y > 0 || player.position.y < 0){
                player.position = new Vector3(player.position.x, 0f, player.position.z);
            }
        }
        

        
    }
}
