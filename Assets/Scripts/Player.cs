using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Damageable
{
    public int Strength = 1;

    public delegate void OnCurrentHealthChangeDelegate();
    public static event OnCurrentHealthChangeDelegate currentHealthChange;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        SetCurrentHealth(MaximumHealth);
    }

    void Update()
    {

    }

    public override void SetCurrentHealth(int health)
    {
        base.SetCurrentHealth(health);
        currentHealthChange();
    }

    public override void Die()
    {
        print("REEEEEEEEEEEEEEEEEEEEEEEE");
    }
}
