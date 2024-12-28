using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//植物状态枚举
enum PlantState
{
    Disable,
    Enable
}
public class Plant : MonoBehaviour
{
    PlantState plantSatate = PlantState.Disable;//初始化植物状态为Disable
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
