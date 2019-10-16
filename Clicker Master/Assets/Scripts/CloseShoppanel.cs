using UnityEngine;
using System.Collections;

public class CloseShoppanel : MonoBehaviour
{
    public GameObject backGroundShopPanel;
    public GameObject shopPanel;
     
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnMouseDown()
    {
        shopPanel.SetActive(false);
        backGroundShopPanel.SetActive(false);
        gameObject.SetActive(false);
        GM.instance.shopBool = false;  
    }
}
