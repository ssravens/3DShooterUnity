using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 50f;
    private float health;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // makes the player take damage
    public void Damage(float dam)
    {
        health -= dam;
        if (health <= 0)
        {
            Death();
        }
    }

    // kills the player
    private void Death()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
