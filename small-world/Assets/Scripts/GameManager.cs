using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// @gObj   GameManager
/// @desc   Singleton, can be used to store score, updating UI etc
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    // ==== GUNS BOOLEANS =====
    public bool m_holdingLEFTGun;
    public bool m_holdingRIGHTGun;
    public bool m_LEFTGunLoaded;
    public bool m_RIGHTGunLoaded;
    public bool m_LEFTGunAmmoIn;
    public bool m_LEFTGunAmmoRight;


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        // if we want this to survive throughout different levels and scenes
        DontDestroyOnLoad(gameObject);

    } // Awake



    public void TestFoo()
    {
        Debug.Log("test foo from Game Manager Singleton");
    }
    
}
