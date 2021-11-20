using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {
	public GameObject []Enemies;//定义游戏中敌人的数组
	public GameObject []props;//定义游戏中道具的数组
	public GameObject[] bosses;//定义boss的数组
	public float spawnWait;//每生成一个敌人的间隔
	public int wavCount;//每一波生成敌人的数量 
	public float wavWait;//每波敌人的等待间隔
	public float startWait;//游戏开始时生成敌人之前的等待时间

	public float propspawnWait;//每生成一个道具的间隔
	public int propwavCount;//每一波生成道具的数量 
	public float propwavWait;//每波道具的等待间隔
	public float propstartWait;//游戏开始时生成道具之前的等待时间
	public float bossspawnWait;//每生成一个敌人的间隔
	public int bosswavCount;//每一波生成敌人的数量 
	public float bosswavWait;//每波敌人的等待间隔
	public float bossstartWait;//游戏开始时生成敌人之前的等待时间
	//UI相关
	private int scoreCount=0;//游戏开始时初始游戏分数
	public Text lbScore;//显示分数变化
	private int propCount = 0;//游戏开始时初始道具数量
	public Text propScore;//显示道具数量变化
	public GameObject endPanel;
	public bool isGameOver=false;//判断游戏是否结束 
	public bool isGamePause =false;
	
	//public bool isGamePause = false;
	// Use this for initialization
	void Start () {
	
		StartCoroutine(SpawnWaves());//开启协程
		StartCoroutine(propSpawnWaves());//开启道具协程
		StartCoroutine(bossSpawnWaves());//开启boss协程
	}
	//完成所有物体的生成（协程，异步，不想中断游戏运行逻辑，每一次经过yield return语句都会等待）
	IEnumerator SpawnWaves()
    {
		yield return new WaitForSeconds(startWait);//开始时停顿
        while (true)//死循环
        {
			for(int i=0;i<wavCount;++i)
            {
				int index = Random.Range(0, Enemies.Length);//生成随机数敌人
				GameObject go = Enemies[index];
				Vector3 pos = new Vector3(Random.Range(-5, 5), 0, 12);//位置信息
				Quaternion rot = Quaternion.identity;//旋转信息
				Instantiate(go, pos, rot);//生成敌人
				yield return new WaitForSeconds(spawnWait);//这是为了让生成的游戏物体生成时间存在间隔，否则将会不停生成
            }
			//当主角死亡后跳出出生逻辑
			if(isGameOver)
            {
				break;
            }
			yield return new WaitForSeconds(wavWait);//每一波之后停顿
		}
    }
	IEnumerator propSpawnWaves()
	{
		yield return new WaitForSeconds(propstartWait);//开始时停顿
		while (true)//死循环
		{
			for (int i = 0; i < propwavCount; ++i)
			{
				int index = Random.Range(0, props.Length);//生成随机数道具
				GameObject go = props[index];
				Vector3 pos = new Vector3(Random.Range(-5, 5), 0, 12);//位置信息
				Quaternion rot = Quaternion.identity;//旋转信息
																//rbd.rotation = Quaternion.Euler(0, 0, rbd.velocity.x * (-1) * titl);
				Instantiate(go, pos, rot);//生成道具
				yield return new WaitForSeconds(propspawnWait);//这是为了让生成的游戏物体生成时间存在间隔，否则将会不停生成
			}
			if (isGameOver)
			{
				break;
			}
			yield return new WaitForSeconds(propwavWait);//每一波之后停顿
		}
	}
	IEnumerator bossSpawnWaves()
	{
		yield return new WaitForSeconds(bossstartWait);//开始时停顿
		while (true)//死循环
		{
			for (int i = 0; i < wavCount; ++i)
			{
				int index = Random.Range(0, bosses.Length);//生成随机数敌人
				GameObject go = bosses[index];
				Vector3 pos = new Vector3(Random.Range(-5, 5), 0, 12);//位置信息
				Quaternion rot = go.transform.rotation;//旋转信息
				Instantiate(go, pos, rot);//生成敌人
				yield return new WaitForSeconds(bossspawnWait);//这是为了让生成的游戏物体生成时间存在间隔，否则将会不停生成
			}
			if (isGameOver)
			{
				break;
			}
			if (isGameOver)
			{
				break;
			}
			yield return new WaitForSeconds(bosswavWait);//每一波之后停顿
		}
	}
	//游戏转场
	
	//增加分数
	public void addScore(int value)
    {
		scoreCount += value;
		Debug.Log("ScoreCount" + scoreCount);//打印到控制台
		lbScore.text = "Score:" + scoreCount.ToString();
    }
	public void addprops(int value)
    {
		propCount = value;
		Debug.Log("PropCount" + propCount);
		propScore.text = "Prop:" + propCount.ToString();
    }
	public void GameOver()
    {
		endPanel.SetActive(true);
		isGameOver = true;
    }
	public void RestartGame()
    {
		//重新加载场景
		ScreenFaderInout.fadeIn = true;
		isGamePause = false;
		Time.timeScale = 1;
		
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
	public void ButtonExit()//返回主界面
    {
		ScreenFaderInout1.fadeIn1 = true;
		//ScreenFaderInout1.fadeIn1 = true;
		//SceneManager.LoadScene(0);
    }
	public void PauseButtonExit()
    {
		
		ScreenFaderInout1.fadeIn1 = true;
		Time.timeScale = 1;

	}
	public void ButtonPause()//暂停游戏
    {
		if (!isGamePause)
		{
			isGamePause = true;
			Time.timeScale = 0; 
		}

	}
   public void ButtonContinue()
    {
		if (isGamePause)
		{
			isGamePause = false;
			Time.timeScale = 1;
		}
    }
    // Update is called once per frame
    void Update () {
	
	}
}
