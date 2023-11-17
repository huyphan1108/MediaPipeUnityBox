using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pickup_test : MonoBehaviour
{
    public AudioClip soundEffect;
    public TextMeshProUGUI pickupText;
    private int timer = 2;

    private void Start()
    {
        pickupText.text = "";
    }

    private void OnTriggerEnter(Collider collider)
    {
        PlayerManager manager = collider.GetComponent<PlayerManager>();
        if (manager )
        {
            bool pickedUp = manager.PickupItems(gameObject);
            if (pickedUp)
            {
                RemoveItem();
            }
        }
    }

    private void RemoveItem()
    {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        Destroy(gameObject);
    }
    private IEnumerator SetText()
    {
        int t = timer;
        while (t > 0) 
        {
            pickupText.text = "You picked up a cube " + t.ToString();
            yield return new WaitForSeconds(1f);
            --t;
        }
        yield return new WaitForSeconds(1f);
        pickupText.text = "";
    }
}
