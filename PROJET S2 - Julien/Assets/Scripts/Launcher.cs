using UnityEngine;
using Photon.Pun;
using TMPro;
using System.Collections.Generic;
using Photon.Realtime;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    //SerializeField => Pour etre vu dans Unity
    [SerializeField] TMP_InputField roomNameInputField;     //Nom de la salle d'attente
    [SerializeField] TMP_Text errorText;                    //Message d'erreur
    [SerializeField] TMP_Text roomNameText;                 //Nom de la salle d'attente
    [SerializeField] Transform roomListContent;             //Liste des salles
    [SerializeField] Transform playerListContent;           //Liste des joueurs dans la salle
    [SerializeField] GameObject roomListItemPrefab;         //Affichage du nom des salles
    [SerializeField] GameObject PlayerListItemPrefab;       //Affichage du nom des joueurs
    [SerializeField] GameObject startGameButton;            //Bouton pour commencer (host uniquement)


    private void Awake()
    {
        Instance = this;
    }

    void Start()    //Lancé dès le lancement de la scène Menus
    {
        Debug.Log("Connecting to Master");      //Affichage
        PhotonNetwork.ConnectUsingSettings();   //Connexion au serveur de Photon
    }

    public override void OnConnectedToMaster()  //Une fois connecté
    {
        Debug.Log("Connected to Master");               //Affichage
        PhotonNetwork.JoinLobby();                      //Rejoins le lobby Photon
        PhotonNetwork.AutomaticallySyncScene = true;    //Synchronise les scènes pour  tous les joueurs
    }

    public override void OnJoinedLobby()    //Une fois le lobby rejoint
    {
        MenuManager.Instance.OpenMenu("Title");     //Ouvre le menu principal
        Debug.Log("Joined Lobby");                  //Affichage
        PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");    //Pseudo random de la forme "Player XXXX"
    }

    
    public void CreateRoom()    //Crée un salle
    {
        if(string.IsNullOrEmpty(roomNameInputField.text))  //Si le nom de salle est vide, on ne la crée pas
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text); //Crée une salle au nom donné
        MenuManager.Instance.OpenMenu("Loading");          //Ouvre l'écran de chargement
    }

    public override void OnJoinedRoom()     //Une fois la salle rejointe
    {
        MenuManager.Instance.OpenMenu("Room");                  //Ouvre le menu de la salle
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;     //Initialise le nom de la salle pour être affiché plus tard

        Player[] players = PhotonNetwork.PlayerList;            //Liste des joueurs dans la salle

        foreach (Transform child in playerListContent)          //Vide les objets de la liste de joueurs
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)               //Pour chaque joueur, instancie un affichage du nom du joueur
        {
            Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }

        startGameButton.SetActive(PhotonNetwork.IsMasterClient); //Montre le bouton de lancement à l'host
    }

    public override void OnMasterClientSwitched(Player newMasterClient)     //Sur migration d'host
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);    //Montre le bouton au nouvel host
    }

    public override void OnCreateRoomFailed(short returnCode, string message)   //Si la création de salle échoue
    {
        errorText.text = "Room Creation Failed: " + message;    //Crée le message d'erreur
        MenuManager.Instance.OpenMenu("Error");                 //Ouvre le menu d'erreur
    }
    
    
    public void StartGame()     //Une fois la partie lancée
    {
        PhotonNetwork.LoadLevel(1);     //Ouvre la scène de jeu
    }

    public void LeaveRoom()     //Quitte la salle
    {
        PhotonNetwork.LeaveRoom();                  //Quitte la salle
        MenuManager.Instance.OpenMenu("Loading");   //Ouvre l'écran de chargement
    }

    public void JoinRoom(RoomInfo info)     //Rejoins une salle
    {
        PhotonNetwork.JoinRoom(info.Name);          //Rejoins la salle info.Name
        MenuManager.Instance.OpenMenu("Loading");   //Ouvre l'écran de chargement
    }

    
    public override void OnRoomListUpdate(List<RoomInfo> roomList)  //Sur actualisation de la liste des salles
    {
        foreach (Transform trans in roomListContent)    //Vide les objets de la liste des salles
        {
            Destroy(trans.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)        //Pour chaque salle dans la liste, instancie un bouton pour la rejoindre
        {
            if (roomList[i].RemovedFromList)            //Sauf si la salle a été retirée
                continue; // <- skip la ligne en dessous
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)  //Quand un joueur rejoins
    {
        Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);   //L'ajoute dans l'affichage
    }
}
