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
    [SerializeField] private AudioSource m_emptyClick;
    [SerializeField] private AudioSource m_openCylinder;
    [SerializeField] private AudioSource m_closeCylinder;   
    [SerializeField] private XRInteractorLineVisual m_LineVisual;

    [SerializeField] private  enum GunHandSide { LeftHandGun, RightHandGun };
    [SerializeField] private GunHandSide m_gunSide;

    private int m_maxBulletsNo  = 7;
    private int m_bulletsLeft;

    [SerializeField] private bool m_isBeingHeld;
    [SerializeField] private bool m_isLoaded;
    [SerializeField] private bool m_isCylinderIn;

    private void Awake()
    {
        m_isLoaded = true;
        m_isCylinderIn = true;
        m_bulletsLeft = m_maxBulletsNo;
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

        Debug.Log(gameObject.name + ": -" + m_bulletsLeft);

        if (m_isLoaded && m_isCylinderIn) {
            //print("bang!");
            if (m_bulletsLeft > 0)
            { 
                m_bulletsLeft--;
                m_bang.Play();
                m_munition.Rotate(45, 0, 0);
                m_trigger.Rotate(0, 0, 25);
                Rigidbody m_newBullet =Instantiate(m_bulletPrefab, m_gunSpawningPoint.position, m_gunSpawningPoint.rotation);
                Destroy(m_newBullet, 5f);
            }    
               
            else m_isLoaded = false;
            
        }

        if (!m_isLoaded && m_isCylinderIn)
        {
            print("click!");
            m_emptyClick.Play();
            m_munition.Rotate(45, 0, 0);
            m_trigger.Rotate(0, 0, 25);
        }

    }


    public void OnGunTriggerReleased()
    {
        m_trigger.Rotate(0, 0, -25);
    }



    public void OnPrimaryBtnPressed()
    {
        if (m_isBeingHeld && m_isCylinderIn)
        {
            m_openCylinder.Play();
            m_munition.position = m_cylinderOUT.position;
            m_isCylinderIn = false;
            Debug.Log(gameObject.name + " open cylinder");
        }
    }

    public void OnSecondaryBtnPressed()
    {

        if (m_isBeingHeld && !m_isCylinderIn)
        {
            m_closeCylinder.Play();
            m_munition.position = m_cylinderIN.position;
            m_isCylinderIn = true;
            m_isLoaded = true;
            m_bulletsLeft = m_maxBulletsNo;
            Debug.Log(gameObject.name + " close cylinder");
        }
    }

}
