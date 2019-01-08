using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //Hingejointコンポーネントを入れる
    private HingeJoint myHingejoint;
    //初期の傾き
    private float defaultAngle=20.0f;
    //弾いた時の傾き
    private float flickAngle=-20.0f;
    //画面のサイズ
    private float size;

    // Start is called before the first frame update
    void Start()
    {
        //Hingejointコンポーネントを取得
        this.myHingejoint=GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
        //画面のサイズを取得
        this.size=Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Touch[] touches = Input.touches;
        
            for(int i = 0; i < Input.touchCount; i++)
            {
                if(touches[i].position.x<this.size/2&&tag=="LeftFripperTag")
                {
                    switch (touches[i].phase)
                    {
                        case TouchPhase.Began:
                        SetAngle(flickAngle);
                        break;

                        case TouchPhase.Ended:
                        SetAngle(defaultAngle);
                        break;
                    }
                }

                if(touches[i].position.x>=this.size/2&&tag=="RightFripperTag")
                {
                    switch (touches[i].phase)
                    {
                        case TouchPhase.Began:
                        SetAngle(flickAngle);
                        break;

                        case TouchPhase.Ended:
                        SetAngle(defaultAngle);
                        break;
                    }
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr=this.myHingejoint.spring;
        jointSpr.targetPosition=angle;
        this.myHingejoint.spring=jointSpr;
    }
}
