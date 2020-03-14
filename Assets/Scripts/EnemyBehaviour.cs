using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject PlayerObject;

    void Start()
    {
        // Initialize NavMeshAgent Component
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = PlayerObject.transform.position + new Vector3(2f, 0f, 0f); ;
    }
}
