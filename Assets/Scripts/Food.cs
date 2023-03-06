using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // 宣告變數
    public GameObject foodPrefab;

    // 碰撞函式
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Tail"))
        {
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.CompareTag("Food"))
        {
            Destroy(coll.gameObject);
        }

        // 生成新的食物
        Vector3 pos = new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
        Instantiate(foodPrefab, pos, Quaternion.identity);
    }

    #region 基本貪吃蛇食物說明
    /*這個程式碼會在食物和尾巴碰撞時刪除對象。在碰撞後，它會生成一個新的食物物體。新的食物物體會在隨機位置生成。要使用這個程式碼，需要將其附加到食物物體上，並在屬性面板中設置食物預置物。
    需要注意的是，這些程式碼僅為基本示例，可以根據需要進行修改和擴展，例如添加障礙物或更多遊戲規則。同時，這些程式碼也不包括遊戲場景的設計，需要使用 Unity 引擎來創建適當的場景和遊戲資源。*/
    #endregion
}
