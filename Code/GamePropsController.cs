using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePropsController : MonoBehaviour {
	public GameObject []props;//定义游戏道具
	public float spawnWait;//每生成一个道具的间隔
	public int wavCount;//每一波生成道具的数量 
	public float wavWait;//每波道具的等待间隔
	public float startWait;//游戏开始时生成道具之前的等待时间
						   // Use this for initialization
	void Start () {
		StartCoroutine(SpawnWaves());//开启协程
	}
	IEnumerator SpawnWaves()//产生游戏道具
	{
		yield return new WaitForSeconds(startWait);//开始时停顿
		while (true)//死循环
		{
			for (int i = 0; i < wavCount; ++i)
			{
				int index = Random.Range(0, props.Length);//生成随机数
				GameObject go = props[index];
				Vector3 pos = new Vector3(Random.Range(-5, 5), 0, 12);//位置信息
				Quaternion rot = Quaternion.identity;//旋转信息
				Instantiate(go, pos, rot);//生成物体
				yield return new WaitForSeconds(spawnWait);//这是为了让生成的游戏道具生成时间存在间隔，否则将会不停生成
			}
			yield return new WaitForSeconds(wavWait);//每一波之后停顿
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
