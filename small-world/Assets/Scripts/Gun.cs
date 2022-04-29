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
    [SerializeField] private Transform m_cylinderIN;
    [SerializeField] private Transform m_cylinderOUT;
    [SerializeField] private float m_shootForce;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private AudioSource m_bang;
    [SerializeField] private XRInteractorLineVisual m_LineVisual;

    [SerializeField] private  enum GunHandSide { LeftHandGun, RightHandGun };
    [SerializeField] private GunHandSide m_gunSide;

    [SerializeField] private bool m_isBeingHeld;
    [SerializeField] private bool m_isLoaded;
    [SerializeField] private bool m_isCylinderIn;

    private void Awake()
    {
        m_isLoaded = true;
        m_isCylinderIn = true;
    }

    public void OnGrabbedGun()
    {
        // print("grabbed");
        m_LineVisual.enabled = false;
        m_isBeingHeld = true;

    }

    public void OnReleasedGun()
    {

        m_LineVisual.enabled = true;
        m_isBeingHeld = false;
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



    public void OnPrimaryBtnPressed()
    {
        if (m_isBeingHeld && m_isCylinderIn)
        {
            m_isCylinderIn = false;
            Debug.Log(gameObject.name + " open cylinder");
        }
    }

    public void OnSecondaryBtnPressed()
    {

        if (m_isBeingHeld && !m_isCylinderIn)
        {
            m_isCylinderIn = true;
            Debug.Log(gameObject.name + " close cylinder");
        }
    }

}
