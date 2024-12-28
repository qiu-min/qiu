using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance { get; private set; }
    public List<Plant> plantList;
    private Plant currentPlant;//��ǰ������ֲ��ֲ�����ϵ�ֲ��
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        FollowCursor();
    }
    //��ֲֲ������һ��ֻ����һ��ֲ��
    public bool AddPlant(PlantType plantType)
    {
        if(currentPlant!= null)return false;
        Plant plantPrefab = GetPlantPrefab(plantType);
        if (plantPrefab == null)
        {
            print("Ҫ��ֲ��ֲ�ﲻ����");return false;
        }
        currentPlant=GameObject.Instantiate(plantPrefab);
        return true;
    }

    private Plant GetPlantPrefab(PlantType plantType)
    {
        foreach(Plant plant in plantList)
        {
            if(plant.plantType == plantType)
            {
                return plant;
            }
        }
        return null;
    }

    void FollowCursor()
    {
        if (currentPlant == null) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        currentPlant.transform.position = mousePos;
        print("123");
    }

    public void OnCellClick(Cell cell)
    {
        if (currentPlant == null) return;
        bool isSuccess = cell.AddPlant(currentPlant);
        if (isSuccess)
        {
            currentPlant = null;
        }
    }
}
   
