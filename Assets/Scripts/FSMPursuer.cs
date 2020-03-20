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

    private NavMeshAgent agent;

    private void Awake()
    {
        statePursuePlayer = new StatePursuePlayer(this);
        statePursueEnemy = new StatePursueEnemy(this);

        agent = GetComponent<NavMeshAgent>();
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
    public StatePursuePlayer(FSMPursuer fsmSoldado)
    {
        fsm = fsmSoldado;
    }

    public void ToStatePursueEnemy()
    {
        throw new System.NotImplementedException();
    }

    public void ToStatePursuePlayer()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}

public class StatePursueEnemy : IStatePursuer
{
    private readonly FSMPursuer fsm;
    public StatePursueEnemy(FSMPursuer fsmSoldado)
    {
        fsm = fsmSoldado;
    }
    public void ToStatePursueEnemy()
    {
        throw new System.NotImplementedException();
    }

    public void ToStatePursuePlayer()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        throw new System.NotImplementedException();
    }
}