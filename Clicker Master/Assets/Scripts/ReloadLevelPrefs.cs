using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadLevelPrefs : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.DeleteAll();
	}	
}
