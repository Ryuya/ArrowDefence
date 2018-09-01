using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShieldController : MonoBehaviour {


    public Transform joystick;

    public Vector3 joystickFirstPos;

    GameObject scoreUI;

    Transform Shield;

	// Use this for initialization
	void Start () {
        joystickFirstPos = joystick.position;
        scoreUI = GameObject.Find("Score");
        Shield = GameObject.Find("Block").GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        //this.transform.rotation = 
        if(Vector3.Distance(joystickFirstPos, joystick.position) < 0.1f){
            
        } else {
            Shield.rotation = Quaternion.Euler(0, 0, GetAim(joystickFirstPos, joystick.position) - 90f);
        }
        Debug.Log(GetAim(joystickFirstPos, joystick.position));
    }
	

    public float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Arrow")
        {
            //本当は、Spriteを破壊させたい。
            scoreUI.GetComponent<Score>().score += 1;
            scoreUI.GetComponent<Text>().text = "Score :"+scoreUI.GetComponent<Score>().score;
            Destroy(other.gameObject);
        }
    }
}
