using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TriggerLevel : MonoBehaviour
{
    [SerializeField] GameObject map;
    [SerializeField] GameObject toActivate;

    private void OnTriggerEnter(Collider other)
    {
        map.SetActive(false);
        toActivate.SetActive(true);
    }
}