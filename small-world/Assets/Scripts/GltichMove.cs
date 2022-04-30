using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a script to influence reaction with colliders of bullets in environement
/// it has two focuses one for movement when stack cleared 
/// one for wobble background when more missed more wobble
/// </summary>
public class GltichMove : MonoBehaviour
{
    //move elements
    public Transform m_sphear;//reference object of inverted sphear
    [Range(0.1f, 4.0f)] [SerializeField] float m_occulsionOffset = 1.0f;//multiplied against timedelta in method
    [SerializeField] Vector3 m_glitch = new Vector3(0, -100, 100);
    [SerializeField] public float xAngle, yAngle, zAngle;
    [SerializeField] [Range(.0f, 10f)] private float lerpValue, lerpDuration;
   //lerp color transition elements of render of sphear
   bool toYellow, toRed;
   public MeshRenderer m_myRenderer;
   public Color m_StartColor, m_EndColor;
   public float time;
   
   //booleans for check on lerp color
   bool goingForward;
   bool isCycling;
   Material myMaterial;

   private float t_Time = 02.0f;

    //variables defined in comma delimited seqqence.
   private Vector3 m_StartPoint1, m_tpoint, m_midPoint, p_point1, p_point2;
    // Start is called before the first frame update
    public void Awake(){
        goingForward = true;
        isCycling = false;
        //bad method for expensive get component render ask best alternative method.
        myMaterial = GetComponent<Renderer>().material;
    }
    public void Glitchy()
     {
        //based on reference object to instance of occulsion
        //different angles can be achieved by reference to invisble game object vector3 translate data
      if (m_sphear == null) return;//if nothing in object do not pass
    
      t_Time += Time.deltaTime * m_occulsionOffset;
      p_point2 = Vector3.Lerp(p_point1, m_midPoint, t_Time);
      p_point1 = Vector3.Lerp(m_midPoint,m_tpoint, t_Time);
      transform.position = Vector3.Lerp(p_point1, p_point2, t_Time);


     }
    void Start()
    {
        //guard clause if nothing in reference
         if(m_sphear == null)
         {
         return;
        }
      //set conditions before update starts in execution
        m_StartPoint1 = transform.position;
        m_tpoint = m_sphear.position +(new Vector3(0, transform.localScale.y, 0)/2);
        m_midPoint = (m_StartPoint1*2 + m_tpoint) /3+ m_glitch;
        p_point1 = m_StartPoint1;
        p_point2 = m_midPoint;
        t_Time = 0;
   
    }

    // Update is called once per frame
    void Update()
    {
        //called to move object to occulsion offset for video generated glitch effect
        //other ways to do this but goal is to get the glitch called each time bullet hit for 
        //a brief second,
        Glitchy();
        
        if(!isCycling)
        {
            if(goingForward)
                StartCoroutine(CyclePhaseGlitchColors(m_StartColor, m_EndColor, time, myMaterial));
            else
                StartCoroutine(CyclePhaseGlitchColors(m_EndColor, m_StartColor, time, myMaterial));
        }
    }
    IEnumerator CyclePhaseGlitchColors(Color m_StartColor,Color m_EndColor, float cycleTime, Material mat){
        isCycling = true;
        float currentTime = 0;
       
        while(currentTime<cycleTime)
        {
            currentTime+=Time.deltaTime;
            float t=currentTime/cycleTime;
            Color currentColor=Color.Lerp(m_StartColor, m_EndColor, t);
            mat.color=currentColor;
            yield return null;
        }
        isCycling = false;
        goingForward= !goingForward;
    }

     
 
}
