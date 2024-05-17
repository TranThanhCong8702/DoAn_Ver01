using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform GamePlay;
    public Camera cam;
    public LineRenderer _line;
    //public Movement2 playermove;
    //public Hooks hook;
    public List<BulletSO> bulletSOs;

    public List<GameObject> Maps;

    public List<GameObject> Players;

    public List<GameObject> mapcurr;
    public List<GameObject> playersCurr;
    public int PlayerNumbCurr;
    string winnerName;

    public List<GameObject> StoryMaps;
    public Image StoryBackGround;
    public List<Sprite> storySprites;
    public CinemachineVirtualCamera StoryCam;

    public bool IsPvp;
    int MapsI = 0;
    private void Awake()
    {
        instance = this;
        FirstBomb();
        //if(Application.)
    }
    public void FirstBomb()
    {
        bulletSOs[0].weapon.IsBought = true;
    }
    public void InsPvPmaps()
    {
        IsPvp = true;
        //int MapsI = Random.Range(0,Maps.Count);
        var t = Instantiate(Maps[MapsI].gameObject, GamePlay);
        MapsI++;
        if(MapsI >= Maps.Count)
        {
            MapsI = 0;
        }
        mapcurr.Add(t);
    }
    public void DestroyMap()
    {
        var t = mapcurr[0].GetComponent<Platform>();
        if (t != null)
        {
            t.SelfDes();
        }
        mapcurr.Clear();
    }
    public void PlayerNumbOn(int number)
    {
        for(int i = 0; i < number; i++)
        {
            var p = Instantiate(Players[i], GamePlay);
            playersCurr.Add(p);
        }
        PlayerNumbCurr = playersCurr.Count;
    }
    public void AllPlayerOff()
    {
        foreach(var p in playersCurr)
        {
            if(p != null)
            {
                var s = p.GetComponent<Playermanager>();
                if(s != null)
                {
                    s.SelfDesImadiate();
                }
            }
        }
        playersCurr.Clear();
        ObjectPool.instance.ReturnAllPool();
    }
    public void OnePlayerOffPvp()
    {
        PlayerNumbCurr--;
        if(PlayerNumbCurr == 1)
        {
            foreach (var p in playersCurr)
            {
                if (p != null)
                {
                    var temp = p.GetComponent<Playermanager>();
                    if (temp)
                    { 
                        if(temp.HPvalue > 0)
                        {
                            winnerName = temp.playerName.ToString();
                        }
                    }
                }
            }
            StartCoroutine(DelayWin());
        }
    }

    public void StoryLoss()
    {
        PlayerNumbCurr--;
        if (PlayerNumbCurr == 0)
        {
            winnerName = "YOU LOSE!";
            StartCoroutine(DelayWinStory(2));
        }
    }
    public void StoryWin()
    {
        winnerName = "YOU WIN!\n\n" + "Gold: + 50!";
        StartCoroutine(DelayWinStory(2));
    }

    public void Escape()
    {
        winnerName = "YOU ESCAPE!";
        StartCoroutine(DelayWinStory(0));
    }

    IEnumerator DelayWinStory(float wait)
    {
        yield return new WaitForSeconds(wait);
        StopTime();
        UIController.instance.storuUI.WinPopUp.SetActive(true);
        UIController.instance.storuUI.winner.text = winnerName;
        StopAllCoroutines();
    }

    IEnumerator DelayWin()
    {
        yield return new WaitForSeconds(2f);
        StopTime();
        UIController.instance.inGameUI.WinPopUp.SetActive(true);
        UIController.instance.inGameUI.winner.text = winnerName + " WIN !";
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }
    public void StartTime()
    {
        Time.timeScale = 1;
    }
    public void InsStorymaps(int id)
    {
        IsPvp = false;
        StoryMaps[id].SetActive(true);
        StoryBackGround.gameObject.SetActive(true);
        StoryBackGround.sprite = storySprites[id];
        int i = /*Random.Range(0, 2)*/0;
        var p = Instantiate(Players[i], Vector3.zero, Quaternion.identity, GamePlay);
        playersCurr.Add(p);
        PlayerNumbCurr = playersCurr.Count;
        ChangeCam();
        StoryCam.Follow = p.GetComponent<Movement2>().Hip.transform;
    }

    public void DesStoryMap()
    {
        foreach(var item in StoryMaps)
        {
            item.SetActive(false);
        }
    }

    private void ChangeCam()
    {
        cam.gameObject.SetActive(false);
        StoryCam.transform.parent.parent.gameObject.SetActive(true);
    }
    public void ChangeCamBack()
    {
        cam.gameObject.SetActive(true);
        StoryCam.transform.parent.parent.gameObject.SetActive(false);
    }
}
