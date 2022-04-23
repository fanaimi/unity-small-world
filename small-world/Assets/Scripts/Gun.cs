using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{

    [SerializeField] private Rigidbody m_bulletPrefab;
    [SerializeField] private Transform m_munition;
    [SerializeField] private Transform m_gunSpawningPoint;
    [SerializeField] private float m_shootForce;
    [SerializeField] private float m_rb;
    
    // Start is called before the first frame update
    void Start()
    {
        // m_rb = GetComponent<Rigidbody>();
        
    }



    
    //public override void OnInteractionStart()
    public void foo()
    {
        // base.OnInteractionStart();
        // print("gun here");
        // AudioManager.instance.Play("bang");
        m_munition.Rotate(25,0,0);
        
        Rigidbody m_newBullet = 
            Instantiate(m_bulletPrefab, m_gunSpawningPoint.position, m_gunSpawningPoint.rotation);

        m_newBullet.AddForce(m_newBullet.transform.forward * m_shootForce);

        Destroy(m_newBullet, 5f);

        
    }
    
}
