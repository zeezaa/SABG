using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    SpriteRenderer SpriteC;
    public GameObject plus1;

    // Use this for initialization
    void Start ()
    {
        SpriteC = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameController.Inst.gameState == "menu")
            {
                transform.GetChild(0).gameObject.SetActive(false);
                GameController.Inst.InvokeRepeating("Timer", 0, 0.01f);
                GameController.Inst.gameState = "play";
            }
            gameObject.GetComponent<AudioSource>().Play();
            AddScore();
            Move();
        }
    }

    void Move()
    {
        float scale = Random.Range(0.8f, 1.2f);
        transform.localScale = new Vector2(scale, scale);
        transform.position = new Vector2(Random.Range(-8.8f, 8.8f), Random.Range(-4.9f, 4.9f)); //generate new position
        SpriteC.color = new Color(Random.Range(0f, 1), Random.Range(0f, 1), Random.Range(0f, 1), 1f); //random color
        while (SpriteC.color.r < 0.4f && SpriteC.color.g < 0.4f && SpriteC.color.b < 0.4f) //if all colors are under 0.4f
        {
            SpriteC.color = new Color(Random.Range(0f, 1), Random.Range(0f, 1), Random.Range(0f, 1), 1f); //random color
        }
    }

    void AddScore()
    {
        GameController.Inst.popped++;
        GameObject p1 = Instantiate(plus1, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        p1.GetComponent<TextMesh>().color = SpriteC.color;
        GameController.Inst.p++;
    }
}
