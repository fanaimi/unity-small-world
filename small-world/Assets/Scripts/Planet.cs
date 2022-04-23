using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Transform m_planet;

    
    public Rigidbody m_rb;

    [SerializeField] private Vector3 m_spawnPoint;
    [SerializeField] private Vector3 m_shootingDirection;
    [SerializeField] private float m_Thrust = 10f;


    private void Start()
    {
        if (m_planet == null) return;
        m_shootingDirection += new Vector3(
                Random.Range(-30, 30),
                Random.Range(15, 30),
                Random.Range(-30, 30)
            );

    }



    private void FixedUpdate()
    {
            m_rb.AddForce(m_shootingDirection * m_Thrust * Time.fixedDeltaTime);
        
    }

}

