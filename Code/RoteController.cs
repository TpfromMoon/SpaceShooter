using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteController : MonoBehaviour {
	public float rotSpeed;//定义旋转速度
	private Rigidbody rbd;//定义一个刚体
						  // Use this for initialization
	void Start () {
		rbd = GetComponent<Rigidbody>();//得到刚体
		rbd.angularVelocity = Random.insideUnitSphere*rotSpeed;//insideUnitSphere是一个半径为一的球面向量
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
