using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    public KeyCode key;

    bool active = false;
    GameObject note;
    SpriteRenderer sr;

    bool createMode = false;
  
    void Awake () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        

        if (createMode)
        {

        }
        else if (Input.GetKeyDown(key))
        {
            StartCoroutine(Pressed());
            if (active)
            {
                AddScore();
                Destroy(note);
                active = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.tag == "Note")
        {
            note = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }

    IEnumerator Pressed()
    {
        Color old = sr.color;
        sr.color = new Color(51, 51, 51, 255);
        yield return new WaitForSeconds(0.1f);
        sr.color = old;
    }

    private void AddScore()
    {
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 50);
    }
}
