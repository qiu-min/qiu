using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//卡片状态枚举
enum CardState
{
    Cooling,
    WaitingSun,
    Redy
}

public enum PlantType
{
    Sunflower,
    PeaShooter
}
public class Card : MonoBehaviour
{
    private CardState cardState = CardState.Cooling;//初始化卡片状态为冷却
    public PlantType plantType = PlantType.Sunflower;
    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMusk;

    public float cdTime = 2;
    public float cdTimer = 0;

    [SerializeField]
    private int needPoint = 50;//该卡片需要的阳光值
    private void Update()//卡片状态更新
    {
        switch (cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Redy:
                ReadyUpdate();
                break;
            default:
                break;
        }
    }

    void CoolingUpdate()//冷却状态更新
    {
        cdTimer += Time.deltaTime;
        cardMusk.fillAmount = (cdTime - cdTimer) / cdTime;
        if (cdTimer >= cdTime)//如果冷却时间结束调用转移等待状态函数
        {
            TransitionToWaitingSun();
        }
    }
    void WaitingSunUpdate()//等待阳光状态更新
    {
        if(SunManager.Instance.SunPoint >= needPoint)//如果当前阳光值大于等于该卡片需要的阳光值调用转移准备状态函数
        {
            TransitionToReady();
        }
    }
    void ReadyUpdate()//准备状态更新
    {
        if (SunManager.Instance.SunPoint < needPoint)//如果当前阳光值小于该卡片需要的阳光值调用转移冷却状态函数
        {
            TransitionToWaitingSun();
        }
    }

    void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;//卡片状态更新为等待阳光状态
        cardGray.SetActive(true);//灰色卡片显示
        cardLight.SetActive(false);//光源卡片隐藏
        cardMusk.gameObject.SetActive(false);//遮罩关闭
    }
    void TransitionToReady()
    {
        cardState = CardState.Redy;//卡片状态更新为准备状态
        cardGray.SetActive(false);//灰色卡片隐藏
        cardLight.SetActive(true);//光源卡片显示
        cardMusk.gameObject.SetActive(false);//遮罩关闭
    }

    void TransitionToCooling()
    {
        cardState = CardState.Cooling;//卡片状态更新为冷却状态
        cdTimer = 0;//冷却时间重置
        cardGray.SetActive(true);//灰色卡片显示
        cardLight.SetActive(false);//光源卡片隐藏
        cardMusk.gameObject.SetActive(true);//遮罩打开
    }
    public void OnClick()//点击卡片
    {
        if (SunManager.Instance.SunPoint < needPoint) return;//如果当前阳光值小于该卡片需要的阳光值则不进行操作
        //TODO:并进行种植
        bool isSuccess = HandManager.Instance.AddPlant(plantType);//将种植物放入鼠标
        if (isSuccess)
        {
            SunManager.Instance.SubPoint(needPoint);//扣除阳光值
            TransitionToCooling();
        }
    }
}

