using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// @gObj SciFi Gun
/// </summary>
public class Gun : MonoBehaviour
{

    [SerializeField] private Rigidbody m_bulletPrefab;
    [SerializeField] private Transform m_munition;
    [SerializeField] private Transform m_trigger;
    [SerializeField] private Transform m_gunSpawningPoint;
    [SerializeField] private float m_shootForce;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private AudioSource m_bang;
    [SerializeField] private XRInteractorLineVisual m_leftLineVisual; 
    [SerializeField] private XRInteractorLineVisual m_rightLineVisual; 
   


    public void OnGrabbedGun()
    {
        print("grabbed");
        m_leftLineVisual.enabled = false;
        m_rightLineVisual.enabled = false;

    }

    public void OnReleasedGun()
    {

        m_leftLineVisual.enabled = true;
        m_rightLineVisual.enabled = true;
    }

    
    public void OnGunTriggerPressed()
    {
        //print("bang!");
        m_bang.Play();

        m_munition.Rotate(25,0,0);
        m_trigger.Rotate(0,0,25);
        
       Rigidbody m_newBullet = 
            Instantiate(m_bulletPrefab, m_gunSpawningPoint.position, m_gunSpawningPoint.rotation);

        // m_newBullet.AddForce(m_newBullet.transform.forward * m_shootForce);

        Destroy(m_newBullet, 5f);
        
        
    }


    public void OnGunTriggerReleased()
    {
        m_trigger.Rotate(0, 0, -25);
    }

}
