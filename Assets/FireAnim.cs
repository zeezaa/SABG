using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireAnim : MonoBehaviour {

    public Sprite[] fire;
    int pos = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Change", 0.15f, 0.15f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Change()
    {
        pos++;
        if(pos > 2)
            pos = 0;
        GetComponent<Image>().sprite = fire[pos];
    }
}
