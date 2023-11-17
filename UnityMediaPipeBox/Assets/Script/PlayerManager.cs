using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.OpenXR;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static int cubeCount;
    public static bool isPaused;
    public GameObject lossText;
    public GameObject winText;

    public TextMeshProUGUI countText;

    public void Start()
    {
        cubeCount = 0;
        countText.text = "";
        lossText.SetActive(false);
        winText.SetActive(false);  
    }

    public bool PickupItems(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Cube":
                cubeCount++;
                SetCountText();
                return true;
            case "Danger":
                lossText.SetActive(true);
                isPaused = true;
                //isPaused = !isPaused;
                PauseGame();
                return true;
            default:
                Debug.LogWarning($"WARNING: No handler implemented for tag {obj.tag}.");
                return false;
        }
    }

    void SetCountText()
    {
        countText.text = "Cubes picked up " + cubeCount.ToString();
        if (cubeCount >= 9)
        {
            winText.SetActive(true);
            //isPaused = !isPaused;
            isPaused = true;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else Time.timeScale = 1;
    }

}
