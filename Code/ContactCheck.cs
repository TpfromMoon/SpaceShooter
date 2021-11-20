using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactCheck : MonoBehaviour {
	public GameObject EnemyExplosion, PlayerExplosion;//敌方与我方爆炸特效
	public int ScoreValue;//敌方被销毁玩家得到的分数
	private GameMgr gameMgr;//定义引用
	// Use this for initialization
	void Start () {
		//拿到GameMgr的引用
		GameObject go = GameObject.FindGameObjectWithTag("GameMgr");
		 gameMgr= go.GetComponent<GameMgr>();
	}
	private void OnTriggerEnter(Collider other)//碰撞检测函数
    {
		if(other.tag=="boundary"||other.tag=="Enemy"||other.tag=="Bonus")//敌人，道具之间发生碰撞或者碰撞边界
        {
			return;
        }



		if (EnemyExplosion != null)
		{ Instantiate(EnemyExplosion, transform.position, transform.rotation); }//实例化行星爆炸特效
		if (other.tag == "Player")
		{ 
			Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
			gameMgr.GameOver();//玩家飞机爆炸后调度游戏结束程序
		}//实例化飞船爆炸特效
																							 //销毁两个物体，顺序不能颠倒！	
																							 //UI相关
		gameMgr.addScore(ScoreValue);

		Destroy(other.gameObject);
		Destroy(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
