using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAboboras : MonoBehaviour
{
    [SerializeField] GameObject abobora;

    public float spawnTime;

    public float limiteXright;
    public float limiteXleft;
    public float limiteZup;
    public float limiteZdown;

    void Start()
    {
        StartCoroutine(Tempo());       
    }

    void Update()
    {
        
    }    

    IEnumerator Tempo()
    {
        float spawnX = Random.Range(limiteXright, limiteXleft);
        float spawnZ = Random.Range(limiteZup, limiteZdown);

        Vector3 spawn_position = new Vector3(spawnX, 0, spawnZ);
        
        yield return new WaitForSeconds(spawnTime);
        Instantiate(abobora, spawn_position, Quaternion.identity);
        StartCoroutine(Tempo());
    }
}
