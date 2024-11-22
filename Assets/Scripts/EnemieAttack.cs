using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattack : MonoBehaviour
{
    public float damageAmount = 10f;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    [SerializeField] private Health baseHealth;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        // Zorg dat de base de tag "Base" heeft
        {
            baseHealth = collision.gameObject.GetComponent<Health>();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            baseHealth = null;
            // Verwijdert de referentie wanneer de vijand de base verlaat
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (baseHealth != null && Time.time >= lastAttackTime + attackCooldown)
        {
            baseHealth.TakeDamage(damageAmount); // Schade doen aan de base
            lastAttackTime = Time.time; // Tijd van laatste aanval bijwerken
            //Debug.Log(this.name + "attacked the base!");
        }
    }
}