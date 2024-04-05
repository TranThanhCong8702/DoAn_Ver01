using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] string VersionName = "0.1";
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject usernameMenu;
    [SerializeField] InputField usernametxt;
    [SerializeField] InputField joinGametxt;
    [SerializeField] InputField CreateGametxt;
    [SerializeField] GameObject Startbtn;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connect");
    }
    public void GetUserName()
    {
        if(usernametxt.text.Length > 0)
        {
            Startbtn.SetActive(true);
        }
        else
        {
            Startbtn.SetActive(false);
        }
    }
    public void StartBtn()
    {
        usernameMenu.SetActive(false);
        mainMenu.SetActive(true);
        PhotonNetwork.playerName = usernametxt.text;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateGametxt.text, new RoomOptions() { MaxPlayers = 5 }, null);
    }

    public void JoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        bool checkJoin = PhotonNetwork.JoinRoom(joinGametxt.text);
        if(!checkJoin)
        {
            //Kiem tra lai ten Room, ko ton tai
        }
    }
    void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainGamePlay");
    }
}
