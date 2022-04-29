using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlanetController : MonoBehaviour
{

    private AudioSource m_clip;
    [SerializeField] private GameObject[] m_planetPrefabs = new GameObject[7];
    [SerializeField] private Transform[] m_planetShooters = new Transform[6];
    [SerializeField] private Transform[] m_hitPrefabs = new Transform[6];

    private void Awake()
    {
        m_clip = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IntantiateRandomPlanetAtRandomShooter", 1, 1);
    }

    private void IntantiateRandomPlanetAtRandomShooter()
    {
        int randPlanetIndex = UnityEngine.Random.Range(0, m_planetPrefabs.Length);
        int randShooterIndex = UnityEngine.Random.Range(0, m_planetShooters.Length);
        int randHitPrefab = UnityEngine.Random.Range(0, m_hitPrefabs.Length);
        m_clip.Play();
        Instantiate(
            m_hitPrefabs[randHitPrefab],
            m_planetShooters[randShooterIndex].position,
            Quaternion.identity
        );

        Instantiate(
            m_planetPrefabs[randPlanetIndex], 
            m_planetShooters[randShooterIndex].position, 
            Quaternion.identity
        );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
