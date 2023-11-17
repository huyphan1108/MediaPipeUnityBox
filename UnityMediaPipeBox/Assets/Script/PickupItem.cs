using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupItems : MonoBehaviour
{
    public AudioClip soundEffect;
    public TextMeshProUGUI pickupText;

    private void Start()
    {
        pickupText.text = "";
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            RemoveItem();
            StartCoroutine(SetText());
        }
    }

    private void RemoveItem()
    {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        Destroy(gameObject);
    }
    private IEnumerator SetText()
    {
        while (true)
        {
            pickupText.enabled = true;
            pickupText.text = "You picked up a cube";

            yield return new WaitForSeconds(1f);
            pickupText.enabled = false;
            pickupText.text = "";
        }
    }
}
