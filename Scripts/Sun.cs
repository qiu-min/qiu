using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sun : MonoBehaviour
{
    public float moveDuration = 1;
    public int point = 50;//每个阳光的点数
    public void JumpTo(Vector3 targertPos)
    {
        targertPos.z = -1;
        Vector3 centerPos = (transform.position + targertPos) / 2;
        float distance = Vector3.Distance(transform.position, targertPos);
        centerPos.y = (distance / 2);
        transform.DOPath(new Vector3[] { transform.position, centerPos, targertPos },moveDuration, PathType.CatmullRom).SetEase(Ease.OutQuad);
    }

    public void OnMouseDown()
    {
        SunManager.Instance.AddSun(point);
        transform.DOMove(SunManager.Instance.GetSunPointTextPosition(), moveDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(()=> { Destroy(gameObject);
                SunManager.Instance.AddSun(point);
            });
    }
}
