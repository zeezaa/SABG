using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plus1 : MonoBehaviour {

    float goal;
    public float speed;
    public AudioClip[] sounds;

	// Use this for initialization
	void Start () {
        goal = transform.position.y+0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        if (transform.position.y > goal)
            Destroy(gameObject);
    }

    public void value(int val)
    {
        GetComponent<TextMesh>().text = val.ToString();
        if (val > 0) //if value to be displayed is positive
            GetComponent<AudioSource>().PlayOneShot(sounds[0]); //play bap sound
        else //if negative
            GetComponent<AudioSource>().PlayOneShot(sounds[1]); //play error sound       
    }
}
