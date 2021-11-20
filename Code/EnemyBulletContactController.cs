using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletContactController : MonoBehaviour
{
    public GameObject  PlayerExplosion;//敌方与我方爆炸特效
    private GameMgr gameMgr;//定义引用
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)//碰撞检测函数
    {
        if (other.tag == "boundary" || other.tag == "Enemy" || other.tag == "Bonus"||other.tag=="bullet")//敌人，道具之间发生碰撞或者碰撞边界
        {
            return;
        }



        
        if (other.tag == "Player")
        { Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            gameMgr.GameOver();//玩家飞机爆炸后调度游戏结束程序
        }//实例化飞船爆炸特效
                               //销毁两个物体，顺序不能颠倒！																			
            Destroy(other.gameObject);
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
