using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Use bool to check if the tag of the other game object is "Package"
    bool hasPackage; // Default value of bool is false
    [SerializeField] float destroyDelay = 0.1f; // Delay before destroying the package

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Ough!!! It's you: " + collision.gameObject.name);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {

        // If the tag is Pakage then print out the message to the console
        if (other.CompareTag("Package") && !hasPackage)
        {
            Debug.Log(other.gameObject.name + " was picked up!");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play(); // Play the particle system when the package is picked up
            Destroy(other.gameObject, destroyDelay); // Destroy the package after the specified delay
        }

        if (other.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("You delivered the package to: " + other.gameObject.name);
            GetComponent<ParticleSystem>().Stop(); // Stop the particle system when the package is delivered
            hasPackage = false; // if the package is delivered, then set hasPackage to false
        }
    }
}
