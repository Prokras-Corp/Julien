using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TriggerLevel : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private void OnTriggerEnter(Collider other)
    {
        menu.SetActive(true);
        Cursor.visible = true;
    }
}