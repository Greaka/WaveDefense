using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower_Angriff : MonoBehaviour {

    public int a_count = 0;
    private double Enemey;
        //Math.Sqrt(Math.Abs(Enemey.Transform.Position.x-transform.position.X)^2+ Math.Abs(Enemey.Transform.Position.x - this.transform.position.X)^2);
    public Collider2D inRange;

	// Use this for initialization
	void Start () {

	}
	
	// FixedUpdate is called once per tick
	void FixedUpdate () {
        a_count++;
        if (a_count > 3)
            attack();
	}

    public void attack()
    {
        if (inRange.isTrigger)
        {
            //Attack
            //Enemey.life--;
            a_count = 0;
        }
    }
}
