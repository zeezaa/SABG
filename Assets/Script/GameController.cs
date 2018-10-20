using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int p = 0;
    public int popped = 0;
    public float sliderVal = 6000;
    public GameObject[] crack;
    public GameObject slider;
    public GameObject ball;
    public Text scoreText;
    int last = 0;
    public AudioClip[] crackS;
    public string gameState = "menu";
    public static GameController Inst;
    public Vector2 curPos;
    public Vector2 lastPos;

    public void Awake()
    {
        Inst = this;
    }

    private void FixedUpdate()
    {
        Vector2 curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //get current mouse position
        float dist = Vector3.Distance(lastPos, curPos); //get distance between last and current mouse position

        RaycastHit2D hit = Physics2D.Raycast(lastPos, curPos, dist); //check whats between last and current mouse position
        if (hit.collider != null && hit.collider.tag == "wall") //check if its a wall
            hit.collider.GetComponent<WallController>().Hit(); //hits wall

        if (curPos != lastPos) //if position has changed
            lastPos = curPos; //mark last position
        
        #if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX //if running on pc/mac
        if (Input.GetKey(KeyCode.Escape)) //if press esc
        {
            Application.Quit(); //quit game
        }
        #endif
        if (popped > last + 4) //after every 5th ball popped
        {
            last = popped; //mark last one to create a wall
            CrackNewOne();
        }
        if (gameState == "play")
        {
            slider.SetActive(true);
        }
        else if (gameState == "over")
        {
            slider.SetActive(false);
            Destroy(ball);
            GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
            for (int i = 0; i < walls.Length; i++)
                Destroy(walls[i]);
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void CrackNewOne(bool Cracked = false)
    {
        int i = Random.Range(0, 4);
        Instantiate(crack[i], new Vector2(Random.Range(-8.8f, 8.8f), Random.Range(-4.9f, 4.9f)), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))); //spawn crack
        if (!Cracked)
            GetComponent<AudioSource>().PlayOneShot(crackS[i]);
    }

    private void Timer()
    {
        if (slider.GetComponent<Slider>().value > 0)
        {
            sliderVal--;
            slider.GetComponent<Slider>().value = sliderVal;
            sliderVal = slider.GetComponent<Slider>().value;
        }
        else
        {
            CancelInvoke();
            slider.SetActive(false);
            gameState = "over";
            scoreText.text = "You Scored: " + p + " points!\nPress Space to restart";
            scoreText.enabled = true;
        }
    }

    IEnumerator AddVal()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 125; i > 0; i--)
        {
            yield return new WaitForSeconds(0.0001f);
            sliderVal = sliderVal-4;
        }
        yield break;
    }
}
