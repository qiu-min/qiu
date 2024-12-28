using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : Plant
{
    public float produceDuration = 100;
    private float produceTimer = 0;
    private Animator anime;
    public GameObject sunPrefab;
    private float jumpmindis = 0.5f;
    private float jumpmaxdis = 1.5f;
    private void Awake()
    {
        anime = GetComponent<Animator>();
    }
    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime;
        if(produceTimer >= produceDuration)
        {
            produceTimer = 0;
            anime.SetTrigger("IsGlowing");
        }
        base.EnableUpdate();
    }
    public void ProduceSun()
    {
        //TODO: ²úÉúÑô¹â
        GameObject go = Instantiate(sunPrefab, transform.position, Quaternion.identity);

        float distance = Random.Range(jumpmindis, jumpmaxdis);
        distance=Random.Range(0, 2) < 1 ? -distance : distance;
        Vector3 position = transform.position;
        position.x += distance;
        go.GetComponent<Sun>().JumpTo(position);
    }

}
