using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Finish : MonoBehaviour
{
    [HideInInspector]
    public bool switchOn = false;
    public GameObject finishActivePrefab;
    private GameObject finishActive;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Box"))
        {
            switchOn = true;
            GM.instance.boxCounts++;
            Invoke("CreateFinishActive", 0.2f);
            Invoke("CheckVictory", 0.5f);
        }
    }
    void OnTriggerExit(Collider col)
    {
        switchOn = false;
        if (GM.instance.game)
        {
            GM.instance.finishs.Remove(finishActive);
            Destroy(finishActive);           
        }
        if (col.gameObject.CompareTag("Box"))
        {
            GM.instance.boxCounts--;
        }
    }
    void CreateFinishActive()
    {
        finishActive = Instantiate(finishActivePrefab, transform.position, Quaternion.identity) as GameObject;
        GM.instance.finishs.Add(finishActive);
    }
    void CheckVictory()
    {
        if (GM.instance.boxCounts == LM.instance.BoxQuantity())
        {
            GM.instance.game = false;
            GM.instance.boxCounts = 0;
            foreach (GameObject f in GM.instance.finishs)
            {
                Destroy(f);
            }
            GM.instance.finishs.Clear();
            switchOn = false;            
            Invoke("ShowEndPanel", 0.8f);
        }
    }
    void ShowEndPanel()
    {
        GM.instance.ShowEndPanel();
    }
    public void DestroyFinish()
    {
        Destroy(finishActive);
    }
}
