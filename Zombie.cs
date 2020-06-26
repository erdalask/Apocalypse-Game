using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    Animator ZombieAnim;


    public Transform target;

    NavMeshAgent Agent;



    public float distance;

    public float health;

	// Use this for initialization
	void Start ()
    {

        ZombieAnim = GetComponent<Animator>();

        Agent = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        ZombieAnim.SetFloat("Speed", Agent.velocity.magnitude);
        ZombieAnim.SetFloat("Health", health);

        distance = Vector3.Distance(transform.position, target.position);


        if(health>0)
        {
            if (distance <= 10)
            {

                Agent.enabled = true;
                Agent.destination = target.position;


            }

            else
            {

                Agent.enabled = false;

            }
        }

       

	}
}
