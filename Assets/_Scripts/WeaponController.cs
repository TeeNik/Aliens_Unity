using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject bullet;
    float fireTime = .5f;
    int poolAmount = 1000;
    List<GameObject> bullets;

    public float speed = 0.1f;

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
        if (Input.GetMouseButtonDown(0))
        {
            GameObject g = (GameObject)Instantiate(bullet);
            g.GetComponent<Rigidbody2D>().MovePosition(transform.position + Input.mousePosition*speed);
        }
	}
}
