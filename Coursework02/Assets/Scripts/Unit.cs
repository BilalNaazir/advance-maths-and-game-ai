using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Callbacks;

public class Unit : MonoBehaviour
{
   	public Transform target;
	public Transform enemy;
	float speed = 5;
	Vector3[] path;
	int targetIndex;
	public float stopDistance;
	// private bool startNow = false;
	public bool startNow;
	
	// public void Move(Transform seeker, Transform targets) {
	// 	print(seeker.position);
	// 	print(targets.position);
	// }
	public void Move(Transform seeker, Transform targets) {
		if(enemy && target){
							
			if(Vector3.Distance(seeker.position, target.position) < 25){
				
				startNow = false;
			}
			else{
				seeker.LookAt(target);
				startNow = true;
				if(enemy){
					PathRequestManager.RequestPath(seeker.position,targets.position, OnPathFound);
				}
				
			}
		}	
	}


	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if(!enemy){
			
		}
		else{
			if (pathSuccessful) {
				path = newPath;
				targetIndex = 0;
				StopCoroutine("FollowPath");
				StartCoroutine("FollowPath");
			}
			else{
				print("issuehere");
				enemy.position = Vector3.MoveTowards(enemy.position,target.position,speed * Time.deltaTime);
			}
		}
		
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];
		
		while (true) {
			if(startNow){
				if (enemy.position == currentWaypoint) {
					targetIndex ++;
					if (targetIndex >= path.Length) {
						yield break;
					}
					currentWaypoint = path[targetIndex];
				}
			
				enemy.position = Vector3.MoveTowards(enemy.position,currentWaypoint,speed * Time.deltaTime);
				yield return null;
			}
			else{
				break;
			}

		}
	}

    public void OnDrawGizmos() {
		if (path != null) {
			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex) {
					Gizmos.DrawLine(enemy.position, path[i]);
				}
				else {
					Gizmos.DrawLine(path[i-1],path[i]);
				}
			}
		}
	}
}
