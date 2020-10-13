using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartDoing : MonoBehaviour
{
  public int time = 8;
  private GameManager gameManager;
  private Text timer;
  private Text start_text;
  void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    timer = GameObject.Find("timer").GetComponent<Text>();
    start_text = GameObject.Find("start_text").GetComponent<Text>();
  }
  public void startLaobin()
  {
    if (gameManager.isDoing)
    {
      return;
    }
    gameManager.isDoing = true;
    start_text.text = "正在烙饼，不能操作!";
    StartCoroutine("DoSomething");
  }

  IEnumerator DoSomething()
  {
    while (time > 0)
    {
      //设置间隔时间为10秒
      time--;
      int seconds = time / 60;
      int milSeconds = time % 60;
      timer.text = "烙饼倒计时: " + seconds + ":" + milSeconds;
      yield return new WaitForSeconds(1);
    }
    finishedLaoBin();
  }

  void finishedLaoBin()
  {
    foreach (Bin item in gameManager.bins)
    {
      if (!item.zheng)
      {
        item.isZhengOk = true;
      }
      if (item.zheng)
      {
        item.isFanOk = true;
      }
    }
    gameManager.isDoing = false;
    time = 8;
    timer.text = "烙饼倒计时: 03:00";
    gameManager.setTimes();
    start_text.text = "开始烙饼";
  }

}
