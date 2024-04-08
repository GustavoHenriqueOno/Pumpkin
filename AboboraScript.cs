using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AboboraScript : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float sphereRaio = 1f;
    public Transform centroEsfera;
    Transform player;
    public float vel;

    public int tempoSumir;   

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        Vector3 calc = player.transform.position - this.gameObject.transform.position;
        calc = calc.normalized;        

        Collider[] colliders = Physics.OverlapSphere(centroEsfera.position, sphereRaio, collisionLayer);

        if (colliders.Length > 0)
        {
            transform.Translate(calc.x * Time.deltaTime * vel, 0, calc.z * Time.deltaTime * vel);
        }

        if (tempoSumir < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            tempoSumir--;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(centroEsfera.position, sphereRaio);
    } 
}
