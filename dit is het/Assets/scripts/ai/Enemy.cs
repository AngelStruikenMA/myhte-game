using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{




private StateMachine stateMachine;
private NavMeshAgent agent;
public NavMeshAgent Agent {get => agent;}

[SerializeField]
private string currentState;
public Path path;
private GameObject Player;
public float sightDistance = 20f;
public float fieldOfView = 85;
public float eyeHeight;

void Start()
{
    stateMachine = GetComponent<StateMachine>();
    agent = GetComponent<NavMeshAgent>();
    stateMachine.Initialise();
    Player = GameObject.FindGameObjectWithTag("Player");
}
 void Update()
 {
    CanSeePlayer();
 }
 public bool CanSeePlayer()
 {
    if(Player != null)
    {
        if(Vector3.Distance(transform.position, Player.transform.position) < sightDistance)
        {
            Vector3 targetDirection = Player.transform.position - transform.position - (Vector3.up * eyeHeight);
            float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
            if(angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
            {
              
             Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection) ;
             RaycastHit hitInfo = new RaycastHit();
             if(Physics.Raycast(ray,out hitInfo, sightDistance))
             {
                if(hitInfo.transform.gameObject == Player)
                {
                    Debug.Log("ray" + hitInfo.transform.name);
                    Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                    return true;
                }

             }
             Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                      
                    
                
            }
        }
    }
    return false;
 }




}