using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPlant : MonoBehaviour
{
    CharacterController player;

    [SerializeField] GameObject cave;
    [SerializeField] GameObject plant;
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject trigger2;

    public void OnTriggerEnter(Collider other)
    {
        cave.SetActive(false);
        trigger.SetActive(false);
        trigger2.SetActive(true);
        plant.SetActive(true);

        player = other.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = new Vector3(230, -23, -74);
        player.enabled = true;
    }
}
