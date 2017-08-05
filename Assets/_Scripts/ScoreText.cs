using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    Text tx;

    private void Awake()
    {
        tx = GetComponent<Text>();
    }

    void Update () {
        tx.text = "Score:  " + PlayerPrefs.GetInt("score");
	}
}
