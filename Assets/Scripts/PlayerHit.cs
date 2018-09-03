using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Breakable")
        {
            Breakable breakable = other.GetComponent<Breakable>();

            if (breakable != null)
            {
                breakable.Break();
            }
        }

        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(player.Strength);
        }
    }


}
