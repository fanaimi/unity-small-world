using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Transform m_planet;
    public Rigidbody m_rb;

    [SerializeField] private Vector3 m_spawnPoint;
    [SerializeField] private Vector3 m_shootingDirection;
    // [SerializeField] 
    private float m_maxThrust = 100f;


    private void Start()
    {
        if (m_planet == null) return;
        m_shootingDirection = new Vector3(
                0, //Random.Range(-2f, 2f),
                Random.Range(10, 30),
                0 //Random.Range(-2f, 2f)
            );
        // print(m_shootingDirection * UnityEngine.Random.Range(30, m_maxThrust));
        m_rb.AddForce(m_shootingDirection * UnityEngine.Random.Range(30, m_maxThrust) );
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 ) // floor
        {
           //  Destroy(gameObject);
        }

    }

}

