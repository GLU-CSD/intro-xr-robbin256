using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;

    void Start()
    {
        // Vind de NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Zoek de XR Rig met de tag "Player"
        if (agent.enabled)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Base");
            if (player != null)
            {
                playerTransform = player.transform;
               
            }
        }
    }

    void Update()
    {
        // Beweeg naar de positie van de speler als deze is gevonden
        if (agent.enabled)
        {
            if (playerTransform != null)
            {
                agent.SetDestination(playerTransform.position);
            }
        }
    }
}