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
    [SerializeField] private Renderer m_AmmoLedRend;
    [SerializeField] private Renderer[] m_shellRenderers;
    [SerializeField] private Material[] m_ledMaterials;
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
    [SerializeField] private bool m_hasTriggerMoved;
    private void Awake()
    {
        m_isLoaded = true;
        m_isCylinderIn = true;
        m_bulletsLeft = m_maxBulletsNo;
        SwitchLEDmaterial(1);
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
                m_munition.Rotate(25, 0, 0); // 25 deg instead of 45 to make movement more visible, maybe add coroutine?
                m_trigger.Rotate(0, 0, 25);
                m_shellRenderers[7 - m_bulletsLeft].sharedMaterial = m_ledMaterials[0];
                m_hasTriggerMoved = true;
                Rigidbody m_newBullet =
                Instantiate(m_bulletPrefab, m_gunSpawningPoint.position, m_gunSpawningPoint.rotation);
                Destroy(m_newBullet, 5f);
            }

            else
            {
                m_isLoaded = false;
                SwitchLEDmaterial(0);
            }

            
        }

        if (!m_isLoaded && m_isCylinderIn)
        {
            print("click!");
            m_emptyClick.Play();
            m_munition.Rotate(25, 0, 0);
            m_trigger.Rotate(0, 0, 25);
            m_hasTriggerMoved = true;
        }

    }


    public void OnGunTriggerReleased()
    {
        if (m_isCylinderIn && m_hasTriggerMoved)
        {
            m_trigger.Rotate(0, 0, -25);
            m_hasTriggerMoved = false;
        }
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
            SwitchLEDmaterial(1);
            m_bulletsLeft = m_maxBulletsNo;
            Debug.Log(gameObject.name + " close cylinder");
        }
    }


    private void SwitchLEDmaterial(int index)
    {
        m_AmmoLedRend.sharedMaterial = m_ledMaterials[index];
        //foreach (var shell in m_shellRenderers)
        //{
        //    shell.sharedMaterial = m_ledMaterials[index];
        //}

    }

    //7  6  5  4  3  2  1  0  
    //0  1  2  3  4  5  6  7

}
