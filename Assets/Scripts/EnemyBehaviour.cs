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
        // Obtain the steering target of the player and sum a position vector to not touching him.
        agent.destination = PlayerObject.GetComponentInChildren<NavMeshAgent>().steeringTarget + new Vector3(2f, 0f, 0f);
    }
}
