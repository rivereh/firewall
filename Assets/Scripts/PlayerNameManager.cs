using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Steamworks;
using TMPro;
using UnityEngine;

public class PlayerNameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;

    void Start()
    {
        // if (PlayerPrefs.HasKey("username"))
        // {
        //     usernameInput.text = PlayerPrefs.GetString("username");
        //     PhotonNetwork.NickName = PlayerPrefs.GetString("username");
        // }
        // else
        // {
        //     usernameInput.text = "Guest " + Random.Range(0, 1000).ToString("0000");
        //     OnUsernameInputValueChanged();
        // }
        if (!SteamManager.Initialized)
        {
            return;
        }
        usernameInput.text = SteamFriends.GetPersonaName();
    }

    public void OnUsernameInputValueChanged()
    {
        PhotonNetwork.NickName = usernameInput.text;
        PlayerPrefs.SetString("username", usernameInput.text);
    }
}
