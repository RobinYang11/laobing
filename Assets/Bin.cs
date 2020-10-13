using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;
public class Bin : MonoBehaviour, IDragHandler, IPointerUpHandler, IEndDragHandler, IPointerClickHandler
{


  [SerializeField]
  public Image image;

  public Sprite bin_shou_zheng;

  public Sprite bin_shou_fan;

  public Sprite bin_sheng_zheng;

  public Sprite bin_sheng_fan;

  public Collider2D targetCol;

  public Collider2D panzi;

  private GameManager gameManager;

  private Vector3 initPositon;

  private Vector3 doingPosition;

  private bool inGuo = false;

  public bool zheng = true;

  public bool isZhengOk = false;

  public bool isFanOk = false;

  // private Button fanzhuan;


  public void OnPointerClick(PointerEventData eventData)
  {
    // if (eventData.clickCount == 2)
    // {
    Debug.Log("dbclick");
    zheng = !zheng;
    Debug.Log(zheng);
    if (zheng)
    {
      if (isZhengOk)
      {
        image.sprite = bin_shou_zheng;
      }
      else
      {
        image.sprite = bin_sheng_zheng;
      }
    }
    if (!zheng)
    {
      if (isFanOk)
      {
        image.sprite = bin_shou_fan;
      }
      else
      {
        image.sprite = bin_sheng_fan;
      }
    }
    // }
  }

  private void OnMouseDrag()
  {
    Debug.Log("drag_mouse");
  }

  public void OnDrag(PointerEventData eventData)
  {
    Debug.Log("drag");
    gameObject.transform.position = eventData.position;
  }

  public void OnEndDrag(PointerEventData eventData)
  {


    //  eventData.position;
    Debug.Log("end drag");
    var cols = Physics2D.OverlapCircleAll(gameObject.transform.position, 1);

    if (gameManager.size >= 2 && !this.inGuo)
    {
      gameObject.transform.position = initPositon;
      // UnityEditor.EditorUtility.DisplayDialog("提示", "一次只能烙2个饼哦!", "知道了", "关闭");
      return;
    }
    foreach (var col in cols)
    {
      if (col == targetCol && gameManager.size <= 2 && !this.inGuo)
      {
        this.inGuo = true;
        gameManager.size++;
        gameManager.bins.Add(this);
      }
      if (col == targetCol && this.inGuo)
      {
        return;
      }
      if (col == panzi && this.inGuo && !gameManager.isDoing)
      {
        gameObject.transform.position = initPositon;
        if (gameManager.size >= 1)
        {
          gameManager.size--;
          this.inGuo = false;
          gameManager.bins.Remove(this);
        }

      }
      if (col == panzi && this.inGuo && gameManager.isDoing)
      {
        gameObject.transform.position = eventData.pressPosition;
        // UnityEditor.EditorUtility.DisplayDialog("提示", "正在烙饼，不能取出", "耐心等待", "只能等待");
      }
    }
  }

  void Start()
  {
    // fanzhuan = GameObject.Find(gameObject.name+"/abc").GetComponent<Button>();
    image = gameObject.GetComponent<Image>();
    image.sprite = bin_sheng_zheng;
    gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    initPositon = this.transform.position;
  }

  private void Update()
  {
    // image.overrideSprite = bin_rou;
  }
  public void OnPointerUp(PointerEventData data)
  {
    // var cols = Physics2D.OverlapCircleAll(gameObject.transform.position, 1);

    // if (gameManager.size >= 2 && !this.inGuo)
    // {
    //   gameObject.transform.position = initPositon;
    //   // UnityEditor.EditorUtility.DisplayDialog("提示", "一次只能烙2个饼哦!", "知道了", "关闭");
    //   return;
    // }
    // foreach (var col in cols)
    // {
    //   if (col == targetCol && gameManager.size <= 2 && !this.inGuo)
    //   {
    //     this.inGuo = true;
    //     gameManager.size++;
    //     gameManager.bins.Add(this);
    //   }
    //   if (col == targetCol && this.inGuo)
    //   {
    //     return;
    //   }
    //   if (col == panzi && this.inGuo && !gameManager.isDoing)
    //   {
    //     gameObject.transform.position = initPositon;
    //     if (gameManager.size >= 1)
    //     {
    //       gameManager.size--;
    //       this.inGuo = false;
    //       gameManager.bins.Remove(this);
    //     }

    //   }
    //   if (col == panzi && this.inGuo && gameManager.isDoing)
    //   {
    //     UnityEditor.EditorUtility.DisplayDialog("提示", "正在烙饼，不能取出", "耐心等待", "只能等待");
    //   }
    // }
  }




}
