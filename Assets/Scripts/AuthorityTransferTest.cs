using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AuthorityTransferTest : MonoBehaviour
{
    PhotonView PV;


    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }


    void Start()
    {
        
    }

    void Update()
    {



    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<PhotonView>() != null)
            {
                // Debug.Log(PV.Owner);
                PV.TransferOwnership(other.gameObject.GetComponent<PhotonView>().Owner);
            }
        }
    }

}
