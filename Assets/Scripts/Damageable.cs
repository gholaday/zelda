using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{

    public int MaximumHealth;
    public int InvulnerabilityFrames;
    public int CurrentHealth;
    bool vulnerable = true;

    public void RecoverHealth(int health)
    {
        CurrentHealth += health;
    }

    public void TakeDamage(int damage)
    {
        if (vulnerable)
        {
            vulnerable = false;

            StartCoroutine(FlashAndBecomeInvulnerable());
            SetCurrentHealth(CurrentHealth - damage);

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }
    }

    public virtual void SetCurrentHealth(int health)
    {
        CurrentHealth = health;
    }

    public abstract void Die();

    public IEnumerator FlashAndBecomeInvulnerable()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            if (sr.material.shader.name == "Sprites/Diffuse Flash")
            {
                for (int i = 0; i < InvulnerabilityFrames / 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        sr.material.SetFloat("_FlashAmount", 1);
                    }
                    else
                    {
                        sr.material.SetFloat("_FlashAmount", 0);

                    }

                    yield return WaitFor.Frames(2);
                }
            }
        }
        else
        {
            yield return WaitFor.Frames(InvulnerabilityFrames);
        }

        vulnerable = true;
    }
}
