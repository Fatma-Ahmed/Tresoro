using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydamage : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public int health = 100;
    public float damage = 5.0f;
    public enemyMovment eM;

    // Use this for initialization


    public void OnDamage()
    {
        health--;
        if (health <= 0)
        {
            eM.death();
        }
    }
}