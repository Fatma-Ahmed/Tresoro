using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour {
    private AudioSource Coins;

    void start()
    {
        Coins = GetComponent<AudioSource>();
        Coins.Stop();
    }
    void Update () {
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Coins.Play();
        }
    }
}
