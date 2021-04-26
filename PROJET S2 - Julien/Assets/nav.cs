using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav : MonoBehaviour
{
    /*[SerializeField]*/ GameObject target;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float DistanceSociale;


    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        Vector3 position = agent.transform.position;
        Vector3 destination = target.transform.position;

        agent.SetDestination(destination);

        if (Vector3.Distance(position, destination) < DistanceSociale)
        {
            agent.SetDestination(position);
        }
    }
}
