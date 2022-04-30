using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble2 : MonoBehaviour
{
public float m_wobbleSpeed;
    public GameObject lever;
    [SerializeField] private Bullet m_scriptClassAccess;
    public float localScale2 = .5f;
    public GameObject SpawnAtAngleIndexed;
    [SerializeField] private Vector3 swing;
    [SerializeField] public Transform move;
public void Update(){
       
       WobbleTwo();
    }



public void WobbleTwo()
{
        transform.eulerAngles = new Vector3(0, 0, Mathf.Cos(Time.time) * m_wobbleSpeed
        );

}

}
