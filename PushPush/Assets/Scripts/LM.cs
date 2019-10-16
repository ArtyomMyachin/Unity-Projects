using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LM : MonoBehaviour
{
    public class Difficulty
    {
        public List<int[,]> difficulty = new List<int[,]>();
    }
    public class World
    {
        public List<Difficulty> world = new List<Difficulty>();
    }    
    [HideInInspector]
    public int currentDifficulty;
    [HideInInspector]
    public int currentWorld;
    [HideInInspector]
    public int currentLevel;    
    private int[,] levels;
    public string unlocked="100";
    string hint = "";
    public GameObject normalLocked;
    public GameObject normalUnlocked;
    public GameObject hardLocked;
    public GameObject hardUnlocked;
    public static LM instance = null;    
    void Awake()
    {
        instance = this;
        if(PlayerPrefs.HasKey("dw1"))
            unlocked = PlayerPrefs.GetString("dw1");        
    }   
    public int ReturnSize()
    {
        return levels.Length;
    }
    public int[,] ReturnLevel()
    {
        return levels;
    }
    public int BoxQuantity()
    {
        int bq = 0;
        foreach(int i in levels)
        {
            if(i == 3 || i == 6)
            {
                bq++;
            }
        }
        return bq;
    }
    public string GetHint()
    {
        int i = 2;
        string s1 = "1";
        foreach (char c in hint)
        {
            if(c == ' ')
            {
                s1 += c + i.ToString();
                i++;
            }
            else
            {
                s1 += c;
            }
        }
        return s1;
    }
    public void NextLevel()
    {
        currentLevel++;
        if(currentLevel > 5)
        {
            currentLevel = 1;
            currentDifficulty++;
        }
        if(currentDifficulty > 3)
        {
            currentDifficulty = 1;
            currentWorld++;
        }
        Invoke("Level"+currentWorld.ToString()+currentDifficulty.ToString()+currentLevel.ToString(),0.1f);
        //Debug.Log("Level"+currentWorld.ToString()+currentDifficulty.ToString()+currentLevel.ToString());
    }
    public void Load1()
    {
        if(PlayerPrefs.HasKey("dw1"))
            unlocked = PlayerPrefs.GetString("dw1");
        if(unlocked[1] == '1')
        {
            normalUnlocked.SetActive(true);
            normalLocked.SetActive(false);
        }
        else
        {
            normalUnlocked.SetActive(false);
            normalLocked.SetActive(true);
        }
        if(unlocked[2] == '1')
        {
            hardUnlocked.SetActive(true);
            hardLocked.SetActive(false);
        }
        else
        {
            hardUnlocked.SetActive(false);
            hardLocked.SetActive(true);
        }
    }
    public void Level111()
    {
        currentWorld = 1;
        currentDifficulty = 1;
        currentLevel = 1;
        levels = new int[,] {       { 0,0,0,0,1,1,1,0,0},
                                    { 0,0,0,0,1,4,1,0,0},
                                    { 1,1,1,1,1,3,1,0,0},
                                    { 1,4,2,2,3,5,1,0,0},
                                    { 1,1,1,1,2,2,1,1,1},
                                    { 0,0,0,1,1,3,3,4,1},
                                    { 0,0,0,0,1,2,1,1,1},
                                    { 0,0,0,0,1,4,1,0,0},
                                    { 0,0,0,0,1,1,1,0,0}
        };
        hint = "← ← ← → → → ↓ ↑ ↑ ↑ ↑ ↓ →";
        GM.instance.CreateLevel();
    }
    public void Level112()
    {
        currentWorld = 1;
        currentDifficulty = 1;
        currentLevel = 2;
        levels = new int[,] {       {0,0,0,0,1,1,1,1,0},
                                    {0,0,0,1,1,2,2,1,1},
                                    {0,0,0,1,2,2,2,2,1},
                                    {0,1,1,1,4,3,3,2,1},
                                    {0,1,2,2,4,1,2,1,1},
                                    {0,1,2,3,4,3,2,1,0},
                                    {0,1,2,2,4,5,2,1,0},
                                    {0,1,1,1,1,1,1,1,0},
                                    {0,0,0,0,0,0,0,0,0}
        };
        hint = "→ ↓ ← → ↓ ↓ ← ↓ ← ↑ → → → ↓ ← ↓ ← ↑ → ↑ ← → ↑ ↑ ↑ ← ← ← ← ↓ ↓ → ↑ ← ↑ →";
        GM.instance.CreateLevel();
    }
    public void Level113()
    {
        currentWorld = 1;
        currentDifficulty = 1;
        currentLevel = 3;
        levels = new int[,] {       { 0,0,0,0,0,0,0,0,0},
                                    { 0,0,0,0,1,1,1,0,0},
                                    { 0,0,1,1,1,4,1,0,0},
                                    { 0,0,1,2,3,4,1,0,0},
                                    { 0,0,1,2,3,4,1,0,0},
                                    { 0,0,1,2,3,4,1,0,0},
                                    { 0,0,1,2,3,1,1,0,0},
                                    { 0,0,1,2,5,1,0,0,0},
                                    { 0,0,1,1,1,1,0,0,0}
        };
        hint = "← ↓ ↓ → ← ↓ ↓ → ← ↑ ↑ → ↓ → ↓ ↑ ← ← ↓ → ← ↑ ↑ ↑ ↑ → ↓ ↓ ← ↓ →";
        GM.instance.CreateLevel();
    }
    public void Level114()
    {
        currentWorld = 1;
        currentDifficulty = 1;
        currentLevel = 4;
        Debug.Log("In Level112");
        levels = new int[,] {       { 0,0,0,0,0,0,0,0,0},
                                    { 0,0,1,1,1,1,0,0,0},
                                    { 0,0,1,2,2,1,1,1,1},
                                    { 0,0,1,2,2,3,2,2,1},
                                    { 0,0,1,6,2,5,2,2,1},
                                    { 0,1,1,2,2,1,1,1,1},
                                    { 0,1,2,2,4,1,0,0,0},
                                    { 0,1,1,1,1,1,0,0,0},
                                    { 0,0,0,0,0,0,0,0,0}
        };
        hint = "← ↓ ← ↑ → → → ↓ ← ↑ ← ← ↓ ↓ → ↑ ← ↑ → ↑ ↑ ← ↓ → ↓ ↓ → → ↑ ← ↓ ← ↑ ↑";
        GM.instance.CreateLevel();
    }
    public void Level115()
    {
        currentWorld = 1;
        currentDifficulty = 1;
        currentLevel = 5;
        levels = new int[,] {       {0,0,0,0,0,0,0,0,0,0,0},
                                    {1,1,1,1,1,1,1,1,1,0,0},
                                    {1,2,2,2,1,5,2,2,1,1,1},
                                    {1,2,3,2,3,2,1,2,3,2,1},
                                    {1,2,2,2,1,2,1,2,2,2,1},
                                    {1,4,1,2,1,2,1,2,1,2,1},
                                    {1,4,1,2,1,2,1,2,1,2,1},
                                    {1,4,1,2,3,2,2,2,3,2,1},
                                    {1,4,1,2,1,1,2,1,1,1,1},
                                    {1,4,1,2,2,2,2,1,0,0,0},
                                    {1,1,1,1,1,1,1,1,0,0,0}
        };
        hint = "↑ ↑ ↑ ↑ ↑ → ↑ ↑ ← ← ← ↓ ↓ ↓ ↓ ↓ ↓ ← ↓ ← ↑ ↑ ↑ ↑ ↑ ↑ ↓ ↓ ↓ ↓ → → ↑ ↑ ↑ ↑ ↑ → → → ↓ ↓ ← ↓ ↓ ↓ ↓ ← ← ← ↓ ← ↑ ↑ ↑ ↑ ↑ ↓ ↓ ↓ → → ↓ → → ↑ ↑ ↑ ↑ ← → → ↑ ↑ ← ← ← ↓ ↓ ↓ ↓ ↓ ↑ ↑ ↑ → → ↓ ↓ ↓ ↓ ← ← ← ↓ ← ↑ ↑ ↑ ↑ ↓ ↓ ↓ → → → → ↓ → → ↑ ↑ → → ↑ ↑ ↑ ← ← ← ← ← → → ↑ ↑ ← ← ← ↓ ↓ ↓ ↓ ↓ ↑ ↑ ↑ → → ↓ ↓ ↓ ↓ ← ← ← ↓ ← ↑ ↑ ↑ ↓ → ↓ → → → ↓ → → ↑ ↑ → → ↓ ← ↑ ← ↑ ↑ ↑ ← ← ↓ ↓ ↓ ↓ ↓ → → ↑ ↑ ↑ ↑ ↓ ↓ → → ↑ ↑ ↑ ← ← ← ← ← → → ↑ ↑ ← ← ← ↓ ↓ ↓ ↓ ↓ ↑ ↑ ↑ → → ↓ ↓ ↓ ↓ ← ← ← ↓ ← ↑ ↑";
        GM.instance.CreateLevel();
    }
    public void Level121()
    {
        currentWorld = 1;
        currentDifficulty = 2;
        currentLevel = 1;
        levels = new int[,] {       {1,1,1,1,1,0,0,0,0,0},
                                    {1,5,2,2,1,1,1,1,0,0},
                                    {1,2,3,2,3,2,2,1,1,1},
                                    {1,2,2,3,2,2,3,2,4,1},
                                    {1,1,1,1,1,2,2,4,4,1},
                                    {0,1,2,4,1,1,3,1,1,1},
                                    {0,1,4,4,2,1,2,2,1,0},
                                    {1,1,1,2,2,3,2,2,1,0},
                                    {0,1,2,2,2,1,2,2,1,0},
                                    {0,1,1,1,1,1,1,1,1,0}
        };
        hint = "→ → ↑ → ↑ → → → ← ↓ ← ↑ → ↑ ↑ ↑ → ↑ ↑ ← ↓ ← ← ↑ ← ↓ ↓ ↑ → → → ↓ ↓ ↓ ← ↓ ↓ → ↑ ← ↑ → → ← ↓ ← ← ← ↓ ↓ ← ← ↑ ↑ → → → → ↓ → ↑ ↑ ↑ ↑ → ↑ ← ← ← ↑ ← ↓ → ↓ ← → ↑ → → ↓ ↓ ↓ ↓ ← ← ← ← ← ↓ ↓ → ↑ ← ↑ → → → → ↓ → ↑ ↑ ↑ ↑ → ↑ ← ← ← ↑ ← ↓ ↑ → ↓ → → ↓ ↓ ↓ ↓ ↓ ← ← ↑ ← ← ↓ ↓ → ↑ ← ↑ → → → ↓ → ↑ ← ↑ →";
       GM.instance.CreateLevel();
    }
    public void Level122()
    {
        currentWorld = 1;
        currentDifficulty = 2;
        currentLevel = 2;
        levels = new int[,] {       { 0,0,0,0,0,0,0,0,0},
                                    { 1,1,1,1,1,0,0,0,0},
                                    { 1,2,2,2,1,1,1,0,0},
                                    { 1,2,1,2,6,2,1,1,0},
                                    { 1,2,2,3,4,2,2,1,0},
                                    { 1,1,1,3,4,5,2,1,0},
                                    { 0,0,1,2,2,2,1,1,0},
                                    { 0,0,1,1,1,1,1,0,0},
                                    { 0,0,0,0,0,0,0,0,0}
        };
        hint = "↓ ← ← ↓ ↓ ← ← ↑ ↑ → → → ↑ → → ↓ ← ↓ ← ↑ ← ← ← ↓ ↓ → → ↑ ↓ ← ← ↑ ↑ → → ↓ → → ↑ ↑ ↑ ← ← ↓ → ↓ → → ↑ ← ↑ ↓ ↓ ← ← ↓ ↓ ← ← ↑ ↑ → →";
        GM.instance.CreateLevel();
    }
    public void Level123()
    {
        currentWorld = 1;
        currentDifficulty = 2;
        currentLevel = 3;
        levels = new int[,] {       {0,0,0,0,0,0,0,0,0},
                                    {0,0,1,1,1,1,1,0,0},
                                    {1,1,1,2,5,2,1,1,1},
                                    {1,2,3,2,1,2,3,2,1},
                                    {1,2,1,4,3,4,1,2,1},
                                    {1,2,4,2,3,2,4,2,1},
                                    {1,1,1,2,2,2,1,1,1},
                                    {0,0,1,1,1,1,1,0,0},
                                    {0,0,0,0,0,0,0,0,0}
        };
        hint = "→ ↑ ↑ ↑ → → ↓ ↓ ← → ↑ ↑ ← ← ↑ ← ← ↓ ↓ ↓ ↓ → → ↑ ↓ ← ← ↑ ↑ ↑ ← ← ↓ ↓ → ← ↑ ↑ → → ↑ → → ↓ ← ← → → → → ↓ ↓ ← ← ↑ ↓ → → ↑ ↑ ← ← ↑ ← ← ↓ ↓ → ← ↑ ↑ → → ↓ → → ↓ ↓ ← ← ↓ ← ← ↑ ↓ → → ↑ → → ↑ ↑ ← ← ↑ ← ← ↓ → →";
        GM.instance.CreateLevel();
    }
    public void Level124()
    {
        currentWorld = 1;
        currentDifficulty = 2;
        currentLevel = 4;
        levels = new int[,] {       {0,0,0,0,0,0,0,0,0},
                                    {0,1,1,1,1,1,1,1,0},
                                    {0,1,2,2,6,2,2,1,0},
                                    {0,1,2,1,2,1,4,1,0},
                                    {0,1,2,3,5,3,2,1,0},
                                    {0,1,2,1,2,1,2,1,0},
                                    {0,1,2,2,2,4,2,1,0},
                                    {0,1,1,1,1,1,1,1,0},
                                    {0,0,0,0,0,0,0,0,0}
        };
        hint = "↑ ↑ ← ← ↓ ↓ → ← ↓ ↓ → → ↑ ↑ ← ← ↑ ↑ → → → → ↓ ↓ ↓ ↓ ← → ↑ ↑ ↑ ↑ ← ← ← ← ↓ ↓ → → → ← ← ← ↑ ↑ → → → → ↓ ↓ ← ← ↑ ↓ ← ← ↑ ↑ → →";
        GM.instance.CreateLevel();
    }
    public void Level125()
    {
        currentWorld = 1;
        currentDifficulty = 2;
        currentLevel = 5;
        levels = new int[,] {       {0,0,0,0,0,0,0,0,0,1,1,1,1},
                                    {0,1,1,1,1,1,1,1,1,1,2,2,1},
                                    {0,1,2,2,2,2,2,2,2,2,2,2,1},
                                    {0,1,2,2,1,2,1,2,1,2,2,2,1},
                                    {0,1,2,3,3,2,3,2,3,2,3,2,1},
                                    {1,1,2,2,1,1,1,1,2,3,3,2,1},
                                    {1,2,2,1,1,4,4,3,5,3,2,2,1},
                                    {1,2,2,2,3,4,4,1,3,2,3,2,1},
                                    {1,1,1,1,1,4,4,1,2,2,2,2,1},
                                    {0,0,0,0,1,4,4,1,1,1,1,1,1},
                                    {0,0,0,0,1,4,4,1,0,0,0,0,0},
                                    {0,0,0,0,1,4,4,1,0,0,0,0,0},
                                    {0,0,0,0,1,1,1,1,0,0,0,0,0}
        };
        hint = "→ ↓ ↓ ↑ ↑ ↑ ↑ → → ↓ ↓ ↓ ↓ ↓ ↓ ← ← ← ← ← ← ← ← ← ↑ ↑ ↑ ↑ ↑ → → → ↓ → ↑ ↑ ↑ ↑ ↓ ↓ ↓ ← ← ← ← ↓ ↓ → ↓ ← ↓ ↓ → → → ↑ ↑ ← ← → → ↓ ↓ ← ← ← ↑ ↑ ↑ ↑ ← ↑ → → → → ↓ → ↑ ↑ ↑ ↓ ↓ ← ← ← ← ↓ ↓ ↓ ↓ ↓ → ↑ ↓ → → ↑ ↑ ← ← ↓ ← ↑ ↑ ↑ ← ↑ → → → → ↓ → ↑ ↑ ↓ ↓ ← ↑ ← ← ← ↓ ↓ ↓ ↓ ↓ → → → → → ↑ ↑ ← ← ← ← ↓ ← ↑ ↑ ↑ ← ↑ → → → → ↓ → ↑ ↓ → → ↓ → ← → ↓ ← ← ← ← ← ← ↓ ← ↑ ↑ ↑ ← ↑ → → → → ↓ → → → ↓ ↓ ← ↓ ↓ → → → → ↑ ↑ ← ← ← ← ← ← ← ← ↓ ← ↑ ↑ ↑ ← ↑ → → → ← ← ↓ ↓ ↓ → → → → → → ↑ ↑ ← ← ← ↑ ↑ ↑ ↑ ↓ ↓ ↓ ↓ → → → ↓ ↓ → → ↓ ↓ ← ↑ → ← → ↑ ← ← ← ← ← ← ← ↓ ← ↑ ↑ ↑ ← ↑ → → → ← ← ↓ ↓ ↓ → → → → → → ↑ ↑ ← ← ← ↑ ↑ ↑ ↓ ↓ ↓ → → → ↓ → ↓ → → ↑ ↑ ↑ ↑ ← ← ↓ ↓ ↓ ↑ ↑ ↑ → → ↓ ↓ ↓ ↓ ← ← ← ← ← ← ← ← ↓ ← ↑ ↑ ↑ ← ↑ → → → ← ← ↓ ↓ ↓ → → → → → → ↑ ↑ ← ← ← ↑ ↑ ↓ ↓ → → → → ↑ ↑ ← ↓ ↓ ↓ → ↓ ← ← ← ← ← ← ↓ ← ↑ ↑ ↑ ← ↑ → → → ← ← ↓ ↓ ↓ → → → → → → ↑ ↑ ← ← ← ↑ ↓ → → → ↑ ↑ → → → ↓ ← ← ↑ ← ↓ → ↓ ← ← ← → → ↑ → → → ↓ ← ← ← ← → → → → ↓ ← ← ↑ ← ↓ → ↓ ← ← ← ← ← ← ↓ ↑ ↓ ← ↑ ↑ ↑ ← ↑ → → →";
        GM.instance.CreateLevel();
    }
    public void Level131()
    {
        currentWorld = 1;
        currentDifficulty = 3;
        currentLevel = 1;
        levels = new int[,] {       {0,0,0,0,0,0,0,0,0,0},
                                    {1,1,1,1,0,0,0,0,0,0},
                                    {1,2,2,1,1,1,1,1,1,0},
                                    {1,2,3,2,3,2,3,2,1,0},
                                    {1,2,2,2,4,4,2,2,1,0},
                                    {1,1,1,1,4,4,1,1,1,1},
                                    {1,2,2,2,4,4,2,2,2,1},
                                    {1,2,3,2,3,2,3,5,2,1},
                                    {1,1,1,1,1,1,1,2,2,1},
                                    {0,0,0,0,0,0,1,1,1,1}
        };
        hint = "↓ ← ← ↑ → ↓ ← ← ← ↑ → → ↓ → → → ↑ ↑ ← ↓ → ↓ ← ← ← ↑ → ← ← ← ↓ ← ← ↑ → ↓ → → ↑ → → ↓ ← ↓ ↓ ↓ ← ↑ ← ← ← ↓ ↓ → ↑ ← ↑ → → → ↑ → ↑ ↑ ← ← → → ↓ ↓ ← ↓ ↓ → ↑ ↓ ← ← ↑ → → → → ↓ ← ← ← ↑ ↑ ↑ ← ↑ → → ↓ ↓ ← ↓ ↓ → → ↑ ← ↓ ← ↑ ↑ ↓ ← ← ← ↓ ↓ → ↑ ← ↑ → → → ↑ → ↓ ← ↓ → ← ← ↑ ← ← ↓ ↓ → ↑ ← ↑ → → ↓ → ↑ → → → ↓ ← ← ← ← ↑ ← ← ↓ ↓ → ↑ ← ↑ → → ↓ → → ↑ ↑ ↑ ↑ ← ← ↓ → ↑ → ↓ ↓ ↑ → → → ↑ ↑ ← ↓ → ↓ ← ← ← ↑ ← ← ↓ → ↑ → ↓ ↑ → ↓ → → ↑ ↑ ← ↓ → ↓ ← ← ← ↑ ← ← ↓ ← ← ↑ → → → → → ↓ → → ↑ ↑ ← ↓ → ↓ ← ←";
        GM.instance.CreateLevel();
    }
    public void Level132()
    {
        currentWorld = 1;
        currentDifficulty = 3;
        currentLevel = 2;
        levels = new int[,] {       {0,1,1,1,1,1,0,0,0},
                                    {0,1,2,2,4,1,0,0,0},
                                    {0,1,2,1,4,1,1,0,0},
                                    {0,1,4,3,2,2,1,0,0},
                                    {0,1,2,3,2,2,1,0,0},
                                    {0,1,3,2,1,1,1,0,0},
                                    {0,1,2,5,1,0,0,0,0},
                                    {0,1,2,2,1,0,0,0,0},
                                    {0,1,1,1,1,0,0,0,0}
        };
        hint = "← ↓ ↓ ↓ → ↑ → → ↓ ← ↓ ↓ ← ← ↑ ↑ → ← ↓ ↓ → → ↑ ↑ ← ↑ ↑ ← ↑ ↑ → ↓ ↓ ← ↓ ↓ → → ↓ ↓ ← ← ↑ ↑ ↑ ↑ → ↓ ← ↓ ↓ ↓ → → ↑ ↑ → ↑ ← ↓ ↓ ↓ ← ← ↑ ↑ → ← ↑ ↑ → ↓ → ↓ ↓ ↑ ↑ ← ← ↓ → ↑ → ↓ ← ↑ ↑ ↑ ↑ ← ↓ ↓ ↓";
        GM.instance.CreateLevel();
    }
    public void Level133()
    {
        currentWorld = 1;
        currentDifficulty = 3;
        currentLevel = 3;
        levels = new int[,] {       {0,1,1,1,1,0,0,0,0},
                                    {0,1,2,2,1,0,0,0,0},
                                    {1,1,2,5,1,1,1,0,0},
                                    {1,2,4,3,3,2,1,0,0},
                                    {1,2,2,4,2,2,1,0,0},
                                    {1,2,4,1,3,1,1,0,0},
                                    {1,1,2,2,2,1,0,0,0},
                                    {0,1,1,1,1,1,0,0,0},
                                    {0,0,0,0,0,0,0,0,0}
        };
        hint = "← ↑ ↑ → ↓ ↑ → → ↓ ← ← ↑ ← ↑ ↑ → → ↓ ↑ ← ← ↓ ↓ → ↓ → → ↑ ← ← → ↑ ↑ ← ← ↓ ← ↓ ↓ → → ← ↓ ↓ → ↑ ↑ ← ← ↑ ↑ → ↓ ↓ ↑ ↑ ↑ → → ↓ ↓ → ↓ ← ← → ↑ ↑ ↑ ← ← ↓ ↓ → ↓ → ↑ ← ← ← ↓ → → ↓ ↓ ← ↑ ↑ → ↑ → → ↓ ← ↑ ← ↓ ← ↓ ↓ → ↑ ↑ ← ← ↑ ↑ → ↓ ↓ → → ↑ ← ↓ ← ← ↑ ↑ → ↑ → → ↓ ↑ ← ← ↓ ← ↓ ↓ → → → → ↑ ← ↓ ← ← ↑ ↓ → ↓ ↓ ← ↑";
        GM.instance.CreateLevel();
    }
    public void Level134()
    {
        currentWorld = 1;
        currentDifficulty = 3;
        currentLevel = 4;
        levels = new int[,] {       {0,0,0,0,1,1,1,1,1,0,0},
                                    {0,0,1,1,1,4,4,4,1,0,0},
                                    {0,0,1,2,2,2,4,2,1,0,0},
                                    {0,0,1,4,3,2,2,1,1,0,0},
                                    {0,0,1,2,3,2,1,1,0,0,0},
                                    {0,0,1,1,3,2,1,0,0,0,0},
                                    {0,0,0,1,2,2,1,0,0,0,0},
                                    {0,0,0,1,3,2,1,0,0,0,0},
                                    {0,0,0,1,2,3,1,0,0,0,0},
                                    {0,0,0,1,5,2,1,0,0,0,0},
                                    {0,0,0,1,1,1,1,0,0,0,0}
        };
        hint = " → ↓ ↓ ↓ ← ↑ → ↓ ↓ ↓ ↓ → ↓ ↓ ← ↑ ← ← ↑ ↑ → ↓ ← ↓ → ↑ ↑ ↑ → ↑ ↑ ← ↓ ↓ ↑ ↑ → ↑ ↑ ← ↓ ↓ → ↓ ↓ ← ↓ ← ↓ ↓ → ↑ ↓ → ↓ → → ↑ ← ↑ ← ↑ ↑ ↑ ↑ ↓ ↓ ↓ ↓ → ↓ ↓ ← ↑ ← ← ↑ ↑ → ↓ ← ↓ → ↑ ↑ ↑ → ↑ ↑ ← ↓ ↓ ↓ ← ↓ ↓ → ↑ ↓ → ↓ → → ↑ ← ↑ ← ↑ ↑ ↓ ↓ → ↓ ↓ ← ↑ ← ← ↑ ↑ → ↓ ← ↓ → → ↓ → → ↑ ← ↑ ← ← ↓ → ↑ → ↓ ← ↓ → ↑ ↑ ← ← ↑ ↑ → ↓ ↓ ← ↓ → ↑ → ↓ ↑ ← ↑ ↑ ← ↑ ↑ → ↓ ↓ ↓ ↓ ↓ ↑ ↑ ↑ ↑ ↑ ← ↑ ↑ → ↓ ↓ ↓ ↓ ↓ ↓ ← ↓ →";
        GM.instance.CreateLevel();
    }
    public void Level135()
    {
        currentWorld = 1;
        currentDifficulty = 3;
        currentLevel = 5;
        levels = new int[,] {       {0,0,0,0,0,0,1,1,1,1,0},
                                    {1,1,1,1,1,1,1,2,5,1,0},
                                    {1,2,2,2,2,2,3,2,2,1,0},
                                    {1,2,2,2,3,1,1,2,3,1,0},
                                    {1,1,3,1,4,4,4,1,2,1,0},
                                    {0,1,2,3,4,4,4,2,2,1,0},
                                    {0,1,2,1,4,2,4,1,2,1,1},
                                    {0,1,2,2,2,1,2,1,3,2,1},
                                    {0,1,3,2,2,3,2,2,2,2,1},
                                    {0,1,2,2,1,1,1,1,1,1,1},
                                    {0,1,1,1,1,0,0,0,0,0,0}
        };
        hint = " ↑ ← ← ← ← ↑ ↑ → ↑ ↑ ← ↓ ↑ ↑ ← ← ↓ ↓ → → → ↑ → ↓ → → ↓ ↓ ← ↓ ← ← ← ↑ ↑ → ↑ ↑ ← ↑ ← ← ↓ ↓ → → → ↑ ← ↑ ↑ ← ↑ ← ↓ ↓ → → ↓ → → ↑ ↑ ← ← ↓ ← ← ↑ ↑ → ↓ → ↓ ↓ ↓ ← ← ↑ ↑ → ↑ → ↓ ↓ ↑ ← ← ↓ ↓ → → ↓ → ↑ ← ↑ → ← ↑ ↑ ← ↑ ← ↓ ↓ → → ↓ ↓ ↓ ↓ ↓ → → → ↑ → ↑ ↑ ↑ ↑ → ↑ ← ← ← ← ← ↓ ← ← ↑ ↑ → ↓ ← ↓ → ↑ → ↓ ↓ ↓ ↑ ↑ ↑ → → → → ↓ ↓ ↓ ↓ ↓ ← ↓ ↓ → ↑ ↑ ↑ ↑ ↑ ↑ → ↑ ← ← ← ← ← ↓ ← ← ↑ ↑ → ↓ → ↓ ↓ ↓ ← ← ↑ ↑ → ↑ → ↓ ↓ ↑ ← ← ↓ ↓ → → ↑ → ↓ ↑ ← ↑ ↑ ← ↑ ← ↓ ↓ ↑ → → → → → → ↓ ↓ ↓ ↓ ↓ ↓ ← ← ← ← ↑ ← ← ↓ → → → → → ↑ → ↑ ↑ ↑ ↑ ↑ ← ← ← ← ↓ ↓ ↓ ← ← ↓ ↓ → → ↓ → → → ↓ → ↑ ↑ ↑ ↑ ↑ ↑ → ↑ ← ← ← ← ← ↓ ← ← ↑ ↑ → ↓ ← ↓ → ↑ → ↓ ↓ ↑ ↑ → → → → ↓ ↓ ↓ ↓ ↓ ↓ ← ← ← ← ↑ ← ← ↑ ↑ → → ← ← ↓ ↓ ← ↓ → → → → → → ↓ → ↑ ↑ ↑ ↑ ↑ ↑ → ↑ ← ← ← ← ← ↓ ← ← ↑ ↑ → ↓ ← ↓ → ↑ → ↓ ↓ ↑ ← ← ↓ ↓ ↓ ↓ ← ↓ → → → → → → ↓ → ↑ ↑ ↑ ↑ ↑ ↑ → ↑ ← ← ← ← ← ↓ ← ← ↑ ↑ → ↓ ← ↓ → ↑ → ↓";
        GM.instance.CreateLevel();
    }
}

