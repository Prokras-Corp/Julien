using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    [SerializeField] GameObject objet;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        objet.SetActive(false);
        ObjectUnlock ou = other.GetComponent<ObjectUnlock>();
        ou.itemState++;
        ou.Invoke("Start", 0.01f);
    }
}
