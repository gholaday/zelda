using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable
{
    public int Strength;

    void Start()
    {
        CurrentHealth = MaximumHealth;
    }

    void Update()
    {

    }

    public override void Die()
    {
        print("oh no im dead");
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Player player = other.GetComponentInParent<Player>();
            if (player != null)
            {
                print("doing " + Strength + " damage to " + other.name);
                player.TakeDamage(Strength);
            }
        }

    }
}
