using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性があるz軸の最大値
    private float visiblePosZ=-6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    private int score=0;

    private GameObject scoreText;
    void Start()
    {
        //シーン中のgameoverTextオブジェクトを取得
        this.gameoverText=GameObject.Find("GameOverText");
        this.scoreText=GameObject.Find("ScoreText");
        this.scoreText.GetComponent<Text>().text="0 point";
    }      

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z<this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text="Game Over";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="SmallStarTag")
        {
            this.score+=10;
        }
        if(other.gameObject.tag=="LargeStarTag")
        {
            this.score+=20;
        }
        if(other.gameObject.tag=="SmallCloudTag")
        {
            this.score+=15;
        }
        if(other.gameObject.tag=="LargeCloudTag")
        {
            this.score+=30;
        }

        this.scoreText.GetComponent<Text>().text=this.score.ToString()+" point";
    }
}
