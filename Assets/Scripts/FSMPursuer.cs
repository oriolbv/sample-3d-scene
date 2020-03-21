using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSMPursuer : MonoBehaviour
{
    // List of the different states
    [HideInInspector] public IStatePursuer stateActual;
    [HideInInspector] public StatePursuePlayer statePursuePlayer;
    [HideInInspector] public StatePursueEnemy statePursueEnemy;

    [HideInInspector] public NavMeshAgent agent;

    public GameObject PlayerObject;
    public GameObject EnemyObject;

    private void Awake()
    {
        statePursuePlayer = new StatePursuePlayer(this);
        statePursueEnemy = new StatePursueEnemy(this);

        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        stateActual = statePursueEnemy;
    }

    private void Update()
    {
        stateActual.UpdateState();
    }
}
 
public interface IStatePursuer
{
    void UpdateState();

    void ToStatePursuePlayer();

    void ToStatePursueEnemy();
}

public class StatePursuePlayer : IStatePursuer
{
    private readonly FSMPursuer fsm;
    public StatePursuePlayer(FSMPursuer fsmPursuer)
    {
        fsm = fsmPursuer;
    }

    public void ToStatePursueEnemy()
    {
        fsm.stateActual = fsm.statePursueEnemy;
    }

    public void ToStatePursuePlayer()
    {
        Debug.Log("Transition not permitted.");
    }

    public void UpdateState()
    {
        // Agent should pursue player
        fsm.agent.destination = fsm.PlayerObject.transform.position + new Vector3(2f, 0f, 0f);
    }
}

public class StatePursueEnemy : IStatePursuer
{
    private readonly FSMPursuer fsm;
    public StatePursueEnemy(FSMPursuer fsmPursuer)
    {
        fsm = fsmPursuer;
    }
    public void ToStatePursueEnemy()
    {
        Debug.Log("Transition not permitted.");
    }

    public void ToStatePursuePlayer()
    {
        fsm.stateActual = fsm.statePursuePlayer;
    }

    public void UpdateState()
    {
        // Agent should pursue enemy
        fsm.agent.destination = fsm.EnemyObject.transform.position + new Vector3(2f, 0f, 0f);
    }
}