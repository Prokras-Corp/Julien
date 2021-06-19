using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    PhotonView PV;
    public GameObject player;
    void Awake()
    {
        
        if (instance != null)
        {
            Debug.Log("More than one instance of Player Manager found");
            return;
        }
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        PV = GetComponent<PhotonView>();
        
    }

    void Start()
    {
        
        if (FindObjectOfType<EventSystem>() == null)
        {
            var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
            
        }
        if (PV.IsMine)
        {
            CreateController();
        }
    }


    void CreateController()
    {
        PhotonNetwork.Instantiate(Path.Combine("Photon Prefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
    }


    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
