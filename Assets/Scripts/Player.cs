using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable
{
    public int Strength = 1;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        CurrentHealth = StartingHealth;
    }

    void Update()
    {

    }



    public override void Die()
    {
        print("REEEEEEEEEEEEEEEEEEEEEEEE");
    }
}
