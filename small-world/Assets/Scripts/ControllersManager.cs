using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @gObj       ControllersManager
/// @desc       Singleton, this will listen to oculus controller buttons etc
/// </summary>
public class ControllersManager : MonoBehaviour
{
    private static ControllersManager _instance;
    public static ControllersManager Instance { get { return _instance; } }

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
