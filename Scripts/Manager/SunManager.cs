using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager Instance { get; private set; }
    [SerializeField]
    private int sunPoint;//当前阳光值
    private Vector3 sunPointTextPosition;//阳光值显示文本框位置
    //get当前阳光值方法
    public int SunPoint
    {
        get { return sunPoint; }
    }
    //Awake方法定义单例
    private void Awake()
    {
        Instance = this;
    }
    public TextMeshProUGUI sunPointText;//阳光值显示文本框
    //Start方法，调用阳光值更新方法
    private void Start()
    {
        UpdateSunPoint();
        CalcSunPointTextPosition();
    }
    private void UpdateSunPoint()//阳光值更新方法，显示阳光值
    {
        sunPointText.text = SunPoint.ToString();
    }

    public void SubPoint(int point)//消耗阳光值方法
    {
        sunPoint -= point;
        UpdateSunPoint();//更新阳光值显示
    }

    public void AddSun(int point)
    {
        sunPoint += point;
        UpdateSunPoint();
    }
    //得到阳光值文本位置
    public Vector3 GetSunPointTextPosition()
    {
        return sunPointTextPosition;
    }
    //计算阳光值文本位置
    private void CalcSunPointTextPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(sunPointText.transform.position);
        position.z = 0;
        sunPointTextPosition = position;
    }
  
}