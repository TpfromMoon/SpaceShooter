using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killall : MonoBehaviour
{
    public GameObject EnemyExplosion;//定义爆炸特效
    public int ScoreValue;//敌方被销毁玩家得到的分数
    private GameMgr gameMgr;//定义引用

    // Start is called before the first frame update
    void Start()
    {
        //拿到GameMgr的引用
        GameObject go = GameObject.FindGameObjectWithTag("GameMgr");
        gameMgr = go.GetComponent<GameMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playershipController.instance.killPower <= 0)
        {
            return;
        }
        if (playershipController.instance.killPower > 0)
        {
            if (Input.GetButton("Fire2"))//右键清屏
            {
                playershipController.instance.killPower--;
                gameMgr.addprops(playershipController.instance.killPower);
                //以下都是清屏操作
                GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < allEnemy.Length; i++)
                {
                    if (EnemyExplosion != null)
                    {
                        Instantiate(EnemyExplosion, allEnemy[i].transform.position, Quaternion.identity);
                        
                    }
                    gameMgr.addScore(ScoreValue);
                    Destroy(allEnemy[i]);


                }


            }
        }
    }
}

