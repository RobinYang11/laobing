using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

  public static Vector3 position1 = new Vector3(800, 200, 0);
  public static Vector3 position2 = new Vector3(800, 400, 0);
  // 当前锅内放的数量
  public int size = 0;
  public List<Bin> bins = new List<Bin>(2);
  //烙饼次数
  public int times = 0;

  //是否正在烙饼
  public bool isDoing = false;

  private Text timeCount;

  private void Start()
  {
    timeCount = GameObject.Find("timecount").GetComponent<Text>();
  }

  public void setTimes()
  {
    times++;
    timeCount.text = "烙饼次数: " + times.ToString();
  }
}
