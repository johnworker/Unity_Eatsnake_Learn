using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    #region 基本貪吃蛇製作
    /*這個程式碼使用 Unity 引擎來實現 3D 版貪吃蛇遊戲。當遊戲開始時， Start 函式會被執行並設置貪吃蛇的初始速度以及移動頻率。 Move 函式被重複調用，使貪吃蛇每個時間間隔向當前方向移動一格，並更新貪吃蛇的尾巴。Update 函式則處理玩家的按鍵輸入來改變貪吃蛇的移動方向。如果貪吃蛇撞到食物，則生成一個新的尾巴並刪除食物。如果貪吃蛇撞到自己的尾巴，則遊戲重新開始。需要注意的是，3D 版貪吃蛇的移動方向是旋轉而不是平移。因此，在 Update 函式中，當玩家按下左或右箭頭時，貪吃蛇會向左或右旋轉 90 度。同時，貪吃蛇的尾巴也需要使用陣列來存儲，而不是使用列表。*/
    #endregion

    // 宣告變數
    public float speed = 1f;
    public GameObject tailPrefab;
    private Transform[] tailList;
    private int tailLength = 0;

    // 開始時執行
    void Start()
    {
        tailList = new Transform[100];
        InvokeRepeating("Move", 0.1f, speed);
    }

    // 移動函式
    void Move()
    {
        Vector3 lastPos = transform.position;
        transform.Translate(Vector3.forward);

        if (tailLength > 0)
        {
            tailList[tailLength - 1].position = lastPos;
            for (int i = tailLength - 1; i > 0; i--)
                tailList[i].position = tailList[i - 1].position;
            tailList[0].position = lastPos;
        }
    }

    // 控制函式
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up * 90);
        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up * -90);
    }

    // 碰撞函式
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Food"))
        {
            GameObject g = Instantiate(tailPrefab, tailList[tailLength - 1].position, Quaternion.identity);
            tailList[tailLength] = g.transform;
            tailLength++;
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.CompareTag("Tail"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
