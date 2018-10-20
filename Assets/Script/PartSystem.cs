using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Die", 2);
	}
	
	// Update is called once per frame
	void Die () {
        Destroy(gameObject);
	}
}
