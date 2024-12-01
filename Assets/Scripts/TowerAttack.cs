using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor.Profiling.Memory.Experimental;

public class TowerAttack : MonoBehaviour
{
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform FirstTarget;
    private LineRenderer lineRenderer;



    private float nextFireTime = 0f;
    private List<Transform> enemiesInRange = new List<Transform>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.transform);
            lineRenderer = GetComponent<LineRenderer>();    
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.transform);

        }
    }

    Transform GetClosestEnemy()
    {
        Transform closestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Transform enemy in enemiesInRange)
        {
            if (enemy == null)
            {
                enemiesInRange.Remove(enemy);
                continue;
            }
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }



    void Update()
    {
        if (gameObject.name == "Tower")
        {
            if (Time.time >= nextFireTime)
            {
                Transform target = GetClosestEnemy();
                if (target != null)
                {
                    Shoot(target);
                    nextFireTime = Time.time + 1f / fireRate;
                }
            }
        } else if (gameObject.name == "Laser Tower")
        {

            Transform target = GetClosestEnemy();
            if (target != null)
            {
                lineRenderer.enabled = true;

                lineRenderer.SetPosition(0, firePoint.position); // Startpunt
                lineRenderer.SetPosition(1, target.position);
                Health enemyHealth = target.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    // Breng schade toe aan het doelwit
                    enemyHealth.TakeDamage(0.05f); // Vervang 10f door de gewenste schadewaarde
                }
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }

    void Shoot(Transform target)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetTarget(target, FirstTarget);
        
        
    }
}