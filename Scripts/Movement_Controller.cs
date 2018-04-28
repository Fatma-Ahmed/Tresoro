using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class Movement_Controller : MonoBehaviour {
    public bool isGrounded;
    private float speed;
    public float rotSpeed;
    public float jumpHeight=1000;
    private float r_speed = 3f; //running speed
    private float rot_speed = 3f;
    private int score;
    public Text scoreText;
    private AudioSource Running;
    Rigidbody rb;
    Animator anim;
    public Transform destination;
    private NavMeshAgent agent;
    private bool isDead = false;
    public DeathMenuScript deathMenu;
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        OnCollisionEnter();
        score = 0;
        scoreText.text = score.ToString();
        Running = GetComponent<AudioSource>();
        Running.Stop();
        agent = GetComponent<NavMeshAgent>();
        if (destination != null)
        {
            agent.SetDestination(destination.position);
        }
    }
    void Update () {
        if (isDead)
        {
            return;
        }
        if (isGrounded)
        {
            Running.Play();
            if (Input.GetKey(KeyCode.W))
            {
                speed = r_speed;
                movementControl("Running Forward");
            }
            else if (Input.GetKey(KeyCode.S))
            {
                speed = r_speed;
                movementControl("Running Backward");
            }
            else
            {
                Running.Stop();
                movementControl("Idle");
            }
            //moving right and left
            if (Input.GetKey(KeyCode.A))
            {
                rotSpeed = rot_speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rotSpeed = rot_speed;
            }
            else
            {
                rotSpeed = 0;
            }
        }
        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * rotSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);
        //jumping function
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            anim.SetTrigger("isJumping");
            rb.AddForce(0, jumpHeight * Time.deltaTime, 0);
            isGrounded = false;
        }
        //Shooting Function
        if ((Input.GetKey(KeyCode.Q)))
        {
            anim.SetTrigger("isShooting");
        }
    }
    void OnCollisionEnter()
    {
        isGrounded = true;
    }
    void movementControl(string state)
    {
        switch (state)
        {
            case "Running Forward":
                anim.SetBool("isRunningForward", true);
                anim.SetBool("isRunningBackward", false);
                anim.SetBool("isIdle", false);
                break;
            case "Running Backward":
                anim.SetBool("isRunningForward", false);
                anim.SetBool("isRunningBackward", true);
                anim.SetBool("isIdle", false);
                break;
            case "Idle":
                anim.SetBool("isRunningForward", false);
                anim.SetBool("isRunningBackward", false);
                anim.SetBool("isIdle", true);
                break;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickUp"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            scoreText.text = score.ToString();
        }
    }
    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);
    }
    public void Death()
    {
        Debug.Log("Deth");
        isDead = true;
        OnDeath();
        Running.Stop();
    }
}
