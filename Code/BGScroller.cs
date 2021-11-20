using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;//可以在面板里直接调节背景运动速度
	private Vector3 startPos;//用来保存背景板起始位置
	// Use this for initialization
	void Start () {
		startPos = transform.position;//获取起始位置
	}
	
	// Update is called once per frame
	void Update () {
		float dis =Mathf.Repeat(scrollSpeed * Time.time,30);//计算背景板移动的距离,利用数学函数在背景版移动到极限距离时进行循环往复
		transform.position = startPos + dis * Vector3.forward*(-1);//使用unity提供给我们的API，计算出之后的位置
	}
}
