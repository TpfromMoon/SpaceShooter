using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
	public float delaytime;//销毁延迟时间
	// Use this for initialization
	void Start () {
		Destroy(gameObject,delaytime);//销毁特效
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
