using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if(PV.IsMine)
        {
            CreateController();
        }
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }

    void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("Photon Prefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
    }
}
