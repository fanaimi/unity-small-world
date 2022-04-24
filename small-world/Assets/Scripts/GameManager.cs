using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject m_planetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("InstantiatePlanet", 1f, 5f);
    }

    private void InstantiatePlanet()
    {
        Instantiate(m_planetPrefab, new Vector3(1, 1, 1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
