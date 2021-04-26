using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVillage : MonoBehaviour
{
    CharacterController player;

    [SerializeField] GameObject level;
    [SerializeField] GameObject village;

    public void OnTriggerEnter(Collider other)
    {
        level.SetActive(false);
        village.SetActive(true);

        player = other.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = new Vector3(0, 0, 0);
        player.enabled = true;
    }
}
