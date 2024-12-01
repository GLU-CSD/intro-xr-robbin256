using System;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 50f;
    public float rotationSpeed = 60f; // Draaisnelheid in graden per seconde
    private Transform target1;
    private Transform target2;
    private Transform currentTarget;
    public void SetTarget(Transform newTarget, Transform FirstTarget)
        //-------------------------------------------------------------------
    {
        target1 = FirstTarget;

        target2 = newTarget;
 
       
    }

    void Start()
    {
        // Begin met het bewegen naar target1
        currentTarget = target1;
    }

    void Update()
    {
        if (currentTarget == null)
        {
            Destroy(gameObject);
            return;
        }


        float distance = Vector3.Distance(transform.position, currentTarget.position);
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.position += direction * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, currentTarget.position) < 5.2f)
        {
            if (currentTarget == target1)
            {
                currentTarget = target2;
            }
            else
            {
                Explode();
                Health enemyHealth = currentTarget.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    // Breng schade toe aan het doelwit
                    enemyHealth.TakeDamage(10f); // Vervang 10f door de gewenste schadewaarde
                }
            }
        }
    }

    void Explode()
    {
        // Zoek Health component van target met GetComponent
        // Als Health script gevonden is, gebruik TakeDamage functie
        // Gebruik damage variable
        // Instantiate eventuele effecten

        Destroy(gameObject);
    }
}