using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUnlock : MonoBehaviour
{
    public int itemState;

    [SerializeField] GameObject grapin;
    [SerializeField] GameObject brace;
    [SerializeField] GameObject card;
    [SerializeField] GameObject torch;

    // Start is called before the first frame update
    void Start()
    {
        switch(itemState)
        {
            case 1:
                grapin.SetActive(true);
                break;
            case 2:
                brace.SetActive(true);
                break;
            case 3:
                card.SetActive(true);
                break;
            case 4:
                torch.SetActive(true);
                break;
        }
    }
}
