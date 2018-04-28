using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovment : MonoBehaviour {

    public playerdamage pld;
    public Transform destination;
    private NavMeshAgent enemy;
    Rigidbody rb;
    Animator anim;
    public bool isGrounded;
    private float speed;
    public float rotSpeed;
    //walk speed
    private float w_speed = 0.05f;
    //rotation speed
    private float rot_speed = 1.0f;
    // Use this for initialization
    void Start () {

        //animation
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isGrounded = true; //indicate that we are in the ground

        //AI
        enemy = GetComponent<NavMeshAgent>();
        
        
        
        
    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(destination.position, transform.position);
        if (isGrounded)
        {
            if (destination == null)
            {
                EnemyMovment("relax");
            }

            if (dist>10)
            {
                EnemyMovment("walking");
                enemy.SetDestination(destination.position);
            }

            if (dist<5)
            {
               // speed = w_speed;
                EnemyMovment("attack");
                pld.OnDamage();

            }
            
        }
		
	}

     public void death()
    {
        enemy.enabled = false;
        EnemyMovment("die");
    }

    void EnemyMovment (string state)
    {
        switch (state)
        {
            case "walking":
                anim.SetBool("iswalking", true);
                anim.SetBool("isrelax", false);
                anim.SetBool("isattack", false);
                anim.SetBool("isdie", false);
                break;
            case "relax":
                anim.SetBool("isrelax", true);
                anim.SetBool("iswalking", false);
                anim.SetBool("isattack", false);
                anim.SetBool("isdie", false);
                break;
            case "attack":
                anim.SetBool("isattack", true);
                anim.SetBool("iswalking", false);
                anim.SetBool("isrelax", false);
                anim.SetBool("isdie", false);
                break;
            case "die":
                anim.SetBool("isdie", true);
                anim.SetBool("iswalking", false);
                anim.SetBool("isrelax", false);
                anim.SetBool("isattack", false);
                break;

        }
    }
}
