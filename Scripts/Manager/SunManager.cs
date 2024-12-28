using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager Instance { get; private set; }
    [SerializeField]
    private int sunPoint;//��ǰ����ֵ
    private Vector3 sunPointTextPosition;//����ֵ��ʾ�ı���λ��
    //get��ǰ����ֵ����
    public int SunPoint
    {
        get { return sunPoint; }
    }
    //Awake�������嵥��
    private void Awake()
    {
        Instance = this;
    }
    public TextMeshProUGUI sunPointText;//����ֵ��ʾ�ı���
    //Start��������������ֵ���·���
    private void Start()
    {
        UpdateSunPoint();
        CalcSunPointTextPosition();
    }
    private void UpdateSunPoint()//����ֵ���·�������ʾ����ֵ
    {
        sunPointText.text = SunPoint.ToString();
    }

    public void SubPoint(int point)//��������ֵ����
    {
        sunPoint -= point;
        UpdateSunPoint();//��������ֵ��ʾ
    }

    public void AddSun(int point)
    {
        sunPoint += point;
        UpdateSunPoint();
    }
    //�õ�����ֵ�ı�λ��
    public Vector3 GetSunPointTextPosition()
    {
        return sunPointTextPosition;
    }
    //��������ֵ�ı�λ��
    private void CalcSunPointTextPosition()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(sunPointText.transform.position);
        position.z = 0;
        sunPointTextPosition = position;
    }
  
}