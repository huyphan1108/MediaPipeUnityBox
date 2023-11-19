using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    public AudioClip soundEffect;
    public TextMeshProUGUI pickupText;
    public Transform spawnPoint;
    //public List<Object> cubes = new List<Object>();
    public GameObject cubes;

    private Rigidbody rb;
    private Vector3 screenBound;
    
    //private int spawnIndex = 0;


    private void Start()
    {
        pickupText.text = "";
    }

    private void Update()
    {
        if (transform.position.x  < screenBound.x)
        {

        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //int i = spawnIndex++ % cubes.Count;
        if (collider.gameObject.tag == "Player")
        {
            RemoveRespawn();
            StartCoroutine(SetText());
            //Instantiate(cubes[i], spawnPoint.position, spawnPoint.rotation);
        }
    }
    private void RemoveRespawn()
    {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        Destroy(gameObject);
        Instantiate(cubes, spawnPoint.position, spawnPoint.rotation);
    }
    private IEnumerator SetText()
    {
        while (true) { 
            pickupText.enabled = true;
            pickupText.text = "You picked up a cube";

            yield return new WaitForSeconds(1f);
            pickupText.enabled = false;
            pickupText.text = "";
        }
    }
}
