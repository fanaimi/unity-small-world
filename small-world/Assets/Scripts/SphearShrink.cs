
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script makes envinroment scale as a factor in game space with timer to give game sense of closing walls 
/// </summary>
public class SphearShrink : MonoBehaviour
{
    public GameObject m_sphear;
    [SerializeField] [Range(1f,10f)] private static float x_1 = .3f;
    [SerializeField] [Range(1f,10f)] private static float y_1 = .1f;
    [SerializeField] [Range(1f,10f)] private static float z_1 = .3f;
    
   
    [SerializeField] [Range(1f,30f)] public float gameTimer = 10f;

    //question during game jame why is vector3 unable to take single declared variable for vector3?
    //[SerializeField] private Vector3 m_theThree = new Vector3(x_1, y_1, z_1);
    //fields have no bearing just a thought on how to change vector3  
    //[SerializeField] [Range(-10f,1f)] private float targetScale = .1f;
    //[SerializeField] [Range(-10f,1f)] private float startScale = .1f;



    
    
    
    // Start is called before the first frame update
    void Start()
    {
        ScaleToTarget(new Vector3(x_1, y_1, z_1), gameTimer);
    }
    //method statement with params that trigger coroutine on start of game shrink
    public void ScaleToTarget(Vector3 targetScale, float duration){
        StartCoroutine(ScaleToTargetCoroutine(targetScale, duration));
    }

    // Update is called once per frame
    void Update()
    {

    }
    //coroutine for time delta time call on transform.localScale
    private IEnumerator ScaleToTargetCoroutine(Vector3 targetScale, float duration){
        Vector3 startScale = transform.localScale;
        float timer = 0f;
        while(timer<duration){
            timer+=Time.deltaTime;
            float t = timer/duration;
            //smoothing frames over time as 
            t=t*t*t*(t*(6f*t-15f)+10f);
            transform.localScale=Vector3.Lerp(startScale,targetScale,t);
            yield return null;
        }
        yield return null;
    }
}
