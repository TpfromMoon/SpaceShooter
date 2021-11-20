using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPropContactCheck : MonoBehaviour
{
    public GameObject playerbuff;//我方buff特效
    private GameMgr gameMgr;//定义引用
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)//碰撞检测函数
    {
        if (other.tag == "boundary" || other.tag == "Enemy" || other.tag == "bullet" || other.tag == "Bonus")//道具之间发生碰撞或者碰撞边界
        {
            return;
        }

        if (other.tag == "Player")
        { Instantiate(playerbuff, other.transform.position, other.transform.rotation); }
        //实例化飞船加buff特效//没问题
        if (playershipController.instance.killPower >= 0)
        { 
            playershipController.instance.killPower++;
           
        }
        gameMgr.addprops(playershipController.instance.killPower);
        Destroy(gameObject);
       

    }
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("GameMgr");
        gameMgr = go.GetComponent<GameMgr>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
