using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdamage : MonoBehaviour {

    public int health = 100;
    public float damage = 5.0f;
    public  Movement_Controller MC;

    // Use this for initialization
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDamage()
    {
        health--;
        if (health <= 0)
        {
            MC.Death();
        }
    }
    /*
        void OnTriggerEnter(Collider Enemy)
        {
            if (Enemy.gameObject.CompareTag("enemy"))
            {
                Enemy.gameObject.SendMessage("OnDamage", damage);
            }
        }
        */
}


