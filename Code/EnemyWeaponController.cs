using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour {

	public GameObject bullet;//定义子弹物体
	public Transform []shootpos;//发射位置
	public float shootspace;//定义子弹飞行时间间隔
	public float shootWait;//发射子弹等待时间
	private AudioSource shotaudio;//飞船射击子弹声音
								  // Use this for initialization
	void Start () {
		InvokeRepeating("EnemyShipFire", shootWait, shootspace);
		shotaudio = GetComponent<AudioSource>();
	}
	void EnemyShipFire()
    {
		for (int i = 0; i < shootpos.Length; ++i)
		{
			Instantiate(bullet, shootpos[i].position, shootpos[i].rotation);//子弹物体，发射位置，发射旋转
			shotaudio.Play();//生成一个子弹实例，出一次声音
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
