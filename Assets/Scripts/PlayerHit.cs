using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

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
    }


}
