using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactPropCheck : MonoBehaviour
{
    public GameObject playerbuff;//我方buff特效
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)//碰撞检测函数
    {
        if (other.tag == "boundary" || other.tag == "Enemy"||other.tag=="bullet"||other.tag=="props")//道具之间发生碰撞或者碰撞边界
        {
            return;
        }
      
        if (other.tag == "Player")
        { Instantiate(playerbuff, other.transform.position, other.transform.rotation); }
        //实例化飞船加buff特效//没问题
        if (playershipController.instance.weaponPower < playershipController.instance.maxweaponPower)
        {
            playershipController.instance.weaponPower++;
        }
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
