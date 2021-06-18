using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCave : MonoBehaviour
{
    CharacterController player;

    [SerializeField] GameObject maze;
    [SerializeField] GameObject cave;
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject trigger2;

    public void OnTriggerEnter(Collider other)
    {
        maze.SetActive(false);
        trigger.SetActive(false);
        trigger2.SetActive(true);
        cave.SetActive(true);

        player = other.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = new Vector3(82, -28, 157);
        player.enabled = true;
    }
}
