using UnityEngine;
using UnityEngine.AI;

public class AgentBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        // Initialize NavMeshAgent Component
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camRay, out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }
}
