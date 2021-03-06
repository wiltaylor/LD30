﻿using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour
{

    public float TimeOut = 20f;
    public float Speed = 10f;
    public GameObject Spawner;
    public AudioClip FireSound;

    private Rigidbody2D _rbody;
    void Start()
    {
        _rbody = gameObject.rigidbody2D;
        AudioSource.PlayClipAtPoint(FireSound, transform.position);
    }
	
	void Update ()
	{
	    TimeOut -= Time.deltaTime;

        if(TimeOut < 0)
            Destroy(gameObject);

        _rbody.AddForce(transform.up.normalized * Speed, ForceMode2D.Force);
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Spawner)
            return;

        if (other.gameObject.tag == "Car")
        {
            other.gameObject.SendMessage("OnProjectileHit");
        }
        
        Destroy(gameObject);
    }
}
