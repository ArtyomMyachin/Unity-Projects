using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    private int clickForSpawn = 0;
    public float minX;
    public float minY;
    public GameObject sdf;
    public GameObject currentClickTextPrefab;
    public int howManyClicks;
    public UIProgressBar clickBar;
    void Start()
    {
        if (PlayerPrefs.HasKey("clickForSpawn"))
        {
            clickForSpawn = PlayerPrefs.GetInt("clickForSpawn");
            clickBar.value = (float)(clickForSpawn % howManyClicks) / howManyClicks;
        }
    }
    void Update()
    {
        PlayerPrefs.SetInt("clickForSpawn", clickForSpawn);
    }
    void OnMouseDown()
    {
        minX = Random.Range(0.02f, 0.71f);
        minY = Random.Range(0.25f, 0.685f);
        clickForSpawn++;
        clickBar.value = (float)(clickForSpawn % howManyClicks) / howManyClicks;
        if (clickForSpawn % howManyClicks == 0)
        {
            GM.instance.SpawnManySnowflakes();
            clickForSpawn = 0;
        }
        GM.instance.clickTimes.Add(Time.timeSinceLevelLoad);
        GM.instance.click += GM.instance.scorePerClick * GM.instance.TemporaryDoubler() * GM.instance.x10;
        GameObject a = Instantiate(currentClickTextPrefab, new Vector3(Random.Range(-200f, 200f), Random.Range(-300f, 300f), 0), Quaternion.Euler(0f, 0f, Random.Range(0f, 25f))) as GameObject;
        UILabel currentClickText = a.GetComponent<UILabel>();
        currentClickText.SetAnchor(sdf, minX, minY, minX + 0.27f, minY + 0.065f);
        currentClickText.text = (GM.instance.scorePerClick * GM.instance.TemporaryDoubler() * GM.instance.x10).ToString();
        StartCoroutine(DestroyText(currentClickText));
        GM.instance.CheckText();
    }
    IEnumerator DestroyText(UILabel o)
    {
        yield return new WaitForSeconds(1);
        Destroy(o.gameObject);

    }
}