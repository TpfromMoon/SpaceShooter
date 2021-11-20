using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveController : MonoBehaviour {
	private Rigidbody rbd;//定义一个刚体
	public float flyspeed;//定义飞行速度
	
	 // Use this for initialization
	void Start () {
		rbd = GetComponent<Rigidbody>();
		rbd.velocity = transform.forward*flyspeed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
