using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class GM : MonoBehaviour
{
    private int adCount;
    int[,] state;
    GameObject inst;
    Camera cam;
    List<GameObject> levelParts;
    Vector3 v;
    int size;
    bool inHint = false;    
    string completedLevels11 = "00000";
    string completedLevels12 = "00000";
    string completedLevels13 = "00000";
    public string progress = "";
    public string hint = "";
    public int boxQuantity;
    public float cellSize;
    public float startX;
    public float startY;
    public int boxCounts = 0;
    public int moves = 0;
    public List<GameObject> finishs;
    public GameObject[] wallPrefabs;
    public GameObject floorPrefab;
    public GameObject boxPrefab;
    public GameObject voidPrefab;
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject finishPrefab;
    public GameObject finishActivePrefab;
    public GameObject camera;
    public GameObject gameO;
    public GameObject miniMenu;
    public GameObject nextLevel;
    public GameObject hintPanel;
    public GameObject hintPanelWithAd;
    public Text endText;
    public Text movesText;
    public Text progressText;
    public Text hintText;
    public Text[] easyTexts;
    public Text[] normalTexts;
    public Text[] hardTexts;
    [HideInInspector]
    public bool game = true;
    public GameObject endPanel;
    public static GM instance = null;
    [HideInInspector]
    public bool push = false;
    public bool watchedAd = false;    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        cam = camera.GetComponent<Camera>();
        levelParts = new List<GameObject>();
        finishs = new List<GameObject>();
        if(PlayerPrefs.HasKey("l11"))
            completedLevels11 = PlayerPrefs.GetString("l11");
        if(PlayerPrefs.HasKey("l12"))
            completedLevels12 = PlayerPrefs.GetString("l12");
        if(PlayerPrefs.HasKey("l13"))
            completedLevels13 = PlayerPrefs.GetString("l13");       
    }    
    void Update()
    {

    }
    public void UpdateMoves()
    {
        movesText.text = "Moves:\n" + moves.ToString();
    }
    string ChangeSymbolInTheString(string s, int n, char c)
    {
        string s1="";
        for(int i=0; i<s.Length; i++)
        {
            s1 += i == n ? c : s[i];
        }
        return s1;
    }
    public void EasyLevelsLoad()
    {
        for(int i=0; i<5; i++)
        {
            if(PlayerPrefs.HasKey("m11"+(i+1).ToString()))
            {
                easyTexts[i].text += "\nbest: " + PlayerPrefs.GetInt("m11"+(i+1).ToString())+ " moves";
            }
        }
    }
    public void NormalLevelsLoad()
    {
        for(int i=0; i<5; i++)
        {
            if(PlayerPrefs.HasKey("m12"+(i+1).ToString()))
            {
                normalTexts[i].text += "\nbest: " + PlayerPrefs.GetInt("m12"+(i+1).ToString())+ " moves";
            }
        }
    }
    public void HardLevelsLoad()
    {
        for(int i=0; i<5; i++)
        {
            if(PlayerPrefs.HasKey("m13"+(i+1).ToString()))
            {
                hardTexts[i].text += "\nbest: " + PlayerPrefs.GetInt("m13"+(i+1).ToString())+ " moves";
            }
        }
    }
    public void CreateLevel()
    {
        game = true;
        movesText.text = "Moves:\n0";
        hint = LM.instance.GetHint();
        size = int.Parse(Math.Sqrt(LM.instance.ReturnSize()).ToString());
        state = LM.instance.ReturnLevel();
        camera.transform.position = new Vector3(startX + (size * cellSize) / 2 - cellSize / 2, startY + (size * cellSize) / 2 - cellSize / 2, -10);
        cam.orthographicSize = size * 1.5f;
        int wallNumber = wallPrefabs.Length;
        int r;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                switch (state[i, j])
                {
                    case 0:
                        inst = Instantiate(voidPrefab, new Vector3(startX + j * cellSize, startY + i * cellSize, 0), Quaternion.identity) as GameObject;
                        break;
                    case 1:
                        r = Random.Range(0, wallNumber);
                        inst = Instantiate(wallPrefabs[r], new Vector3(startX + j * cellSize, startY + i * cellSize, 0), Quaternion.identity) as GameObject;
                        if (r == 3)
                        {
                            wallNumber--;
                        }
                        break;
                    case 2:
                        inst = Instantiate(floorPrefab, new Vector3(startX + j * cellSize, startY + i * cellSize, 1), Quaternion.identity) as GameObject;
                        break;
                    case 3:
                        inst = Instantiate(floorPrefab, new Vector3(startX + j * cellSize, startY + i * cellSize, 1), Quaternion.identity) as GameObject;
                        inst.transform.parent = gameO.transform;
                        levelParts.Add(inst);
                        inst = Instantiate(boxPrefab, new Vector3(startX + j * cellSize, startY + i * cellSize, 0), Quaternion.identity) as GameObject;
                        break;
                    case 4:
                        inst = Instantiate(finishPrefab, new Vector3(startX + j * cellSize, startY + i * cellSize, 0), Quaternion.identity) as GameObject;
                        break;
                    case 5:
                        inst = Instantiate(floorPrefab, new Vector3(startX + j * cellSize, startY + i * cellSize, 1), Quaternion.identity) as GameObject;
                        inst.transform.parent = gameO.transform;
                        levelParts.Add(inst);
                        v = new Vector3(startX + j * cellSize, startY + i * cellSize, 0);
                        player.transform.position = v;
                        break;
                    case 6:
                        inst = Instantiate(finishPrefab, new Vector3(startX + j * cellSize, startY + i * cellSize, 0), Quaternion.identity) as GameObject;
                        inst.transform.parent = gameO.transform;
                        levelParts.Add(inst);
                        inst = Instantiate(boxPrefab, new Vector3(startX + j * cellSize, startY + i * cellSize, 0), Quaternion.identity) as GameObject;
                        break;
                }
                inst.transform.parent = gameO.transform;
                levelParts.Add(inst);
            }
        }        
    }
    public void ShowEndPanel()
    {
        adCount++;
        if (adCount % 3 == 1)
        {
            AdManager.instance.ShowAd();
        }
        endText.text = "Level Completed";
        nextLevel.SetActive(true);
        if(LM.instance.currentDifficulty == 1)
        {
            if(completedLevels11[LM.instance.currentLevel-1] == '0')
            {
                completedLevels11 = ChangeSymbolInTheString(completedLevels11, LM.instance.currentLevel-1, '1');
                PlayerPrefs.SetString("l11", completedLevels11);
                PlayerPrefs.SetInt("m11" + LM.instance.currentLevel.ToString(), moves); 
                if(completedLevels11 == "11111")
                {
                    endText.text += "\nYou have unlocked Normal levels!";
                    LM.instance.unlocked = "110";
                    PlayerPrefs.SetString("dw1", LM.instance.unlocked);
                }
            }
            else
            {
                if(moves < PlayerPrefs.GetInt("m11" + LM.instance.currentLevel.ToString()))
                {
                    PlayerPrefs.SetInt("m11" + LM.instance.currentLevel.ToString(), moves);
                }
            }
            if( LM.instance.currentLevel == 5 && LM.instance.unlocked == "100") 
            {
                nextLevel.SetActive(false);
            }
        }
        if(LM.instance.currentDifficulty == 2)
        {
            if(completedLevels12[LM.instance.currentLevel-1] == '0')
            {
                completedLevels12 = ChangeSymbolInTheString(completedLevels12, LM.instance.currentLevel-1, '1');
                PlayerPrefs.SetString("l12", completedLevels12);
                PlayerPrefs.SetInt("m12" + LM.instance.currentLevel.ToString(), moves); 
                if(completedLevels12 == "11111")
                {
                    endText.text += "\nYou have unlocked Hard levels!";
                    LM.instance.unlocked = "111";
                    PlayerPrefs.SetString("dw1", LM.instance.unlocked);
                }
            }
            else
            {
                if(moves < PlayerPrefs.GetInt("m12" + LM.instance.currentLevel.ToString()))
                {
                    PlayerPrefs.SetInt("m12" + LM.instance.currentLevel.ToString(), moves);
                }
            }
            if( LM.instance.currentLevel == 5 && LM.instance.unlocked != "111") 
            {
                nextLevel.SetActive(false);
            }
        }
        if(LM.instance.currentDifficulty == 3)
        {
            if( LM.instance.currentLevel == 5) 
            {
                nextLevel.SetActive(false);
            }
            if(completedLevels13[LM.instance.currentLevel-1] == '0')
            {
                completedLevels13 = ChangeSymbolInTheString(completedLevels13, LM.instance.currentLevel-1, '1');
                PlayerPrefs.SetString("l13", completedLevels13);
                PlayerPrefs.SetInt("m13" + LM.instance.currentLevel.ToString(), moves);
                if(completedLevels13 == "11111")
                {
                    endText.text += "\nYou have completed all game levels!\nThank you for playing our game. We hope it was interesting.";
                    PlayerPrefs.SetInt("all", 1);
                }
            }
            else
            {
                if(moves < PlayerPrefs.GetInt("m13" + LM.instance.currentLevel.ToString()))
                {
                    PlayerPrefs.SetInt("m13" + LM.instance.currentLevel.ToString(), moves);
                }
            }
        }
        endPanel.SetActive(true);
        ClearLevel();
    }
    public void ClearLevel()
    {
        boxCounts = 0;
        moves = 0;
        movesText.text = "";
        hint = "";
        progress = "";
        watchedAd = false;
        foreach (GameObject go in finishs)
        {
            Destroy(go);
        }
        finishs.Clear();
        gameO.SetActive(false);
        miniMenu.SetActive(false);
        foreach (GameObject go in levelParts)
        {
            Destroy(go);
        }
        levelParts.Clear();
    }
    public void Play()
    {
        for(int i=0; i<5; i++)
        {
            easyTexts[i].text = "Level " + (i+1).ToString();
            normalTexts[i].text = "Level " + (i+1).ToString();
            hardTexts[i].text = "Level " + (i+1).ToString();
        }
    }
    public void RestartLevel()
    {
        ClearLevel();
        gameO.SetActive(true);
        miniMenu.SetActive(true);
        CreateLevel();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void HintPanel()
    {
        hintPanelWithAd.SetActive(false);
        hintPanel.SetActive(true);
        progressText.text = "Your moves:\n" + progress;
        hintText.text = "Try this to complete the level!\n" + hint;
    }
    public void WatchAd()
    {
        AdManager.instance.ShowHintVideo();
    }
    public void Hint()
    {
        miniMenu.SetActive(false);
        if(!watchedAd)
        {
            hintPanelWithAd.SetActive(true);
        }
        else
        {
            HintPanel();
        }
    }
}
