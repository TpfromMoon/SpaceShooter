using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]//可序列化
public class Boundary//给飞船设定运动范围
{
	public float xMAX, xMIN, zMAX, zMIN;//四个方向上的速度最大值与最小值

}



public class playershipController : MonoBehaviour {
	private Rigidbody rbd;//定义一个刚体
	public float shootspace;//定义子弹飞行时间间隔
	public float speed;
	public float titl;//偏转量
	private AudioSource shotaudio;//飞船射击子弹声音
	public Boundary bound;
	public GameObject bullet;//定义子弹物体
	public Transform []shootpos;//发射位置
	private float nextshoot;//下次射击时间
	//子弹数量
	[Tooltip("current weapon power")]
	[Range(1, 3)]       //change it if you wish
	public int weaponPower = 1;
	[HideInInspector] public int maxweaponPower = 3;
	//清屏道具数量
	[Tooltip("current killall power")]
	public int killPower = 0;
	public static playershipController instance;
	// Use this for initialization
	void Start () {
		rbd = GetComponent<Rigidbody>();
		shotaudio = GetComponent<AudioSource>();
	}
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")&&Time.time>nextshoot)//创建子弹
        {
			nextshoot = Time.time+shootspace;//相当于增加了攻击后摇
			switch(weaponPower)
            {
				case 1:
					Instantiate(bullet, shootpos[0].position, shootpos[0].rotation);
					shotaudio.Play();
					break;
				case 2:
					for (int i = 1; i < 3; ++i)
					{ Instantiate(bullet, shootpos[i].position, shootpos[i].rotation); }//子弹物体，发射位置，发射旋转
					shotaudio.Play();//生成一个子弹实例，出一次声音*/
					break;
				case 3:
					for (int i = 0; i < shootpos.Length; ++i)
					{ Instantiate(bullet, shootpos[i].position, shootpos[i].rotation); }//子弹物体，发射位置，发射旋转

					shotaudio.Play();//生成一个子弹实例，出一次声音
					break;
			}
			/*for (int i = 0; i < shootpos.Length; ++i)
			{ Instantiate(bullet, shootpos[i].position, shootpos[i].rotation); }//子弹物体，发射位置，发射旋转
			
			shotaudio.Play();//生成一个子弹实例，出一次声音*/
        }
		
	}
	private void FixedUpdate()
    {
		//计算运动方向速度向量
		float h = Input.GetAxis("Horizontal");//获取到水平方向的输入
		float v = Input.GetAxis("Vertical");//获取到垂直方向的输入
		Vector3 vel = new Vector3(h, 0, v);//不需要在y轴上有运动
										   //操作刚体速度产生运动
		rbd.velocity = vel * speed;
		//产生偏转
		rbd.rotation = Quaternion.Euler(0, 0, rbd.velocity.x * (-1)*titl);//需要在x轴上有偏转；偏转速度也是渐变的；乘以titl是为了可以在面板里进行调节
																		  //设定边界
		float posX =Mathf.Clamp(rbd.position.x,bound.xMIN,bound.xMAX);//获取当前x坐标,如果大于最大值，返回最大值，如果小于最小值，返回最小值
		float posZ =Mathf.Clamp(rbd.position.z,bound.zMIN,bound.zMAX);//获取当前z坐标，作用同上
																	  //赋予刚体组件新的位置
		rbd.position = new Vector3(posX, 0, posZ);

	}


}
