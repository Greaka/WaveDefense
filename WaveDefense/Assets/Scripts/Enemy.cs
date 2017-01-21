using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int Health;

    public float Speed;

    public int Bounty;

    public event Death Die;

    public delegate void Death(Enemy instance);

    public bool isDead = false;

    public int Speicherpunkt;

	// Use this for initialization
    public void Start ()
    {
        ;
    }
	
	// Update is called once per frame
    public void Update ()
    {
        if (Health <= 0)
        {
            isDead = true;
        }

        if (isDead == true)
        {
            if (Die != null)
            {
                Die(this);
                Die = null;
            }
        }
    }
}
