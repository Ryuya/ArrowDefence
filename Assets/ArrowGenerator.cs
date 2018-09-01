using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour {
    public List<Transform> generatePoints = new List<Transform>();
    public float span = 0.3f;
    public float currentTime = 0f;

    public int gameLevel = 0;

    public Score score;
	// Use this for initialization
	void Start () {
        //GenerateA();
        score = GameObject.Find("Score").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () {

        //Lv検知
        CheckLevel(score.score);


        if(currentTime > span){
            currentTime = 0f;
            int rand = Random.Range(0, generatePoints.Count);
            //ゲームLv
            switch(gameLevel){
                case 1:
                    ArrowGenerateRandome(rand);
                    break;
                case 2:
                    StartCoroutine(ArrowGenerate3Way_P());
                    //ArrowGenerateIkkini();
                    break;
                case 3:
                    //ArrowGenerateRandome(rand);
                    int randLv3 = Random.Range(0,3);
                    switch(randLv3){
                        case 0:
                            StartCoroutine(ArrowGenerate3Way_P());
                            break;
                        case 1:
                            StartCoroutine(ArrowGenerate3Way_M());
                            break;
                    }
                    break;
                case 4:
                    int randLv4 = Random.Range(0, 4);
                    switch (randLv4)
                    {
                        case 0:
                            StartCoroutine(ArrowGenerate3Way_P());
                            break;
                        case 1:
                            StartCoroutine(ArrowGenerate3Way_M());
                            break;
                        case 2:
                            StartCoroutine(ArrowGenerate5Way_P());
                            break;
                        case 3:
                            StartCoroutine(ArrowGenerate5Way_M());
                            break;
                    }
                    break;
                case 5:
                    break;
                case 6:
                    break;
            }
        } else {
            currentTime += Time.deltaTime;
        }

	}

    // ---------Arrow 生成パターン---------
    public void ArrowGenerateRandome(int index){
        var generatePoint = generatePoints[index];
        var go = Instantiate((GameObject)Resources.Load("Prefabs/Arrow"));
        go.transform.position = generatePoint.position;
    }

    public IEnumerator ArrowGenerate3Way_P(){
        int index = Random.Range(0, generatePoints.Count - 3);

        for (int i = 0; i < 3; i++){
            var generatePoint = generatePoints[index+i];
            var go = Instantiate((GameObject)Resources.Load("Prefabs/Arrow"));
            go.transform.position = generatePoint.position;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator ArrowGenerate3Way_M()
    {
        int index = Random.Range(0, generatePoints.Count - 3);

        for (int i = 3; i > 0; i--)
        {
            var generatePoint = generatePoints[index + i];
            var go = Instantiate((GameObject)Resources.Load("Prefabs/Arrow"));
            go.transform.position = generatePoint.position;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator ArrowGenerate5Way_P()
    {
        int index = Random.Range(0, generatePoints.Count - 5);

        for (int i = 0; i < 5; i++)
        {
            var generatePoint = generatePoints[index + i];
            var go = Instantiate((GameObject)Resources.Load("Prefabs/Arrow"));
            go.transform.position = generatePoint.position;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator ArrowGenerate5Way_M()
    {
        int index = Random.Range(0, generatePoints.Count - 5);

        for (int i = 5; i > 0; i--)
        {
            var generatePoint = generatePoints[index + i];
            var go = Instantiate((GameObject)Resources.Load("Prefabs/Arrow"));
            go.transform.position = generatePoint.position;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ArrowGenerateIkkini(){
        var generatePoint1 = generatePoints[0];
        var go1 = Instantiate((GameObject)Resources.Load("Prefabs/Arrow"));
        go1.transform.position = generatePoint1.position;

        var generatePoint2 = generatePoints[generatePoints.Count-1];
        var go2 = Instantiate((GameObject)Resources.Load("Prefabs/Arrow"));
        go2.transform.position = generatePoint2.position;

        var generatePoint3 = generatePoints[5];
        var go3 = Instantiate((GameObject)Resources.Load("Prefabs/Arrow"));
        go3.transform.position = generatePoint3.position;
    }

    // ---------Arrow 生成パターン---------

    public void CheckLevel(int score){

        if (score < 10)
        {
            gameLevel = 1;
        } else if (score >= 10 && score < 30)
        {
            gameLevel = 2;
        } else if (score >= 30 && score < 80){
            gameLevel = 3;
        } else if (score >= 80 && score < 130){
            gameLevel = 4;
        } else if(score >= 130 && score < 200){
            gameLevel = 5;
        }
    }
}
