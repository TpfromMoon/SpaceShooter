using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossmovecontroller : MonoBehaviour
{
    private Rigidbody rbd;//定义一个刚体
    public float flyspeed;//定义飞行速度
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
        rbd.velocity = transform.forward * flyspeed;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
