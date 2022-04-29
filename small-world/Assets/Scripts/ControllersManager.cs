using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;


/// <summary>
/// @gObj       ControllersManager
/// @desc       Singleton, this will listen to oculus controller buttons etc
/// </summary>
public class ControllersManager : MonoBehaviour
{
    private static ControllersManager _instance;
    public static ControllersManager Instance { get { return _instance; } }

    //[SerializeField] private InputDeviceCharacteristics m_rightCtrlChars;

    [SerializeField] private Gun m_LEFTgun; 
    [SerializeField] private Gun m_Rightgun; 

    private InputDevice m_rightController;
    private InputDevice m_leftController;

    [SerializeField] private UnityEvent m_btnA_pressed;
    [SerializeField] private UnityEvent m_btnB_pressed;
    [SerializeField] private UnityEvent m_btnX_pressed;
    [SerializeField] private UnityEvent m_btnY_pressed;

    // list to store all devices
    private List<InputDevice> m_devices = new List<InputDevice>();

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
        AttemptInit();
    }

    private void AttemptInit()
    {

        /*
        // ============== IF WE WANT A SINGLE DEVICE =================

            // chars we want to get
            m_rightCtrlChars = 
                InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

            // getting devices with given chars
            InputDevices.GetDevicesWithCharacteristics(m_rightCtrlChars, m_devices);

            foreach (var device in m_devices)
            {
                Debug.Log(device.name + " => " + device.characteristics);
            }
        */


        // ======== getting ALL devices and saving what we need
        //populating list with all available devices
        InputDevices.GetDevices(m_devices);

        //foreach (var device in m_devices)
        //{
        //    Debug.Log(device.name + " => " + device.characteristics);
        //}

        if (m_devices.Count > 0)
        {
            m_leftController = m_devices[1];
            m_rightController = m_devices[2];
        }

        // Debug.Log(m_leftController.name + " => " + m_leftController.characteristics);
        // Debug.Log(m_rightController.name + " => " + m_rightController.characteristics);
    }

    // Update is called once per frame
    void Update()
    {
        m_rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool btnA);
        m_rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool btnB);
        
        m_leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool btnX);
        m_leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool btnY);

        if (btnA) m_btnA_pressed.Invoke();
        if (btnB) m_btnB_pressed.Invoke();
        if (btnX) m_btnX_pressed.Invoke();
        if (btnY) m_btnY_pressed.Invoke();


        // DebugGlobal();
    }

    private void DebugGlobal()
    {
        Debug.Log("A: " + m_btnA_pressed);
        Debug.Log("B: " + m_btnB_pressed);
        Debug.Log("X: " + m_btnX_pressed);
        Debug.Log("Y: " + m_btnY_pressed);
    }







}
