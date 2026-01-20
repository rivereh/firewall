using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;
using Steamworks;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;
    PhotonView PV;
    Camera sceneCamera;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (!PV.IsMine)
        {
            DisableComponents();
            Destroy(GetComponent<Rigidbody>());
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {

                Camera.main.gameObject.SetActive(false);
            }

            // Lock cursor
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;


        }


    }

    void DisableComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

}
