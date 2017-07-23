using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    GameObject bullet;
    float fireTime = .5f;
    int poolAmount = 1000;
    List<GameObject> bullets;

	// Use this for initialization
	void Start () {
        bullets = new List<GameObject>();
        for(int i = 0; i < poolAmount; ++i)
        {
            GameObject g = (GameObject)Instantiate(bullet);
            g.SetActive(false);
            bullets.Add(g);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
