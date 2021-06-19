using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] NavMeshAgent agent;

    [SerializeField] float DistanceView;
    [SerializeField] float DistanceSociale;

    private CharacterCombat combat;

    void Start()
    {
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        target = PlayerManager.instance.player;

        Vector3 position = agent.transform.position;
        Vector3 destination = target.transform.position;
                    
            
        if (Vector3.Distance(position, destination) < DistanceView) 
        { 
            agent.SetDestination(position);
            if (Vector3.Distance(position, destination) < DistanceSociale)
            {
                CharacterStats targetStats = target.transform.GetComponent<CharacterStats>(); 
                combat.Attack(targetStats);
            }
        }
        else 
        { 
            agent.SetDestination(destination);
        }
    }
    
}
