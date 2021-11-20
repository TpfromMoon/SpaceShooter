using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//闪避AI脚本
public class DodgeController : MonoBehaviour {
	//最大的与最小随机速度
	public float DodgeMinSpeed;
	public float DodgeMaxSpeed;
	private float DodgeTargetSpeed;//随机闪避目标速度
	public float waitMax, waitMin;//开始第一次的闪避所需的时间的最小和最大时间
	public float dodgeMaxTime, dodgeMinTime;//闪避最短最长时间
	private Rigidbody rbd;
	public float titl;//偏转量
	public float accelerSpeed;//定义加速度
	public Boundary bound;//设定边界
	// Use this for initialization
	void Start () {
		rbd = GetComponent<Rigidbody>();//得到刚体组件
		StartCoroutine(calcDodgeSpeed());//开启协程
	}
	IEnumerator calcDodgeSpeed()
    {
		while (true)//敌机需要不停闪避
		{
			yield return new WaitForSeconds(Random.Range(waitMin, waitMax));
			DodgeTargetSpeed = Random.Range(DodgeMinSpeed, DodgeMaxSpeed);//随机计算目标闪避速度
			if (transform.position.x > 0)//出生地在左边，往右跑，出生地在右边，往左跑
			{
				DodgeTargetSpeed = -DodgeTargetSpeed;
			}
			yield return new WaitForSeconds(Random.Range(dodgeMinTime, dodgeMaxTime));
			DodgeTargetSpeed = 0;//经过一段闪避时间之后速度需要变为0
		}
    }
	// Update is called once per frame
	void Update () {
		
	}
	private void FixedUpdate()
    {
		//通过加速度获取现速度
		float val = Mathf.MoveTowards(rbd.velocity.x,DodgeTargetSpeed,Time.time*accelerSpeed);
		rbd.velocity = new Vector3(val, 0, rbd.velocity.z) ;
		//产生偏转
		rbd.rotation = Quaternion.Euler(0, 0, rbd.velocity.x * (-1) * titl);//需要在x轴上有偏转；偏转速度也是渐变的；乘以titl是为了可以在面板里进行调节
																			//设定边界
		float posX = Mathf.Clamp(rbd.position.x, bound.xMIN, bound.xMAX);//获取当前x坐标,如果大于最大值，返回最大值，如果小于最小值，返回最小值
		float posZ = Mathf.Clamp(rbd.position.z, bound.zMIN, bound.zMAX);//获取当前z坐标，作用同上
																		 //赋予刚体组件新的位置
		rbd.position = new Vector3(posX, 0, posZ);

	}
}
