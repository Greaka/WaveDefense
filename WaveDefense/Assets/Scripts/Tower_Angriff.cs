using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Remoting.Messaging;

public class Tower_Angriff : MonoBehaviour {

    public float a_count = 0F;
    public int cost = 10;
    public float reloadtime = 0.5F;
    private Enemy enemey;
    public int damage;
        //Math.Sqrt(Math.Abs(Enemey.Transform.Position.x-transform.position.X)^2+ Math.Abs(Enemey.Transform.Position.x - this.transform.position.X)^2);
    public Collider2D inRange;
    private bool mayattack = false;

	// Use this for initialization
	void Start () {

	}
	
	// FixedUpdate is called once per tick
    void FixedUpdate()
    {
        a_count += Time.deltaTime;
        if (a_count > reloadtime)
        {
            mayattack = true;
            a_count = 0;
        }
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (mayattack == true && collider.gameObject.CompareTag("enemy"))
        {
            enemey = collider.gameObject.GetComponent<Enemy>();
            enemey.Health -= damage;
            mayattack = false;
            //Debug.Log("Toll!");
        }
    }
}
