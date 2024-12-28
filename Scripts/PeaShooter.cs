using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Plant
{
    public float shootduration = 2;
    private float shoottimer = 0;
    public Transform shootPointTransform;
    public PeaBullet peaBulletPrefab;

    public float BulletSpeed = 5;
    protected override void EnableUpdate()
    {
        shoottimer += Time.deltaTime;
        if(shoottimer >= shootduration)
        {
            Shoot();
            shoottimer = 0;
        }
    }
    void Shoot()
    {
        PeaBullet pea = GameObject.Instantiate(peaBulletPrefab,shootPointTransform.position, Quaternion.identity);
        pea.setSpeed(BulletSpeed);
    }
}
