using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//��Ƭ״̬ö��
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
    private CardState cardState = CardState.Cooling;//��ʼ����Ƭ״̬Ϊ��ȴ
    public PlantType plantType = PlantType.Sunflower;
    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMusk;

    public float cdTime = 2;
    public float cdTimer = 0;

    [SerializeField]
    private int needPoint = 50;//�ÿ�Ƭ��Ҫ������ֵ
    private void Update()//��Ƭ״̬����
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

    void CoolingUpdate()//��ȴ״̬����
    {
        cdTimer += Time.deltaTime;
        cardMusk.fillAmount = (cdTime - cdTimer) / cdTime;
        if (cdTimer >= cdTime)//�����ȴʱ���������ת�Ƶȴ�״̬����
        {
            TransitionToWaitingSun();
        }
    }
    void WaitingSunUpdate()//�ȴ�����״̬����
    {
        if(SunManager.Instance.SunPoint >= needPoint)//�����ǰ����ֵ���ڵ��ڸÿ�Ƭ��Ҫ������ֵ����ת��׼��״̬����
        {
            TransitionToReady();
        }
    }
    void ReadyUpdate()//׼��״̬����
    {
        if (SunManager.Instance.SunPoint < needPoint)//�����ǰ����ֵС�ڸÿ�Ƭ��Ҫ������ֵ����ת����ȴ״̬����
        {
            TransitionToWaitingSun();
        }
    }

    void TransitionToWaitingSun()
    {
        cardState = CardState.WaitingSun;//��Ƭ״̬����Ϊ�ȴ�����״̬
        cardGray.SetActive(true);//��ɫ��Ƭ��ʾ
        cardLight.SetActive(false);//��Դ��Ƭ����
        cardMusk.gameObject.SetActive(false);//���ֹر�
    }
    void TransitionToReady()
    {
        cardState = CardState.Redy;//��Ƭ״̬����Ϊ׼��״̬
        cardGray.SetActive(false);//��ɫ��Ƭ����
        cardLight.SetActive(true);//��Դ��Ƭ��ʾ
        cardMusk.gameObject.SetActive(false);//���ֹر�
    }

    void TransitionToCooling()
    {
        cardState = CardState.Cooling;//��Ƭ״̬����Ϊ��ȴ״̬
        cdTimer = 0;//��ȴʱ������
        cardGray.SetActive(true);//��ɫ��Ƭ��ʾ
        cardLight.SetActive(false);//��Դ��Ƭ����
        cardMusk.gameObject.SetActive(true);//���ִ�
    }
    public void OnClick()//�����Ƭ
    {
        if (SunManager.Instance.SunPoint < needPoint) return;//�����ǰ����ֵС�ڸÿ�Ƭ��Ҫ������ֵ�򲻽��в���
        //TODO:��������ֲ
        bool isSuccess = HandManager.Instance.AddPlant(plantType);//����ֲ��������
        if (isSuccess)
        {
            SunManager.Instance.SubPoint(needPoint);//�۳�����ֵ
            TransitionToCooling();
        }
    }
}

