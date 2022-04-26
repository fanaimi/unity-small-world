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
