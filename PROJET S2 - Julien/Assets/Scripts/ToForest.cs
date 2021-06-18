using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToForest : MonoBehaviour
{
    CharacterController player;

    [SerializeField] GameObject plant;
    [SerializeField] GameObject forest;
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject trigger2;

    public void OnTriggerEnter(Collider other)
    {
        plant.SetActive(false);
        trigger.SetActive(false);
        trigger2.SetActive(true);
        forest.SetActive(true);

        player = other.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = new Vector3(100, -26, -57);
        player.enabled = true;
    }
}
