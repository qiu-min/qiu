using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ֲ��״̬ö��
enum PlantState
{
    Disable,
    Enable
}
public class Plant : MonoBehaviour
{
    PlantState plantSatate = PlantState.Disable;//��ʼ��ֲ��״̬ΪDisable
    public PlantType plantType = PlantType.Sunflower;

    private void Start()
    {
        TransitionToDisablenable();
    }
    private void Update()
    {
        switch (plantSatate)
        {
            case PlantState.Disable:
                DisableUpdate();
                break;
            case PlantState.Enable:
                EnableUpdate();
                break;
            default:
                break;
        }
    }

    protected virtual void EnableUpdate()
    {

    }

    void DisableUpdate()
    {

    }

    void TransitionToDisablenable()
    {
        plantSatate = PlantState.Disable;
        GetComponent<Animator>().enabled = false;
    }

    public void TransitionToEnable()
    {
        plantSatate = PlantState.Enable;
        GetComponent<Animator>().enabled = true;
    }

}
