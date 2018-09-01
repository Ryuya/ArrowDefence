using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x < -3 || transform.position.x > 3)
        //{
        //    gamengai = true;
        //}
        // 
        //if (gamengai){
        //    if(time > span){
        //        speed = speed *= -1;
        //        time = 0;
        //        gamengai = false;
        //    } else {
        //        this.transform.position += this.transform.up * 0.8f * Time.deltaTime;
        //        time += Time.deltaTime;
        //    }
        //}
        //if(!gamengai){
        //    this.transform.position += this.transform.right * speed * Time.deltaTime;
        //}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.gameObject.tag == "Arrow"){
            SceneManager.LoadScene("GameOver");
        }
	}
}
