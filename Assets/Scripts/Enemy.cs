using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Damageable
{
    public int Strength;

    void Start()
    {
        CurrentHealth = StartingHealth;
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

        if (other.tag == "PlayerHurt")
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
