using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWobble : MonoBehaviour
{
public float wobbleSpeed;
    public GameObject invertedSphear;
    [SerializeField] private Bullet m_scriptClassAccess;
    public float localScale2 = .5f;
    public GameObject SpawnAtAngleIndexed;
    [SerializeField] private Vector3 swing;
    [SerializeField] public Transform move;
public void Update(){
        Wobble();
    }



public void Wobble(){
   
    transform.eulerAngles = new Vector3(0, 0, Mathf.Cos(Time.time) * 10);
}
public void Wobble2(){
        transform.eulerAngles = new Vector3(0, 0, Mathf.Cos(Time.time) * wobbleSpeed


        );

}

}
