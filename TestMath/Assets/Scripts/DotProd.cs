using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProd : MonoBehaviour
{

    [SerializeField] private Transform target;
    

    private Vector3 DirectionToTarget;
    private float dot;

    void Start()
    {
    }

    void Update()
    {
        DirectionToTarget = (target.position - transform.position).normalized;
        dot = Vector3.Dot(transform.forward, DirectionToTarget);

        if(dot > 0.99f){
            Debug.Log("Target is in front of me");
        }

    }
}
