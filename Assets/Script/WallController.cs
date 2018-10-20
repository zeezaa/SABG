using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallController : MonoBehaviour {

    public GameObject error;
    public GameObject particles;
    public bool OnMouse = true;

    private void Start()
    {
        Invoke("On", 0.0001f);
    }

    private void On()
    {
        OnMouse = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void OnMouseOver()
    {
        if (gameObject.CompareTag("wall"))
        {
            Hit();
        }
    }

    public void Hit()
    {

        if (OnMouse)
        {
            Debug.Log("you hit an invisible crack!");
            GameController.Inst.CrackNewOne(true);
            Destroy(gameObject);
        }

        else
        {
            GameController.Inst.StartCoroutine("AddVal");
            GameObject not = Instantiate(error, transform.position, Quaternion.identity);
            not.GetComponent<Plus1>().value(-5);
            Instantiate(particles, transform.position, Quaternion.identity); //timer fire particles
            GameController.Inst.p = GameController.Inst.p - 5;
            Destroy(gameObject);
        }
    }
}
