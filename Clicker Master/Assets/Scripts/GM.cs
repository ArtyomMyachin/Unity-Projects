using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GM : MonoBehaviour
{
    public bool shopBool = false;
    public EventSystem es;
    public float adTimeForFirstEntry = 10f;
    public float adTimeForShop = 120f;
    public float maxTimeSpawnPref;
    public float minTimeSpawnPref;
    public float time = 0;
    public float timeBeforeX10 = 300;
    public float snowFlakeTime;
    public GameObject backGroundShopPanel;
    public GameObject backGroundShopPanelAll;
    public GameObject bigSnowFlakes;
    public GameObject shopPanel;
    public int averageTimeClick;
    public int x10;
    public List<Artifact> artifactList;
    public List<float> clickTimes;
    public long click = 0;
    public long cps = 0;
    public long rcps = 0;
    public long scorePerClick = 1;
    public Sprite[] snowFlakesTextures;
    public UILabel bonusText;
    public UILabel cpsText;
    public UILabel scoreText;
    public UILabel timeText;
    public UILabel[] levelText;
    public UILabel[] priceText; public static GM instance = null;
    public UIProgressBar timeBar;
    void Start()
    {
        snowFlakeTime = Random.Range(minTimeSpawnPref, maxTimeSpawnPref);
        instance = this;
        artifactList = new List<Artifact>();
        scoreText.text = "0 Score!";
        clickTimes = new List<float>();
        Artifact art1 = new Artifact("Artifact1", 0, 5, 200);
        Artifact art2 = new Artifact("Artifact2", 0, 15, 2500);
        Artifact art3 = new Artifact("Artifact3", 0, 30, 10000);
        Artifact art4 = new Artifact("Artifact4", 0, 50, 50000);
        Artifact art5 = new Artifact("Artifact5", 0, 75, 100000);
        Artifact art6 = new Artifact("Artifact6", 0, 110, 200000);
        Artifact art7 = new Artifact("Artifact7", 0, 165, 500000);
        Artifact art8 = new Artifact("Artifact8", 0, 225, 1000000);
        Artifact art9 = new Artifact("Artifact9", 0, 300, 5000000);
        Artifact art10 = new Artifact("Artifact10", 0, 1500, 30000000);
        Artifact art11 = new Artifact("Artifact11", 0, 3000, 70000000);
        Artifact art12 = new Artifact("Artifact12", 0, 8000, 200000000);
        Artifact art13 = new Artifact("Artifact13", 0, 15000, 400000000);
        Artifact art14 = new Artifact("Artifact14", 0, 20000, 600000000);
        Artifact art15 = new Artifact("Artifact15", 0, 30000, 1000000000);
        Artifact art16 = new Artifact("Artifact16", 0, 80000, 3000000000);
        Artifact art17 = new Artifact("Artifact17", 0, 120000, 5000000000);
        Artifact art18 = new Artifact("Artifact18", 0, 200000, 10000000000);
        Artifact art19 = new Artifact("Artifact19", 0, 350000, 20000000000);
        Artifact art20 = new Artifact("Artifact20", 0, 600000, 50000000000);
        Artifact art21 = new Artifact("Artifact21", 0, 1000000, 100000000000);
        Artifact art22 = new Artifact("Artifact22", 0, 1500000, 200000000000);
        Artifact art23 = new Artifact("Artifact23", 0, 2500000, 400000000000);
        Artifact art24 = new Artifact("Artifact24", 0, 4000000, 800000000000);
        Artifact art25 = new Artifact("Artifact25", 0, 7000000, 1600000000000);
        Artifact art26 = new Artifact("Artifact26", 0, 10000000, 2500000000000);
        Artifact art27 = new Artifact("Artifact27", 0, 15000000, 4000000000000);
        Artifact art28 = new Artifact("Artifact28", 0, 25000000, 8000000000000);
        Artifact art29 = new Artifact("Artifact29", 0, 40000000, 15000000000000);
        Artifact art30 = new Artifact("Artifact30", 0, 100000000, 1000000000000000);
        Artifact art31 = new Artifact("Artifact31", 0, 0, 5000);

        artifactList.Add(art1);
        artifactList.Add(art2);
        artifactList.Add(art3);
        artifactList.Add(art4);
        artifactList.Add(art5);
        artifactList.Add(art6);
        artifactList.Add(art7);
        artifactList.Add(art8);
        artifactList.Add(art9);
        artifactList.Add(art10);
        artifactList.Add(art11);
        artifactList.Add(art12);
        artifactList.Add(art13);
        artifactList.Add(art14);
        artifactList.Add(art15);
        artifactList.Add(art16);
        artifactList.Add(art17);
        artifactList.Add(art18);
        artifactList.Add(art19);
        artifactList.Add(art20);
        artifactList.Add(art21);
        artifactList.Add(art22);
        artifactList.Add(art23);
        artifactList.Add(art24);
        artifactList.Add(art25);
        artifactList.Add(art26);
        artifactList.Add(art27);
        artifactList.Add(art28);
        artifactList.Add(art29);
        artifactList.Add(art30);
        artifactList.Add(art31);
        if (PlayerPrefs.HasKey("Click"))
        {
            click = long.Parse(PlayerPrefs.GetString("Click"));
        }
        if (PlayerPrefs.HasKey("Levels"))
        {
            string s = "";
            string levels = PlayerPrefs.GetString("Levels");
            int i = 0;
            foreach (Artifact a in artifactList)
            {
                while (levels[i] != ' ')
                {
                    s += levels[i];
                    i++;
                }
                a.Level = int.Parse(s);
                i++;
                s = "";
            }
        }
        if (PlayerPrefs.HasKey("Price"))
        {
            string s = "";
            string price = PlayerPrefs.GetString("Price");
            int i = 0;
            foreach (Artifact a in artifactList)
            {
                while (price[i] != ' ')
                {
                    s += price[i];
                    i++;
                }
                a.Price = long.Parse(s);
                i++;
                s = "";
            }
        }
        if (PlayerPrefs.HasKey("ScorePerClick"))
        {

            scorePerClick = long.Parse(PlayerPrefs.GetString("ScorePerClick"));

        }
        scoreText.text = click.ToString();
        for (int i = 0; i < priceText.Length; i++)
        {
            priceText[i].text = artifactList[i].Price.ToString();
            levelText[i].text = artifactList[i].Level.ToString();
        }        
    }
    void Update()
    {
        if (Time.timeSinceLevelLoad >= snowFlakeTime)
        {
            SnowFlakesCreating();
        }
        timeBeforeX10 = Time.timeSinceLevelLoad % 320 <= 300 ? Time.timeSinceLevelLoad % 320 : 4800 - 15 * (Time.timeSinceLevelLoad % 320);
        timeBar.value = timeBeforeX10 / 300;
        x10 = Time.timeSinceLevelLoad % 320 <= 300 ? 1 : 10;
        if (Time.timeSinceLevelLoad - time >= 0.2f)
        {
            RobotAction();
            time = Time.timeSinceLevelLoad;
        }
        cps = ClicksPerNSeconds(averageTimeClick) * TemporaryDoubler() * scorePerClick * x10 + rcps;
        cpsText.text = cps + " Per second";
        timeText.text = Mathf.FloorToInt(timeBeforeX10).ToString();
        if (x10 != 1 || TemporaryDoubler() != 1)
        {
            bonusText.text = "X " + (x10 * TemporaryDoubler()).ToString();
            bonusText.gameObject.SetActive(true);
        }
        else
        {
            bonusText.gameObject.SetActive(false);
        }
        PlayerPrefs.SetString("Click", click.ToString());
        PlayerPrefs.SetString("Levels", LevelsToString());
        PlayerPrefs.SetString("Price", PriceToString());
        PlayerPrefs.SetString("ScorePerClick", scorePerClick.ToString());
    }
    /*void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Click", click.ToString());
        PlayerPrefs.SetString("Levels", LevelsToString());
        PlayerPrefs.SetString("Price", PriceToString());
        PlayerPrefs.SetString("ScorePerClick", scorePerClick.ToString());
    }*/
    long ClicksPerNSeconds(int n)
    {
        int count = 0, num = 0;
        while (num < clickTimes.Count)
        {
            if (Time.timeSinceLevelLoad - clickTimes[num] > n)
            {
                clickTimes.RemoveAt(num);
            }
            else
            {
                count++;
                num++;
            }
        }
        return count;
    }
    long LongPow(int a, int b)
    {
        long c = 1;
        for (int i = 0; i < b; i++)
        {
            c *= a;
        }
        return c;
    }
    string LevelsToString()
    {
        string s = "";
        foreach (Artifact a in artifactList)
        {
            s += a.Level.ToString() + " ";
        }
        return s;
    }
    string PriceToString()
    {
        string s = "";
        foreach (Artifact a in artifactList)
        {
            s += a.Price.ToString() + " ";
        }
        return s;
    }
    void RobotAction()
    {
        rcps = 0;
        foreach (Artifact a in artifactList)
        {
            rcps += a.Level * a.Damage;
            click += a.Level * a.Damage / 5;
        }
        CheckText();
    }
    public Artifact GetByTitle(string title)
    {
        foreach (Artifact a in artifactList)
        {
            if (a.Title == title)
            {
                return a;
            }
        }
        return null;
    }
    public void BuyArtifact(GameObject o)
    {
        //int price1 = 10;
        //if (click >= GetByTitle(es.currentSelectedGameObject.transform.name).Price)
        if (click >= GetByTitle(o.name).Price)
        {
            long a = GetByTitle(o.name).Price;
            GetByTitle(o.name).Level++;
            click -= GetByTitle(o.name).Price;
            a *= 13;
            a /= 10;
            GetByTitle(o.name).Price = a;
            priceText[artifactList.IndexOf(GetByTitle(o.name))].text = GetByTitle(o.name).Price.ToString();
            levelText[artifactList.IndexOf(GetByTitle(o.name))].text = GetByTitle(o.name).Level.ToString();
        }
    }
    public void DoublerScorePerClick()
    {
        if (click >= artifactList[30].Price)
        {
            long a = artifactList[30].Price;
            artifactList[30].Level++;
            click -= artifactList[30].Price;
            a *= 25;
            a /= 10;
            artifactList[30].Price = a;
            priceText[30].text = artifactList[30].Price.ToString();
            levelText[30].text = artifactList[30].Level.ToString();
            scorePerClick *= 2;
        }
    }
    public void PlayerPrefsClear()
    {
        PlayerPrefs.DeleteAll();
    }
    public void SpawnManySnowflakes()
    {
        GameObject SF;
        float y = 6f;
        for (int i = 0; i < 10; i++)
        {
            SF = Instantiate(bigSnowFlakes, new Vector3(Random.Range(-2.2f, 2.2f), y, -2f), Quaternion.identity) as GameObject;
            SF.GetComponent<SpriteRenderer>().sprite = snowFlakesTextures[Random.Range(0, snowFlakesTextures.Length)];
            SF.AddComponent<PolygonCollider2D>();
            y += 5;
        }
    }
    public int SummAllLvls()
    {
        int summ = 0;
        foreach (Artifact a in artifactList)
        {
            summ += a.Level;
        }
        return summ;
    }
    public int TemporaryDoubler()
    {
        if (ClicksPerNSeconds(1) >= 3 && ClicksPerNSeconds(1) < 6)
        {
            return 2;
        }
        else if (ClicksPerNSeconds(1) >= 6 && ClicksPerNSeconds(1) < 9)
        {
            return 3;
        }
        else if (ClicksPerNSeconds(1) >= 9 && ClicksPerNSeconds(1) < 12)
        {
            return 4;
        }
        else if (ClicksPerNSeconds(1) >= 12)
        {
            return 5;
        }
        return 1;
    }
    public void CheckText()
    {
        scoreText.text = click + " Score!";
    }
    public void ShopButton()
    {
        shopPanel.SetActive(!shopBool);
        backGroundShopPanel.SetActive(!shopBool);
        backGroundShopPanelAll.SetActive(!shopBool);
        shopBool = !shopBool;
        if (Time.timeSinceLevelLoad >= adTimeForShop)
        {
            AdManager.instance.ShowAd();
            adTimeForShop += Time.timeSinceLevelLoad;
        }
    }
    public void SnowFlakesCreating()
    {
        GameObject SF;
        snowFlakeTime += Random.Range(minTimeSpawnPref, maxTimeSpawnPref);
        SF = Instantiate(bigSnowFlakes, new Vector3(Random.Range(-2.2f, 2.2f), 6f, -2f), Quaternion.identity) as GameObject;
        SF.GetComponent<SpriteRenderer>().sprite = snowFlakesTextures[Random.Range(0, snowFlakesTextures.Length)];
        SF.AddComponent<PolygonCollider2D>();
    }
    public class Artifact
    {
        private string title = "";
        private int level = 0;
        private long damage = 0;
        private long price = 0;

        public Artifact(string _title, int _level, long _damage, long _price)
        {
            title = _title;
            level = _level;
            damage = _damage;
            price = _price;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public long Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public long Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
