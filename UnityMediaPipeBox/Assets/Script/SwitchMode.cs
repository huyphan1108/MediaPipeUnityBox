using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMode : MonoBehaviour
{
    public KeyCode normalModeKey = KeyCode.Z;
    public KeyCode respawnModeKey = KeyCode.X;
    public GameObject respawnModeObject;
    public GameObject normalModeObject;

    void Start()
    {
        respawnModeObject.SetActive(false);
        normalModeObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(normalModeKey))
        {
            normalModeObject.SetActive(true);
            respawnModeObject.SetActive(false);
        }
        else if (Input.GetKeyDown(respawnModeKey))
        {
            respawnModeObject.SetActive(true);
            normalModeObject.SetActive(false);
        }
    }
}
