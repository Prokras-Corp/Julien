using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerListItem : MonoBehaviourPunCallbacks     //Affiche la liste des joueurs dans la salle
{
    [SerializeField] TMP_Text text;
    Player player;

    public void SetUp(Player _player)   //Sert à instancier les joueurs aux bons noms
    {
        player = _player;
        text.text = _player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) //Retire "LUI" de la liste s'il quitte la salle
    {
        if(player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom() //Retire "MOI" de la salle
    {
        Destroy(gameObject);
    }
}
