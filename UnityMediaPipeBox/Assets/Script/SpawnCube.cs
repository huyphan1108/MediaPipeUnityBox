using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject cube;
    public float respawnTime = 1.0f;
    private Vector3 spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        spawnRange = Camera.main.ScreenToWorldPoint(new Vector3());
    }

    private void spawnCubes()
    {
        GameObject a = Instantiate(cube) as GameObject;
        a.transform.position = new Vector3();
    }

    IEnumerator spawnTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCubes();
        }
    }
}
