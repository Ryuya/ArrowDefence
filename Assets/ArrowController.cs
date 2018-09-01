using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour {
    public GameObject player;
    public Rigidbody2D rb;
    float speed = 8f;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        transform.LookAt2D(player.transform, Vector2.left);
	}
	
	// Update is called once per frame
	void Update () {

        //rb.AddForce(transform.right * speed,ForceMode2D.Force);
        transform.position += transform.right *  speed * Time.deltaTime;
	}
}
