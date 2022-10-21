using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum PickupType
{
    Gold,
    Health
}

public class Pickup : MonoBehaviourPun
{
    public PickupType type;
    public int value;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //not master client
        if (!PhotonNetwork.IsMasterClient)
            return;
        
        if(collision.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            //is this a gold pickup
            if (type == PickupType.Gold)
                player.photonView.RPC("GiveGold", player.photonPlayer, value);
            else if (type == PickupType.Health)
                player.photonView.RPC("Heal", player.photonPlayer, value);


            //PICKUP DESTROY FIX
            //Used the same code provided in BattleRoyale 
            photonView.RPC("DestroyPickup", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void DestroyPickup()
    {
        Destroy(gameObject);
    }
}
