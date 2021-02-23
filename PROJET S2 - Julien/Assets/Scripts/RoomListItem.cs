using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class RoomListItem : MonoBehaviour //Bouton pour rejoindre la salle dans la liste
{
    [SerializeField] TMP_Text text;
    public RoomInfo info;
    
    public void SetUp(RoomInfo _info) //Sert à instancier le bouton au bon nom
    {
        info = _info;
        text.text = _info.Name;
    }

    public void OnClick()   //Rejoins la salle
    {
        Launcher.Instance.JoinRoom(info);
    }
}
