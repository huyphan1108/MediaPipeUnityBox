using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public float respawnTime = 2f;
    public List<Transform> respawnPositions;
    public GameObject objectToRespawn;
    public AudioClip soundEffect;
    public static int respawnCount;


    //private static int respawnLimit = 2;

    private void Start()
    {
        //Debug.Log(respawnCount);
        respawnCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerManager manager = other.GetComponent<PlayerManager>();
        if (manager)
        {
            bool pickedUp = manager.PickupItems(gameObject);
            if (pickedUp)
            {
                DestroyCube();
                respawnCount++;
                //Debug.Log(respawnCount);
                if (respawnCount < 10) { 
                    StartCoroutine(Respawn(gameObject));
                }
            }
        }
        
    }

    private void DestroyCube()
    {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        Destroy(gameObject);
    }

    private IEnumerator Respawn(GameObject gameObject)
    {
        int index = Random.Range(0, respawnPositions.Count);
        Instantiate(objectToRespawn, respawnPositions[index].position, transform.rotation);
        yield return new WaitForSeconds(respawnTime);
    }
}
